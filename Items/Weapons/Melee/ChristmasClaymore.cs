using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Melee;
namespace WorldsCollide.Items.Weapons.Melee
{
    public class ChristmasClaymore : ModItem
    {
        int currentAttack = 1;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Timber!!");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Green;

            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 60;
            Item.useTime = 60;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 20;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<ChristmasClaymoreHeld>();
            Item.shootSpeed = 4f;

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, dir);
            return false;
        }










    }
}
