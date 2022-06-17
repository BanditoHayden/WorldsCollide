
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Ammo
{
    public class FusionCell : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.width = 14; 
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged; 
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2f;
			Item.value = 100;
			Item.rare = ItemRarityID.Green; 
			Item.shoot = ModContent.ProjectileType<LaserProj>(); 

			Item.ammo = Item.type; 
		}
		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(ModContent.ItemType<Plastic>(), 1)
				.AddIngredient(ItemID.CopperBar, 5)
				.AddTile(TileID.Anvils)
				.Register();
			// Alt
			CreateRecipe(50)
			.AddIngredient(ModContent.ItemType<Plastic>(), 1)
			.AddIngredient(ItemID.TinBar, 5)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
