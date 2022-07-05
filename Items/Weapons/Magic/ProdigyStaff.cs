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
    public class ProdigyStaff : ModItem
    {
        public override void SetStaticDefaults()
        {

            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Red;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.noMelee = true;
            // Weapon Properties
            Item.damage = 28;
            Item.knockBack = 5.6f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 14;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<ProdigyOrb>();
            Item.shootSpeed = 12f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.HellstoneBar, 16)
           .AddTile(TileID.Anvils)
           .Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

    }
}
