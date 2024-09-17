using System;
using MiNET.Entities.World;
using MiNET.Particles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Entities.Projectiles
{
	public class ExperienceBottle : Projectile
	{
		public ExperienceBottle(Player shooter, Level level) : base(shooter, EntityType.ThrownBottleoEnchanting, level, 0)
		{
			Width = 0.25;
			Length = 0.25;
			Height = 0.25;

			Gravity = 0.15;
			Drag = 0.25;

			Damage = -1;
			HealthManager.IsInvulnerable = true;
			DespawnOnImpact = true;
			BroadcastMovement = true;
		}

		public override void DespawnEntity()
		{
			var particle = new SplashPotionParticle(Level, KnownPosition, 0, 0, 255);
			particle.Spawn();

			Random random = new Random();

			for (int a = 0; a < random.Next(3, 12); a++)
			{
				var xp = new ExperienceOrb(Level);
				xp.KnownPosition.X = KnownPosition.X + GetRandomFloat();
				xp.KnownPosition.Y = KnownPosition.Y + 0.1f;
				xp.KnownPosition.Z = KnownPosition.Z + GetRandomFloat();
				xp.SpawnEntity();
			}
			Level.BroadcastSound(KnownPosition, LevelSoundEventType.Glass);
			base.DespawnEntity();
		}

		static float GetRandomFloat()
		{
			Random random = new Random();
			return (float)(random.NextDouble() * 2) - 1;
		}
	}
}