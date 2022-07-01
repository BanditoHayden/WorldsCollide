using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using WorldsCollide.Assets.Common;

namespace WorldsCollide.Items.Accessory
{
    [AutoloadEquip(EquipType.Face)]
    public class Diplopia : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your seeing double!\nOre drops are now doubled!");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 2));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true; // Makes the item have an animation while in world (not held.). Use in combination with RegisterItemAnimation
           ItemID.Sets.ItemIconPulse[Item.type] = true; // The item pulses while in the player's inventory


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
