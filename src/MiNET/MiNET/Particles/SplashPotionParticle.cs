﻿using System;
using MiNET.Net;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Particles
{
	public class SplashPotionParticle : LegacyParticle
	{
		public SplashPotionParticle(Level level, BlockCoordinates coordinates, int r, int g, int b) : base(0, level)
		{
			Data = CustomPotionColor(r, g, b);
			Position = coordinates;
		}

		public override void Spawn()
		{
			McpeLevelEvent particleEvent = McpeLevelEvent.CreateObject();
			particleEvent.eventId = (int)LevelEventType.ParticlesPotionSplash;
			particleEvent.position = Position;
			particleEvent.data = Data;
			Level.RelayBroadcast(particleEvent);
		}

		public static int CustomPotionColor(int red, int green, int blue)
		{
			red = Math.Clamp(red, 0, 255);
			green = Math.Clamp(green, 0, 255);
			blue = Math.Clamp(blue, 0, 255);

			int colorCode = (red << 16) + (green << 8) + blue;

			if (colorCode > 0x00FFFFFF)
			{
				colorCode &= 0x00FFFFFF;
			}

			return colorCode;
		}
	}
}