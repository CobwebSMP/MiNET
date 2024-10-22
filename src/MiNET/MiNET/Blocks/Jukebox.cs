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
using MiNET.Particles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;
using System;
using System.Linq;
using System.Numerics;

namespace MiNET.Blocks
{
	public partial class Jukebox : Block
	{
		private static int[] discIds = { 500, 501, 502, 503, 504, 505, 506, 507, 508, 509, 510, 511 };
		private static Item disc { get; set; }
		private static bool playing { get; set; } = false;
		public Jukebox() : base(84)
		{
			BlastResistance = 30;
			Hardness = 2f;
		}

		public override bool IsBestTool(Item item)
		{
			return item is ItemAxe ? true : false;
		}

		public override void BreakBlock(Level level, BlockFace face, bool silent = false)
		{
			if (level.BlockWithTicks.TryGetValue(Coordinates, out long value))
			{
				level.CancelBlockTick(this);
			}
			if (playing)
			{
				level.BroadcastSound(Coordinates, LevelSoundEventType.RecordNull);
				level.DropItem(Coordinates, disc);
			}
			base.BreakBlock(level, face);
		}

		public override void OnTick(Level level, bool isRandom)
		{
			if (isRandom) { return; }
			LegacyParticle particle = new NoteParticle(level) { Position = new Vector3(Coordinates.X + 0.5f, Coordinates.Y + 1, Coordinates.Z + 0.5f) };
			particle.Spawn();
			if (playing)
			{
				level.ScheduleBlockTick(this, 20);
			}
		}

		public override bool Interact(Level level, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoord)
		{
			if (playing == true)
			{
				level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordNull);
				level.DropItem(blockCoordinates, disc);
				playing = false;
				level.CancelBlockTick(this);
			}
			else
			{
				var itemInHand = player.Inventory.GetItemInHand();
				if (!discIds.Contains(itemInHand.Id)) { return true; }
				disc = itemInHand;
				player.Inventory.SetInventorySlot(player.Inventory.InHandSlot, new ItemAir());
				switch (itemInHand.Id)
				{
					case 500:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.Record13);
						break;
					case 501:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordCat);
						break;
					case 502:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordBlocks);
						break;
					case 503:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordChirp);
						break;
					case 504:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordFar);
						break;
					case 505:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordMall);
						break;
					case 506:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordMellohi);
						break;
					case 507:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordStal);
						break;
					case 508:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordStrad);
						break;
					case 509:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordWard);
						break;
					case 510:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.Record11);
						break;
					case 511:
						level.BroadcastSound(blockCoordinates, LevelSoundEventType.RecordWait);
						break;
					default:
						return true;
				}
				playing = true;
				level.ScheduleBlockTick(this, 20);
			}
				return true;
		}
	}
}