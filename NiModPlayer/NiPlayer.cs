using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Ni;
using Ni.Items.Accessories;
using Microsoft.Xna.Framework;
using Ni.Projectiles.Minions;
using Terraria.ModLoader.IO;
using Ni.Buffs;
using Terraria.GameInput;
using Ni.Projectiles;
using Ni.GlobalItems;
using Ni.NiGlobalProj;
using Ni.NiPrefix;
using Ni.NiGlobalNPC;

namespace Ni.NiModPlayer
{
    public partial class NiPlayer : ModPlayer
    {
        public List<Projectile> OwnedMinions = new();

        public bool BaseCheckActive;
        public int SnakeCount;
        public bool Magnifier;
        public bool LightningOrb;
        public bool PenNibCanCount;
        public int PenNibCount;
        public bool EmotionChip;
        public bool FlameBarrier;
        public bool Brimstone;
        public bool Envenom;
        public bool WBlade;
        public bool NinjaScroll;
        public bool Artifact;
        public bool Barricade;
        public bool[] UpgradedEffect = new bool[4];
        //public bool critup;

        public override void ModifyItemScale(Item item, ref float scale)
        {
            #region 魔法放大镜效果
            if (Magnifier)
            {
                scale *= 2f;
            }
            #endregion
            base.ModifyItemScale(item, ref scale);
        }
        public override void PostHurt(Player.HurtInfo info)
        {
            #region 情感芯片上buff
            if (EmotionChip)
            {
                Player.AddBuff(ModContent.BuffType<EmotionChipBuff>(), 6 * 60, false);
            }
            #endregion
            base.PostHurt(info);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            #region 钢笔尖计数
            if (Player.HasBuff<PenNibBuff>())
            {
                PenNibCount = 0;
                Player.ClearBuff(ModContent.BuffType<PenNibBuff>());
            }
            if (PenNibCanCount)
            {
                PenNibCount++;
                if (PenNibCount > 8 && !Player.HasBuff<PenNibBuff>())
                {
                    Player.AddBuff(ModContent.BuffType<PenNibBuff>(), 1145141919);
                }
            }
            #endregion
            base.OnHitNPC(target, hit, damageDone);
        }
        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Item, consider using OnHitNPC instead */
        {
            
            #region 涂毒效果
            //if (Envenom)
            //{
            //    target.AddBuff(BuffID.Poisoned, item.damage / 5);
            //}
            #endregion
            base.OnHitNPCWithItem(item, target, hit, damageDone);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Projectile, consider using OnHitNPC instead */
        {
            
            #region 涂毒效果
            if (Envenom)
            {
                target.AddBuff(BuffID.Poisoned, (proj.damage / 10 < 1) ? 1 : proj.damage / 10);
            }
            #endregion
            base.OnHitNPCWithProj(proj, target, hit, damageDone);
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            #region 钢笔尖双倍伤害效果
            if (Player.HasBuff<PenNibBuff>())
            {
                modifiers.FinalDamage *= 2;
            }
            #endregion
            base.ModifyHitNPC(target, ref modifiers);
        }
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            var source = npc.GetGlobalNPC<NiGNPC>().entitySource;
            EntitySource_Parent parent = source is EntitySource_Parent ? source as EntitySource_Parent : null;
            #region 硫磺加伤
            if (Brimstone)
            {
                modifiers.FinalDamage *= 1.1f;
            }
            #endregion
            base.ModifyHitByNPC(npc, ref modifiers);
        }
        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            NiGProj niGProj = proj.GetGlobalProjectile<NiGProj>();
            #region 硫磺加伤
            if (Brimstone)
            {
                modifiers.FinalDamage *= 1.1f;
            }
            #endregion
            //Main.NewText($"proj.damage: {proj.damage} damage: {damage}");
            //--------------proj.damage: 35 普通: 70(两倍) 专家: 140(四倍) 大师: 210(六倍) ------------------
            base.ModifyHitByProjectile(proj, ref modifiers);
        }


