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
    public class LaserRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Laser Rifle");
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
            Item.UseSound = SoundID.Item12;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 22;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<LaserProj>();
            Item.shootSpeed = 20.5f;
            Item.useAmmo = ModContent.ItemType<FusionCell>();

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<ReinforcedPlastic>(), 10)
           .AddIngredient(ItemID.AdamantiteBar, 15)
           .AddTile(TileID.MythrilAnvil)
           .Register();
            // Alt
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<ReinforcedPlastic>(), 10)
           .AddIngredient(ItemID.TitaniumBar, 15)
           .AddTile(TileID.MythrilAnvil)
           .Register();
        }

    }
}
