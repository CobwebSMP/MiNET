using MiNET.Entities.Projectiles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	public class ItemExperienceBottle : Item
	{
		public ItemExperienceBottle() : base("minecraft:experience_bottle", 384)
		{
			MaxStackSize = 64;
		}

		public override void UseItem(Level world, Player player, BlockCoordinates blockCoordinates)
		{
			float force = 1.5f;

			var experienceBottle = new ExperienceBottle(player, world);
			experienceBottle.KnownPosition = (PlayerLocation) player.KnownPosition.Clone();
			experienceBottle.KnownPosition.Y += 1.62f;
			experienceBottle.Velocity = experienceBottle.KnownPosition.GetDirection().Normalize() * force;
			experienceBottle.SpawnEntity();
			world.BroadcastSound(player.KnownPosition, LevelSoundEventType.Throw, "minecraft:player");
			var itemInHand = player.Inventory.GetItemInHand();
			itemInHand.Count--;
		}
	}
}