        public override void ResetEffects()
        {
            BaseCheckActive = false;
            SnakeCount = 0;
            Magnifier = false;
            LightningOrb = false;
            PenNibCanCount = false;
            EmotionChip = false;
            FlameBarrier = false;
            Brimstone = false;
            Envenom = false;
            WBlade = false;
            NinjaScroll = false;
            Artifact = false;
            Barricade = false;
            //critup = false;
        }

        public override float UseSpeedMultiplier(Item item)
        {
            return Magnifier ? 0.7f : 1f;
        }
        public override bool CanUseItem(Item item)
        {
            NiGItem niGItem = item.GetGlobalItem<NiGItem>();
            return base.CanUseItem(item);
        }
        public override void PreUpdateMovement()
        {

            base.PreUpdateMovement();
        }
        public override void PostUpdate()
        {
            Ni.CanUsualUpdate = false;
            Vector2 tomouse = Main.MouseWorld - Player.Center;
            tomouse.Normalize();
            #region 壁垒
            if (Barricade)
            {
                //Player.statLifeMax2 += (int)(Player.statDefense * (HasUpgradedItem[0] ? 1.5 : 1));
            }
            #endregion
            #region 检查召唤物是否溢出
            if (OwnedMinions.Count > 0)
            {
                OwnedMinions[0].ai[0] += 0;
                OwnedMinions.RemoveAll(x => x == null || !x.active);
                //OwnedMinions.Sort((x,y) => x.whoAmI > y.whoAmI ? 1 : 0);
            }
            if (OwnedMinions.Count > Player.maxMinions)
            {
                int count = OwnedMinions.Count - Player.maxMinions;
                for(int i = 0; i < count; i++)
                {
                    OwnedMinions.RemoveAll(x => x == null || !x.active);
                    var p = OwnedMinions.Find(x => x.ai[0] == 1);
                    if (p != null)
                    {
                        for(int j = 0; j < OwnedMinions.Count; j++)
                        {
                            if (OwnedMinions[j].type == ModContent.ProjectileType<LightningOrb>() && OwnedMinions[j].ai[0] != 1)
                            {
                                OwnedMinions[j].ai[0] -= 1;
                            }
                        }
                        p.Kill();
                    }
                    //if (OwnedMinions[i].type == ModContent.ProjectileType<LightningOrb>() && OwnedMinions[i].ai[0] == 1)
                    //{
                    //    if (OwnedMinions[i].ai[0] == 1)
                    //    {
                    //        for(int j = i + 1; j < OwnedMinions.Count; j++)
                    //        {
                    //            if (OwnedMinions[j].type == ModContent.ProjectileType<LightningOrb>())
                    //            {
                    //                OwnedMinions[j].ai[0]--;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            #endregion
        }
        
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            //if (NiSystem.FlameKey.JustPressed && Player.active && !Player.dead)
            //{
            //    if (!Player.HasBuff(ModContent.BuffType<FlameBarrierBuff>()) && FlameBarrier)
            //    {
            //        bool cardprefix = false;
            //        for(int i = 0; i < 10; i++)
            //        {
            //            if (Player.armor[i].type == ModContent.ItemType<FlameBarrier>() && Player.armor[i].prefix == ModContent.PrefixType<UpgradeCard>())
            //            {
            //                cardprefix = true;
            //            }
            //        }
            //        Player.AddBuff(ModContent.BuffType<FlameBarrierBuff>(), 4 * 60);
            //        Projectile p = Projectile.NewProjectileDirect(Player.GetSource_FromThis(), Player.Center, Vector2.Zero, ModContent.ProjectileType<FlameLogicProj>(), 0, 0f, Player.whoAmI, cardprefix ? 400 : 300);
            //    }
            //}
            base.ProcessTriggers(triggersSet);
        }
    }
}
