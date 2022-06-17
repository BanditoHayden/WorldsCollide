using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.ID;

namespace WorldsCollide.Projectiles.Melee
{
    public class TridentProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.timeLeft = 60;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.arrow = true;
            Projectile.penetrate = 3;
            AIType = ProjectileID.WoodenArrowFriendly;
        }
       
       
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch);
            }
        }
    }
}
