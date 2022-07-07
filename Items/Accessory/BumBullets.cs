using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using WorldsCollide.Assets.Common;

namespace WorldsCollide.Items.Accessory
{
    public class BumBullets : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bumblecore\nShooting occasionally spawns additional bees.");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<WorldsPlayer>().Bumble = true;
        }
        
    }
}