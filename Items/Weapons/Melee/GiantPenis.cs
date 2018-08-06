using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class GiantPenis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Penis");
			Tooltip.SetDefault("A Giant Penis made of human bodies.");
		}
		public override void SetDefaults()
		{
			item.damage = 69;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 10f;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			//item.shoot = mod.ProjectileType<Projectiles.???>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GuideVoodooDoll, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GuideVoodooDoll, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
