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

using MiNET.Items;
using MiNET.Utils.Vectors;
using MiNET.Worlds;
using System;
using System.Numerics;

namespace MiNET.Blocks
{
	public partial class Planks : Block
	{
		public Planks() : base(5)
		{
			FuelEfficiency = 15;
			BlastResistance = 15;
			Hardness = 2;
			IsFlammable = true;
		}

		public override bool IsBestTool(Item item)
		{
			return item is ItemAxe ? true : false;
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{
			var itemInHand = player.Inventory.GetItemInHand();
			WoodType = itemInHand.Metadata switch
			{
				0 => "oak",
				1 => "spruce",
				2 => "birch",
				3 => "jungle",
				4 => "acacia",
				5 => "dark_oak",
				_ => throw new ArgumentOutOfRangeException()
			};
			return false;
		}
	}
}