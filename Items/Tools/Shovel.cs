using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Assets.Common;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Tools
{
    public class Shovel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shovel");
            Tooltip.SetDefault("As seen in Grease\nHas a chance to reward gems and ores when mining");
        }
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			
			Item.rare = ItemRarityID.Blue;
			Item.pick = 35;
			Item.damage = 5;
			Item.knockBack = 1;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 16;
			Item.useAnimation = 20;
			Item.DamageType = DamageClass.Melee;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}
        public override void HoldItem(Player player)
        {
			WorldsPlayer modPlayer = player.GetWorldPlayer();
			modPlayer.Pickaxe = true;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Plastic>(), 7)
				.AddTile(TileID.Anvils)
				.Register();
			
		}





	}
}
