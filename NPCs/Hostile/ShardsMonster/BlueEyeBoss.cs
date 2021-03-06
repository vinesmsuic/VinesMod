﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
    [AutoloadBossHead]
    public class BlueEyeBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/BlueEyeBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/BlueEyeBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Eye");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.EyeofCthulhu);
            npc.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            npc.lifeMax = 3500; 
            npc.damage = 5; 
            npc.defense = 5; 
            //npc.width = 120;
            //npc.height = 120;
            npc.scale = 1.2f;
            npc.value = 10000;
            npc.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            npc.boss = true; // Is a boss
            npc.lavaImmune = true;
            npc.noGravity = true; 
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.2f;
            music = MusicID.Boss1;
            bossBag = mod.ItemType("BlueEyeBossBag"); // Needed for the NPC to drop loot bag.
            aiType = 2; // Different Movement at Night
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (int)(npc.defense + numPlayers);
        }
        
        public override void AI() //Daytime movement
        {
            Target();
            DespawnHandler();

            Move(new Vector2(Main.rand.Next(-200, 200), -Main.rand.Next(100, 250))); // Calls the Move Method
            //Attacking
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.
            if(npc.ai[1] <= 0f)
            {
                Shoot();
            }
        }

        private void Target()
        {
            player = Main.player[npc.target]; // This will get the player target.
        }

        private void Move(Vector2 offset)
        {
            speed = 15f; // Sets the max speed of the npc.
            Vector2 moveTo = player.Center + offset; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude; 
            }
            float turnResistance = 25f; // The larget the number the slower the npc will turn.
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }

        private void DespawnHandler()// Handles if the NPC should despawn.
        {
            if(!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if(!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if(npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private void Shoot()
        {
            int type = mod.ProjectileType("BlueEyeBossProjectile");
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= 5f / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage, 2f);
            npc.ai[1] = (float) Main.rand.Next(75 , 100);
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;

            RotateNPCToTarget();
        }

        private void RotateNPCToTarget()
        {
            if (player == null) return;
            Vector2 direction = npc.Center - player.Center;
            float rotation = (float)Math.Atan2(direction.Y, direction.X);
            npc.rotation = rotation + ((float)Math.PI * 0.5f);
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
            npc.DropBossBags();
            }
            else{
                    if (Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueEyeBall"), 1);
                    }

                    if (Main.rand.Next(5) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CodeO"), 1);
                    }

                    if (Main.rand.Next(10) == 0)
                {
                Item.NewItem(npc.getRect(), ItemID.BlackLens, 1);
                }

                    if (Main.rand.Next(30) == 0)
                {
                Item.NewItem(npc.getRect(), ItemID.Binoculars, 1);
                }

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardBlue"), Main.rand.Next(5, 10));
                Item.NewItem(npc.getRect(), ItemID.Lens, Main.rand.Next(3, 5));
                Item.NewItem(npc.getRect(), ItemID.GoldBar, Main.rand.Next(3, 5));
                Item.NewItem(npc.getRect(), ItemID.SilverOre, Main.rand.Next(10, 20));
                Item.NewItem(npc.getRect(), ItemID.IronBar, Main.rand.Next(3, 7));
                Item.NewItem(npc.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));
                Item.NewItem(npc.getRect(), ItemID.CrimsonSeeds, Main.rand.Next(1, 2));
                Item.NewItem(npc.getRect(), ItemID.CorruptSeeds, Main.rand.Next(1, 2));
                Item.NewItem(npc.getRect(), ItemID.DemoniteOre, Main.rand.Next(20, 40));
                Item.NewItem(npc.getRect(), ItemID.CrimtaneOre, Main.rand.Next(20, 40));
                Item.NewItem(npc.getRect(), ItemID.Sapphire, Main.rand.Next(1, 2));   
            }

            // For settings if the boss has been downed
            VinesWorld.downedBlueEyeBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
