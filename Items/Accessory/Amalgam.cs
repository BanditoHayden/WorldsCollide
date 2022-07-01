using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace WorldsCollide.Items.Accessory
{
    public class Amalgam : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces damage taken by 17%\nHas a chance to create illusions and dodge an attack\nTemporarily increase critical chance after dodge\nMay confuse nearby enemies after being struck");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Expert;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.brainOfConfusionItem = Item;
            player.endurance += 0.17f;
          }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.WormScarf, 1)
           .AddIngredient(ItemID.BrainOfConfusion, 1)
           .AddTile(TileID.DemonAltar)
           .Register();

           
        }
    }
}