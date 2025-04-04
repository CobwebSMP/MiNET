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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System.Collections.Generic;
using Newtonsoft.Json;

namespace MiNET
{
	public class AttributeModifiers : Dictionary<string, AttributeModifier>
	{
	}

	public class PlayerAttributes : Dictionary<string, PlayerAttribute>
	{
	}

	public class EntityAttributes : Dictionary<string, EntityAttribute>
	{
	}

	public class EntityLink
	{
		public long FromEntityId { get; set; }
		public long ToEntityId { get; set; }
		public EntityLinkType Type { get; set; }
		public bool Immediate { get; set; }
		public bool CausedByRider { get; set; }
		public float VehicleAngularVelocity { get; set; }

		public EntityLink(long fromEntityId, long toEntityId, EntityLinkType type, bool immediate, bool causedByRider, float vehicleAngularVelocity)
		{
			FromEntityId = fromEntityId;
			ToEntityId = toEntityId;
			Type = type;
			Immediate = immediate;
			CausedByRider = causedByRider;
			VehicleAngularVelocity = vehicleAngularVelocity;
		}
		
		public enum EntityLinkType : byte
		{
			Remove = 0,
			Rider = 1,
			Passenger = 2
		}
	}
	
	public class EntityLinks : List<EntityLink>
	{
	}

	public class GameRules : HashSet<GameRule>
	{
	}

	public class Itemstates : List<Itemstate>
	{
		public static Itemstates FromJson(string json)
		{
			return JsonConvert.DeserializeObject<Itemstates>(json);
		}
	}

	public class Itemstate
	{
		[JsonProperty("runtime_id")]
		public short Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("component_based")]
		public bool ComponentBased { get; set; } = false;

		[JsonProperty("version")]
		public int Version { get; set; }

		[JsonProperty("components")]
		public byte[]  Components { get; set; }
	}
}