using Terraria;
using Terraria.ModLoader;
using WorldsCollide.Items.Materials;

namespace WorldsCollide
{
    public class WorldsItem : GlobalItem
    {
        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            if(extractType == 0)
            {
                if(Main.rand.NextBool(5))
                resultType = ModContent.ItemType<Plastic>();
                resultStack = 1;
            }
        }
    }
}
