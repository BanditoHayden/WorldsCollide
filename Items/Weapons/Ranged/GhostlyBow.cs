using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Ammo;
using Terraria.Audio;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Weapons.Ranged
{
    public class GhostlyBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Ghostly Bow");
            Tooltip.SetDefault("look another line\nConverts wooden arrows to ghostly arrows");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Blue;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 10;
            Item.knockBack = 3.6f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
       
            Item.shootSpeed = 5.7f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
             if (type == ProjectileID.WoodenArrowFriendly) { // or ProjectileID.WoodenArrowFriendly
                 type = ModContent.ProjectileType<GhostArrow>(); // or ProjectileID.FireArrow;
             }
         }



    }
}
