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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

using System.Numerics;
using MiNET.Blocks;
using MiNET.Effects;
using MiNET.Entities.Passive;
using MiNET.Items;
using MiNET.Net;
using MiNET.Utils.Metadata;
using MiNET.Worlds;

namespace MiNET.Entities.Projectiles
{
	public class Arrow : Projectile
	{
		public byte EffectValue { get; set; } = 0;
		public bool isFlame { get; set; }
		public int PickupDelay = 10;
		public Arrow(Player shooter, Level level, int damage = 2, bool isCritical = false) : base(shooter, EntityType.ShotArrow, level, damage, isCritical)
		{
			Width = 0.15;
			Length = 0.15;
			Height = 0.15;

			Gravity = 0.05;
			Drag = 0.01;

			//OK: Drag = 0.0083;

			HealthManager.IsInvulnerable = true;
			Ttl = 1200;
			DespawnOnImpact = false;
		}

		protected override void OnHitBlock(Block blockCollided)
		{
			IsCritical = false;
			BroadcastSetEntityData();

			McpeEntityEvent entityEvent = McpeEntityEvent.CreateObject();
			entityEvent.runtimeEntityId = EntityId;
			entityEvent.eventId = 39;
			entityEvent.data = 14;
			Level.RelayBroadcast(entityEvent);
			Level.BroadcastSound(blockCollided.Coordinates, LevelSoundEventType.BowHit);
		}

		protected override void OnHitEntity(Entity entityCollided)
		{
			IsCritical = false;
			BroadcastSetEntityData();
			var effects = Effect.GetEffects((byte) (EffectValue - 1));
			if (entityCollided is Player player)
			{
				foreach (var effect in effects)
				{
					effect.Duration = effect.Duration / 8;
					player.SetEffect(effect);
				}
				if (isFlame)
				{
					player.HealthManager.Ignite(100);
				}
			}
			else if (entityCollided is PassiveMob mob) //todo
			{
				if (isFlame)
				{
					mob.HealthManager.Ignite(100);
				}
			}
		}

		public override void OnTick(Entity[] entities)
		{
			base.OnTick(entities);

			if (PickupDelay > 0)
			{
				PickupDelay--;
			}
			else if(Velocity == Vector3.Zero)
			{
				var bbox = GetBoundingBox();
				var players = Level.GetSpawnedPlayers();
				foreach (var player in players)
				{
					if (player.GameMode != GameMode.Spectator && bbox.Intersects(player.GetBoundingBox() + 1))
					{
						if (player.Inventory.SetFirstEmptySlot(ItemFactory.GetItem("minecraft:arrow", EffectValue), true))
						{
							var takeItemEntity = McpeTakeItemEntity.CreateObject();
							takeItemEntity.runtimeEntityId = EntityId;
							takeItemEntity.target = player.EntityId;
							Level.RelayBroadcast(takeItemEntity);

							var takeItemEntity2 = McpeTakeItemEntity.CreateObject();
							takeItemEntity2.runtimeEntityId = EntityId;
							takeItemEntity2.target = EntityManager.EntityIdSelf;
							player.SendPacket(takeItemEntity2);
						}
						DespawnEntity();
					}
				}
			}
		}

		public override MetadataDictionary GetMetadata()
		{
			if (isFlame)
			{
				HealthManager.Ignite();
			}
			MetadataDictionary metadata = base.GetMetadata();
			metadata[(int) MetadataFlags.CustomDisplay] = new MetadataByte(EffectValue);
			return metadata;
		}
	}
}