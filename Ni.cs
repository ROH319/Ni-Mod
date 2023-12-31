﻿using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Achievements;
using Ni.Items.Weapons;
using Ni.Projectiles.Minions;
using log4net.Util;
using Ni.Dusts;
using System;
using static System.Formats.Asn1.AsnWriter;
using MonoMod.Cil;
using System.Reflection;
using Ni.Buffs;
using Ni.Items.AccEffects;
using Ni.Core;
using Ni.Helpers;

namespace Ni
{
    public class TemporaryFix : PreJITFilter
    {
        public override bool ShouldJIT(MemberInfo member)
        {
            return false;
        }
    }
    public class Ni : Mod
    {
        public static Ni instance;
        public static bool CanUsualUpdate;
        public static int pumpkinTimer;
        
        public static Dictionary<int, string> eliteStr = new Dictionary<int, string>();

        public Ni()
        {
            instance = this;
            PreJITFilter = new TemporaryFix();
        }

        public override void Load()
        {
            
            AssetHelper.LoadAsset();
            #region 加字典
            eliteStr.Add(1, "分裂");
            eliteStr.Add(2, "再生");
            eliteStr.Add(3, "嘲讽");
            eliteStr.Add(4, "致盲");
            eliteStr.Add(5, "冰霜");
            eliteStr.Add(6, "？？？");
            eliteStr.Add(7, "伪装");
            eliteStr.Add(8, "饥饿");
            eliteStr.Add(9, "复仇");
            eliteStr.Add(10, "狱火");
            eliteStr.Add(11, "柔韧");
            eliteStr.Add(12, "鼓舞");
            eliteStr.Add(13, "治疗");
            eliteStr.Add(14, "传播");
            eliteStr.Add(15, "吸血");
            eliteStr.Add(16, "易位");
            eliteStr.Add(17, "映像");
            #endregion
            Terraria.On_Player.FreeUpPetsAndMinions += Player_FreeUpPetsAndMinions;
            Terraria.On_Main.DrawDust += Main_DrawDust;
            Terraria.On_Player.AddBuff += Player_AddBuff;
            #region STOP
            //On.Terraria.Cloud.Update += Cloud_Update;
            //On.Terraria.Main.UpdateWeather += Main_UpdateWeather;
            //On.Terraria.Main.UpdateTime_SpawnTownNPCs += Main_UpdateTime_SpawnTownNPCs;
            //On.Terraria.Main.DoUpdate_AnimateWaterfalls += Main_DoUpdate_AnimateWaterfalls;
            #endregion
            pumpkinTimer = 0;
            instance = this;
            base.Load();
        }

        private void Player_AddBuff(Terraria.On_Player.orig_AddBuff orig, Player self, int type, int timeToAdd, bool quiet, bool foodHack)
        {
            self.TryGetModPlayer<NiPlayer>(out NiPlayer niplayer);
            if(niplayer.Artifact && Main.debuff[type] && !Main.buffNoTimeDisplay[type])
            {
                niplayer.Artifact = false;
                self.AddBuff(ModContent.BuffType<ClockworkCooldown>(), 20 * 60);
                return;
            }
            orig(self, type, timeToAdd, quiet, foodHack);
        }

        #region STOP
        /*
        private void Main_DoUpdate_AnimateWaterfalls(On.Terraria.Main.orig_DoUpdate_AnimateWaterfalls orig, Main self)
        {
            if (!CanUsualUpdate)
            {
                return;
            }
            orig(self);
        }

        private void Main_UpdateTime_SpawnTownNPCs(On.Terraria.Main.orig_UpdateTime_SpawnTownNPCs orig)
        {
            if (!CanUsualUpdate)
            {
                return;
            }
            orig();
        }

        private void Main_UpdateWeather(On.Terraria.Main.orig_UpdateWeather orig, Main self, GameTime gameTime)
        {
            if (!CanUsualUpdate)
            {
                return;
            }
            orig(self, gameTime);
        }

        private void Cloud_Update(On.Terraria.Cloud.orig_Update orig, Cloud self)
        {
            if (!CanUsualUpdate)
            {
                return;
            }
            orig(self);
        }
        */
        #endregion

