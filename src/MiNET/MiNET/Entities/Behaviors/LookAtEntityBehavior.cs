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

using System;
using System.Linq;
using System.Numerics;
using MiNET.Particles;

namespace MiNET.Entities.Behaviors
{
	public class LookAtEntityBehavior : BehaviorBase
	{
		private readonly Mob _entity;
		private readonly double _lookDistance;
		private int _duration = 0;
		private Entity _otherEntity;
		private readonly int _chance;

		public LookAtEntityBehavior(Mob entity, double lookDistance = 4.0, int chance = 20)
		{
			this._entity = entity;
			_lookDistance = lookDistance;
			_chance = chance;
		}

		public override bool ShouldStart()
		{
			if (_entity.Level.Random.Next(_chance) != 0)
			{
				return false;
			}

			var entity = _entity.Level.Entities
				.OrderBy(p => Vector3.Distance(_entity.KnownPosition, p.Value.KnownPosition))
				.FirstOrDefault(p =>
					p.Value != _entity
					&& _entity.DistanceTo(p.Value) < _lookDistance).Value;

			_otherEntity = entity;
			_duration = 200 + _entity.Level.Random.Next(200);

			if (entity == null)
			{
				return false;
			}

				return true;
		}

		public override bool CanContinue()
		{
			return _duration-- > 0;
		}

		public override void OnTick(Entity[] entities)
		{
			var dx = _otherEntity.KnownPosition.X - _entity.KnownPosition.X;
			var dz = _otherEntity.KnownPosition.Z - _entity.KnownPosition.Z;

			double tanOutput = 90 - RadianToDegree(Math.Atan(dx / (dz)));
			double thetaOffset = 270d;
			if (dz < 0)
			{
				thetaOffset = 90;
			}
			var yaw = thetaOffset + tanOutput;

			double bDiff = Math.Sqrt((dx * dx) + (dz * dz));

			double lookDir = 0;
			if (_entity.IsBaby)
			{
				lookDir = _otherEntity.IsBaby ? _otherEntity.Height * 2 : _otherEntity.Height;
			}
			else
			{
				lookDir = _otherEntity.IsBaby ? _otherEntity.Height / 2 : _otherEntity.Height;
			}

			var dy = (_entity.KnownPosition.Y + _entity.Height) - (_otherEntity.KnownPosition.Y + lookDir);
			double pitch = RadianToDegree(Math.Atan(dy / (bDiff)));

			_entity.EntityDirection = (float) yaw;
			_entity.KnownPosition.Yaw = (float) yaw;
			_entity.KnownPosition.HeadYaw = (float) yaw;
			_entity.KnownPosition.Pitch = (float) pitch;
			_entity.BroadcastMove(true);
		}

		public override void OnEnd()
		{
			if (_otherEntity.IsBaby && !_entity.IsBaby && _entity.Level.Random.Next(4) != 0)
			{
				LegacyParticle particle = new HeartParticle(_entity.Level);
				particle.Position = _entity.KnownPosition + new Vector3(0, (float) (_entity.Height + 0.85d), 0);
				particle.Spawn();
			}
			_otherEntity = null;
			_entity.KnownPosition.Pitch = 0;
			_entity.BroadcastMove(true);
		}

		private double RadianToDegree(double angle)
		{
			return angle * (180.0 / Math.PI);
		}
	}
}