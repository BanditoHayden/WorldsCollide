using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Threading.Tasks;

namespace WorldsCollide.Buffs
{
    public class Empowered : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Empowered");
            Description.SetDefault("Increased damage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

      
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.10f;
        }


    }

}
