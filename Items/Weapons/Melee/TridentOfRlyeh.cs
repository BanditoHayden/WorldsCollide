
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
    public class TridentOfRlyeh : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trident of R'lyeh");
        }
        public override void SetDefaults()
        {
            // Common Properties
            // Item.rare = ModContent.RarityType<testrarity>();
            Item.rare = 2;
            Item.value = Item.sellPrice(silver: 10);
            Item.width = 40;
            Item.height = 40;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item71;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
            // Weapon Properties
            Item.damage = 16;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<TridentOfRlyehProjectile>();
            Item.shootSpeed = 12.5f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<TridentProjectile>(), damage, knockback, player.whoAmI);
        
            return true;
        }

    }
}
