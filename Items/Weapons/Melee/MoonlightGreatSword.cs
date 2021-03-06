using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class MoonlightGreatSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonlight GreatSword");
		}

		public override void SetDefaults()
		{
<<<<<<< HEAD
			item.damage = 37;      
=======
			item.damage = 27;      
>>>>>>> 5cfce4fe86ba513331988f5649d54bd2274c6e1b
			item.melee = true; 
			item.width = 40; 
			item.height = 40;           
			item.useTime = 20;
			item.useAnimation = 30;
			item.useStyle = 1;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
<<<<<<< HEAD
			item.knockBack = 3f;
			item.value = Item.sellPrice(copper: 60);           //The value of the weapon
			item.rare = 3;
=======
			item.knockBack = 10f;
			item.value = Item.sellPrice(copper: 60);           //The value of the weapon
			item.rare = 2;
>>>>>>> 5cfce4fe86ba513331988f5649d54bd2274c6e1b
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.MoonlightProjectile>();
			item.shootSpeed = 15f;
<<<<<<< HEAD
			item.scale = 0.7f;
=======
			item.scale = 2f;
>>>>>>> 5cfce4fe86ba513331988f5649d54bd2274c6e1b
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 15);
			recipe.AddIngredient(ItemID.GoldBar, 12);
			recipe.AddIngredient(mod, "ShardBlue", 5);
			recipe.AddIngredient(mod, "ShardYellow", 5);
<<<<<<< HEAD
			recipe.AddIngredient(mod, "ShardWhite", 15);
=======
			recipe.AddIngredient(mod, "ShardWhite", 5);
>>>>>>> 5cfce4fe86ba513331988f5649d54bd2274c6e1b
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if (Main.rand.Next(5) == 0)
			{
				target.AddBuff(BuffID.Chilled, 60 * 5);
			}
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleBlue"));
			}
		}
	}
}
