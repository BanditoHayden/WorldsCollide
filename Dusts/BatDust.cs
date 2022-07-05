using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace WorldsCollide.Dusts
{
    public class BatDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true; // Makes the dust have no gravity.
            dust.noLight = true;
            
        }
       

    }
}