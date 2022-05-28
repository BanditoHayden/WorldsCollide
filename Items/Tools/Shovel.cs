using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldsCollide.Items.Tools
{
    public class Shovel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shovel");
            Tooltip.SetDefault("Has a chance to reward gems when mining");
        }
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			//Item.value = 12000;
			Item.rare = ItemRarityID.Blue;
			Item.pick = 35;
			Item.damage = 5;
			Item.knockBack = 3;
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






    }
}
