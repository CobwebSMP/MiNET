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

using System;
using System.Numerics;
using log4net;
using MiNET.Entities.Behaviors;
using MiNET.Items;
using MiNET.Particles;
using MiNET.Utils.Metadata;
using MiNET.Worlds;

namespace MiNET.Entities.Passive
{
	public class Wolf : PassiveMob  //ok
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
			IsInLove = false;

			TargetBehaviors.Add(new FindAttackableEntityTargetBehavior<Sheep>(this, 15));
			TargetBehaviors.Add(new FindAttackableEntityTargetBehavior<Rabbit>(this, 15));

			Behaviors.Add(new SittingBehavior(this));
			Behaviors.Add(new PanicBehavior(this, 60, Speed, 1.4));
			Behaviors.Add(new MeleeAttackBehavior(this, 1.0, 16));
			Behaviors.Add(new FollowOwnerBehavior(this, 20, 1.0));
			Behaviors.Add(new FollowAdultBehavior(this)); // NEW! This Behavior makes baby wolf follow adult wolf.

			//chance based
			Behaviors.Add(new WanderBehavior(this, 1.0, 30));
			Behaviors.Add(new RandomLookaroundBehavior(this, 20));
			Behaviors.Add(new LookAtEntityBehavior(this, 4, 30)); // NEW! This Behavior makes entities to look at other entities.
			Behaviors.Add(new LookAtPlayerBehavior(this, 4, 30));
			Behaviors.Add(new BreedingBehavior(this, 10)); // NEW! This Behavior allows mob breeding.
		}

		public override void DoInteraction(int actionId, Player player)
		{
			if (IsTamed)
			{
				var item = player.Inventory.GetItemInHand();
				if (Owner == player)
				{
					if (item is ItemDye)
					{
						var color = ItemDye.toColorCode(item.Metadata);
						if (color != 255 && color != CollarColor)
						{
							CollarColor = color;
							item.Count--;
						}
						else if (color == CollarColor)
						{
							IsSitting = !IsSitting;
						}
					}
					else if (item is ItemChicken or ItemCookedChicken or ItemBeef or ItemCookedBeef or ItemPorkchop or ItemCookedPorkchop or ItemMuttonRaw or ItemCookedMutton)
					{

					}
					else
					{
						IsSitting = !IsSitting;
					}
					BroadcastSetEntityData();
				}
				else
				{
					LegacyParticle particle = new HeartParticle(Level);
					particle.Position = KnownPosition + new Vector3(0, (float) (Height + 0.85d), 0);
					particle.Spawn();
				}
				if (item is ItemChicken or ItemCookedChicken or ItemBeef or ItemCookedBeef or ItemPorkchop or ItemCookedPorkchop or ItemMuttonRaw or ItemCookedMutton )
				{
					item.Count--;
					if (!IsBaby)
					{
						IsInLove = true;
						breedTime = 400;
						BroadcastSetEntityData();
					}
				}
			}
			else
			{
				if (player.Inventory.GetItemInHand() is ItemBone)
				{
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

		public override void OnTick(Entity[] entities)
		{
			base.OnTick(entities);
			if (breedTime > 0 && IsInLove == true)
			{
				if (breedTime % 20 == 0)
				{
					LegacyParticle particle = new HeartParticle(Level);
					particle.Position = KnownPosition + new Vector3(0, (float) (Height + 0.85d), 0);
					particle.Spawn();
				}
				breedTime--;
			}
			else if (breedTime < 2 && breedTime != 0)
			{
				breedTime = 0;
				IsInLove = false;
				BroadcastSetEntityData();
			}
		}

		public override MetadataDictionary GetMetadata()
		{
			Scale = IsBaby ? 0.50f : 1.0;
			MetadataDictionary metadata = base.GetMetadata();
			metadata[(int) MetadataFlags.Color] = new MetadataByte(CollarColor);
			if (Owner != null)
			{
				metadata[(int) MetadataFlags.Owner] = new MetadataLong(Owner.EntityId);
			}

			return metadata;
		}
	}
}