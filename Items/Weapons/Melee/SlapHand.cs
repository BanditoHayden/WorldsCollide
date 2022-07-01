using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
	public class SlapHand : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			SacrificeTotal = 1;

			
			ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.useAnimation = 45;
			Item.useTime = 45; 
			Item.knockBack = 6.75f; 
			Item.width = 30; 
			Item.height = 10;
			Item.damage = 18; 
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<SlapHandProj>(); 
			Item.shootSpeed = 12f; 
			Item.UseSound = SoundID.Item1; 
			Item.rare = ItemRarityID.Orange; 
			Item.value = Item.sellPrice(gold: 2, silver: 50);
			Item.DamageType = DamageClass.Melee; 
			Item.channel = true;
			Item.noMelee = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

	}
}
