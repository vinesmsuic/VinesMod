using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class UltStarForce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate StarForce");
			Tooltip.SetDefault("Increase damage by 300%" + "\n +50 liferegen" + "\n +300 mana" + "\n +4 minions" + "\nIncrease critical strike chance by 75%" + "\nThe power of stars.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = 13;
			item.accessory = true;
			item.lifeRegen = 50;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeSpeed *= 1.5f;
				player.meleeDamage *= 3f;
				player.thrownDamage *= 3f;
				player.rangedDamage *= 3f;
				player.magicDamage *= 3f;
				player.minionDamage *= 3f;
				player.statManaMax2 += 300;
				player.moveSpeed += 0.3f;
				player.maxMinions += 4;
				player.rangedCrit += 25;
				player.meleeCrit += 25;
				player.magicCrit += 25;
				player.thrownCrit += 25;
				player.AddBuff(11, 10);
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(mod.BuffType("FloatingSword"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "TriForce", 1);
			recipe.AddIngredient(mod, "TreeOfSavior", 1);
			recipe.AddIngredient(mod, "OverDriveBlue", 1);
			recipe.AddIngredient(mod, "OverDriveYellow", 1);
			recipe.AddIngredient(mod, "OverDrivePurple", 1);
			recipe.AddIngredient(mod, "OverDriveGreen", 1);
			recipe.AddIngredient(mod, "OverDriveRed", 1);
			recipe.AddIngredient(mod, "OverDriveWhite", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}