using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Teaser.Content.Events;

namespace Teaser.Content.Items.Consumables
{
    public class MeteorsSummon : ModItem
    {
        private int useDelay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteors Scroll");
            Tooltip.SetDefault("Summons a meteor shower!");
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
            Item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool? UseItem(Player player)
        {
            if (useDelay == 0)
            {
                MonstersMeteors.Instance.SwitchMeteorShower();
                useDelay = 60;
            }
            return false;
        }

        public override void HoldItem(Player player)
        {
            if (useDelay > 0)
            {
                useDelay--;
            }
        }
    }
}
