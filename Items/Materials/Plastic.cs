using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
namespace WorldsCollide.Items.Materials
{
    public class Plastic : ModItem
    {
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			Tooltip.SetDefault("Handy, reliable plastic");
		}
        public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 24;
			Item.value = 100;
			Item.rare = ItemRarityID.Green;
			Item.maxStack = 999;
		}
	}
}
