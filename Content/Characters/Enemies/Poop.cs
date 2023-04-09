using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;

namespace Teaser.Content.Characters.Enemies
{
	public class Poop : ModNPC
	{
		public override void SetDefaults()
		{
			NPC.width = 35;
			NPC.height = 30;
			NPC.damage = 14;
			NPC.defense = 6;
			NPC.lifeMax = 90;
            NPC.scale = .3f;
			NPC.HitSound = new Terraria.Audio.SoundStyle("Teaser/Assets/Sounds/Poop");
			NPC.DeathSound = new Terraria.Audio.SoundStyle("Teaser/Assets/Sounds/Poop");
			NPC.value = 10f;
			NPC.aiStyle = NPCAIStyleID.Fighter;
			NPC.knockBackResist = 0.5f;
			AIType = NPCID.DesertBeast;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDaySlime.Chance * 0.6f;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frame.Y = 0;
		}
	}
}
