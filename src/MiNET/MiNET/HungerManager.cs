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

using log4net;
using MiNET.Items;
using MiNET.Net;
using MiNET.Worlds;

namespace MiNET
{
	public class HungerManager
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(HungerManager));

		public Player Player { get; set; }

		public int Hunger { get; set; } = 20;
		public int MinHunger { get; set; } = 0;
		public int MaxHunger { get; set; } = 20;
		public double Saturation { get; set; } = 5;
		public double Exhaustion { get; set; } = 0;

		public HungerManager(Player player)
		{
			Player = player;
			ResetHunger();
		}

		public virtual bool CanEat()
		{
			return Hunger < MaxHunger;
		}

		public virtual void IncreaseFoodAndSaturation(Item item, int foodPoints, double saturationRestore)
		{
			Hunger += foodPoints;
			Saturation += saturationRestore;

			ProcessHunger(true);
		}

		public virtual void IncreaseExhaustion(float amount)
		{
			Exhaustion += amount;
			ProcessHunger();
		}

		public virtual void Move(double distance)
		{
			//Swimming                                                    0.01     per meter (ok)
			//Breaking a block                                            0.005    per block broken (ok)
			//Sprinting                                                   0.1      per meter (ok)
			//Jumping	                                                  0.05     per jump (ok)
			//Attacking an entity	                                      0.1      per attack landed (ok)
			//Taking damage that is normally protected by armor           0.1      per distinct instance of damage being received ?? (todo)
			//Hunger                                                      0.005    per tick, per Hunger status effect level (todo)
			//Jumping while sprinting                                     0.2      per jump (ok)

			//Sneaking and walking no longer affect exhaustion since 1.18.30

			//double movementStrainFactor = 0.01;

			if (Player.CurrentTick % 20 == 0) //questionable
			{
				if (Player.IsSwimming)
				{
					IncreaseExhaustion(0.01f);
				}
				else if (Player.IsSprinting)
				{
					IncreaseExhaustion(0.1f);
				}
			}
		}

		public virtual void ProcessHunger(bool forceSend = false)
		{
			bool send = forceSend;

			if (Hunger > MaxHunger)
			{
				Hunger = MaxHunger;
				send = true;
			}

			if (Saturation > Hunger)
			{
				Saturation = Hunger;
				send = true;
			}

			while (Exhaustion >= 4)
			{
				Exhaustion -= 4;

				if (Saturation > 0)
				{
					if (Player.Level.Difficulty != Difficulty.Peaceful)
					{
						Saturation -= 1;
					}

					if (Saturation < 0)
					{
						Saturation = 0;
						send = true;
					}
				}
				else
				{
					Hunger -= 1;
					Saturation = 0;

					if (Hunger < 0) Hunger = 0; // Damage!
					send = true;
				}
			}

			if (send) SendHungerAttributes();
		}

		private long _ticker;

		public virtual void OnTick()
		{
			if (Hunger <= 0)
			{
				_ticker++;

				if (_ticker == 80)
				{
					if (
						(Player.Level.Difficulty == Difficulty.Easy && Player.HealthManager.Hearts > 10) ||  // on Easy difficulty player health stops dropping at 10
						(Player.Level.Difficulty == Difficulty.Normal && Player.HealthManager.Hearts > 1) || // on Normal at 1
						(Player.Level.Difficulty == Difficulty.Hard)                                         // on Hard keep draining until the player eats something or starves to death
						)
					{
						Player.HealthManager.TakeHit(null, 1, DamageCause.Starving);
					}
					_ticker = 0;
				}
			}
			else if ((Player.Level.Difficulty == Difficulty.Peaceful || Hunger > 17) && Player.HealthManager.Hearts < 20)
			{
				_ticker++;
				if (Player.Level.NaturalRegeneration)
				{
					if (_ticker == 80)
					{
						IncreaseExhaustion(6);
						Player.HealthManager.Regen(1);
						_ticker = 0;
					}
				}
			}
			else
			{
				_ticker = 0;
			}
		}

		public void DisplayDebugPopup()
		{
			if (Log.IsDebugEnabled)
			{
				if (Player.Level.TickTime % 10 == 0)
				{
					if (Player.Username.Equals("gurunx"))
					{
						Popup popup = new Popup
						{
							Duration = 20 * 2,
							MessageType = MessageType.Tip,
							Message = $"Saturation={Saturation}, Exhaustion={Exhaustion:F3}"
						};

						Player.AddPopup(popup);
					}
				}
			}
		}

		public virtual PlayerAttributes AddHungerAttributes(PlayerAttributes attributes)
		{
			attributes["minecraft:player.hunger"] = new PlayerAttribute
			{
				Name = "minecraft:player.hunger",
				MinValue = MinHunger,
				MaxValue = MaxHunger,
				Value = Hunger,
				Default = MaxHunger,
				Modifiers = new AttributeModifiers()
			};

			attributes["minecraft:player.saturation"] = new PlayerAttribute
			{
				Name = "minecraft:player.saturation",
				MinValue = 0,
				MaxValue = MaxHunger,
				Value = (float) Saturation,
				Default = MaxHunger,
				Modifiers = new AttributeModifiers()
			};
			attributes["minecraft:player.exhaustion"] = new PlayerAttribute
			{
				Name = "minecraft:player.exhaustion",
				MinValue = 0,
				MaxValue = 5,
				Value = (float) Exhaustion,
				Default = 5,
				Modifiers = new AttributeModifiers()
			};

			return attributes;
		}

		public virtual void SendHungerAttributes()
		{
			var attributes = AddHungerAttributes(new PlayerAttributes());

			McpeUpdateAttributes attributesPackate = McpeUpdateAttributes.CreateObject();
			attributesPackate.runtimeEntityId = EntityManager.EntityIdSelf;
			attributesPackate.attributes = attributes;
			Player.SendPacket(attributesPackate);
		}

		public virtual void ResetHunger()
		{
			Hunger = MaxHunger;
			Saturation = 5;
			Exhaustion = 0;
		}
	}
}