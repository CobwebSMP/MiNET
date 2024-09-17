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

using System.Linq;
using System.Numerics;
using AStarNavigator;
using MiNET.Entities.Passive;
using MiNET.Utils.Vectors;

namespace MiNET.Entities.Behaviors
{
	public class BreedingBehavior : BehaviorBase
	{
		private readonly Mob _entity;
		private double _lookDistance;
		private int _duration;

		public BreedingBehavior(Mob entity, double lookDistance = 5.0)
		{
			_entity = entity;
			_lookDistance = lookDistance;
		}

		public override bool ShouldStart()
		{
			if (_entity.IsBaby || !_entity.IsInLove) return false;

			return true;
		}

		private Path _currentPath;

		public override void OnTick(Entity[] entities)
		{
			var target = _entity.Level.Entities
				.OrderBy(p => Vector3.Distance(_entity.KnownPosition, p.Value.KnownPosition))
				.FirstOrDefault(p =>
				p.Value != _entity
				&& p.Value.IsInLove
				&& !p.Value.IsBaby
				&& _entity.DistanceTo(p.Value) < _lookDistance).Value;

			if (target == null)
				return;

			_duration = 1000;

			var distanceToEntity = _entity.DistanceTo(target);

			if (distanceToEntity < 1)
			{
				_entity.Velocity = Vector3.Zero;
				_entity.Controller.LookAt(target);

				//if (_entity.Level.Random.Next(15) == 0)
				if (_entity.IsInLove)
				{
					var newPos = _entity.KnownPosition.Clone() as PlayerLocation;
					var mob = new Wolf(_entity.Level) { IsBaby = true };
					mob.KnownPosition = newPos + new Vector3(0, 0.5f, 0);
					mob.NoAi = true;
					mob.SpawnEntity();

					_entity.IsInLove = false;
					_entity.BroadcastSetEntityData();

					target.IsInLove = false;
					target.BroadcastSetEntityData();
				}
				return;
			}

			if (_currentPath == null || _currentPath.NoPath())
			{
				var pathFinder = new Pathfinder();
				_currentPath = pathFinder.FindPath(_entity, target, _lookDistance);
			}

			if (_currentPath.HavePath())
			{
				if (!_currentPath.GetNextTile(_entity, out Tile next))
					return;

				_entity.Controller.RotateTowards(new Vector3((float) next.X + 0.5f, _entity.KnownPosition.Y, (float) next.Y + 0.5f));

				if (distanceToEntity < 0.5f)
				{
					_entity.Velocity = Vector3.Zero;
					_currentPath = null;
				}
				else
				{
					var m = 2 - distanceToEntity;
					if (m <= 0)
					{
						m = 1;
					}
					else
					{
						m = m / 2.0;
					}
					_entity.Controller.MoveForward(1 * m, entities);
				}
			}
			else
			{
				_entity.Velocity = Vector3.Zero;
				_currentPath = null;
			}

			_entity.Controller.LookAt(target);
		}

		public override void OnEnd()
		{
			_entity.Velocity = Vector3.Zero;
			_entity.KnownPosition.Pitch = 0;
			_currentPath = null;
		}


		public override bool CanContinue()
		{
			return _duration-- > 0;
		}
	}
}