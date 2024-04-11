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
using System.Threading.Tasks;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public abstract class Button : Block
	{
		public int TickRate { get; set; }
		public static int Direction { get; set; }
		private BlockCoordinates[] cord = [];
		[StateBit] public virtual bool ButtonPressedBit { get; set; } = false;
		[StateRange(0, 5)] public virtual int FacingDirection { get; set; } = 2;

		protected Button(int id) : base(id)
		{
			IsSolid = false;
			IsTransparent = true;
			BlastResistance = 2.5f;
			Hardness = 0.5f;
		}

		public override bool PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{
			Direction = (int) face;
			FacingDirection = Direction;
			world.SetBlock(this);
			return true;
		}

		public override bool Interact(Level level, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoord)
		{
			level.BroadcastSound(blockCoordinates, LevelSoundEventType.ButtonOn);
			ButtonPressedBit = true;
			FacingDirection = Direction;
			level.SetBlock(this);
			level.ScheduleBlockTick(this, TickRate);

			if (!level.RedstoneEnabled) { return true; }

			cord = [Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockDown(), Coordinates.BlockNorthEast(), Coordinates.BlockNorthWest(), Coordinates.BlockSouthEast(), Coordinates.BlockSouthWest()];

			if (ButtonPressedBit)
			{
				foreach (BlockCoordinates bCord in cord)
				{
					RedstoneController.signal(level, bCord, true);
					TurnOff(level);
				}
			}
			return true;
		}

		public override void OnTick(Level level, bool isRandom)
		{
			if (isRandom) return;
			level.BroadcastSound(Coordinates, LevelSoundEventType.ButtonOff);
			ButtonPressedBit = false;
			level.SetBlock(this);
		}

		private async void TurnOff(Level level)
		{
			await Task.Delay((TickRate / 2) * 100);
			foreach (BlockCoordinates bCord in cord)
			{
				RedstoneController.signal(level, bCord, false);
			}
		}
	}
}