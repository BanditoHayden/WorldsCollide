
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
    public class AeroScimitar : ModItem
    {
        int currentAttack = 1;
        public override void SetStaticDefaults()
        {
       
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Green;

            Item.width = 60;
            Item.height = 60;
            Item.scale = 0.9f;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 15;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<Tornado>();
            Item.shootSpeed = 8f;
            // Projectile Properties

        }


    }
}
