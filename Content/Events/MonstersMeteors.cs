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
        private List<int> EnemyTypes = new List<int> { NPCID.Zombie, NPCID.DemonEye, NPCID.Wraith };

        public void SwitchMeteorShower() {
            meteorShowerActive = !meteorShowerActive;
            Main.NewText(meteorShowerActive ? "A meteor shower is incoming!" : "A meteor shower ended!", 175, 75, 255);
        }

        public override void PostUpdateTime()
        {
            if (meteorShowerActive && Main.player[Main.myPlayer].dead)
            {
                SwitchMeteorShower();
            }
            if (meteorShowerActive)
            {
                // WorldGen.PlaceTile(x, y, TileID.Meteorite);

                // Spawn enemies
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

        private void SpawnMeteorHead()
        {
            var (x, y) = GenerateRandomXY();
            // multiplied by 16 to convert from tile coordinates to pixel coordinates
            NPC.NewNPC(null, x * 16, y * 16, NPCID.MeteorHead);
        }

        private void SpawnRandomEnemy()
        {
            var (x, y) = GenerateRandomXY();
            int type = EnemyTypes[Main.rand.Next(EnemyTypes.Count)];
            NPC.SpawnOnPlayer(Main.myPlayer, type);
            // NPC.NewNPC(null, x * 16, y * 16, type);
        }

        private (int, int) GenerateRandomXY()
        {
            int x = Main.rand.Next(Main.maxTilesX);
            int y = Main.rand.Next(WorldSurfaceHeight);
            return (x, y);
        }
    }
}
