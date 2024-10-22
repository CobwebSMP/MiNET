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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System;
using System.Numerics;
using MiNET.Items;
using MiNET.Utils;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public partial class WoodenSlab : Block
	{
		public WoodenSlab() : base(158)
		{
			BlastResistance = 15;
			Hardness = 2;
			IsFlammable = true;
			IsTransparent = true; // Partial - blocks light.
			IsBlockingSkylight = false; // Partial - blocks light.
		}

		public override bool IsBestTool(Item item)
		{
			return item is ItemAxe ? true : false;
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates targetCoordinates, BlockFace face, Vector3 faceCoords)
		{
			var itemInHand = player.Inventory.GetItemInHand();

			TopSlotBit = (faceCoords.Y > 0.5 && face != BlockFace.Up);

			WoodType = itemInHand.Metadata switch
			{
				1 => "spruce",
				2 => "birch",
				3 => "jungle",
				4 => "acacia",
				5 => "dark_oak",
				_ => throw new ArgumentOutOfRangeException()
			};

			var slabcoordinates = new BlockCoordinates(Coordinates.X, Coordinates.Y - 1, Coordinates.Z);

			foreach (var state in world.GetBlock(slabcoordinates).GetState().States)
			{
				if (state is BlockStateString s && s.Name == "wood_type")
				{
					if (world.GetBlock(slabcoordinates).Name == "minecraft:wooden_slab" && s.Value == WoodType)
					{
						world.SetBlock(new DoubleWoodenSlab { WoodType = WoodType, TopSlotBit = true });
						return true;
					}
				}
			}
			return false;
		}
	}
}