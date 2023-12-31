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
using Ni.Buffs;
using Terraria.GameContent.ItemDropRules;
using Ni.Items.Weapons;
using Ni.Items.Accessories;
using Terraria.DataStructures;

namespace Ni.Core
{
    public class NiGNPC : GlobalNPC
    {
        public IEntitySource entitySource;
        public bool FirstAttacked;
        public int[] Artifact = new int[BuffLoader.BuffCount];
        //public int Artifact;
        public override bool InstancePerEntity => true;
        public override void SetStaticDefaults()
        {
            for (int i = 0; i < Artifact.Length; i++)
            {
                Artifact[i] = -1;
            }
            base.SetStaticDefaults();
        }
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
        }
        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            Player player = Main.player[Main.myPlayer];
            player.TryGetModPlayer<NiPlayer>(out NiPlayer niplayer);
            entitySource = source;
            FirstAttacked = false;
            base.OnSpawn(npc, source);
        }
        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            
            base.ModifyHitByItem(npc, player, item, ref modifiers);
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            Player player = Main.player[projectile.owner];
            NiPlayer niPlayer = player.GetModPlayer<NiPlayer>();
            NiGProj niGProj = projectile.GetGlobalProjectile<NiGProj>();

            #region 电鞭召唤标记伤害
            if (npc.HasBuff<ElectronicWhipDebuff>() && projectile.minion)
            {
                modifiers.FlatBonusDamage += 10;
            }
            #endregion

        }
        public override void PostAI(NPC npc)
        {

            base.PostAI(npc);
        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            base.PostDraw(npc, spriteBatch, screenPos, drawColor);
        }

        public override bool PreAI(NPC npc)
        {
            Main.npc[0].ai[0] += 0;
            //if(npc.type == 517)
            //{
            //    npc.life = npc.lifeMax;
            //}
            //Player player = Main.player[Main.myPlayer];
            //if (player.GetModPlayer<NiPlayer>().NoMercy)
            //{
            //    if (npc.lifeMax != 0
            //            && npc.active
            //            && (float)((float)npc.life / npc.lifeMax) <= (npc.IsBoss() ? 0.05 : 0.15)
            //            && !npc.immortal
            //            && npc.type != NPCID.GolemHead
            //            )
            //    {
            //        if (Vector2.Distance(player.Center, npc.Center) < 1200)
            //        {
            //            CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), Color.DarkRed, npc.IsBoss() ? "处决BOSS！" : "处决！");
            //            npc.life = 0;
            //            npc.checkDead();
            //        }
            //    }
            //}
            return base.PreAI(npc);
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            Player player = Main.player[Main.myPlayer];
            NiPlayer niPlayer = player.GetModPlayer<NiPlayer>();

            //if (npc.HasBuff(BuffID.Poisoned))
            //{
            //    int buffIndex = npc.FindBuffIndex(BuffID.Poisoned);
            //    if (Main.player[Main.myPlayer].GetModPlayer<NiPlayer>().Envenom)
            //    {
            //        npc.lifeRegen += 4;
            //    }
            //}
            if (npc.HasBuff<ElectronicWhipDebuff>())
            {
                if(npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 100;
                if(damage < 10)
                {
                    damage = 10;
                }
            }
            if (niPlayer.SnakeCount > 0)
            {
                npc.lifeRegen *= niPlayer.SnakeCount * 3;
            }
            base.UpdateLifeRegen(npc, ref damage);
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if(npc.type == NPCID.Golem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WarJavelin>()));
            }
            if(npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MagicFlower>()));
            }
            if(npc.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistMask>()));
            }
            if(npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodCup>(), 20));
            }
            //base.ModifyNPCLoot(npc, npcLoot);
        }
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            globalLoot.Add(ItemDropRule.ByCondition(new ATCDropCondition(), ModContent.ItemType<ATC>(),20));
            base.ModifyGlobalLoot(globalLoot);
        }
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Cyborg)
            {
                shop.Add<Seeri>();

                shop.Add<RunicCapacitor>();
                if(shop.TryGetEntry(ModContent.ItemType<RunicCapacitor>(),out NPCShop.Entry entry))
                {
                    entry.AddCondition(Condition.DownedCultist);
                }
                //if (NPC.downedAncientCultist)
                //{
                //    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RunicCapacitor>());
                //    nextSlot++;
                //}
            }
            base.ModifyShop(shop);
        }
    }
}
