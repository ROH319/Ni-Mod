using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Buffs;
using Terraria.DataStructures;
using System.Collections.Specialized;
using Terraria.Audio;
using Ni.Dusts;
using Ni.NiPrefix;
using ReLogic.Content;
using System.Collections.Generic;
using System.Linq;
using Ni.Helpers;
using Ni.Core;

namespace Ni.Projectiles.Minions
{
    public class LightningOrb : BaseMinion
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override int BuffType => ModContent.BuffType<LightningBuff>();

        static int Currentslot;
        int timer;
        float factor;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.projPet[Type] = true;
        }
        public override void SetDefaults()
        {
            QuickMinion(24, 24, 40, 2f, 1f, 1);
            Projectile.maxPenetrate = -1;
            Projectile.penetrate = -1;
        }
        public override void OnSpawn(IEntitySource source)
        {
            //Main.NewText($"Spawn ownproj:{player.ownedProjectileCounts[Type]} UsedSlots:{NiSystem.UsedMinionSlots} {Main.time}");
            //if (player.ownedProjectileCounts[Type] == 0)
            //{
            //    Currentslot = 0;
            //}
            //Currentslot++;
            //Main.NewText($"Spawn Currentslot：{Currentslot} ai0：{ai0} {Main.time}");
            player.GetModPlayer<NiPlayer>().OwnedMinions.RemoveAll(x => !x.active);
            foreach(var p in player.GetModPlayer<NiPlayer>().OwnedMinions)
            {
                if(p.type == Projectile.type && p.whoAmI != Projectile.whoAmI)
                {

                }
            }
        }
        int drawcount;
        public override void PostDraw(Color lightColor)
        {
            //Texture2D passive = AssetHelper.LightningPassive[4 - drawcount];
            //Texture2D orb = ModContent.Request<Texture2D>("Ni/Projectiles/Minions/LightningOrb", AssetRequestMode.ImmediateLoad).Value;
            //bool candraw = false;
            sb.AdditiveBegin();
            sb.Draw(AssetHelper.LightningOrb, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, AssetHelper.LightningOrb.Size() / 2, Projectile.scale / 2, 0, 0);
            Lighting.AddLight(Projectile.Center, TorchID.Yellow);
            if (drawcount > 0 && !Main.gamePaused)
            {
                //闪
                sb.Draw(AssetHelper.OrbFX, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, AssetHelper.OrbFX.Size() / 2, Projectile.scale / 2, 0, 0f);
                //被动
                //sb.Draw(passive, Projectile.Center - Main.screenPosition, null, Color.White, Main.rand.NextFloat()*Projectile.rotation, passive.Size() / 2, 0.5f, 0, 0f);
            }
            sb.VanillaBegin();
        }
        public override void AI()
        {
            var list = player.GetModPlayer<NiPlayer>().OwnedMinions;
            list.RemoveAll(x => !x.active);
            int orbs = list.Count(x => x.type == Projectile.type);
            Projectile.rotation += 0.05f;
            #region CheckActive
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType);

                return;
            }
            if (player.HasBuff(BuffType))
            {
                //Main.NewText("114514");
                  Projectile.timeLeft = 2;
            }
            #endregion
            Vector2 r = new Vector2(80 + 4 * orbs, 0);
            Vector2 rightPos = new Vector2(0,0);
            #region 绘制逻辑
            if (drawcount == 0)
            {
                if (Main.rand.NextBool(45))
                {
                    drawcount = 4;
                }
            }
            if (drawcount > 0)
            {
                drawcount--;
            }
            #endregion
            if (timer == 0)
            {
                factor = 0;
            }
            factor = 0.35f;
            if(timer > 60)
            {
                factor += 0.05f;
            }
            if (timer > 0)//电球移动
            {
                //Main.NewText($"{ai0}");
                switch (orbs)//现存电球数量
                {
                    case 1:
                        {
                            rightPos = player.Center + r.RotatedBy(-MathHelper.PiOver2);
                            break;
                        }
                    case 2:
                        {
                            rightPos = (ai0 == 1) ? player.Center + r.RotatedBy(-MathHelper.PiOver2 + MathHelper.PiOver4) : player.Center + r.RotatedBy(-MathHelper.PiOver2 - MathHelper.PiOver4);
                            break;
                        }
                    default:
                        {
                            if(ai0 == 1)
                            {
                                rightPos = player.Center + r;
                            }
                            if(ai0 == orbs)
                            {
                                rightPos = player.Center + r.RotatedBy(-MathHelper.Pi);
                            }
                            else
                            {
                                rightPos = player.Center + r.RotatedBy(-MathHelper.Pi / (orbs - 1) * (ai0 - 1));
                            }
                            break;
                        }
                }
                if (Vector2.Distance(Projectile.Center, rightPos) > 5)
                {
                    Projectile.Center = Vector2.Lerp(Projectile.Center, rightPos, factor);
                }
                else
                {
                    Projectile.Center = rightPos;
                }
            }
            SearchForTargets(player, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Vector2 totarget = targetCenter - Projectile.Center;
            totarget.Normalize();
            if (timer > 40)
            {
                timer = 1;
                if (foundTarget)
                {
                    SummonLightning(targetCenter,1f);
                }
            }
            timer++;
        }
        
        public bool CheckActive()
        {
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType);
                return false;
            }
            if (player.HasBuff(BuffType))
            {
                Projectile.timeLeft = 114514;
            }
            return true;
        }
        public void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            NPC target = null;
            // 索敌范围
            distanceFromTarget = 1000f;
            targetCenter = player.Center;
            foundTarget = false;

            // 如果你的召唤武器可以锁定敌人, 那这是必须的
            if (owner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[owner.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, player.Center);

                // 设置一个合理的范围, 这样它不会隔着几个屏幕的距离追人
                if (between < 1200f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                    //target = npc;
                }
            }

            if (!foundTarget)
            {
                foreach (NPC npc in Main.npc)
                {
                    // 如果npc活着且敌对
                    if (!npc.CanBeChasedBy() || !npc.active || npc.friendly || npc.immortal) continue;
                    // 计算与玩家的距离，可以改成与弹幕的距离
                    float currentDistance = Vector2.Distance(npc.Center, player.Center);
                    // 如果npc距离比当前最大距离小
                    if (currentDistance < distanceFromTarget)
                    {
                        // 就把最大距离设置为npc和玩家的距离
                        // 并且暂时选取这个npc为距离最近npc
                        distanceFromTarget = currentDistance;
                        targetCenter = npc.Center;
                        foundTarget = true;
                        target = npc;
                    }
                }
            }

            // 将 friendly 设为 true 使召唤物能够造成接触伤害
            // 闲置时则将 friendly 设为 false 以防它伤害到傀儡之类的东西
            // 因为这取决于它有没有目标, 所以就在这设置
            // 如果你的召唤物不造成接触伤害而是发射弹幕, 那就不需要这个了
            //Projectile.friendly = foundTarget;
        }
        public void SummonLightning(Vector2 targetCenter, float damageScale)
        {
            Projectile lightning = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), targetCenter + new Vector2(0, -1600), Vector2.Zero, ModContent.ProjectileType<LightningProj>(), (int)(Projectile.damage * damageScale), Projectile.knockBack, player.whoAmI, targetCenter.X, targetCenter.Y);
            //lightning.rotation = (targetCenter - Projectile.Center).ToRotation() - MathHelper.PiOver2;
            lightning.localAI[0] = Projectile.whoAmI;
            for (int i = 0; i < 20; i++)
            {
                Dust d = Dust.NewDustPerfect(targetCenter, ModContent.DustType<ElecCyan>(), null, 0, default, 0.7f);
                d.velocity = NiUtils.Vector2RandUnit(Main.rand.Next(10), 0, MathHelper.TwoPi);
                d.noGravity = true;
                d.noLight = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            bool upgraded = Projectile.GetGlobalProjectile<NiGProj>().entitySource is EntitySource_ItemUse_WithAmmo source && source.Item.prefix == ModContent.PrefixType<UpgradeCard>();
            foreach (NPC npc in Main.npc)
            {
                if (Vector2.Distance(npc.Center, player.Center) < 1000f && npc.active && !npc.friendly && !npc.immortal && npc.CanBeChasedBy(Projectile))
                {
                    SummonLightning(npc.Center, upgraded ? 1f : 0.5f);
                }
            }
            //Currentslot--;
            //Main.NewText($"Kill Currentslot {Currentslot} {Main.time}");
            SoundEngine.PlaySound(AssetHelper.LightningOrb_Evoke, Projectile.Center);
        }
    }
}

