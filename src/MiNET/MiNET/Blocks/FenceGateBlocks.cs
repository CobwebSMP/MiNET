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

using MiNET.Utils.Vectors;
using System.Numerics;
using MiNET.Worlds;
using MiNET.Sounds;
using MiNET.Entities;
using System;

namespace MiNET.Blocks
{
	public abstract class FenceGateBlocks : Block
	{
		[StateRange(0, 3)] public virtual int Direction { get; set; }
		[StateBit] public virtual bool OpenBit { get; set; } = false;
		public FenceGateBlocks(byte id) : base(id)
		{
			FuelEfficiency = 15;
			IsTransparent = true;
			BlastResistance = 15;
			Hardness = 2;
			IsFlammable = true;
		}
		public override bool PlaceBlock(Level world, Player player, BlockCoordinates targetCoordinates, BlockFace face, Vector3 faceCoords)
		{
			Direction = player.GetDirectionEmum() switch
			{
				Entity.Direction.West => 0,
				Entity.Direction.North => 1,
				Entity.Direction.East => 2,
				Entity.Direction.South => 3,
				_ => throw new ArgumentOutOfRangeException()
			};
			return false;
		}
		public override bool Interact(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoord)
		{
			var sound = new Sound((short) LevelEventType.SoundOpenDoor, blockCoordinates);
			sound.Spawn(world);
			return true;
		}
	}
}