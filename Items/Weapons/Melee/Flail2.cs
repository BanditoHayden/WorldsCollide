using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class Flail2 : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grasping Chain");
			Tooltip.SetDefault("This is a modded flail with normal behavior.");
			SacrificeTotal = 1;

			// This line will make the damage shown in the tooltip twice the actual Item.damage. This multiplier is used to adjust for the dynamic damage capabilities of the projectile.
			// When thrown directly at enemies, the flail projectile will deal double Item.damage, matching the tooltip, but deals normal damage in other modes.
			ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
		}

		public override void SetDefaults()
		{
			// These default values aside from Item.shoot match the Sunfury values, feel free to tweak them.
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.useAnimation = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.knockBack = 6.75f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
			Item.width = 30; // Hitbox width of the item.
			Item.height = 10; // Hitbox height of the item.
			Item.damage = 32; // The damage of your flail, this is dynamically adjusted in the projectile code.
			Item.crit = 7; // Critical damage chance %
			Item.scale = 1.1f;
			Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
			Item.shoot = ModContent.ProjectileType<Flail>(); // The flail projectile
			Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
			Item.UseSound = SoundID.Item1; // The sound that this item makes when used
			Item.rare = ItemRarityID.Orange; // The color of the name of your item
			Item.value = Item.sellPrice(gold: 2, silver: 50); // Sells for 2 gold 50 silver
			Item.DamageType = DamageClass.Melee; // Deals melee damage
			Item.channel = true;
			Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation
		}

		public override Color? GetAlpha(Color lightColor)
		{
			// Aside from SetDefaults, when making a copy of a vanilla weapon you may have to hunt down other bits of code. This code makes the item draw in full brightness when dropped.
			return Color.White;
		}

	}
}
