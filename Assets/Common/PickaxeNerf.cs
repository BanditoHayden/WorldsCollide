using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;



namespace WorldsCollide.Assets.Common
{
    public class PickaxeNerf : GlobalItem
    {
        public static class Sets
        {
            public static bool[] Valid
            {
                get;
                private set;
            }

            public static void Initialize()
            {
                Valid = new bool[ItemLoader.ItemCount];
                Valid[ItemID.GoldPickaxe] = true;
                Valid[ItemID.CnadyCanePickaxe] = true;
                Valid[ItemID.FossilPickaxe] = true;
                Valid[ItemID.BonePickaxe] = true;
                Valid[ItemID.PlatinumPickaxe] = true;
                Valid[ItemID.ReaverShark] = true;

            }

        }
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return Sets.Valid[item.type];
        }
        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); 
            item.pick = 50; 
        }
    }
}
