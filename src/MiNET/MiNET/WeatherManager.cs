using System;
using System.Numerics;
using MiNET.Entities.World;
using MiNET.Net;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET
{
	public class WeatherManager
	{
		private Level Level { get; set; }
		public enum weatherTypes
		{
			clear, rain, thunder
		}

		public WeatherManager(Level level)
		{
			Level = level;
		}

		public virtual void setWeather(weatherTypes types, float downfallStrength = 1.0f)
		{
			McpeLevelEvent levelEvent = McpeLevelEvent.CreateObject();
			if (types == weatherTypes.clear) { levelEvent.eventId = (int) LevelEventType.StopRaining; downfallStrength = 0; }
			if (types == weatherTypes.rain) { levelEvent.eventId = (int) LevelEventType.StartRaining; }
			if (types == weatherTypes.thunder) { levelEvent.eventId = (int) LevelEventType.StartThunderstorm; }
			levelEvent.data = getStrength(downfallStrength);
			Level.RelayBroadcast(levelEvent);

			if (Level.Weather == weatherTypes.thunder) //need to stop both rain and thunder to stop thunder
			{
				McpeLevelEvent levelEvent2 = McpeLevelEvent.CreateObject();
				levelEvent2.eventId = (int) LevelEventType.StopThunderstorm;
				Level.RelayBroadcast(levelEvent2);
			}

			Level.rainLevel = downfallStrength;
			Level.Weather = types;
		}

		public virtual void tick(long tickTime)
		{
			if (tickTime % 40 == 0 && Level.Weather == weatherTypes.thunder)
			{
				Random r = new Random();

				if (r.Next(7) == 0)
				{
					Player[] players = Level.GetSpawnedPlayers();
					foreach (var player in players)
					{
						int maxDistance = player.ChunkRadius * 16;

						var lightning = new Lightning(Level);
						lightning.KnownPosition.X = player.KnownPosition.X + r.Next(-maxDistance, maxDistance);
						lightning.KnownPosition.Y = Level.GetHeight((BlockCoordinates) player.KnownPosition);
						lightning.KnownPosition.Z = player.KnownPosition.Z + r.Next(-maxDistance, maxDistance);
						lightning.SpawnToPlayers(new Player[] { player });

						//var fire = new Fire { Coordinates = (BlockCoordinates) xp.KnownPosition };  todo: add fire extinguishing logic for this
						//Level.SetBlock(fire);

						float distance = Vector3.Distance(player.KnownPosition, lightning.KnownPosition);

						McpePlaySound sound = McpePlaySound.CreateObject();
						sound.name = "ambient.weather.lightning.impact";
						sound.coordinates = (BlockCoordinates) lightning.KnownPosition / 8;
						sound.volume = Math.Clamp(1.0f - (distance / maxDistance), 0.0f, 1.0f);
						sound.pitch = 1;
						player.SendPacket(sound);
					}
				}
			}
		}

		private int getStrength(float downfallStrength)
		{
			var Strength = Math.Clamp(downfallStrength, 0.0f, 1.0f);
			return (int)(Strength * 65535);
		}
	}
}
