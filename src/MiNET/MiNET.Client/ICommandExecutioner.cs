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
using System.Threading.Tasks;
using log4net;
using MiNET.Net;
using MiNET.Utils;

namespace MiNET.Client
{
	public interface ICommandExecutioner
	{
		public bool CanExecute(string text);
		public void Execute(BedrockTraceHandler caller, string text);
	}

	public interface IGenericPacketHandler
	{
		public void HandlePacket(BedrockTraceHandler caller, Packet packet);
	}

	public class PlaceAllBlocksExecutioner : ICommandExecutioner, IGenericPacketHandler
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(PlaceAllBlocksExecutioner));

		public bool CanExecute(string text)
		{
			return text.Contains("blockstates") || text.Contains("blockstate") || text.Contains("export");
		}

		public void Execute(BedrockTraceHandler caller, string text)
		{
			if (text.Contains("blockstates"))
			{
				ExecuteBlockstates(caller);
			}
			else if (text.Contains("blockstate"))
			{
				Log.Error(text);
				string[] textAr = text.Split(' ');
				BlockstateGenerator.customState(Int32.Parse(textAr[2]), Int32.Parse(textAr[3]));
				ExecuteBlockstates(caller);
			}
			else if (text.Contains("export"))
			{
				ExportBlockstates();
			}
			else
			{
				Log.Debug($"Found no matching method for '{text}'");
			}
		}

		private static void SendCommand(MiNetClient client, string command)
		{
			var request = McpeCommandRequest.CreateObject();
			request.command = command;
			request.commandType = 0;
			request.unknownUuid = new UUID(Guid.NewGuid().ToString());
			request.isinternal = false;
			request.version = 36;
			client.SendPacket(request);
		}

		private void SetGameRules(BedrockTraceHandler caller)
		{
			var client = caller.Client;
			SendCommand(client, $"/gamerule randomtickspeed 0");
			SendCommand(client, $"/gamerule doentitydrops false");
			SendCommand(client, $"/gamerule domobloot false");
			SendCommand(client, $"/gamerule domobspawning false");
			SendCommand(client, $"/gamerule dotiledrops false");
			SendCommand(client, $"/gamerule mobgriefing false");
			SendCommand(client, $"/gamerule doweathercycle false");
			SendCommand(client, $"/gamerule showcoordinates true");
			
			SendCommand(client, $"/gamerule dotiledrops false");
		}
		async void ExecuteBlockstates(BedrockTraceHandler caller)
		{
			BlockstateGenerator.init();
			var client = caller.Client;
			Log.Warn("Starting blockstate generator wait....");
			Log.Warn("If exporting not started automatically say 'export'");
			SendCommand(client, $"/setblock 0 50 0 cobblestone"); //hack to place air
			await Task.Delay(4000); //delay just to read this /|\
			SetGameRules(caller);
			SendCommand(client, $"/tp TheGrey 0 352 0");
			await Task.Delay(500);

			var x = 0;
			var tp = 0;
			foreach (var block in BlockstateGenerator.Schemas)
			{
				if (block.Data > 7 && (block.Id == 107 || block.Id == 183 || block.Id == 184 || block.Id == 185 || block.Id == 186 || block.Id == 187)) { continue; } //disable fence_gate with in_wall_bit. because they have same runtime id?
				if ((block.Id == BlockstateGenerator.customId && block.Data == BlockstateGenerator.customData && BlockstateGenerator.customMode) || BlockstateGenerator.customMode == false)
				{
					SendCommand(client, $"/setblock {x} 49 0 barrier"); //add something below or a lot of thing will fail
					var posX = x;
					var posZ = 0;

					if (block.Name == "minecraft:redstone_wire" && block.Data > 0) { SendCommand(client, $"/setblock {posX} 50 0 {block.Command}"); } //hack for redstone wire. BDS won't activate signal until placed again
					if (block.Id == 386 || block.Id == 388 || block.Id == 390 || block.Id == 391 || block.Id == 392 || block.Id == 393 || block.Id == 411 || block.Id == 415) { SendCommand(client, $"/setblock {x} 50 0 water"); } //place water for sea things
					if (block.Id == 131 && (block.Data == 4 || block.Data == 8)) { SendCommand(client, $"/setblock {posX} 50 -1 barrier"); } //tripwire hook will fall off without bock for support
					if (block.Id == 131 && (block.Data == 5 || block.Data == 9)) { SendCommand(client, $"/setblock {posX + 1} 50 0 barrier"); } //tripwire hook will fall off without bock for support
					if (block.Id == 131 && (block.Data == 6 || block.Data == 10)) { SendCommand(client, $"/setblock {posX} 50 1 barrier"); } //tripwire hook will fall off without bock for support
					if (block.Id == 131 && (block.Data == 7 || block.Data == 11)) { SendCommand(client, $"/setblock {posX - 1} 50 0 barrier"); } //tripwire hook will fall off without bock for support
					
					if (block.Id == 26 && (block.Data == 0 || block.Data == 4)) { posZ = posZ + 1; } //offset to get bed first update
					if (block.Id == 26 && (block.Data == 1 || block.Data == 5)) { posX = posX - 1; } //offset to get bed first update
					if (block.Id == 26 && (block.Data == 2 || block.Data == 6)) { posZ = posZ - 1; } //offset to get bed first update
					if (block.Id == 26 && (block.Data == 3 || block.Data == 7)) { posX = posX + 1; } //offset to get bed first update

					await Task.Delay(100);
					SendCommand(client, $"/setblock {posX} 200 {posZ} {block.Command}");
					SendCommand(client, $"/setblock {posX} 200 {posZ} {block.Command}");  //TODO find out why sometimes at random time and random block are not placed
					SendCommand(client, $"/setblock {posX} 200 {posZ} {block.Command}");
					SendCommand(client, $"/tp TheGrey {x} 210 0");
					if (!BlockstateGenerator.blockPosition.ContainsKey(x)) { BlockstateGenerator.blockPosition.Add(x, block); }
					x += 2;
					tp++;
					await Task.Delay(100);
				}
			}
		}

		public void HandlePacket(BedrockTraceHandler caller, Packet packet)
		{
			switch (packet)
			{
				case McpeUpdateBlock mcpePacket:
					HandleMcpeUpdateBlock(caller, mcpePacket);
					break;
				case McpeUpdateSubChunkBlocksPacket mcpePacket:
					HandleMcpeUpdateSubChunkBlocksPacket(caller, mcpePacket);
					break;
				default:
					return;
			}
		}

		public void HandleMcpeUpdateBlock(BedrockTraceHandler caller, McpeUpdateBlock message) //for blocks with one update
		{
			//Log.Error($"defaultupdate {message.blockRuntimeId} {message.coordinates.X} {message.coordinates.Y} {message.coordinates.Z}");
			if (BlockstateGenerator.blockPosition.TryGetValue(message.coordinates.X, out var state) && message.coordinates.Y == 200 && message.coordinates.Z == 0 && !BlockstateGenerator.BlockPalette.ContainsKey((int) message.blockRuntimeId))
			{
				Log.Warn($"Got runtimeID for {state.Name} (id: {state.Id} data: {state.Data})");
				BlockstateGenerator.createContainer(state.Name, message.blockRuntimeId, state.Id, state.Data, state.States);
				BlockstateGenerator.blockPosition.Remove(message.coordinates.X);
				if (state.Name == "minecraft:barrier")
				{
					BlockstateGenerator.write();
				}
				if (state.Id == BlockstateGenerator.customId && state.Data == BlockstateGenerator.customData && BlockstateGenerator.customMode)
				{
					BlockstateGenerator.write();
				}
			}
		}

		public void HandleMcpeUpdateSubChunkBlocksPacket(BedrockTraceHandler caller, McpeUpdateSubChunkBlocksPacket message) //for blocks with two updates
		{
			foreach (var block in message.layerZeroUpdates)
			{
			//	Log.Error($"layer0 {block.BlockRuntimeId} {block.Coordinates.X} {block.Coordinates.Y} {block.Coordinates.Z}");
				if (BlockstateGenerator.blockPosition.TryGetValue(block.Coordinates.X, out var state) && block.Coordinates.Y == 200 && block.Coordinates.Z == 0 && !BlockstateGenerator.BlockPalette.ContainsKey((int)block.BlockRuntimeId))
				{
					Log.Warn($"Got runtimeID for {state.Name} (id: {state.Id} data: {state.Data})");
					BlockstateGenerator.createContainer(state.Name, block.BlockRuntimeId, state.Id, state.Data, state.States);
					BlockstateGenerator.blockPosition.Remove(block.Coordinates.X);
				}
			}
			foreach (var block in message.layerOneUpdates)
			{
				//Log.Error($"layer1 {block.BlockRuntimeId} {block.Coordinates.X} {block.Coordinates.Y} {block.Coordinates.Z}");
			}
		}

		private void ExportBlockstates()
		{
			BlockstateGenerator.write();
		}
	}
}