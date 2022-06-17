using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace WorldsCollide.Items.Accessory
{
    public class StrengthMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Greatsword damage");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<WorldsPlayer>().StrengthMedallion = true;
        }
    }
}
