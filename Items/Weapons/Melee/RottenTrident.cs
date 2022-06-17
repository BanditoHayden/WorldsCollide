
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class RottenTrident : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Eater of Spoons");
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
            Item.autoReuse = false;
            Item.useTime = 60;
            Item.useAnimation = 60;
            // Weapon Properties
            Item.damage = 16;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<RottenTridentProjectile>();
            Item.shootSpeed = 3.7f;
        }
   
    }
}
