using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;
using WorldsCollide.Projectiles.Ranged;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class Yamato : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle($"{nameof(WorldsCollide)}/Assets/Sounds/Items/Guns/Unsheathe")
            {
                Volume = 0.9f,
                PitchVariance = 0.0f,
                MaxInstances = 3,
            };
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 10;
            Item.knockBack = 3.6f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<YamatoSlash>();
            Item.shootSpeed = 12.7f;
            
        }
     
     
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
    }
}
