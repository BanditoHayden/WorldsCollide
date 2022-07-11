
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
    public class GreatShadewoodSword : ModItem
    {
        int currentAttack = 1;
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Green;

            Item.width = 50;
            Item.height = 50;
            Item.scale = 1f;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 17;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties

        }


    }
}
