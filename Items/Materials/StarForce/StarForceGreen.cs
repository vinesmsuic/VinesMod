using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.StarForce
{
	public class StarForceGreen : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Star");
			Tooltip.SetDefault("Stored the shard power.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 7;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "ShardGreen", 250);
            recipe.AddIngredient(ItemID.LargeEmerald, 1);
			recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
