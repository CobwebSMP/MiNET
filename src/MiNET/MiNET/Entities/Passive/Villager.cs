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

using MiNET.Entities.Behaviors;
using MiNET.Utils.Metadata;
using MiNET.Worlds;

namespace MiNET.Entities.Passive
{
	public class Villager : PassiveMob
	{
		public Villager(Level level) : base(EntityType.Villager, level)
		{
			Width = Length = 0.6;
			Height = 1.9;
			HealthManager.MaxHealth = 200;
			HealthManager.ResetHealth();
			Speed = 0.3;
			IsInLove = false;

			Behaviors.Add(new PanicBehavior(this, 60, Speed, 1.4));

			Behaviors.Add(new WanderBehavior(this, 1.0, 40));
			Behaviors.Add(new LookAtEntityBehavior(this, 4, 20));
			Behaviors.Add(new LookAtPlayerBehavior(this, 4, 10));
			Behaviors.Add(new RandomLookaroundBehavior(this, 40));
			Behaviors.Add(new FindJobBlockBehaviour(this));
		}

		public override MetadataDictionary GetMetadata()
		{
			Scale = IsBaby ? 0.50f : 1.0;
			MetadataDictionary metadata = base.GetMetadata();
			metadata[(int) MetadataFlags.Variant] = new MetadataInt(Variant);
			metadata[(int) MetadataFlags.ContainerType] = new MetadataShort(247);
			metadata[(int) MetadataFlags.ContainerSize] = new MetadataByte(8);
			metadata[(int) MetadataFlags.MaxTradeTier] = new MetadataInt(4);

			return metadata;
		}
	}
}