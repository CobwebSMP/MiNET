#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE.
// The License is based on the Mozilla Public License Version 1.1, but Sections 14
// and 15 have been added to cover use of software over a computer network and
// provide for limited attribution for the Original Developer. In addition, Exhibit A has
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using fNbt;
using log4net;
using MiNET.Blocks;
using MiNET.Crafting;
using MiNET.Entities;
using MiNET.Items;
using MiNET.Net;
using MiNET.Utils;
using MiNET.Utils.Metadata;
using MiNET.Utils.Vectors;
using MiNET.Worlds;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiNET.Client
{
	public class BedrockTraceHandler : McpeClientMessageHandlerBase
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(BedrockTraceHandler));


		public BedrockTraceHandler(MiNetClient client) : base(client)
		{
		}

		public override void HandleMcpeUpdateSoftEnum(McpeUpdateSoftEnum message)
		{
			Log.Warn($"Got soft enum update for {message}");
		}

		public override void HandleMcpeDisconnect(McpeDisconnect message)
		{
			Log.Warn("[Disconnect Screen] ");
			switch (message.message.ToString())
			{
				case "disconnectionScreen.notAuthenticated":
					Log.Warn("You need to authenticate to Xbox Live services to join this server.");
					break;
				case "disconnectionScreen.invalidSkin":
					Log.Warn("Invalid skin.");
					break;
				case "disconnectionScreen.serverFull":
				case "disconnectionScreen.serverFull.title":
					Log.Warn("Server is full.");
					break;
				case "disconnectionScreen.resourcePack":
					Log.Warn("Resource pack error.");
					break;
				case "disconnectionScreen.badPacket":
					Log.Warn("Client sent invalid packet.");
					break;
				default:
					Log.Warn($"Server requested disconnect with message {message.message.ToString()}");
					break;
			}
			base.HandleMcpeDisconnect(message);
		}

		public override void HandleMcpeResourcePacksInfo(McpeResourcePacksInfo message)
		{
			//Log.Warn($"HEX: \n{Packet.HexDump(message.Bytes)}");

			var sb = new StringBuilder();
			sb.AppendLine();

			sb.AppendLine("Texture packs:");
			foreach (TexturePackInfo info in message.texturepacks)
			{
				sb.AppendLine($"ID={info.UUID}, Version={info.Version}, Unknown={info.Size}");
			}

			Log.Debug(sb.ToString());

			base.HandleMcpeResourcePacksInfo(message);
		}

		public override void HandleMcpeResourcePackStack(McpeResourcePackStack message)
		{
			//Log.Debug($"HEX: \n{Package.HexDump(message.Bytes)}");

			var sb = new StringBuilder();
			sb.AppendLine();

			sb.AppendLine("Resource pack stacks:");
			foreach (var info in message.resourcepackidversions)
			{
				sb.AppendLine($"ID={info.Id}, Version={info.Version}, Subpackname={info.SubPackName}");
			}

			sb.AppendLine("Behavior pack stacks:");
			foreach (var info in message.behaviorpackidversions)
			{
				sb.AppendLine($"ID={info.Id}, Version={info.Version}, Subpackname={info.SubPackName}");
			}

			Log.Debug(sb.ToString());

			base.HandleMcpeResourcePackStack(message);
		}

		private List<ICommandExecutioner> _executioners = new List<ICommandExecutioner>() {new PlaceAllBlocksExecutioner()};

		private void CallPacketHandlers(Packet packet)
		{
			var wantExec = _executioners.Where(e => e is IGenericPacketHandler);
			List<Task> tasks = new List<Task>();
			foreach (var commandExecutioner in wantExec)
			{
				var executioner = (IGenericPacketHandler) commandExecutioner;
				tasks.Add(Task.Run(() => executioner.HandlePacket(this, packet)));
			}
			Task.WaitAll(tasks.ToArray());
		}

		public override void HandleMcpeText(McpeText message)
		{
			string text = message.message;
			if (string.IsNullOrEmpty(text)) return;

			var wantExec = _executioners.Where(e => e.CanExecute(text));

			foreach (var executioner in wantExec)
			{
				Log.Debug($"Executing command handler: {executioner.GetType().FullName}");
				Task.Run(() => executioner.Execute(this, text));
			}

			if (text.Equals(".do"))
			{
				Client.SendCraftingEvent();
			}
		}

		public override void HandleMcpeInventorySlot(McpeInventorySlot message)
		{
			Log.Debug($"Inventory slot: {message.item}");
		}

		public override void HandleMcpePlayerHotbar(McpePlayerHotbar message)
		{
			CallPacketHandlers(message);
		}

		public override void HandleMcpeInventoryContent(McpeInventoryContent message)
		{
			Log.Error($"Set container content on Window ID: 0x{message.inventoryId:x2}, Count: {message.input.Count}, ContainerName: {message.ContainerName.ContainerId} - {message.ContainerName.DynamicId}");

			CallPacketHandlers(message);

			if (Client.IsEmulator) return;

			ItemStacks slots = message.input;

			//if (message.inventoryId == 0x79)
			//{
			//	string fileName = Path.GetTempPath() + "Inventory_0x79_" + Guid.NewGuid() + ".txt";
			//	Client.WriteInventoryToFile(fileName, slots);
			//}
			//else if (message.inventoryId == 0x00)
			//{
			//	//string fileName = Path.GetTempPath() + "Inventory_0x00_" + Guid.NewGuid() + ".txt";
			//	//Client.WriteInventoryToFile(fileName, slots);
			//}
		}

		public override void HandleMcpeCreativeContent(McpeCreativeContent message)
		{
			Log.Warn($"[McpeCreativeContent] Received {message.input.Count} creative items");
			FileStream file = File.OpenWrite("newResources/creativeInventory.txt");
			var writer = new IndentedTextWriter(new StreamWriter(file), "\t");
			writer.WriteLine($"//Minecraft Bedrock Edition {McpeProtocolInfo.GameVersion} Creative Inventory");
			foreach (var item in message.input)
			{
				//Log.Warn($"Got item: {item.Name} ({item.Id} : {item.Metadata})");
				if (item.ExtraData == null)
				{
					writer.WriteLine($"new Item({item.Id}, {item.Metadata}){{ RuntimeId = {item.RuntimeId},");
				}
				else
				{
					writer.WriteLine($"new Item({item.Id}, {item.Metadata}){{ RuntimeId = {item.RuntimeId}, ExtraData = {item.ExtraData}}},");
				}
			}
			Log.Warn($"[McpeCreativeContent] Done reading {message.input.Count} creative items\n");
			writer.Flush();
			file.Close();
			Log.Warn("Received creative items exported to newResources/creativeInventory.txt\n");
		}

		public override void HandleMcpeAddItemEntity(McpeAddItemEntity message)
		{
			CallPacketHandlers(message);
		}

		public override void HandleMcpeUpdateBlock(McpeUpdateBlock message)
		{
			CallPacketHandlers(message);
		}

		public override void HandleMcpeUpdateSubChunkBlocksPacket(McpeUpdateSubChunkBlocksPacket message)
		{
			CallPacketHandlers(message);
		}

		public override void HandleMcpeStartGame(McpeStartGame message)
		{
			Client.EntityId = message.runtimeEntityId;
			Client.NetworkEntityId = message.entityIdSelf;
			Client.SpawnPoint = message.spawn;
			Client.CurrentLocation = new PlayerLocation(Client.SpawnPoint, message.rotation.X, message.rotation.X, message.rotation.Y);

			LogGamerules(message.levelSettings.gamerules);

			Client.LevelInfo.LevelName = "Default";
			Client.LevelInfo.Version = 19133;
			Client.LevelInfo.GameType = message.levelSettings.gamemode;

			{
				var packet = McpeRequestChunkRadius.CreateObject();
				Client.ChunkRadius = 5;
				packet.chunkRadius = Client.ChunkRadius;

				Client.SendPacket(packet);
			}
		}

		public static string CodeName(string name, bool firstUpper = false)
		{
			//name = name.ToLowerInvariant();

			bool upperCase = firstUpper;

			var result = string.Empty;
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i] == ' ' || name[i] == '_')
				{
					upperCase = true;
				}
				else
				{
					if ((i == 0 && firstUpper) || upperCase)
					{
						result += name[i].ToString().ToUpperInvariant();
						upperCase = false;
					}
					else
					{
						result += name[i];
					}
				}
			}

			result = result.Replace(@"[]", "s");
			return result;
		}

		public override void HandleMcpeAddPlayer(McpeAddPlayer message)
		{
			if (Client.IsEmulator) return;

			Log.DebugFormat("McpeAddPlayer Entity ID: {0}", message.entityIdSelf);
			Log.DebugFormat("McpeAddPlayer Runtime Entity ID: {0}", message.runtimeEntityId);
			Log.DebugFormat("X: {0}", message.x);
			Log.DebugFormat("Y: {0}", message.y);
			Log.DebugFormat("Z: {0}", message.z);
			Log.DebugFormat("Yaw: {0}", message.yaw);
			Log.DebugFormat("Pitch: {0}", message.pitch);
			Log.DebugFormat("Velocity X: {0}", message.speedX);
			Log.DebugFormat("Velocity Y: {0}", message.speedY);
			Log.DebugFormat("Velocity Z: {0}", message.speedZ);
			Log.DebugFormat("Metadata: {0}", Client.MetadataToCode(message.metadata));
			Log.DebugFormat("Links count: {0}", message.links?.Count);
		}

		public override void HandleMcpeAddEntity(McpeAddEntity message)
		{
			if (Client.IsEmulator) return;

			if (!Client.Entities.ContainsKey(message.entityIdSelf))
			{
				var entity = new Entity(message.entityType, null);
				entity.EntityId = message.runtimeEntityId;
				entity.KnownPosition = new PlayerLocation(message.x, message.y, message.z, message.yaw, message.yaw, message.pitch);
				entity.Velocity = new Vector3(message.speedX, message.speedY, message.speedZ);
				Client.Entities.TryAdd(entity.EntityId, entity);
			}

			Log.DebugFormat("McpeAddEntity Entity ID: {0}", message.entityIdSelf);
			Log.DebugFormat("McpeAddEntity Runtime Entity ID: {0}", message.runtimeEntityId);
			Log.DebugFormat("Entity Type: {0}", message.entityType);
			Log.DebugFormat("X: {0}", message.x);
			Log.DebugFormat("Y: {0}", message.y);
			Log.DebugFormat("Z: {0}", message.z);
			Log.DebugFormat("Yaw: {0}", message.yaw);
			Log.DebugFormat("Pitch: {0}", message.pitch);
			Log.DebugFormat("Velocity X: {0}", message.speedX);
			Log.DebugFormat("Velocity Y: {0}", message.speedY);
			Log.DebugFormat("Velocity Z: {0}", message.speedZ);
			Log.DebugFormat("Metadata: {0}", Client.MetadataToCode(message.metadata));
			Log.DebugFormat("Links count: {0}", message.links?.Count);

			if (message.metadata.Contains(0))
			{
				long? value = ((MetadataLong) message.metadata[0])?.Value;
				if (value != null)
				{
					long dataValue = (long) value;
					Log.Debug($"Bit-array datavalue: dec={dataValue} hex=0x{dataValue:x2}, bin={Convert.ToString(dataValue, 2)}b ");
				}
			}

			if (Log.IsDebugEnabled)
			{
				foreach (var attribute in message.attributes)
				{
					Log.Debug($"Entity attribute {attribute}");
				}
			}

			Log.DebugFormat("Links count: {0}", message.links);

			if (Log.IsDebugEnabled && Client._mobWriter != null)
			{
				Client._mobWriter.WriteLine("Entity Type: {0}", message.entityType);
				Client._mobWriter.Indent++;
				Client._mobWriter.WriteLine("Metadata: {0}", Client.MetadataToCode(message.metadata));
				Client._mobWriter.Indent--;
				Client._mobWriter.WriteLine();
				Client._mobWriter.Flush();
			}

			if (message.entityType == "minecraft:horse")
			{
				var id = message.runtimeEntityId;
				Vector3 pos = new Vector3(message.x, message.y, message.z);
				Task.Run(BotHelpers.DoWaitForSpawn(Client))
					.ContinueWith(t => Task.Delay(3000).Wait())
					//.ContinueWith(task =>
					//{
					//	Log.Warn("Sending jump for player");

					//	McpeInteract action = McpeInteract.CreateObject();
					//	action.targetRuntimeEntityId = id;
					//	action.actionId = (int) 3;
					//	SendPackage(action);
					//})
					//.ContinueWith(t => Task.Delay(2000).Wait())
					//.ContinueWith(task =>
					//{
					//	for (int i = 0; i < 10; i++)
					//	{
					//		Log.Warn("Mounting horse");

					//		McpeInventoryTransaction transaction = McpeInventoryTransaction.CreateObject();
					//		transaction.transaction = new Transaction()
					//		{
					//			TransactionType = McpeInventoryTransaction.TransactionType.ItemUseOnEntity,
					//			TransactionRecords = new List<TransactionRecord>(),
					//			EntityId = id,
					//			ActionType = 0,
					//			Slot = 0,
					//			Item = new ItemAir(),
					//			//Item = new ItemBlock(new Cobblestone()) { Count = 64 },
					//			Position = BlockCoordinates.Zero,
					//			FromPosition = CurrentLocation,
					//			ClickPosition = pos,
					//		};

					//		SendPackage(transaction);
					//		Thread.Sleep(4000);
					//	}

					//})
					.ContinueWith(task =>
					{
						Log.Warn("Sending sneak for player");

						McpePlayerAction action = McpePlayerAction.CreateObject();
						action.runtimeEntityId = Client.EntityId;
						action.actionId = (int) PlayerAction.StartSneak;
						Client.SendPacket(action);
					})
					.ContinueWith(t => Task.Delay(2000).Wait())
					.ContinueWith(task =>
					{
						Log.Warn("Sending transaction for horse");

						var transaction = McpeInventoryTransaction.CreateObject();
						transaction.transaction = new ItemUseOnEntityTransaction()
						{
							TransactionRecords = new List<TransactionRecord>(),
							EntityId = id,
							ActionType = 0,
							Slot = 0,
							Item = new ItemAir(),
							FromPosition = Client.CurrentLocation,
							ClickPosition = pos,
						};

						Client.SendPacket(transaction);
					});
			}
		}

		public override void HandleMcpeRemoveEntity(McpeRemoveEntity message)
		{
			Log.DebugFormat("McpeAddPlayer Entity ID: {0}", message.entityIdSelf);
			Client.Entities.TryRemove(message.entityIdSelf, out _);
		}

		public override void HandleMcpeLevelEvent(McpeLevelEvent message)
		{
			int data = message.data;
			if (message.eventId == (int) LevelEventType.ParticlesDestroyBlock)
			{
				int blockId = data & 0xff;
				int metadata = data >> 12;
				Log.Debug($"BlockID={blockId}, Metadata={metadata}");
			}
			else if (message.eventId == (int)LevelEventType.ParticlesPotionSplash)
			{
				Log.Warn($"Got effect with data: {message.data}");
				var r = (message.data >> 16) & 0xFF;
				var g = (message.data >> 8) & 0xFF;
				var b = message.data & 0xFF;

				Log.Warn($"Actual effect color R: 0x{r.ToString("x")} G: 0x{g.ToString("x")} B: 0x{b.ToString("x")}");
			}
		}

		public override void HandleMcpeUpdateAttributes(McpeUpdateAttributes message)
		{
			foreach (var playerAttribute in message.attributes)
			{
				Log.Debug($"Attribute {playerAttribute}");
			}
		}

		public override void HandleMcpeCraftingData(McpeCraftingData message)
		{
			if (Client.IsEmulator) return;

			string fileName = "newResources/recipes.txt";
			Log.Info("Writing recipes to filename: " + fileName);
			FileStream file = File.OpenWrite(fileName);

			var writer = new IndentedTextWriter(new StreamWriter(file), "\t");

			writer.WriteLine();
			writer.Indent++;
			writer.Indent++;

			writer.WriteLine("static RecipeManager()");
			writer.WriteLine("{");
			writer.Indent++;
			writer.WriteLine("Recipes = new Recipes");
			writer.WriteLine("{");
			writer.Indent++;

			foreach (Recipe recipe in message.recipes)
			{
				var shapelessRecipe = recipe as ShapelessRecipe;
				if (shapelessRecipe != null)
				{
					writer.WriteLine($"new ShapelessRecipe(");
					writer.Indent++;

					writer.WriteLine("new List<Item>");
					writer.WriteLine("{");
					writer.Indent++;
					foreach (var itemStack in shapelessRecipe.Result)
					{
						writer.WriteLine($"new Item({itemStack.Id}, {itemStack.Metadata}, {itemStack.Count}){{ UniqueId = {itemStack.UniqueId}, RuntimeId={itemStack.RuntimeId} }},");
					}
					writer.Indent--;
					writer.WriteLine($"}},");

					writer.WriteLine("new List<Item>");
					writer.WriteLine("{");
					writer.Indent++;
					foreach (var itemStack in shapelessRecipe.Input)
					{
						writer.WriteLine($"new Item({itemStack.Id}, {itemStack.Metadata}, {itemStack.Count}){{ UniqueId = {itemStack.UniqueId}, RuntimeId={itemStack.RuntimeId} }},");
					}
					writer.Indent--;
					writer.WriteLine($"}}, \"{shapelessRecipe.Block}\"){{ UniqueId = {shapelessRecipe.UniqueId} }},");

					writer.Indent--;
					continue;
				}

				var shapedRecipe = recipe as ShapedRecipe;
				//if (shapedRecipe != null && Client._recipeToSend == null)
				//{
				//	if (shapedRecipe.Result.Id == 5 && shapedRecipe.Result.Count == 4 && shapedRecipe.Result.Metadata == 0)
				//	{
				//		Log.Error("Setting recipe! " + shapedRecipe.Id);
				//		Client._recipeToSend = shapedRecipe;
				//	}
				//}

				if (shapedRecipe != null)
				{
					writer.WriteLine($"new ShapedRecipe({shapedRecipe.Width}, {shapedRecipe.Height},");
					writer.Indent++;

					writer.WriteLine("new List<Item>");
					writer.WriteLine("{");
					writer.Indent++;
					foreach (Item item in shapedRecipe.Result)
					{
						writer.WriteLine($"new Item({item.Id}, {item.Metadata}, {item.Count}){{ UniqueId = {item.UniqueId}, RuntimeId={item.RuntimeId} }},");
					}
					writer.Indent--;
					writer.WriteLine($"}},");

					writer.WriteLine("new Item[]");
					writer.WriteLine("{");
					writer.Indent++;
					foreach (Item item in shapedRecipe.Input)
					{
						writer.WriteLine($"new Item({item.Id}, {item.Metadata}, {item.Count}){{ UniqueId = {item.UniqueId}, RuntimeId={item.RuntimeId} }},");
					}
					writer.Indent--;
					writer.WriteLine($"}}, \"{shapedRecipe.Block}\"){{ UniqueId = {shapedRecipe.UniqueId} }},");

					writer.Indent--;

					continue;
				}

				var smeltingRecipe = recipe as SmeltingRecipe;
				if (smeltingRecipe != null)
				{
					writer.WriteLine($"new SmeltingRecipe(new Item({smeltingRecipe.Result.Id}, {smeltingRecipe.Result.Metadata}, {smeltingRecipe.Result.Count}){{ UniqueId = {smeltingRecipe.Result.UniqueId}, RuntimeId={smeltingRecipe.Result.RuntimeId} }}, new Item({smeltingRecipe.Input.Id}, {smeltingRecipe.Input.Metadata}){{ UniqueId = {smeltingRecipe.Input.UniqueId}, RuntimeId={smeltingRecipe.Input.RuntimeId} }}, \"{smeltingRecipe.Block}\"),");
					continue;
				}

				var multiRecipe = recipe as MultiRecipe;
				if (multiRecipe != null)
				{
					writer.WriteLine($"new MultiRecipe() {{ Id = new UUID(\"{recipe.Id}\"), UniqueId = {multiRecipe.UniqueId} }}, // {recipe.Id}");
					continue;
				}
			}

			writer.Indent--;
			writer.WriteLine("};");
			writer.Indent--;
			writer.WriteLine("}");

			writer.Flush();
			file.Close();
			Log.Warn("Received recipes exported to newResources/recipes.txt\n");
			//Environment.Exit(0);
		}

		public override void HandleMcpeBlockEntityData(McpeBlockEntityData message)
		{
			Log.DebugFormat("X: {0}", message.coordinates.X);
			Log.DebugFormat("Y: {0}", message.coordinates.Y);
			Log.DebugFormat("Z: {0}", message.coordinates.Z);
			Log.DebugFormat("NBT:\n{0}", message.namedtag.NbtFile.RootTag);
		}

		public override void HandleMcpeLevelChunk(McpeLevelChunk message)
		{
			// TODO doesn't work anymore I guess
			if (Client.IsEmulator) return;

			if (message.blobHashes != null)
			{
				var hits = new ulong[message.blobHashes.Length];

				for (int i = 0; i < message.blobHashes.Length; i++)
				{
					ulong hash = message.blobHashes[i];
					hits[i] = hash;
					Log.Debug($"Got hashes for {message.chunkX}, {message.chunkZ}, {hash}");
				}

				var status = McpeClientCacheBlobStatus.CreateObject();
				status.hashHits = hits;
				Client.SendPacket(status);
			}
			else
			{
				Client.Chunks.GetOrAdd(new ChunkCoordinates(message.chunkX, message.chunkZ), coordinates =>
				{
					Log.Debug($"Chunk X={message.chunkX}, Z={message.chunkZ}, size={message.chunkData.Length}, Count={Client.Chunks.Count}");
					if (BlockstateGenerator.running == false){ Console.WriteLine($"[McpeLevelChunk] Got chunk | X: {message.chunkX,-4} | Z: {message.chunkZ,-4} |"); ; }
						//broken, chunkData have weird values. Expected header something like: 09 01 02 08
						//Log.Debug($"{Packet.HexDump(message.Bytes)}");
						ChunkColumn chunk = null;
					/*try
					{
						chunk = ClientUtils.DecodeChunkColumn((int) message.subChunkCount, message.chunkData);
						if (chunk != null)
						{
							chunk.X = coordinates.X;
							chunk.Z = coordinates.Z;
							chunk.RecalcHeight();
							Log.DebugFormat("Chunk X={0}, Z={1}", chunk.X, chunk.Z);
							foreach (KeyValuePair<BlockCoordinates, NbtCompound> blockEntity in chunk.BlockEntities)
							{
								Log.Debug($"Blockentity: {blockEntity.Value}");
							}
						}
					}
					catch (Exception e)
					{
						Log.Error("Reading chunk", e);
					}*/

					return chunk;
				});
			}
		}

		public override void HandleMcpeGameRulesChanged(McpeGameRulesChanged message)
		{
			GameRules rules = message.rules;
			LogGamerules(rules);
		}

		private static void LogGamerules(GameRules rules)
		{
			foreach (var rule in rules)
			{
				if (rule is GameRule<bool>)
				{
					Log.Debug($"Rule: {rule.Name}={(GameRule<bool>) rule}");
				}
				else if (rule is GameRule<int>)
				{
					Log.Debug($"Rule: {rule.Name}={(GameRule<int>) rule}");
				}
				else if (rule is GameRule<float>)
				{
					Log.Debug($"Rule: {rule.Name}={(GameRule<float>) rule}");
				}
				else
				{
					Log.Warn($"Rule: {rule.Name}={rule}");
				}
			}
		}

		public override void HandleMcpeAvailableCommands(McpeAvailableCommands message)
		{
			Log.Warn($"[McpeAvailableCommands] Received {message.CommandList.Count} commnands");
			foreach (var command in message.CommandList)
			{
				//Log.Warn($"Got command: {command.Name} - {command.Versions[0].Description}");
			}
			Log.Warn($"[McpeAvailableCommands] Done reading {message.CommandList.Count} commnands\n");
		}

		public override void HandleMcpeResourcePackChunkData(McpeResourcePackChunkData message)
		{
			string fileName = Path.GetTempPath() + "ResourcePackChunkData_" + message.packageId + ".zip";
			Log.Warn("Writing ResourcePackChunkData part " + message.chunkIndex.ToString() + " to filename: " + fileName);

			FileStream file = File.OpenWrite(fileName);
			file.Seek((long) message.progress, SeekOrigin.Begin);

			file.Write(message.payload, 0, message.payload.Length);
			file.Close();

			Log.Debug($"packageId={message.packageId}");
			Log.Debug($"unknown1={message.chunkIndex}");
			Log.Debug($"unknown3={message.progress}");
			Log.Debug($"Actual Lenght={message.payload.Length}");

			base.HandleMcpeResourcePackChunkData(message);
		}

		public override void HandleMcpeAvailableEntityIdentifiers(McpeAvailableEntityIdentifiers message)
		{
			foreach (var entity in message.namedtag.NbtFile.RootTag["idlist"] as NbtList)
			{
				var id = (entity["id"] as NbtString).Value;
				var rid = (entity["rid"] as NbtInt).Value;
				if (!Enum.IsDefined(typeof(EntityType), rid))
				{
					Log.Debug($"{{ (EntityType) {rid}, \"{id}\" }},");
				}
			}
		}

		public override void HandleMcpeBiomeDefinitionList(McpeBiomeDefinitionList message)
		{
			NbtCompound list = new NbtCompound("");
			foreach (var biome in message.namedtag.NbtFile.RootTag as NbtCompound)
			{
				string biomeName = biome.Name;
				float downfall = (biome["downfall"] as NbtFloat).Value;
				float temperature = (biome["temperature"] as NbtFloat).Value;
				list.Add(
					new NbtCompound(biomeName)
					{
						new NbtFloat("temperature", temperature),
						new NbtFloat("downfall", downfall),
					}
				);
			}

			File.WriteAllText("newResources/biomes.txt", list.ToString());
			Log.Warn("Received biome definitions exported to newResources/biomes.txt\n");
		}

		public override void HandleMcpeNetworkChunkPublisherUpdate(McpeNetworkChunkPublisherUpdate message)
		{
		}

		public override void HandleMcpePlayStatus(McpePlayStatus message)
		{

			base.HandleMcpePlayStatus(message);

			if (Client.PlayerStatus == 0)
			{
				var packet = McpeClientCacheStatus.CreateObject();
				packet.enabled = Client.UseBlobCache;
				Client.SendPacket(packet);
			}
		}

		/// <inheritdoc />
		public override void HandleMcpeCommandOutput(McpeCommandOutput message)
		{
			base.HandleMcpeCommandOutput(message);

			//foreach (var msg in message.Messages)
			//{
			//	Log.Warn($"Received command output: {msg}");
			//}
		}
	}
}