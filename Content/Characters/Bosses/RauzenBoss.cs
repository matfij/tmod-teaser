using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Teaser.Content.Characters.Bosses
{
	[AutoloadBossHead]
	public class RauzenBoss : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rauzen");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[20];
			NPCID.Sets.MPAllowedEnemies[Type] = true;
			NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned,
					BuffID.Confused,
					BuffID.BrokenArmor,
				}
			});
		}

		public override void SetDefaults()
		{
			NPC.width = 212;
			NPC.height = 182;
			NPC.damage = 20;
			NPC.defense = 10;
			NPC.lifeMax = 4200;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 10f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.value = Item.buyPrice(gold: 10);
			NPC.SpawnWithHigherTime(30);
			NPC.boss = true;
			NPC.npcSlots = 10;
			if (!Main.dedServ) {
				Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/RauzenBoss");
			}
		}

		public override void FindFrame(int frameHeight)
		{
			frameHeight = 182;
			NPC.frameCounter++;
			if (NPC.frameCounter >= 20) {
				NPC.frameCounter = 0;
			}
			NPC.frame.Y = (int)NPC.frameCounter * frameHeight;
		}

		public override void AI()
		{
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active) {
				NPC.TargetClosest();
			}
			Player player = Main.player[NPC.target];
			if (player.dead) {
				NPC.velocity.Y -= 0.04f;
				NPC.EncourageDespawn(10);
				return;
			}
			SeekPlayer(player);
		}

		private void SeekPlayer(Player player)
		{
			float baseSpeed = 100;
			Vector2 toDestination = player.position - NPC.Center;
			Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
			float speed = Math.Min(baseSpeed, toDestination.Length());
			NPC.velocity = toDestinationNormalized * speed / 60;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.Wood, 1, 400, 600));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Weapons.IceSpikeSword>(), 5, 1, 1));
		}

	}
}