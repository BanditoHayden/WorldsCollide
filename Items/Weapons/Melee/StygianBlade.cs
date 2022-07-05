using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

using Terraria;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Melee;
using WorldsCollide.Dusts;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class StygianBlade : ModItem
    {
        int currentAttack = 1;
        int fired;


        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("[c/ff8c00:The Blade of The Underworld]");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Master;

            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            // Weapon Properties
            Item.noMelee = true;
            Item.damage = 100;
            Item.knockBack = 8.6f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<StygianBladeHeld>();
            Item.shootSpeed = 4f;

        }
      
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            fired++;
            int dir = currentAttack;
            currentAttack = -currentAttack;
            if (fired < 3)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, dir);
            }
            if (fired == 3)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<StygianBladeHeld2>(), damage, knockback, player.whoAmI); 
            }            
            if (fired == 4)
            {
                player.velocity += player.DirectionTo(Main.MouseWorld) * 10;
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, dir);
                fired = 0;
            }
            return false;
        }
        
    }
}
