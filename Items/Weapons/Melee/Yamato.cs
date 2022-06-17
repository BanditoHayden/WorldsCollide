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
            Tooltip.SetDefault("[c/465e95:Now I’m a little Motivated]\n[c/465e95:Has the power to separate man from demon]");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Red;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 60;
            Item.useAnimation = 60;
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
            Item.knockBack = 0f;
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
