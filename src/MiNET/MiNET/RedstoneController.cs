using MiNET.Blocks;
using MiNET.LevelDB;
using MiNET.Sounds;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET
{
	public static class RedstoneController
	{
		public static void doFenceGate(Level level, BlockCoordinates coordinates, bool openBit)
		{
			var block = level.GetBlock(coordinates);
			if (block is FenceGateBlocks)
			{
				var stateBlock = block as FenceGateBlocks;
				if (boolStateIsSame(openBit, stateBlock.OpenBit))
				{
					return;
				}
				stateBlock.Direction = block.GetDirection();
				stateBlock.Coordinates = new BlockCoordinates(coordinates);
				stateBlock.OpenBit = openBit;
				level.SetBlock(stateBlock);
				var sound = new Sound((short) LevelEventType.SoundOpenDoor, coordinates);
				sound.Spawn(level);
			}
		}

		public static void doTrapDoors(Level level, BlockCoordinates coordinates, bool openBit)
		{
			var block = level.GetBlock(coordinates);
			if (block is TrapdoorBase)
			{
				var stateBlock = block as TrapdoorBase;
				if (boolStateIsSame(openBit, stateBlock.OpenBit))
				{
					return;
				}
				stateBlock.Direction = block.GetDirection();
				stateBlock.Coordinates = new BlockCoordinates(coordinates);
				stateBlock.OpenBit = openBit;
				level.SetBlock(stateBlock);
				var sound = new Sound((short) LevelEventType.SoundOpenDoor, coordinates);
				sound.Spawn(level);
			}
		}

		public static void doDoors (Level level, BlockCoordinates coordinates, bool openBit)
		{
			var block = level.GetBlock(coordinates);
			if (block is DoorBase)
			{
				var stateBlock = block as DoorBase;
				if (stateBlock.UpperBlockBit)
				{
					block = level.GetBlock(coordinates.X, coordinates.Y - 1, coordinates.Z);
					stateBlock = block as DoorBase;
					if (boolStateIsSame(openBit, stateBlock.OpenBit)){ return; }
					stateBlock.Coordinates = new BlockCoordinates(coordinates.X, coordinates.Y - 1, coordinates.Z);
				}
				else
				{
					if (boolStateIsSame(openBit, stateBlock.OpenBit)){ return; }
					stateBlock.Coordinates = new BlockCoordinates(coordinates);
				}
				stateBlock.OpenBit = openBit;
				level.SetBlock(stateBlock);
				var sound = new Sound((short) LevelEventType.SoundOpenDoor, coordinates);
				sound.Spawn(level);
			}
		}

		public static void doRedstoneLamp(Level level, BlockCoordinates coordinates, bool On)
		{
			var block = level.GetBlock(coordinates);
			if (On)
			{
				if (block is RedstoneLamp) {
					if (blockTypeIsSame(block, new LitRedstoneLamp())) { return; }
					level.SetBlock(new LitRedstoneLamp { Coordinates = new BlockCoordinates(coordinates) });
				}
			}
			else
			{
				if (block is LitRedstoneLamp) {
					if (blockTypeIsSame(block, new LitRedstoneLamp())) { return; }
					level.SetBlock(new RedstoneLamp { Coordinates = new BlockCoordinates(coordinates) });
				}
			}
		}

		public static void signal(Level level, BlockCoordinates coordinates, bool On)
		{
			doRedstoneLamp(level, coordinates, On);
			doDoors(level, coordinates, On);
			doRedstoneWire(level, coordinates);
			doTrapDoors(level, coordinates, On);
			doFenceGate(level, coordinates, On);
		}

		public static void doRedstoneWire(Level level, BlockCoordinates coordinates)
		{
			var block = level.GetBlock(coordinates);
			if (block is RedstoneWire)
			{
				if (!level.BlockWithTicks.TryGetValue(coordinates, out long value))
				{
					level.ScheduleBlockTick(level.GetBlock(coordinates), 10);
				}
			}
		}

		private static bool boolStateIsSame(bool input, bool output)
		{
			if (input == output)
			{
				return true;
			}
			return false;
		}

		private static bool blockTypeIsSame(Block input, Block output)
		{
			if (input == output)
			{
				return true;
			}
			return false;
		}
	}
}
