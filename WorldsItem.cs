using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Items.Materials;
using WorldsCollide.Items.Tools;
using WorldsCollide.Items.Weapons.Magic;
using WorldsCollide.Items.Weapons.Melee;

namespace WorldsCollide
{
    public class WorldsItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Keybrand)
            {
                // Need to add a font override for this item name, and only this item name
                item.SetNameOverride("Keyblade");
            }
        }
       
        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
           
            if (extractType == 0)
            {
                if (Main.rand.NextBool(5))
                 resultType = ModContent.ItemType<Plastic>();
                resultStack = 1;
            }
          
           /* if (extractType == ItemID.IronBar)
            {
                if (Main.rand.NextBool(2))
                {
                    resultType = ModContent.ItemType<Plastic>();
                    resultStack += Main.rand.Next(0, 3);
                }
            }*/




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



        }
    }



        
}
