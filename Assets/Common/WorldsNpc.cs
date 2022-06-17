using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Items.Materials;
using WorldsCollide.Items.Weapons.Magic;
using WorldsCollide.Items.Weapons.Melee;
using WorldsCollide.Items.Weapons.Summon;

namespace WorldsCollide.Assets.Common
{
    public class WorldsNpc : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Ghost)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GhostlyCloth>(), 8));
            }
            if (npc.type == NPCID.GraniteFlyer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GraniteStaff>(), 16));
            }
            if (npc.type == NPCID.GraniteGolem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OreClub>(), 16));
            }
            if (npc.type == NPCID.EaterofSouls)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RottenTrident>(), 75));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LeadEater>(), 75));
            }
            if (npc.type == NPCID.FaceMonster)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClaretDisk>(), 85));
            }
            if (npc.type == NPCID.Crimera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClaretDisk>(), 85));
            }
            if (npc.type == NPCID.BloodCrawler)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClaretDisk>(), 85));
            }
            if (npc.type == NPCID.Harpy)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AeroScimitar>(),30));
            }
            if (npc.type == NPCID.DemonEye)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeStaff>(), 30));
            }
            if (npc.type == NPCID.DemonEye2)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeStaff>(), 30));
            }
             if (npc.type == NPCID.BlueSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SlimeDust>(), 5));
            }
             if (npc.type == NPCID.SlimedZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SlimeDust>(), 5));
            }
        
        }
    }
}
