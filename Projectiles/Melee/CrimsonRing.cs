using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using WorldsCollide.Dusts;
using System;

namespace WorldsCollide.Projectiles.Melee
{
    public class CrimsonRing : ModProjectile
    {
        public override void SetStaticDefaults()
        {


        }
        public override void SetDefaults()
        {
            Projectile.ignoreWater = false;
            Projectile.width = 40;
            Projectile.penetrate = -1;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.scale = 0.8f;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 3;
            AIType = 52;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Bone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);

            }
        }

    }
}
