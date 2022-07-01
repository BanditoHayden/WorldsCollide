using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Accessory
{
    public class ViridianMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+5% Damage\n+5% Movement Speed");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.05f;
        }
       


    }
}
