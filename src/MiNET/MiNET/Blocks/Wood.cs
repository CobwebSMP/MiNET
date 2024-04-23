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
using MiNET.Items;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public partial class Wood : Block
	{
		public Wood() : base(467)
		{
			FuelEfficiency = 15;
			BlastResistance = 10;
			Hardness = 2;
			IsFlammable = true;
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{
			var itemInHand = player.Inventory.GetItemInHand();
			woodType = itemInHand.Metadata switch
			{
				7 or 15 => "oak",
				1 or 9 => "spruce",
				2 or 10 => "birch",
				3 or 11 => "jungle",
				4 or 12 => "acacia",
				5 or 13 => "dark_oak",
				_ => throw new ArgumentOutOfRangeException()
			};

			StrippedBit = itemInHand.Metadata switch
			{
				15 or 9 or 10 or 11 or 12 or 13 => true,
				_ => false
			};
			switch (ItemBlock.GetPillarAxisFromFace(face))
			{
				case BlockAxis.X:
					PillarAxis = "x";
					break;
				case BlockAxis.Y:
					PillarAxis = "y";
					break;
				case BlockAxis.Z:
					PillarAxis = "z";
					break;
			}
			return false;
		}



	}
}