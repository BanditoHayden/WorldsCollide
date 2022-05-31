using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
namespace WorldsCollide.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class DrFaust : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dr.Faust");
            Tooltip.SetDefault("");
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
           
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.vanity = true;
        }
    

    }
}
