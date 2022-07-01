using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Magic;
using Terraria.Audio;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Weapons.Magic
{
    public class GhostlyWand : ModItem
    {
        public override void SetStaticDefaults()
        {

        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = 2;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 12;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<GhostBall>();
            Item.shootSpeed = 8f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<GhostlyCloth>(), 3)
           .AddIngredient(ItemID.Wood, 12)
           .AddTile(TileID.WorkBenches)
           .Register();
        }
    }
}
