using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class ClaretDisk : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
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
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item18;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 24;
            Item.knockBack = 3.6f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<CrimsonRing>();
            Item.shootSpeed = 12f;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }


    }
}
