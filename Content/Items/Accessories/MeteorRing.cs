using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Teaser.Content.Items.Accessories
{
    public class MeteorRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Immunity Ring");
            Tooltip.SetDefault("Grants immunity to the fire caused by meteors");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Burning] = true;
        }
    }
}
