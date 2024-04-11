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

using System.Numerics;
using log4net;
using MiNET.Items;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public partial class RedstoneWire : Block
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(RedstoneWire));
		public RedstoneWire() : base(55)
		{
			IsTransparent = true;
		}

		public override void OnTick(Level level, bool isRandom)
		{
			if (isRandom) { return; }
			BlockCoordinates[] cord = { Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockUp(), Coordinates.BlockDown() };
			int currentSignal = 0;
			foreach (BlockCoordinates bCord in cord)
			{
				var blockk = level.GetBlock(bCord);
				if (blockk is Lever)
				{
					var lever = blockk as Lever;
					if (lever.OpenBit == true)
					{
						currentSignal = 15;
					}
				}
				if (blockk is Button)
				{
					var button = blockk as Button;
					if (button.ButtonPressedBit == true)
					{
						currentSignal = 15;
					}
				}
				if (blockk is RedstoneTorch)
				{
					var button = blockk as RedstoneTorch;
					currentSignal = 15;
				}
				else if (blockk is RedstoneWire)
				{
					var wire = blockk as RedstoneWire;
					if (wire.RedstoneSignal - RedstoneSignal == wire.RedstoneSignal)
					{
						currentSignal = wire.RedstoneSignal - 1;
					}
					else if (wire.RedstoneSignal - RedstoneSignal == 1) 
					{
						currentSignal = RedstoneSignal;
					}
					if (!level.BlockWithTicks.TryGetValue(blockk.Coordinates, out long value))
					{
						level.ScheduleBlockTick(blockk, 10);
					}
				}
				else
				{
					if ( RedstoneSignal > 0)
					{
						RedstoneController.signal(level, bCord, true);
					}
					else
					{
						RedstoneController.signal(level, bCord, false);
					}
				}
				level.SetBlock(new RedstoneWire { Coordinates = new BlockCoordinates(Coordinates), RedstoneSignal = currentSignal == -1 ? 0 : currentSignal });
			}
		}
		public override bool Interact(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoord)
		{
			if (player.Inventory.GetItemInHand() is ItemRedstone)
			{
				return true;
			}
			return false;
		}

		public override void BlockAdded(Level level)
		{
			if (level.RedstoneEnabled) { level.ScheduleBlockTick(this, 10); }
		}

		public override Item[] GetDrops(Item tool)
		{
			return new[] {ItemFactory.GetItem(331)};
		}
	}
}