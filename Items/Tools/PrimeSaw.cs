using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Tools
{
    public class PrimeSaw : ModItem
    {
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Purple;
            Item.width = 94;
            Item.height = 18;
            //Item.scale = 1.3f;
            Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 25;
            Item.useTime = 7;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 38;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<PrimeSawHeld>();
            Item.shootSpeed = 40f;
            Item.channel = true;
            Item.axe = 20;
            Item.noMelee = true;
        }
      


    }
}
