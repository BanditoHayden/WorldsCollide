using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace WorldsCollide.Items.Accessory
{
    public class FriendshipBracelet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+5% Summon Damage");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += 0.05f;
        }
    }
}