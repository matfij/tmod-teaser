using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Teaser.Content.Items.Weapons
{
	public class Dziao : ModItem
	{
		public override void SetDefaults() {
			Item.width = 62;
			Item.height = 32;
			Item.scale = .3f;
			Item.rare = ItemRarityID.Green;

			Item.useTime = 4;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 50;
			Item.knockBack = 5f;
			Item.noMelee = true;

			// Item.shoot = ModContent.ProjectileType<Projectiles.IceShotProjectile>();
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 40f;
			Item.useAmmo = AmmoID.None;
        }

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}
