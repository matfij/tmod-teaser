using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Teaser.Content.Items.Weapons
{
    public class IceSpikeSword : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Ice Spike");
            Tooltip.SetDefault("Souvenir on the occasion of the event auction.");
        }

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 50;
            Item.useStyle = 1;
            Item.knockBack = 6f;
            Item.value = 100 * 100 * 100;
            Item.rare = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("IceShotProjectile").Type;
			Item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
