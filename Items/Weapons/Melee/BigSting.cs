
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
    public class BigSting : ModItem
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Green;

            Item.width = 60;
            Item.height = 60;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 20;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = false;
            // Projectile Properties
            Item.shootSpeed = 10;
            Item.shoot = ProjectileID.GiantBee;
        }
       
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
           // Projectile.NewProjectile(Item.GetSource_OnHit(target), target.Center.X, target.Center.Y + Main.rand.Next(1, 30), 0f, 0f, ProjectileID.Bee, damage, knockBack, player.whoAmI);
        }
    }
}