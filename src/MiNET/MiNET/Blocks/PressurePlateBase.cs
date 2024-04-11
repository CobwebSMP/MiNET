using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Blocks
{
	public abstract class PressurePlateBase : Block
	{
		public virtual int RedstoneSignal { get; set; }
		private BlockCoordinates[] cord = [];

		protected PressurePlateBase(int id) : base(id)
		{
			IsTransparent = true;
			IsSolid = false;
			BlastResistance = 2.5f;
			Hardness = 0.5f;
		}

		public override void BlockAdded(Level level)
		{
			if (level.RedstoneEnabled) { level.ScheduleBlockTick(this, 20); }
		}

		public override void BreakBlock(Level level, BlockFace face, bool silent = false)
		{
			level.CancelBlockTick(this);
			base.BreakBlock(level, face);
		}

		public override void OnTick(Level level, bool isRandom)
		{
			if (isRandom) { return; }
			var entities = level.GetSpawnedPlayers();
			cord = [Coordinates.BlockNorth(), Coordinates.BlockSouth(), Coordinates.BlockEast(), Coordinates.BlockWest(), Coordinates.BlockDown()];
			foreach (var entity in entities)
			{
				if ((int) (entity.KnownPosition.X < 0 ? entity.KnownPosition.X - 1 : entity.KnownPosition.X) == Coordinates.X && (int) entity.KnownPosition.Y == Coordinates.Y && (int) (entity.KnownPosition.Z < 0 ? entity.KnownPosition.Z - 1 : entity.KnownPosition.Z) == Coordinates.Z)
				{
					if (RedstoneSignal == 0)
					{
						RedstoneSignal = 15;
						level.SetBlock(this);
						level.BroadcastSound(Coordinates, LevelSoundEventType.PressurePlateOn);
						foreach (BlockCoordinates bCord in cord)
						{
							RedstoneController.signal(level, bCord, true);
						}
					}
				}
				else if (RedstoneSignal > 0)
				{
					RedstoneSignal = 0;
					level.SetBlock(this);
					level.BroadcastSound(Coordinates, LevelSoundEventType.PressurePlateOff);
					foreach (BlockCoordinates bCord in cord)
					{
						RedstoneController.signal(level, bCord, false);
					}
				}
			}
			level.ScheduleBlockTick(this, 20);
		}

	}
}
