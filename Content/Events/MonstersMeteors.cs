using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Teaser.Content.Events
{
    public class MonstersMeteors : ModSystem
    {
        public static MonstersMeteors Instance;
        internal bool meteorShowerActive = false;
        
        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            Instance = null;
        }

        private int WorldSurfaceHeight = (int)(Main.worldSurface * 0.8f);
        private const int spawnDelay = 240; // 240/60=4s
        private int spawnTimer = spawnDelay;
        private List<int> EnemyTypes = new List<int> { NPCID.Zombie, NPCID.DemonEye, NPCID.Wraith,
                                                        ModContent.NPCType<Characters.Enemies.Scavenger>() };
        private bool rauzenSpawned = false;

        public void SwitchMeteorShower() {
            meteorShowerActive = !meteorShowerActive;
            Main.NewText(meteorShowerActive ? "A meteor shower is incoming!" : "A meteor shower ended!", 175, 75, 255);
            if (!meteorShowerActive)
            {
                rauzenSpawned = false;
            }
        }

        public override void PostUpdatePlayers() {
            if (meteorShowerActive && Main.player[Main.myPlayer].dead)
            {
                SwitchMeteorShower();
            }
        }

        public override void PreUpdateTime()
        {
            if (!rauzenSpawned && spawnTimer == 0) {
                rauzenSpawned = true;
                var (x, y) = GenerateSurfaceNearXY();
                NPC.SpawnBoss(x, y, ModContent.NPCType<Characters.Bosses.RauzenBoss>(), Main.myPlayer);
            }
            if (meteorShowerActive)
            {
                // WorldGen.PlaceTile(x, y, TileID.Meteorite);
                if (spawnTimer <= 0)
                {
                    SpawnRandomEnemy();
                    spawnTimer = spawnDelay;
                }
                else
                {
                    SpawnMeteorHead();
                    spawnTimer--;
                }
            }
        }

        public override void PostUpdateTime() {
            if (rauzenSpawned && NPC.AnyNPCs(ModContent.NPCType<Characters.Bosses.RauzenBoss>()) == false && meteorShowerActive)
            {
                SwitchMeteorShower();
            }
        }

        private void SpawnMeteorHead()
        {
            int x = Main.rand.Next(Main.maxTilesX);
            int y = Main.rand.Next(WorldSurfaceHeight);
            // multiplied by 16 to convert from tile coordinates to pixel coordinates
            NPC.NewNPC(null, x * 16, y * 16, NPCID.MeteorHead);
        }

        private void SpawnRandomEnemy()
        {
            var (x, y) = GenerateSurfaceNearXY();
            int type = EnemyTypes[Main.rand.Next(EnemyTypes.Count)];
            // NPC.SpawnOnPlayer(Main.myPlayer, type);
            NPC.NewNPC(null, x, y, type);
            Main.NewText($"Spawned random enemy at {x}, {y}, type: {type}", 175, 75, 255);
            Main.NewText($"My position at {Main.player[Main.myPlayer].position.X}, {Main.player[Main.myPlayer].position.Y}", 175, 75, 255);
        }

        private (int, int) GenerateSurfaceNearXY()
        {
            int range = 800;
            int playerX = (int)(Main.player[Main.myPlayer].position.X);
            int x = Main.rand.Next(playerX - range, playerX + range);
            int y = (int)(Main.player[Main.myPlayer].position.Y) - Main.rand.Next(range);
            return (x, y);
        }
    }
}
