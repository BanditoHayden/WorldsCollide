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
    public class VendettaHeld2 : ModProjectile
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
            Projectile.scale = 1f;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 3;
            AIType = 52;

        }
    }
}
