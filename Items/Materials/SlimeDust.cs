using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace WorldsCollide.Items.Materials
{
	public class SlimeDust : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		//	Tooltip.SetDefault("Spooky");
		}
		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 36;
			Item.value = 200; // All of these need to be changed ahhhhhhh 
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 999;
		}
	}
}
