namespace MiNET.Blocks
{
	public partial class Deny : Block
	{
		public Deny() : base(211)
		{
			Hardness = 60000;
			BlastResistance = 18000000;
		}
	}
}