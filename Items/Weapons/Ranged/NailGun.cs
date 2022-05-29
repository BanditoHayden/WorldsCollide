using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Ammo;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Weapons.Ranged
{
    public class NailGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Nail-Gun");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item108;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 7;
            Item.knockBack = 3.6f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<NailProjectile>();
            Item.shootSpeed = 15.7f;
            Item.useAmmo = ModContent.ItemType<BoxOfNails>();

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
    }
}
