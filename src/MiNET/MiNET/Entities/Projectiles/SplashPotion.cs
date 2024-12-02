using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using MiNET.Effects;
using MiNET.Particles;
using MiNET.Utils.Metadata;
using MiNET.Worlds;

namespace MiNET.Entities.Projectiles
{
	public class SplashPotion : Projectile
	{
		public short Metadata { get; set; }
		public SplashPotion(Player shooter, Level level, short metadata) : base(shooter, EntityType.ThrownSpashPotion, level, 0)
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
			Metadata = metadata;
		}

		public override void DespawnEntity()
		{
			var effects = Effect.GetEffects(Metadata);
			var particle = new SplashPotionParticle(Level, KnownPosition, effects.Count == 0 ? Color.FromArgb(0x38, 0x5d, 0xc6) : effects[0].ParticleColor);
			particle.Spawn();
			Level.BroadcastSound(KnownPosition, LevelSoundEventType.Glass);

			var playersInArea = new List<Player>();

			foreach (var player in Level.Players.Values)
			{
				var box = player.GetBoundingBox() + 4.00f;
				if (box.Intersects(GetBoundingBox()))
				{
					playersInArea.Add(player);
				}
			}
			if(playersInArea.Count <= 0)
			{
				base.DespawnEntity();
				return;
			}
			ApplyPotionEffects(playersInArea, effects);
			base.DespawnEntity();
		}

		private void ApplyPotionEffects(List<Player> players, List<Effect> effects)
		{
			if (effects == null) return;
			foreach (var player in players)
			{
				foreach (var effect in effects)
				{
					if (!GetBoundingBox().Intersects(player.GetBoundingBox() + 1))
					{
						float distance = Vector3.Distance(player.KnownPosition + new Vector3(0, 1.62f, 0), KnownPosition);
						float multiplier = (1 - (distance / 4));
						effect.Duration = (int) (effect.Duration * multiplier);
					}
					effect.Particles = true;
					player.SetEffect(effect);
				}
			}
		}

		public override MetadataDictionary GetMetadata()
		{
			return new MetadataDictionary
			{
				[(int) MetadataFlags.AuxValueData] = new MetadataShort(Metadata),
			};
		}
	}
}
