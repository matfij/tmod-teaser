using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Teaser.Content.Characters.Bosses;

namespace Teaser.Content.Items.Consumable
{
	public class RauzenSummonItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rauzen Scroll");
			Tooltip.SetDefault("Calls the forest successor");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<RauzenBoss>());
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI != Main.myPlayer) {
				return false;
			}
			SoundEngine.PlaySound(SoundID.DD2_OgreAttack, player.position);
			int type = ModContent.NPCType<RauzenBoss>();
			if (Main.netMode != NetmodeID.MultiplayerClient) {
				NPC.SpawnOnPlayer(player.whoAmI, type);
			}
			else {
				NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 10)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
