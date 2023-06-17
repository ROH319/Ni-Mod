using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Ni.NiUtils;
using Microsoft.Xna.Framework.Graphics;
using rail;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Classification;
using ReLogic.Content;
using Ni.Dusts;
using Terraria.DataStructures;
using Ni.NiPrefix;

namespace Ni
{
    public static class NiUtil
    {
        private static bool onuseitem;
        //public static bool IsVanillaWhipProj(this Projectile projectile) => WhipList.VanillaWhipProjList.Contains(projectile.type);
        public static bool Upgraded(this Item item) => item.prefix == ModContent.PrefixType<UpgradeCard>();
        public static NPC Source2NPC(EntitySource_Parent parent)
        {
            return (NPC)parent.Entity;
        }
        
        public static int ProjectileDamageMul(int damage)
        {
            return damage * (Main.masterMode ? 6 : (Main.expertMode ? 4 : 2));
        }
        public static bool IsBoss(this NPC npc)
        {
            return npc.boss || npc.type is NPCID.TheDestroyer or NPCID.TheDestroyerBody or NPCID.TheDestroyerTail or NPCID.EaterofWorldsHead or NPCID.EaterofWorldsBody or NPCID.EaterofWorldsTail or NPCID.Golem or NPCID.GolemFistLeft or NPCID.GolemFistRight or NPCID.GolemHead;
        }
        public static void Fall(this Projectile projectile, float XMult = 0.99f, float YAdd = 0.15f, float YMax = 20f)
        {
            projectile.velocity.X *= XMult;
            if (projectile.velocity.Y < YMax) projectile.velocity.Y += YAdd;
        }
        public static bool IsVanillaWhipProj(this Projectile projectile) => ProjectileID.Sets.IsAWhip[projectile.type];
        public static Vector2 DirectionToSafe(this Entity entity, Vector2 position)
        {
            Vector2 dir = entity.DirectionTo(position);
            if (dir.HasNaNs()) dir = Vector2.Zero;
            return dir;
        }
        public static Vector2 NormalizeV(this Vector2 vector)
        {
            if (vector.Length() == 0) return Vector2.Zero;
            vector.Normalize();
            return vector;
        }
        public static int XinSign(this Vector2 vector2) => Math.Sign(vector2.X);
        /// <summary>
        /// 返回随机角度的Vector2
        /// </summary>
        /// <param name="length">向量长度</param>
        /// <param name="startFrom"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Vector2 Vector2RandUnit(int length, float startFrom, float end) => new Vector2(length, 0).RotatedBy(Main.rand.NextFloat(startFrom, end));

        public static Texture2D GetTex(string path) => ModContent.Request<Texture2D>(path, AssetRequestMode.ImmediateLoad).Value;

