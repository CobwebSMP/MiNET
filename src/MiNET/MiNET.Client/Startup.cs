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
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using MiNET.Net;
using MiNET.Utils;
using MiNET.Utils.Vectors;

namespace MiNET.Client
{
	public class Startup
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Startup));

		// ReSharper disable once InconsistentNaming
		private const string MiNET = "\r\n __   __  ___   __    _  _______  _______ \r\n|  |_|  ||   | |  |  | ||       ||       |\r\n|       ||   | |   |_| ||    ___||_     _|\r\n|       ||   | |       ||   |___   |   |  \r\n|       ||   | |  _    ||    ___|  |   |  \r\n| ||_|| ||   | | | |   ||   |___   |   |  \r\n|_|   |_||___| |_|  |__||_______|  |___|  \r\n";

		static void Main(string[] args)
		{
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "log4net.xml")));

			Log.Info(MiNET);
			Console.WriteLine(MiNET);
			Console.WriteLine("Starting client...");
			BlockstateGenerator.preInit();

			var client = new MiNetClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 19132), "TheGrey");

			client.MessageHandler = new BedrockTraceHandler(client);

			client.StartClient();
			Log.Warn("Client listening for connecting on: " + client.ClientEndpoint);

			Console.WriteLine("Looking for server...");

			if(!client.Connection.TryLocate(client.ServerEndPoint, out (IPEndPoint serverEndPoint, string serverName) info))
			{
				Console.WriteLine($"Failed to locate server at {client.ServerEndPoint}");
				return;
			}

			Console.WriteLine($"... YEAH! FOUND SERVER! It's at {info.serverEndPoint}, \"{info.serverName}\"");

			if (!client.Connection.TryConnect(info.serverEndPoint))    
			{
				Console.WriteLine($"Failed to connect to server at {info.serverEndPoint}");
				return;
			}

			Log.Debug("Waiting for spawn...");
			client.PlayerStatusChangedWaitHandle.WaitOne();

			client.HasSpawned = true;

			Action<Task, PlayerLocation> doMoveTo = BotHelpers.DoMoveTo(client);

			Action<Task, string> doSendCommand = BotHelpers.DoSendCommand(client);

			Thread.Sleep(4000);
			Log.Warn($"Client spawned at X: {client.CurrentLocation.X}, Y: {client.CurrentLocation.Y}, Z: {client.CurrentLocation.Z}");
			while (true)
			{
				Log.Warn("Do [command] and Enter to execute function. /help to print available functions.");
				string command = Console.ReadLine();
				doCommand(command, client);
			}
		}

		static void doCommand(string command, MiNetClient client)
		{
			string[] cmd = command.Split(' ');
			switch (cmd[0])
			{
				case "/tp":
					teleport(client, Int32.Parse(cmd[1]), Int32.Parse(cmd[2]), Int32.Parse(cmd[3]));
					break;
				case "/blockstates":
					blockstates(client);
					break;
				case "/viewdistance":
					chunkRadius(client, Int32.Parse(cmd[1]));
					break;
				case "/exit":
					disconnectCmd(client);
					break;
				case "/help":
					helpCmd();
					break;
				default:
					Log.Warn("Unknown command. /help to print available functions.");
					break;
			}
		}

		static void teleport(MiNetClient client, int x, int y, int z)
		{
			var request = McpeCommandRequest.CreateObject();
			request.command = $"/tp TheGrey {x} {y} {z}";
			request.commandType = 0;
			request.unknownUuid = new UUID(Guid.NewGuid().ToString());
			request.isinternal = false;
			request.version = 36;
			client.SendPacket(request);
		}

		static void disconnectCmd(MiNetClient client)
		{
			if (client.IsConnected) client.SendDisconnectionNotification();
			Thread.Sleep(50);
			client.StopClient();
		}

		static void helpCmd()
		{
			Log.Warn("======== Client functions ========\n");
			Log.Warn("/blockstates - Generate new blockstate runtime ids according to schema.json");
			Log.Warn("/exit - Disconnect from the server");
			Log.Warn("/help - Display this info");
			Log.Warn("/tp <x:int> <y:int> <z:int> - Teleport client to specific position");
			Log.Warn("/viewdistance <chunkdistance:int> - Change view distance");
		}

		static void chunkRadius(MiNetClient client, int radius)
		{
			var packet = McpeRequestChunkRadius.CreateObject();
			client.ChunkRadius = radius;
			packet.chunkRadius = client.ChunkRadius;
			client.SendPacket(packet);
		}

		static void blockstates(MiNetClient client)
		{
			if (client.permissionLevel == PermissionLevel.Operator)
			{
				client.SendChat("blockstates");
			}
			else
			{
				Log.Warn("Error: Client need OP permissions. Type /op thegrey in BSD console");
			}
		}
	}
}