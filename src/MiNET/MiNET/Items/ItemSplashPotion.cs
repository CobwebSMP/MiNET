using log4net;
using MiNET.Entities.Projectiles;
using MiNET.Utils.Vectors;
using MiNET.Worlds;

namespace MiNET.Items
{
	public class ItemSplashPotion : Item
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ItemSplashPotion));

		public ItemSplashPotion() : base("minecraft:splash_potion", 438)
		{
			MaxStackSize = 64;
		}

		public override void UseItem(Level world, Player player, BlockCoordinates blockCoordinates)
		{
			float force = 1.5f;

			var splashPotion = new SplashPotion(player, world, Metadata);
			splashPotion.KnownPosition = (PlayerLocation) player.KnownPosition.Clone();
			splashPotion.KnownPosition.Y += 1.62f;
			splashPotion.Velocity = splashPotion.KnownPosition.GetDirection().Normalize() * force;
			splashPotion.SpawnEntity();
			world.BroadcastSound(player.KnownPosition, LevelSoundEventType.Throw, "minecraft:player");
			var itemInHand = player.Inventory.GetItemInHand();
			if (itemInHand.Count != 0)
			{
				var newCount = (byte)(itemInHand.Count - 1);
				var slot = player.Inventory.InHandSlot;
				player.Inventory.SetInventorySlot(slot, new ItemSplashPotion() { Count = newCount, Metadata = 21 });
			} else
			{
				itemInHand.Count--;
			}
		}
	}
}
