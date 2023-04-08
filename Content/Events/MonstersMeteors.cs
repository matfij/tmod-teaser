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

        public override void PostUpdateTime()
        {
            if (meteorShowerActive)
            {
                // Spawn meteorites
                for (int i = 0; i < 10; i++)
                {
                    int x = Main.rand.Next(Main.maxTilesX);
                    int y = Main.rand.Next((int)(Main.worldSurface * 0.8f));
                    WorldGen.PlaceTile(x, y, TileID.Meteorite);
                }

                // Spawn enemies
                int enemyCount = Main.rand.Next(3, 6); // Spawn between 3 and 6 enemies
                for (int i = 0; i < enemyCount; i++)
                {
                    int x = Main.rand.Next(Main.maxTilesX);
                    int y = Main.rand.Next((int)(Main.worldSurface * 0.8f));
                    int type = Main.rand.Next(5); // Spawn a random enemy type
                    NPC.NewNPC(null, x * 16, y * 16, type);
                }
            }
        }
    }
}
