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
using log4net;
using MiNET.Items;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public partial class Lever : Block
	{
		public static string Direction { get; set; }
		private BlockCoordinates[] cord = [];
		private static readonly ILog Log = LogManager.GetLogger(typeof(Lever));
		public Lever() : base(69)
		{
			IsTransparent = true;
			IsSolid = false;
			BlastResistance = 2.5f;
			Hardness = 0.5f;
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{
			var FacingDirection = ItemBlock.GetFacingDirectionFromEntity(player);
			Log.Debug(FacingDirection);
			if (face == BlockFace.Down)
			{
				Direction = FacingDirection switch
				{
					5 or 4 => "down_east_west",
					2 or 3 => "down_north_south",
					_ => throw new ArgumentOutOfRangeException()
				};
			}
			else if (face == BlockFace.Up)
			{
				Direction = FacingDirection switch
				{
					5 or 4 => "up_east_west",
					2 or 3 => "up_north_south",
					_ => throw new ArgumentOutOfRangeException()
				};
			}
			else
			{
				Direction = FacingDirection switch
				{
					5 => "east",
					3 => "south",
					4 => "west",
					2 => "north",
					_ => throw new ArgumentOutOfRangeException()
				};
			}
			LeverDirection = Direction;
			return false;
		}

		public override bool Interact(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoord)
		{
			world.BroadcastSound(blockCoordinates, LevelSoundEventType.ButtonOn);
			world.ScheduleBlockTick(this, 10);
			LeverDirection = Direction;
			if (!OpenBit)
			{
				OpenBit = true;
				world.SetBlock(this);
			}
			else
			{
				OpenBit = false;
				world.SetBlock(this);
			}
			return true;
		}

		public override void BreakBlock(Level level, BlockFace face, bool silent = false)
		{
			BlockCoordinates[] cord = { Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockUp(), Coordinates.BlockDown() };
			level.CancelBlockTick(this);
			foreach (BlockCoordinates bCord in cord)
			{
				var blockk = level.GetBlock(bCord);
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
			cord = [Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockDown(), Coordinates.BlockNorthEast(), Coordinates.BlockNorthWest(), Coordinates.BlockSouthEast(), Coordinates.BlockSouthWest()];
			foreach (BlockCoordinates bCord in cord)
			{
				if (OpenBit)
				{
					RedstoneController.signal(level, bCord, true);
				}
				else
				{
					RedstoneController.signal(level, bCord, false);
				}
			}
			level.ScheduleBlockTick(this, 10);
		}

	}
}