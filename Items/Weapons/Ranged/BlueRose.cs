using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Ammo;
using WorldsCollide.Items.Materials;
using Terraria.DataStructures;

namespace WorldsCollide.Items.Weapons.Ranged
{
    public class BlueRose : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            
           Tooltip.SetDefault("[Is that all you got?]");

        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.width = 30;
            Item.height = 30;
            // Use Properties
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 7;
            Item.knockBack = 3.6f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 10.5f;
            Item.useAmmo = AmmoID.Bullet;
            Item.scale = 1.3f;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2;
            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(1));
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
                position.Y += -5f;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
    }
}
