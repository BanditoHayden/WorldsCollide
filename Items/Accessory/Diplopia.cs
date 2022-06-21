using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using WorldsCollide.Assets.Common;

namespace WorldsCollide.Items.Accessory
{
    public class Diplopia : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your seeing double!\nOre drops are now doubled!");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<WorldsPlayer>().Diplopia = true;
        }
    }
}
