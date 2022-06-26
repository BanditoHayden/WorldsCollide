using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Magic;
using Terraria.Audio;

namespace WorldsCollide.Items.Weapons.Magic
{
	public class CrackTheSky : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.staff[Item.type] = true;

		}
		public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Red;
			Item.width = 30;
			Item.height = 30;
			Item.scale = 1.0f;
			// Use Properties
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			// Weapon Properties
			Item.damage = 25;
			Item.knockBack = 5.6f;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			// Projectile Properties
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 15f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			// Loop these functions 3 times.
			for (int i = 0; i < 3; i++)
			{
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}

				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
			}

			return false;
		}


	}
}
