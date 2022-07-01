
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;
using static Terraria.ModLoader.ModContent;

namespace WorldsCollide.Items.Weapons.Melee
{
	public class EyeOfTheStorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.width = 24;
            Item.height = 24;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 2.5f;
			Item.damage = 12;
			Item.rare = ItemRarityID.White;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 1);
			Item.shoot = ProjectileType<StormProj>();
		}
		public override void AddRecipes()
		{
			CreateRecipe()
		   .AddIngredient(ItemID.Cloud, 13)
			.AddIngredient(ItemID.RainCloud, 13)
		   .AddTile(TileID.Anvils)
		   .Register();
		}



	}
}