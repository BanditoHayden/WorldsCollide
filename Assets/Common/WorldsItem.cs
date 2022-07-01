using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Items.Accessory;
using WorldsCollide.Items.Materials;
using WorldsCollide.Items.Tools;
using WorldsCollide.Items.Weapons.Magic;
using WorldsCollide.Items.Weapons.Melee;

namespace WorldsCollide.Assets.Common
{
    public class WorldsItem : GlobalItem
    {
       
        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            if (extractType == 0)
            {
                if (Main.rand.NextBool(5))
                 resultType = ModContent.ItemType<Plastic>();
                resultStack = 1;
            }
        }
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            var newsource = player.GetSource_OpenItem(arg);
            float spawnChance = Main.rand.NextFloat();
            if (context == "present")
            {
                if (spawnChance < 0.033f)
                {
                    player.QuickSpawnItem(newsource, ModContent.ItemType<ChristmasClaymore>());
                }

            }
            if(context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag)
            {
                if (spawnChance < 0.33f)
                {
                    player.QuickSpawnItem(newsource, ModContent.ItemType<PrimeSaw>());
                }
            }
            if (context == "bossBag" && arg == ItemID.EaterOfWorldsBossBag)
            {
                if (spawnChance < 0.33f)
                {
                    player.QuickSpawnItem(newsource, ModContent.ItemType<GreatDemonSword>());
                }
            }
            if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag)
            {
                if (spawnChance < 0.33f)
                {
                    player.QuickSpawnItem(newsource, ModContent.ItemType<EyeSpy>());
                }
            }
            if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
            {
                if (spawnChance < 0.22f)
                {
                    player.QuickSpawnItem(newsource, ItemID.SlimeStaff);
                }
            }
            if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
            {
                player.QuickSpawnItem(newsource, ModContent.ItemType<Diplopia>());
            }
        }
    }



        
}
