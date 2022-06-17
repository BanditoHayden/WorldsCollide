using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class SwordOfArtorias : ModItem
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
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item18;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 19;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties

        }

       
    }

}
