using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using WorldsCollide.Items.Weapons.Magic;
using WorldsCollide.Items.Weapons.Melee;

namespace WorldsCollide.Items.Consumables
{
    public class TreasureBag : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right Click To Open"); // References a language key that says "Right Click To Open" in the language of the game
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

		public override void SetDefaults()
		{
			
			Item.width = 12; //The hitbox dimensions are intentionally smaller so that it looks nicer when fished up on a bobber
			Item.height = 12;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Expert;
			Item.value = Item.sellPrice(0, 2);
		}
		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var entitySource = player.GetSource_OpenItem(Type);

			int guaranteedType = Main.rand.Next(new int[] {
				ModContent.ItemType<GhostlySkull>(), // Guranteed Expert item

			});
			if (Main.expertMode)
			{
				player.QuickSpawnItem(entitySource, guaranteedType);
			}
			if (Main.rand.NextBool(6))
			{
				player.QuickSpawnItem(entitySource, ModContent.ItemType<Curser>());
			}
			if (Main.rand.NextBool(6))
			{
				player.QuickSpawnItem(entitySource, ModContent.ItemType<Flail2>());
			}
		}

	}
}
