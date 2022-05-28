using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace WorldsCollide.Items.Materials
{
    public class GhostlyCloth : ModItem
    {
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			Tooltip.SetDefault("Spooky");
		}
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 24;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
			Item.maxStack = 999;
		}
	}
}
