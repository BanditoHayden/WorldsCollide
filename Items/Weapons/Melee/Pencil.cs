
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class Pencil : ModItem
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
            Item.damage = 18;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<PencilHeld>();
            Item.shootSpeed = 4f;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ItemID.Wood, 20)
           .AddIngredient(ItemID.LeadBar, 10)
           .AddTile(TileID.WorkBenches)
           .Register();

            CreateRecipe()
           .AddIngredient(ItemID.Wood, 20)
           .AddIngredient(ItemID.IronBar, 10)
           .AddTile(TileID.WorkBenches)
           .Register();

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
