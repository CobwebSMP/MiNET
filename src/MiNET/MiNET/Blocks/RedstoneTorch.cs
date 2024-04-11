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

using System.Numerics;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public partial class RedstoneTorch : Block
	{
		public RedstoneTorch() : base(76)
		{
			LightLevel = 7;
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{

			if (face == BlockFace.Down)
				return true;

			switch (face)
			{
				case BlockFace.Up:
					TorchFacingDirection = "top";
					break;
				case BlockFace.North:
					TorchFacingDirection = "south";
					break;
				case BlockFace.South:
					TorchFacingDirection = "north";
					break;
				case BlockFace.West:
					TorchFacingDirection = "east";
					break;
				case BlockFace.East:
					TorchFacingDirection = "west";
					break;
			}

			return false;
		}

		public override void BreakBlock(Level level, BlockFace face, bool silent = false)
		{
			BlockCoordinates[] cord = { Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockUp(), Coordinates.BlockDown() };
			level.CancelBlockTick(this);
			foreach (BlockCoordinates bCord in cord)
			{
				RedstoneController.signal(level, bCord, false);
			}
			base.BreakBlock(level, face);
		}

		public override void BlockAdded(Level level)
		{
			if (level.RedstoneEnabled) { level.ScheduleBlockTick(this, 10); }
		}

		public override void OnTick(Level level, bool isRandom)
		{
			if (isRandom) { return; }
			BlockCoordinates[] cord = { Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockUp(), Coordinates.BlockDown() };
			foreach (BlockCoordinates bCord in cord)
			{
				RedstoneController.signal(level, bCord, true);
			}
			level.ScheduleBlockTick(this, 10);
		}
	}
}