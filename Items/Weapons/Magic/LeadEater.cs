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
    public class LeadEater : ModItem
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Red;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 21;
            Item.knockBack = 2;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 14;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<CorruptionBall>();
            
            Item.shootSpeed = 10f;
        }
    }
}
