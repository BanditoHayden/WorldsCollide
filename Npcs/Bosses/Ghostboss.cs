using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Hostile;

namespace WorldsCollide.Npcs.Bosses
{
    [AutoloadBossHead]
    public class Ghostboss : ModNPC
    {
        public float BlastSpeed { get; init; } = 18;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
            DisplayName.SetDefault("Hand");
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }
        public override void SetDefaults()
        {
            NPC.width = 36;
            NPC.height = 55;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 200;
            //NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.npcSlots = 15f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
        }
        int timer;
        int choice;
        float Timer
        {
            get => NPC.ai[1];
            set => NPC.ai[1] = value;
        }
        public override void AI()
        {
           
            
        }



















        private void Teleport()
        {
            Player player = Main.player[NPC.target];
            NPC npc = Main.npc[NPC.target];
            NPC.velocity = Vector2.Zero;
            npc.position = player.position + new Vector2(Main.rand.Next(0, 300));
        }
        private void TeleportClose()
        {
            Player player = Main.player[NPC.target];
            NPC npc = Main.npc[NPC.target];
            NPC.velocity = Vector2.Zero;
            npc.position = player.position + new Vector2(0, -100);
        }
        private void makebaby()
        {
            var newsource = NPC.GetSource_FromAI();
            Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 2f);
            const int babies = 4;
            for (int i = 0; i < babies; i++)
            
            {
                NPC.NewNPC(newsource, (int)spawnAt.X, (int)spawnAt.Y, NPCID.Ghost);
            }
        }
        private void chase()
        {
            Player target = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 6;
            NPC.velocity = ToPlayer;
        }
        private void fastchase()
        {
            Player target = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 10;
            NPC.velocity = ToPlayer;
        }
        private void BlastAttack()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            NPC.velocity = Vector2.Zero;
            Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center) * 5, ModContent.ProjectileType<GhostBlast>(), damage, 0f, Main.myPlayer);
        }
        private void BlastBarrage()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            const int NumProjectiles = 4;
            NPC.velocity = Vector2.Zero;
            for (int i = 0; i < NumProjectiles; i++)
            {
                Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center).RotatedByRandom(MathHelper.ToRadians(35)) * 8, ModContent.ProjectileType<GhostBlast>(), damage, 0f, Main.myPlayer);
            }
        }
       
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = -NPC.direction;
            NPC.frameCounter++;

            if (NPC.frameCounter % 6 == 5f) // Ticks per frame
            {
                NPC.frame.Y += frameHeight;
            }
            if (NPC.frame.Y >= frameHeight * 2) // 4 is max # of frames
            {
                NPC.frame.Y = 0; // Reset back to default
            }

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("")
            });
        }

    }
}
    
        








