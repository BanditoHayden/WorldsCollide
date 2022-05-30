
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Ammo
{
    public class BouncyArrow : ModItem
    {
		public override void SetStaticDefaults()
		{
			

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
			Item.shoot = ModContent.ProjectileType<BouncyArrowProj>();
			Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Arrow;
		}
		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(ItemID.WoodenArrow, 50)
				.AddIngredient(ItemID.PinkGel, 1)
			
				.AddTile(TileID.WorkBenches)
				.Register();
			
		}






	}
}
