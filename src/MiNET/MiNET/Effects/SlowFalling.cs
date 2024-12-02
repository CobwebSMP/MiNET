using System.Drawing;

namespace MiNET.Effects
{
	public class SlowFalling : Effect
	{
		public SlowFalling() : base(EffectType.SlowFalling)
		{
			ParticleColor = Color.FromArgb(0xf3, 0xcf, 0xb9);
		}
	}
}