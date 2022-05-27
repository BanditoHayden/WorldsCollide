using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace WorldsCollide.Items.Materials
{
	public class ReinforcedPlastic : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			Tooltip.SetDefault("Perfected");
		}
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 24;
			Item.value = 100;
			Item.rare = ItemRarityID.Lime;
			Item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Plastic>(), 1)
				.AddIngredient(ItemID.TitaniumBar, 3)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			// Alt
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Plastic>(), 1)
			.AddIngredient(ItemID.AdamantiteBar, 3)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}
