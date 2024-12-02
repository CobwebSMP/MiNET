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

using System.Collections.Generic;
using System.Drawing;
using MiNET.Net;
using MiNET.Worlds;

namespace MiNET.Effects
{
	public enum EffectType : byte
	{
		None = 0,
		Speed = 1,
		Slowness = 2,
		Haste = 3,
		MiningFatigue = 4,
		Strength = 5,
		InstantHealth = 6,
		InstantDamage = 7,
		JumpBoost = 8,
		Nausea = 9,
		Regeneration = 10,
		Resistance = 11,
		FireResistance = 12,
		WaterBreathing = 13,
		Invisibility = 14,
		Blindness = 15,
		NightVision = 16,
		Hunger = 17,
		Weakness = 18,
		Poison = 19,
		Wither = 20,
		HealthBoost = 21,
		Absorption = 22,
		Saturation = 23,
		Levitation = 24,
		FatalPoison = 25,
		Conduit = 26,
		SlowFalling = 27,
		BadOmen = 28,
		VillageHero = 29
	}

	public class Effect
	{
		public const int MaxDuration = 0x7fffffff;

		public EffectType EffectId { get; set; }
		public int Duration { get; set; }
		public int Level { get; set; }
		public bool Particles { get; set; }
		public Color ParticleColor { get; set; } = Color.Black;

		protected Effect(EffectType id)
		{
			EffectId = id;
			Particles = true;
		}

		public virtual void SendAdd(Player player)
		{
			var message = McpeMobEffect.CreateObject();
			message.runtimeEntityId = EntityManager.EntityIdSelf;
			message.eventId = 1;
			message.effectId = (int) EffectId;
			message.duration = Duration;
			message.amplifier = Level;
			message.particles = Particles;
			message.tick = player.CurrentTick;
			player.SendPacket(message);

			player.BroadcastSetEntityData();
		}

		public virtual void SendUpdate(Player player)
		{
			var message = McpeMobEffect.CreateObject();
			message.runtimeEntityId = EntityManager.EntityIdSelf;
			message.eventId = 2;
			message.effectId = (int) EffectId;
			message.duration = Duration;
			message.amplifier = Level;
			message.particles = Particles;
			message.tick = player.CurrentTick;
			player.SendPacket(message);
		}

		public virtual void SendRemove(Player player)
		{
			var message = McpeMobEffect.CreateObject();
			message.runtimeEntityId = EntityManager.EntityIdSelf;
			message.eventId = 3;
			message.effectId = (int) EffectId;
			message.tick = player.CurrentTick;
			player.SendPacket(message);
		}

		public virtual void OnTick(Player player)
		{
			if (Duration > 0 && Duration != MaxDuration) Duration -= 1;
			if (Duration < 20) player.RemoveEffect(this); // Need 20 tick grace for some effects that fade
		}

		public override string ToString()
		{
			return $"EffectId: {EffectId}, Duration: {Duration}, Level: {Level}, Particles: {Particles}";
		}

