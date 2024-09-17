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
using MiNET.Blocks;
using MiNET.Entities.Passive;
using MiNET.Utils.Vectors;

namespace MiNET.Entities.Behaviors
{
	public class FindJobBlockBehaviour : BehaviorBase
	{
		private readonly Villager _entity;
		private Path _currentPath;
		private BlockCoordinates? blockPosition;

		public FindJobBlockBehaviour(Villager entity)
		{
			_entity = entity;
		}

		public override bool ShouldStart()
		{
			if (_entity.Variant != 0) return false;

			blockPosition = FindTargetBlock(_entity, 8, 3);

			if (!blockPosition.HasValue) return false;

			var pathfinder = new Pathfinder();
			_currentPath = pathfinder.FindPath(_entity, blockPosition.Value, blockPosition.Value.DistanceTo((BlockCoordinates) _entity.KnownPosition) + 2);

			return _currentPath.HavePath();
		}

		private BlockCoordinates _lastPosition;
		private int _stallTime = 0;

		public override bool CanContinue()
		{
			var currPos = (BlockCoordinates) _entity.KnownPosition;
			if (currPos == _lastPosition)
			{
				if (_stallTime++ > 200)
					return true;
			}
			else
			{
				_stallTime = 0;
				_lastPosition = currPos;
			}

			return _currentPath.HavePath();
		}

		public override void OnTick(Entity[] entities)
		{
			if (_currentPath.HavePath())
			{
				if (!_currentPath.GetNextTile(_entity, out var next))
				{
					return;
				}

				_entity.Controller.RotateTowards(new Vector3((float) next.X + 0.5f, _entity.KnownPosition.Y, (float) next.Y + 0.5f));
				_entity.EntityDirection = Mob.ClampDegrees(_entity.EntityDirection);
				_entity.KnownPosition.HeadYaw = (float) _entity.EntityDirection;
				_entity.KnownPosition.Yaw = (float) _entity.EntityDirection;
				_entity.Controller.MoveForward(1, entities);

				if (_lastPosition.DistanceTo((BlockCoordinates) blockPosition) < 3)
				{
					var block = _entity.Level.GetBlock(blockPosition);
					if (block is Composter composter && _entity.Variant == 0)
					{
						composter.doInteract(_entity.Level, (BlockCoordinates) blockPosition);
					}

					_entity.Variant = 1;
					_entity.BroadcastSetEntityData();
					_entity.Controller.LookAt(blockPosition);
				}
			}
			else
			{
				return;
			}
		}

		public override void OnEnd()
		{
			_entity.Velocity = Vector3.Zero;
			_entity.KnownPosition.Pitch = 0;
			_currentPath = null;
		}


		protected static BlockCoordinates? FindTargetBlock(Entity entity, int dxz, int dy)
		{
			BlockCoordinates coords = (BlockCoordinates) entity.KnownPosition;
			Block currentBlock = null;
			for (int x = -dxz; x <= dxz; x++)
			{
				for (int y = -dy; y <= dy; y++)
				{
					for (int z = -dxz; z <= dxz; z++)
					{
						var blockCoordinates = new BlockCoordinates(x, y, z) + coords;
						var block = entity.Level.GetBlock(blockCoordinates);

						if (block is Composter composter)
						{
							currentBlock = composter;

							return currentBlock.Coordinates;
						}
					}
				}
			}
			return null;
		}
	}
}