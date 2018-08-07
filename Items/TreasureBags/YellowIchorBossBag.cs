using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace VinesMod.Items.TreasureBags
{
    public class YellowIchorBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 9;
            item.expert = false;
            bossBagNPC = mod.NPCType("YellowIchorBoss"); // The NPC this bag drops from
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor(); // This will have a chance to spawn the Dev Armour.
            if(Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 3));
			    player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(3, 5));
            }

            if(Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(ItemID.LifeFruit, 1);
            }

            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.AmberMosquito, 1);
            }
            player.QuickSpawnItem(ItemID.GoldBar, 5);
            player.QuickSpawnItem(ItemID.IronBar, 7);
            player.QuickSpawnItem(mod.ItemType("ShardYellow"), Main.rand.Next(5,10));
            player.QuickSpawnItem(ItemID.Amber, Main.rand.Next(5, 7));
            player.QuickSpawnItem(ItemID.Topaz, Main.rand.Next(3, 5));
            player.QuickSpawnItem(ItemID.LifeCrystal, 1);

            player.QuickSpawnItem(ItemID.GoldOre, Main.rand.Next(40, 60));
            player.QuickSpawnItem(ItemID.PlatinumOre, Main.rand.Next(40, 60));
        }
    }
}