		public static List<Effect> GetEffects(short Metadata)
		{
			List<Effect> effect = new List<Effect>();
			switch (Metadata)
			{
				case 5: // Night Vision (3:00)
					effect.Add(new NightVision { Duration = 3600 });
					break;
				case 6: // Night Vision (8:00)
					effect.Add(new NightVision { Duration = 9600 });
					break;
				case 7: // Invisibility (3:00)
					effect.Add(new Invisibility { Duration = 3600 });
					break;
				case 8: // Invisibility (8:00)
					effect.Add(new Invisibility { Duration = 9600 });
					break;
				case 9: // Leaping (Jump Boost 1, 3:00)
					effect.Add(new JumpBoost { Duration = 3600 });
					break;
				case 10: // Leaping (Jump Boost 1, 8:00)
					effect.Add(new JumpBoost { Duration = 9600 });
					break;
				case 11: // Leaping (Jump Boost 2, 1:30)
					effect.Add(new JumpBoost { Duration = 2600, Level = 1 });
					break;
				case 12: // Fire Resistance (3:00)
					effect.Add(new FireResistance { Duration = 3600 });
					break;
				case 13: // Fire Resistance (8:00)
					effect.Add(new FireResistance { Duration = 9600 });
					break;
				case 14: // Swiftness (Speed 1, 3:00)
					effect.Add(new Speed { Duration = 3600 });
					break;
				case 15: // Swiftness (Speed 1, 8:00)
					effect.Add(new Speed { Duration = 9600 });
					break;
				case 16: // Swiftness (Speed 2, 1:30)
					effect.Add(new Speed { Duration = 1800, Level = 1 });
					break;
				case 17: // Slowness (1:30)
					effect.Add(new Slowness { Duration = 1800 });
					break;
				case 18: // Slowness (4:00)
					effect.Add(new Slowness { Duration = 4800 });
					break;
				case 19: // Water Breathing (3:00)
					effect.Add(new WaterBreathing { Duration = 3600 });
					break;
				case 20: // Water Breathing (8:00)
					effect.Add(new WaterBreathing { Duration = 9600 });
					break;
				case 21: // Healing
					effect.Add(new InstantHealth { });
					break;
				case 22: // healing 2
					effect.Add(new InstantHealth { Level = 1 });
					break;
				case 23: // Harming
					effect.Add(new InstantDamage { });
					break;
				case 24: // Harming 2
					effect.Add(new InstantDamage { Level = 1 });
					break;
				case 25: // Poison (Poison 1, 0:45)
					effect.Add(new Poison { Duration = 900 });
					break;
				case 26: // Poison (Poison 1, 2:00)
					effect.Add(new Poison { Duration = 2400 });  //test
					break;
				case 27: // Poison (Poison 2, 0:22)
					effect.Add(new Poison { Duration = 440, Level = 1 });
					break;
				case 28: // Regeneration (Regen 1, 0:45)
					effect.Add(new Regeneration { Duration = 900 });
					break;
				case 29: // Regeneration (Regen 1, 2:00)
					effect.Add(new Regeneration { Duration = 2400 });  //test
					break;
				case 30: // Regeneration (Regen 2, 0:22)
					effect.Add(new Regeneration { Duration = 440, Level = 1 });
					break;
				case 31: // Strength (Strength 1, 3:00)
					effect.Add(new Strength { Duration = 3600 });
					break;
				case 32: // Strength (Strength 1, 8:00)
					effect.Add(new Strength { Duration = 9600 });
					break;
				case 33: // Strength (Strength 2, 1:30)
					effect.Add(new Strength { Duration = 1800, Level = 1 });
					break;
				case 34: // Weakness (1:30)
					effect.Add(new Weakness { Duration = 1800 });
					break;
				case 35: // Weakness (4:00)
					effect.Add(new Weakness { Duration = 4800 });
					break;
				case 36: // Decay (Wither 2, 0:40)
					effect.Add(new Wither { Duration = 800, Level = 1 });
					break;
				case 37: //Turtle Master (Slowness 4 & Resistance 3, 0:20)
					effect.Add(new Slowness { Duration = 400, Level = 3 });
					effect.Add(new Resistance { Duration = 400, Level = 2 });
					break;
				case 38: // Turtle Master (Slowness 4 & Resistance 3, 0:40)
					effect.Add(new Slowness { Duration = 800, Level = 3 });
					effect.Add(new Resistance { Duration = 800, Level = 2 });
					break;
				case 39: // Turtle Master (Slowness 6 & Resistance 4, 0:20)
					effect.Add(new Slowness { Duration = 400, Level = 5 });
					effect.Add(new Resistance { Duration = 400, Level = 3 });
					break;
				case 40: // Slow Falling (1:30)
					effect.Add(new SlowFalling { Duration = 1800 });
					break;
				case 41: // Slow Falling (4:00)
					effect.Add(new SlowFalling { Duration = 4800 });
					break;
			}
			return effect;
		}
	}
}