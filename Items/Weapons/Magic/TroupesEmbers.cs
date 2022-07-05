using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Magic;
using Terraria.Audio;
using System;

namespace WorldsCollide.Items.Weapons.Magic
{
	public class TroupesEmbers : ModItem
	{
		int fired;
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Troupe's Embers");

		}
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.NPCHit21;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TroupeBat2>();
			Item.shootSpeed = 15f;

			Item.mana = 10;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Vector2 playerPos = player.RotatedRelativePoint(player.MountedCenter, true);
			float speed = Item.shootSpeed;
			float xPos = (float)Main.mouseX + Main.screenPosition.X - playerPos.X;
			float yPos = (float)Main.mouseY + Main.screenPosition.Y - playerPos.Y;
			float f = Main.rand.NextFloat() * ((float)Math.PI * 2f);
			float sourceVariationLow = 20f;
			float sourceVariationHigh = 60f;
			Vector2 source1 = playerPos + f.ToRotationVector2() * MathHelper.Lerp(sourceVariationLow, sourceVariationHigh, Main.rand.NextFloat());
			for (int i = 0; i < 50; i++)
			{
				source1 = playerPos + f.ToRotationVector2() * MathHelper.Lerp(sourceVariationLow, sourceVariationHigh, Main.rand.NextFloat());
				if (Collision.CanHit(playerPos, 0, 0, source1 + (source1 - playerPos).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
				{
					break;
				}
				f = Main.rand.NextFloat() * ((float)Math.PI * 2f);
			}
			Vector2 newvelocity = Main.MouseWorld - source1;
			Vector2 velocityVariation = new Vector2(xPos, yPos).SafeNormalize(Vector2.UnitY) * speed;
			newvelocity = newvelocity.SafeNormalize(velocityVariation) * speed;
			newvelocity = Vector2.Lerp(newvelocity, velocityVariation, 0.25f);
			int Proj = Projectile.NewProjectile(source, source1,newvelocity, type, damage, knockback, player.whoAmI, 0f, Main.rand.Next(3));
			Projectile obj = Main.projectile[Proj];
			for (int i = 0; i < 100; i++)
			{
				Vector2 outerdustring = Main.rand.NextVector2CircularEdge(0.2f, 0.2f);
				Dust Dusty = Dust.NewDustPerfect(obj.position, DustID.Firework_Red, outerdustring * 5, Scale: 0.5f);			
				Dusty.noGravity = true;
			}
			return false;
		}
    }
}