        private void Main_DrawDust(Terraria.On_Main.orig_DrawDust orig, Main self)
        {
            //Main.pixelShader.CurrentTechnique.Passes[0].Apply();
            orig(self); 
            SpriteBatch sb = Main.spriteBatch;
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X - 1000, (int)Main.screenPosition.Y - 1050, Main.screenWidth + 2000, Main.screenHeight + 2100);
            sb.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.Transform);
            for (int i = 0; i < Main.maxDustToDraw; i++)
            {
                Dust dust = Main.dust[i];
                if (new Rectangle((int)dust.position.X, (int)dust.position.Y, 4, 4).Intersects(rectangle))
                {
                    if (!dust.active || dust.type != ModContent.DustType<ElecCyan>())
                        continue;
                    float num5 = Math.Abs(dust.velocity.X) + Math.Abs(dust.velocity.Y);
                    num5 *= 0.3f;
                    num5 *= 10f;
                    if (num5 > 10f)
                        num5 = 10f;

                    for (int n = 0; n < num5; n++)
                    {
                        Vector2 velocity5 = dust.velocity;
                        Vector2 value5 = dust.position - velocity5 * n;
                        float scale6 = dust.scale * (1f - n / 10f);
                        Color color5 = Lighting.GetColor((int)(dust.position.X + 4.0) / 16, (int)(dust.position.Y + 4.0) / 16);
                        color5 = dust.GetAlpha(color5);
                        sb.Draw(AssetHelper.ElecCyan_Dust, value5 - Main.screenPosition, dust.frame, color5, dust.rotation, new Vector2(4f, 4f), scale6, SpriteEffects.None, 0f);
                    }
                    Color newColor = Lighting.GetColor((int)(dust.position.X + 4.0) / 16, (int)(dust.position.Y + 4.0) / 16);
                    newColor = dust.GetAlpha(newColor);
                    sb.Draw(AssetHelper.ElecCyan_Dust, dust.position - Main.screenPosition, dust.frame, newColor, dust.GetVisualRotation(), new Vector2(4f, 4f), dust.scale, SpriteEffects.None, 0f);
                }
            }
            sb.End();
        }


        private void Player_FreeUpPetsAndMinions(Terraria.On_Player.orig_FreeUpPetsAndMinions orig, Player self, Item sItem)
        {
            /*
            if (ProjectileID.Sets.MinionSacrificable[sItem.shoot])
            {
                if (sItem.type == ModContent.ItemType<Electrodynamics>() && NiSystem.UsedMinionSlots >= self.maxMinions)
                {
                    List<int> orb1 = new();
                    //int[] orbs = new int[14] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }; //用orbs数组来存电球proj在main.projectile数组中的索引
                    bool reorder = false;
                    //int count = 0;
                    for (int i = 0; i < 1000; i++)
                    {
                        if (Main.projectile[i].active && Main.projectile[i].type == ModContent.ProjectileType<LightningOrb>())
                        {
                            if (Main.projectile[i].ai[0] == 1)
                            {
                                Main.projectile[i].Kill();
                                reorder = true;
                            }
                            else
                            {
                                //orbs[count++] = i;
                                orb1.Add(i);
                            }
                        }
                    }
                    if (reorder)
                    {
                        orb1.RemoveAll(x => x == 0);
                        for(int i = 0; i < orb1.Count; i++)
                        {
                            if (orb1[i] != -1)
                            {
                                Main.projectile[orb1[i]].ai[0] -= 1;
                            }
                        }
                    }
                    return;
                }
            }
            */
            //orig(self,sItem);
        }

        public override void Unload()
        {
            //On.Terraria.Main.DrawInventory -= PrefixDrawInventory;
            //On.Terraria.Player.Hurt -= Player_Hurt;
            Terraria.On_Player.FreeUpPetsAndMinions -= Player_FreeUpPetsAndMinions;
            Terraria.On_Main.DrawDust -= Main_DrawDust;
            Terraria.On_Player.AddBuff -= Player_AddBuff;
            //On.Terraria.Cloud.Update -= Cloud_Update;
            //On.Terraria.Main.UpdateWeather -= Main_UpdateWeather;
            //On.Terraria.Main.UpdateTime_SpawnTownNPCs -= Main_UpdateTime_SpawnTownNPCs;
            //On.Terraria.Main.DoUpdate_AnimateWaterfalls -= Main_DoUpdate_AnimateWaterfalls;
            AssetHelper.UnloadAsset();
            instance = null;
            base.Unload();
        }
    }
}