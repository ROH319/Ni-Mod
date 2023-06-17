using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;
using Terraria.GameContent;
using Ni.NiGlobalProj;
using Ni.Buffs;
using Terraria.DataStructures;
using Terraria.Audio;
using System.Collections.Generic;
using Ni.NiUtils;
using System.Numerics;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Ni.NiModPlayer;
using Ni.NiGlobalNPC;
using TemplateMod2.Utils;

namespace Ni.Projectiles
{
    public class FlameLogicProj : BaseRotateProj
    {
        public float scale = 0f;
        public int radius = 50;
        public int FlameLife;
        public override string Texture => AssetLoader.TransparentImg;
        public override void SetDefaults()
        {
            QuickSD(1, 1, 0, DamageClass.Default, 0f, true, false, -1, 0, -1, 1f, 10 * 60, false, false, false, true);
            Projectile.penetrate = -1;
            base.SetDefaults();
        }
        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(AssetLoader.FlameBarrier_Evoke, Projectile.Center);
            FlameLife = (int)ai0;
            base.OnSpawn(source);
        }
        public override void AI()
        {
            #region CheckActive
            if (!player.GetModPlayer<NiPlayer>().FlameBarrier)
            {
                Projectile.Kill();
            }
            #endregion
            //ai0++;
            Projectile.timeLeft += 1;
            for(int i = 0; i < 6; i++)
            {
                var pos = Projectile.Center + new Vector2(radius * scale, 0).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(0f, 360f)));
                var d = Dust.NewDustPerfect(pos, MyDustId.Fire, (pos - player.Center).NormalizeV() * Main.rand.NextFloat(1, 5), Scale: 1.1f);
                d.noGravity = true;
            }

            if (Projectile.timeLeft < 11)
            {
                scale -= 0.08f;
            }
            else if (scale < 1f)
            {
                scale += 0.05f;
            }
            
            Projectile.Center = player.Center;
            foreach (Projectile p in Main.projectile)
            {
                if (p.active)
                {
                    NiGProj niGProj = p.GetGlobalProjectile<NiGProj>();
                    if (Vector2.Distance(p.Center, player.Center) < radius * scale && !niGProj.Barried && p.hostile && p.damage > 0 && FlameLife > 0)
                    {
                        //Main.CalculateDamagePlayersTake(p.damage * 6, player.statDefense);
                        
                        //int truedamage = (int)Main.CalculateDamagePlayersTake(NiUtil.ProjectileDamageMul(p.damage), player.statDefense);
                        //bool a = false;
                        ////player.GetModPlayer<NiPlayer>().ModifyHitByProjectile(p, ref truedamage, ref a);
                        //FlameLife -= truedamage;
                        //CombatText.NewText(p.Hitbox, Color.Blue, truedamage);
                        ////Main.NewText($"truedamage: {truedamage} muldamage: {NiUtil.ProjectileDamageMul(p.damage)} defense: {player.statDefense}");
                        //if(p.GetGlobalProjectile<NiGProj>().entitySource is EntitySource_Parent parent && parent.Entity is NPC npc && npc.active && !npc.friendly && !npc.immortal)
                        //{
                        //    npc.StrikeNPC()
                        //    npc.StrikeNPCNoInteraction(truedamage, 0, 0);
                        //}
                        //niGProj.Barried = true;
                        //p.Kill();
                        
                        SoundEngine.PlaySound(AssetLoader.BlockAttack, p.Center);
                    }
                }
            }
            foreach(NPC npc in Main.npc)
            {
                if(npc.active && npc.damage > 0 && !npc.friendly && npc.lifeMax == 1 && Vector2.Distance(npc.Center,player.Center) < radius * scale && FlameLife > 0)
                {
                    //if(npc.GetGlobalNPC<NiGNPC>().entitySource is EntitySource_Parent parent && parent.Entity is NPC iparent && iparent.active && !iparent.friendly && !iparent.immortal)
                    //{
                    //    iparent.StrikeNPCNoInteraction(npc.damage, 0, 0);
                    //}
                    //FlameLife -= npc.damage;
                    //npc.life = 0;
                    //npc.checkDead();
                }
            }
            if(FlameLife <= 0)
            {
                Projectile.Kill();
            }
            //base.AI();
        }
        Vector2[] veclaser = new Vector2[600];
        public override void PostDraw(Color lightColor)
        {
            Texture2D colorTex = AssetLoader.Heatmap;
            Texture2D shapeTex = AssetLoader.Laser1;
            Texture2D maskTex = AssetLoader.TrailLaser;
            sb.End();
            sb.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullNone, AssetLoader.MyColor, Main.GameViewMatrix.ZoomMatrix);
            if (player != null && player.active && !player.dead)
            {
                /*
                float num = 1f;
                float num2 = 0.1f;
                float num3 = 0.9f;
                if (!Main.gamePaused)
                {
                    player.flameRingScale += 0.004f;
                }

                if (player.flameRingScale < 1f)
                {
                    num = player.flameRingScale;
                }
                else
                {
                    player.flameRingScale = 0.8f;
                    num = player.flameRingScale;
                }

                if (!Main.gamePaused)
                {
                    player.flameRingRot += 0.05f;
                }

                if (player.flameRingRot > (float)Math.PI * 2f)
                {
                    player.flameRingRot -= (float)Math.PI * 2f;
                }

                if (player.flameRingRot < (float)Math.PI * -2f)
                {
                    player.flameRingRot += (float)Math.PI * 2f;
                }
                */
                List<VertexInfo2> bars = new();
                int width = 40;
                for(int i = 0; i < 100; i++)
                {
                    ai0++;
                    var factor = i / 100f;
                    var normaldir = new Vector2(radius * scale, 0).RotatedBy(MathF.PI * 2 * i / 99);
                    bars.Add(new VertexInfo2(Projectile.Center + normaldir + normaldir.NormalizeV() * width, Color.White, new Vector3(factor * 5f + (float)Main.time * 0.003f, 1, (float)(0.5f + Math.Sin(ai0) / 32))));
                    bars.Add(new VertexInfo2(Projectile.Center + normaldir - normaldir.NormalizeV() * width, Color.White, new Vector3(factor * 5f + (float)Main.time * 0.003f, 0, (float)(0.5f + Math.Sin(ai0) / 32))));
                }

                List<VertexInfo2> triangleList = new();
                if (bars.Count > 2)
                {
                    //for (int i = 0; i < bars.Count - 2; i += 2)
                    //{
                    //    triangleList.Add(bars[i]);
                    //    triangleList.Add(bars[i + 2]);
                    //    triangleList.Add(bars[i + 1]);

                    //    triangleList.Add(bars[i + 1]);
                    //    triangleList.Add(bars[i + 2]);
                    //    triangleList.Add(bars[i + 3]);
                    //}

                    //triangleList.Add(bars[bars.Count - 2]);
                    //triangleList.Add(bars[bars.Count - 1]);
                    //triangleList.Add(bars[0]);

                    //triangleList.Add(bars[bars.Count - 1]);
                    //triangleList.Add(bars[0]);
                    //triangleList.Add(bars[1]);
                    //按照顺序连接三角形
                    triangleList.Add(bars[0]);
                    triangleList.Add(bars[1]);
                    triangleList.Add(bars[2]);
                    for (int i = 0; i < bars.Count - 2; i += 2)
                    {
                        triangleList.Add(bars[i]);
                        triangleList.Add(bars[i + 2]);
                        triangleList.Add(bars[i + 1]);

                        triangleList.Add(bars[i + 1]);
                        triangleList.Add(bars[i + 2]);
                        triangleList.Add(bars[i + 3]);
                    }

                    //count用于返回bars里面的元素数量（即顶点数量）

                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.Transform);
                    RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                    //RasterizerState rasterizerState = new RasterizerState();
                    //rasterizerState.CullMode = CullMode.None;
                    //rasterizerState.FillMode = FillMode.WireFrame;
                    //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                    var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                    var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0)) * Main.Transform;

                    // 把变换和所需信息丢给shader
                    AssetLoader.Trail.Parameters["uTransform"].SetValue(model * projection);
                    AssetLoader.Trail.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);

                    Main.graphics.GraphicsDevice.Textures[0] = colorTex;
                    Main.graphics.GraphicsDevice.Textures[1] = shapeTex;
                    Main.graphics.GraphicsDevice.Textures[2] = maskTex;
                    Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                    Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                    Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                    //Main.graphics.GraphicsDevice.Textures[0] = (Texture)TextureAssets.MagicPixel;
                    //Main.graphics.GraphicsDevice.Textures[1] = (Texture)TextureAssets.MagicPixel;
                    //Main.graphics.GraphicsDevice.Textures[2] = (Texture)TextureAssets.MagicPixel;
                    AssetLoader.Trail.CurrentTechnique.Passes[0].Apply();

                    Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);
                    sb.GraphicsDevice.RasterizerState = originalState;
                    sb.End();
                    sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

                    //sb.VanillaBegin();
                }
                
            }

        }

        public override void Kill(int timeLeft)
        {
            player.AddBuff(ModContent.BuffType<FlameCooldownDebuff>(), (int)(MathHelper.Lerp(20,0, FlameLife / 300)) * 60);
            base.Kill(timeLeft);
        }
    }
}

