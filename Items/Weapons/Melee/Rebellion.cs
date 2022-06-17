
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
    public class Rebellion : ModItem
    {
        int currentAttack = 1;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("[c/8b0000:This Party's Getting Crazy! Let's Rock!]");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Green;

            Item.width = 60;
            Item.height = 60;
           Item.scale = 1.3f;
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
            Item.noMelee = true;
            // Projectile Properties

        }


    }
}
