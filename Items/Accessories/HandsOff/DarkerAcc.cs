using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class DarkerAcc : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darker Matter");
			Tooltip.SetDefault("+ 15% crit"+"\nDeal x2 Damage"+"\n...");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeSpeed *= 1.2f;
				player.meleeDamage *= 2f;
				player.thrownDamage *= 2f;
				player.rangedDamage *= 2f;
				player.magicDamage *= 2f;
				player.minionDamage *= 2f;
				player.moveSpeed += 0.3f;
				player.rangedCrit += 5;
				player.meleeCrit += 5;
				player.magicCrit += 5;
				player.thrownCrit += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "LightMatter", 1);
			recipe.AddIngredient(mod, "DarkMatter", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}