        public static bool CheckAABBvLineColliding(Projectile projectile, Rectangle targetHitbox)
        {
            float point = 0f;
            Vector2 endPoint = projectile.Center + projectile.rotation.ToRotationVector2() * (projectile.width * projectile.scale / 2);
            Vector2 startPoint = projectile.Center - projectile.rotation.ToRotationVector2() * (projectile.width * projectile.scale / 2);

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), startPoint, endPoint, projectile.height * projectile.scale / 2, ref point);
        }
        public static bool CheckAABBvLineColliding2(Projectile projectile,Rectangle targetHitbox)
        {
            float point = 0f;
            Vector2 endPoint = projectile.Center + (projectile.rotation + MathHelper.PiOver2).ToRotationVector2() * (projectile.height * projectile.scale  / 2);
            Vector2 startPoint = projectile.Center - (projectile.rotation + MathHelper.PiOver2).ToRotationVector2() * (projectile.height * projectile.scale / 2);
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), startPoint, endPoint, projectile.width * projectile.scale / 2, ref point);
        }
        public static bool CheckAABBvLineColliding(Vector2 startpos, Vector2 endpos, int width, Rectangle targetHitbox)
        {
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), startpos, endpos, width, ref point);
        }
        public static bool CheckAABB_ByVel(Projectile projectile,Rectangle targetHitbox)
        {
            float point = 0f;
            Vector2 length = projectile.velocity;
            length.Normalize();
            length *= projectile.height * projectile.scale / 2;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center - length, projectile.Center + length, projectile.width * projectile.scale / 2, ref point);
        }

        /// <summary>
        /// 带判断玩家是否在使用物品的转方向
        /// </summary>
        /// <param name="player"></param>
        /// <param name="changeEvenAmiActive">为true时就算玩家在使用物品也会转方向</param>
        public static void ChangeDirEX(this Player player,bool changeEvenAmiActive)
        {
            if (!changeEvenAmiActive)
            {
                if (player.ItemAnimationActive)
                {
                    return;
                }
            }
            player.direction = XinSign(Main.MouseWorld - player.Center);
        }


        public static void MyBegin(this SpriteBatch sb,SpriteSortMode sortMode,BlendState blendState,SamplerState samplerState,Effect effect)
        {
            sb.End();
            sb.Begin(sortMode, blendState, samplerState, DepthStencilState.Default, RasterizerState.CullNone, effect, Main.GameViewMatrix.TransformationMatrix);
        }

        public static void MyBegin(this SpriteBatch sb,SpriteSortMode sortMode,BlendState blendState)
        {
            sb.End();
            sb.Begin(sortMode,blendState);
        }
        /// <summary>
        /// 开始AlphaBlend模式绘制，也就是原版的绘制模式
        /// </summary>
        /// <param name="sb"></param>
        public static void VanillaBegin(this SpriteBatch sb, SpriteSortMode sortMode = SpriteSortMode.Deferred)
        {
            sb.MyBegin(sortMode, BlendState.AlphaBlend, SamplerState.PointWrap, null);
        }

        /// <summary>
        /// 开始Additive模式绘制
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="sortMode">绘制顺序，默认Deferred（刷新缓存的时候一次性的绘制到屏幕上），Immediate模式是只要调用Draw就立刻画</param>
        public static void AdditiveBegin(this SpriteBatch sb,SpriteSortMode sortMode = SpriteSortMode.Immediate)
        {
            sb.MyBegin(sortMode, BlendState.Additive, null, null);
        }

        public static void NonPremultipliedBegin(this SpriteBatch sb, SpriteSortMode sortMode = SpriteSortMode.Immediate)
        {
            sb.MyBegin(sortMode, BlendState.NonPremultiplied, null, null);
        }

        /// <summary>
        /// 这个向量是否朝向二、三象限，true为朝向
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool IsLeftQuadrant(this Vector2 vector2)
        {
            return vector2.ToRotation() > MathHelper.Pi / 2 || vector2.ToRotation() < -MathHelper.Pi / 2;
        }

        /// <summary>
        /// 画一个顶点激光
        /// </summary>
        /// <param name="collitex">碰撞后draw的贴图</param>
        /// <param name="tex">激光贴图</param>
        /// <param name="veclaser">传入的vector2顶点数组</param>
        /// <param name="startpos">起始点</param>
        /// <param name="rotation">旋转</param>
        /// <param name="interval">取点间距</param>
        /// <param name="collitexsize">碰撞贴图大小</param>
        /// <param name="size">激光宽度</param>
        public static void VertexLaserDraw(Texture2D collitex, Texture2D colorTex, Texture2D shapeTex, Texture2D maskTex, Vector2[] veclaser,Vector2 startpos,float rotation,float interval,int collitexsize, float size = 1f)
        {
            int Count = 0;
            Vector2 collipos = new Vector2(0, 0);
            if (collitex != null)//如果有碰撞贴图
            {
                for (int m = 0; m < veclaser.Length; ++m)
                {
                    if (Collision.SolidCollision(startpos - new Vector2(0, interval).RotatedBy(rotation) * m, 1, 1))
                    {
                        collipos = startpos - new Vector2(0, interval).RotatedBy(rotation) * m;
                        //这里可以写碰撞后的一些效果，比如Draw个光效什么的
                        break;
                    }
                    veclaser[m] = startpos - new Vector2(0, interval).RotatedBy(rotation) * m;//乘以m让这些点随m的增加而延伸，这样就能模拟一条直线的效果了
                    ++Count;
                }
            }
            List<VertexInfo2> bars = new List<VertexInfo2>();
            for (int k = 1; k < Count; k++)
            {
                if (veclaser[k] == Vector2.Zero) break;

                var normalDir = veclaser[k - 1] - veclaser[k];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                float factor = k / (float)Count;
                var color = new Color(255, 0, 0);
                var w = MathHelper.Lerp(1f, 0.05f, factor);
                if (k < 10)
                {
                    size = k / 10f;
                }
                float width = 6 * 1f * size;//激光的宽度


                bars.Add(new VertexInfo2(veclaser[k] + normalDir * width - Main.screenPosition, color, new Vector3(factor + (float)Main.time * 0.03f, 1, w)));
                bars.Add(new VertexInfo2(veclaser[k] + normalDir * -width - Main.screenPosition, color, new Vector3(factor + (float)Main.time * 0.03f, 0, w)));
            }
            List<VertexInfo2> triangleList = new List<VertexInfo2>();
            if (bars.Count > 2)
            {
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

                Main.spriteBatch.AdditiveBegin();

                //Main.NewText($"{Main.time}");
                if (collitex != null && collipos != new Vector2(0, 0))//如果有碰撞贴图和碰撞点
                {
                    Main.spriteBatch.Draw(collitex, new Rectangle((int)((collipos - Main.screenPosition).X - collitexsize / 2), (int)((collipos - Main.screenPosition).Y - collitexsize / 2), collitexsize, collitexsize), Color.Red);

                }
                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);//正交投影
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));
                // 把变换和所需信息丢给shader
                AssetLoader.SetColor.Parameters["uTransform"].SetValue(model * projection);
                AssetLoader.SetColor.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = colorTex;
                Main.graphics.GraphicsDevice.Textures[1] = shapeTex;
                Main.graphics.GraphicsDevice.Textures[2] = maskTex;
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                AssetLoader.SetColor.CurrentTechnique.Passes[0].Apply();
                //Utils.DrawLine(Main.spriteBatch, player.Center.ToPoint(), (player.Center + (Main.MouseScreen - player.Center).ToRotation().ToRotationVector2() * 100).ToPoint(), Color.Red);
                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);
                //Main.spriteBatch.Draw(Ni.laser1, new Rectangle(0, 0, 2000, 1), new Rectangle(1, 1, 256, 256), Color.White, (Main.MouseWorld - player.Center).ToRotation(), new Vector2(0, 128),0,0f);

                Main.spriteBatch.VanillaBegin();
                //DrawLine(Main.spriteBatch, Main.graphics.GraphicsDevice, Ni.laser1, PrimitiveType.TriangleList, triangleList);
            }
        }

        /// <summary>
        /// 二阶贝塞尔曲线变换
        /// </summary>
        /// <param name="factor">线性插值</param>
        /// <param name="startpos">起始点</param>
        /// <param name="ctrlpos">控制点</param>
        /// <param name="endpos">终止点</param>
        /// <returns></returns>
        public static Vector2 BezierTrans2(int factor,Vector2 startpos,Vector2 ctrlpos,Vector2 endpos)
        {
            return MathF.Pow(1 - factor, 2) * startpos + 2 * factor * (1 - factor) * ctrlpos + MathF.Pow(factor, 2) * endpos;
        }

        /// <summary>
        /// 三阶贝塞尔曲线变换
        /// </summary>
        /// <param name="factor">线性插值</param>
        /// <param name="startpos">起始点</param>
        /// <param name="ctrlpos1">控制点1</param>
        /// <param name="ctrlpos2">控制点2</param>
        /// <param name="endpos">终止点</param>
        /// <returns></returns>
        public static Vector2 BezierTrans3(int factor,Vector2 startpos,Vector2 ctrlpos1,Vector2 ctrlpos2,Vector2 endpos)
        {
            return startpos * MathF.Pow(1 - factor, 3) + 3 * ctrlpos1 * factor * MathF.Pow(1 - factor, 2) + 3 * ctrlpos2 * MathF.Pow(factor, 2) * (1 - factor) + endpos * MathF.Pow(factor, 3);
        }

        public static void DrawDustTrail()
        {
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
                    float traillength = Math.Abs(dust.velocity.X) + Math.Abs(dust.velocity.Y);
                    traillength *= 0.3f;
                    traillength *= 10f;
                    if (traillength > 10f)
                        traillength = 10f;

                    for (int n = 0; n < traillength; n++)
                    {
                        Vector2 pos = dust.position - dust.velocity * n;
                        float scale = dust.scale * (1f - n / 10f);
                        Color poscolor = Lighting.GetColor((int)(dust.position.X + 4.0) / 16, (int)(dust.position.Y + 4.0) / 16);
                        poscolor = dust.GetAlpha(poscolor);
                        sb.Draw(AssetLoader.ElecCyan_Dust, pos - Main.screenPosition, dust.frame, poscolor, dust.rotation, new Vector2(4f, 4f), scale, SpriteEffects.None, 0f);
                    }
                    Color newColor = Lighting.GetColor((int)(dust.position.X + 4.0) / 16, (int)(dust.position.Y + 4.0) / 16);
                    newColor = dust.GetAlpha(newColor);
                    sb.Draw(AssetLoader.ElecCyan_Dust, dust.position - Main.screenPosition, dust.frame, newColor, dust.GetVisualRotation(), new Vector2(4f, 4f), dust.scale, SpriteEffects.None, 0f);
                }
            }
            sb.End();
            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }
        public static bool TileIsTrueAir(Tile tile)
        {
            return tile.TileType == 0 && tile.WallType == 0 && tile.LiquidAmount == 0;
        }
        public static void ClearTileAndLiquid(int x,int y)
        {
            Tile tile = Main.tile[x, y];
            WorldGen.KillTile(x, y, noItem: true);

            tile.ClearEverything();
        }
    }

}

