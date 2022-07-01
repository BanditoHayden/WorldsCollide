using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Items.Consumables;
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
            DisplayName.SetDefault("Phantom Hand");
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
            NPC.damage = 30;
            NPC.defense = 10;
            NPC.lifeMax = 5000;
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
            timer++;
            choice = 0;
            Player player = Main.player[NPC.target];
            NPC.TargetClosest(true);
            if (timer == 60)
            {
                chase();
                Main.NewText("Chase");
            }
            if (timer == 120)
            {
                BlastAttack();
                Main.NewText("Blast Attack");
            }
            if (timer == 180)
            {
                chase();
                Main.NewText("Chase");
            }
            if (timer == 240)
            {
                choice = Main.rand.Next(7, 9); 
                Main.NewText(choice);

            }
            if (timer == 420)
            {
                chase();
                Main.NewText("Chase");
            }
            // Barrage
            if (timer == 480)
            {
                BlastBarrage();
                Main.NewText("Barrage");

            }
            if (timer == 540)
            {
                choice = Main.rand.Next(1, 4);
                Main.NewText("Choosing");

            }
            
            if (choice == 1)
            {
                makebaby();
                timer = 1000;
                Main.NewText("Choice 1");
            }
            if (choice == 2)
            {
                fastchase();
                timer = 1000;
                Main.NewText("Choice 2");
            }
            if (choice == 3)
            {
                CursedBarrage();
                timer = 1000;
                Main.NewText("Choice 3");
            }
            if (choice == 4)
            {
                DarkBarrage();
                timer = 1000;
                Main.NewText("Choice 4");
            }
            if (choice == 5)
            { 
                ConfusedBarrage();
                timer = 1000;
                Main.NewText("Choice 5");
            }
            if (choice == 7)
            {
                timer = 360;
                CursedBlast();
                Main.NewText("Choice 4");
            }
            if (choice == 8)
            {
                timer = 360;
                DarkBlast();
                Main.NewText("Choice 5");
            }
            if (choice == 9)
            {
                timer = 360;
                SlowBlast();
                Main.NewText("Choice 6");
            }
            if (timer == 1060)
            {
                timer = 0;
            }

            if (!player.active || player.dead)
            {
                //if the player we are currently targeting is dead or not "active"(meaning the player is no longer playing)
                NPC.TargetClosest(false);//try to find a new target
                player = Main.player[NPC.target];//get the new target we just got
                if (!player.active || player.dead)
                {
                    // if the new one is also dead, then we know there is no active player, and can despawn 
                    NPC.active = false;//set ourselves to inactive, this makes it so we don't drop loot and instead disappear
                }
            }
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
            if (Main.expertMode)
            {
                for (int i = 0; i < 5; i++)
                {
                    NPC.NewNPC(newsource, (int)spawnAt.X, (int)spawnAt.Y, +Main.rand.Next(10, 100), NPCID.Ghost);
                }
            }
            if (Main.masterMode)
            {
                for (int i = 0; i < 7; i++)
                {
                    NPC.NewNPC(newsource, (int)spawnAt.X, (int)spawnAt.Y, + Main.rand.Next(10, 100), NPCID.Ghost);
                }
            }
            else
            for (int i = 0; i < 3; i++)
            {
                    NPC.NewNPC(newsource, (int)spawnAt.X + Main.rand.Next(1,200), (int)spawnAt.Y + Main.rand.Next(1,15), NPCID.Ghost);
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
        private void CursedBlast()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            NPC.velocity = Vector2.Zero;
            Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center) * 6, ModContent.ProjectileType<CursedBlast>(), damage, 0f, Main.myPlayer);
        }
        private void DarkBlast()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            NPC.velocity = Vector2.Zero;
            Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center) * 6, ModContent.ProjectileType<DarknessBlast>(), damage, 0f, Main.myPlayer);
        }
        private void SlowBlast()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            NPC.velocity = Vector2.Zero;
            Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center) * 6, ModContent.ProjectileType<ConfusedBlast>(), damage, 0f, Main.myPlayer);
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
       private void CursedBarrage()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            const int NumProjectiles = 4;
            NPC.velocity = Vector2.Zero;
            for (int i = 0; i < NumProjectiles; i++)
            {
                Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center).RotatedByRandom(MathHelper.ToRadians(35)) * 8, ModContent.ProjectileType<CursedBlast>(), damage, 0f, Main.myPlayer);
            }
        }
        private void ConfusedBarrage()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            const int NumProjectiles = 4;
            NPC.velocity = Vector2.Zero;
            for (int i = 0; i < NumProjectiles; i++)
            {
                Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center).RotatedByRandom(MathHelper.ToRadians(35)) * 8, ModContent.ProjectileType<ConfusedBlast>(), damage, 0f, Main.myPlayer);
            }
        }
        private void DarkBarrage()
        {
            Player player = Main.player[NPC.target];
            int damage = NPC.damage;
            var entitySource = NPC.GetSource_FromAI();
            const int NumProjectiles = 4;
            NPC.velocity = Vector2.Zero;
            for (int i = 0; i < NumProjectiles; i++)
            {
                Projectile.NewProjectile(entitySource, NPC.Center, NPC.DirectionTo(player.Center).RotatedByRandom(MathHelper.ToRadians(35)) * 8, ModContent.ProjectileType<DarknessBlast>(), damage, 0f, Main.myPlayer);
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
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<TreasureBag>()));
            if(!Main.expertMode && Main.masterMode)
            {

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
    
        








