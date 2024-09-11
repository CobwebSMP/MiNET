﻿#region LICENSE

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

using System;
using System.Numerics;
using log4net;
using MiNET.Entities.Behaviors;
using MiNET.Items;
using MiNET.Particles;
using MiNET.Utils;
using MiNET.Utils.Metadata;
using MiNET.Worlds;

namespace MiNET.Entities.Passive
{
	public class Wolf : PassiveMob
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Wolf));

		public byte CollarColor { get; set; }
		public Entity Owner { get; set; }

		public Wolf(Level level) : base(EntityType.Wolf, level)
		{
			Width = Length = 0.6;
			Height = 0.8;
			IsAngry = false;
			CollarColor = 14;
			HealthManager.MaxHealth = 80;
			HealthManager.ResetHealth();
			Speed = 0.3;

			AttackDamage = 2;

			TargetBehaviors.Add(new HurtByTargetBehavior(this));
			TargetBehaviors.Add(new FindAttackableEntityTargetBehavior<Sheep>(this, 16));
			TargetBehaviors.Add(new FindAttackableEntityTargetBehavior<Rabbit>(this, 16));

			Behaviors.Add(new SittingBehavior(this));
			Behaviors.Add(new MeleeAttackBehavior(this, 1.0, 16));
			Behaviors.Add(new OwnerHurtByTargetBehavior(this));
			Behaviors.Add(new OwnerHurtTargetBehavior(this));
			Behaviors.Add(new FollowOwnerBehavior(this, 20, 1.0));
			Behaviors.Add(new WanderBehavior(this, 1.0));
			Behaviors.Add(new LookAtPlayerBehavior(this, 8.0));
			Behaviors.Add(new RandomLookaroundBehavior(this));
		}

		public override void DoInteraction(int actionId, Player player)
		{
			if (IsTamed)
			{
				if (Owner == player)
				{
					IsSitting = !IsSitting;
					var item = player.Inventory.GetItemInHand();
					if (player.Inventory.GetItemInHand() is ItemDye)
					{
						var color = ItemDye.toColorCode(item.Metadata);
						if (color != 255)
						{
							CollarColor = color;
							item.Count--;
						}
					}
					BroadcastSetEntityData();
				}
				else
				{
					// Hmm?
				}
			}
			else
			{
				if (player.Inventory.GetItemInHand() is ItemBone)
				{
					Log.Debug($"Wolf taming attempt by {player.Username}");

					player.Inventory.RemoveItems(new ItemBone().Id, 1);

					var random = new Random();
					if (random.Next(3) == 0)
					{
						Owner = player;
						IsTamed = true;
						IsSitting = true;
						IsAngry = false;
						AttackDamage = 4;
						BroadcastSetEntityData();

						for (int i = 0; i < 7; ++i)
						{
							LegacyParticle particle = new HeartParticle(Level, random.Next(3));
							particle.Position = KnownPosition + new Vector3(0, (float) (Height + 0.85d), 0);
							particle.Spawn();
						}


						Log.Debug($"Wolf is now tamed by {player.Username}");
					}
					else
					{
						for (int i = 0; i < 7; ++i)
						{
							LegacyParticle particle = new SmokeParticle(Level);
							particle.Position = KnownPosition + new Vector3(0, (float) (Height + 0.85d), 0);
							particle.Spawn();
						}
					}
				}
			}
		}

		public override MetadataDictionary GetMetadata()
		{
			MetadataDictionary metadata = base.GetMetadata();
			metadata[(int) MetadataFlags.Color] = new MetadataByte(CollarColor);
			if (Owner != null)
			{
				metadata[(int) MetadataFlags.Owner] = new MetadataLong(Owner.EntityId);
			}
			metadata[(int) MetadataFlags.CollisionBoxWidth] = new MetadataFloat(0.6f);
			metadata[(int) MetadataFlags.CollisionBoxHeight] = new MetadataFloat(0.8f);
			metadata[(int) MetadataFlags.EntityAge] = new MetadataShort(0);

			return metadata;
		}
	}
}