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
    public class Vendetta : ModItem
    {
       
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Master;

            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            Item.noUseGraphic = false;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 40;
            Item.useTime = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.scale = 1.4f;
            // Weapon Properties
            Item.damage = 10;
            Item.knockBack = 8.6f;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 14;
            // Projectile Properties
          
        }


        

    }
}
