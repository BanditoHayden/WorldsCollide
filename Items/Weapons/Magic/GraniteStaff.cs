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
    public class GraniteStaff : ModItem
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
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.noMelee = true;
            // Weapon Properties
            Item.damage = 25;
            Item.knockBack = 5.6f;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<GraniteBall>();
            Item.shootSpeed = 15f;
        }
    }
}
