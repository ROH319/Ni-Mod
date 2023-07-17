using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;
using System.Collections.Generic;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Terraria.GameContent;
using Ni.Core;

namespace Ni.Projectiles
{
    public class WarJavelin_Tele : BaseProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
            QuickSD(1, 1, 0, DamageClass.Default, 0f, true, false, -1, 0, -1, 1, 8);
            Projectile.penetrate = -1;
        }

        Vector2[] veclaser = new Vector2[600];
        Vector2 pretelepos = new Vector2(0, 0);
        Vector2 currpos = new Vector2(0, 0);
        public override void AI()
        {
            pretelepos = new Vector2(ai0, ai1);
            currpos = Collision.SolidTiles(Projectile.position + new Vector2(0, 20), 16, 16) ? Projectile.position + new Vector2(0, -20) : Projectile.position;
            base.AI();
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return NiUtils.CheckAABBvLineColliding(pretelepos, currpos, 40, targetHitbox);
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D colorTex = AssetHelper.Color_Yellow_Orange2;
            Texture2D shapeTex = AssetHelper.Laser1;
            Texture2D maskTex = AssetHelper.TrailShape;
            float size = 1f;
            var rotation = (currpos - pretelepos).ToRotation() +MathHelper.PiOver2;
            //Main.NewText($"{plrpos} {player.Center}");
            if (pretelepos != new Vector2(0, 0))
            {
                int Count = 0;
                List<VertexInfo2> bars = new List<VertexInfo2>();
                for (int m = 0; m < 600; ++m)
                {
                    veclaser[m] = Vector2.Lerp(currpos, pretelepos, m / 600f);
                    //veclaser[m] = pretelepos - new Vector2(0, 2).RotatedBy(rotation) * m;//乘以m让这些点随m的增加而延伸，这样就能模拟一条直线的效果了
                    //Main.NewText($"{veclaser[m]} {currpos} {Projectile.Center} {pretelepos}");
                    ++Count;
                }
                for (int k = 1; k < Count; k++)
                {
                    if (veclaser[k] == Vector2.Zero) break;

                    var normalDir = veclaser[k - 1] - veclaser[k];
                    normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                    float factor = k / (float)Count;
                    var w = MathHelper.Lerp(1f, 0.3f, factor);
                    if (k < 10)
                    {
                        size = k / 10f;
                    }
                    float width = 30 * 1f * size;//激光的宽度

                    bars.Add(new VertexInfo2(veclaser[k] + normalDir * width * 2, Color.White, new Vector3(factor * 1.5f + (float)Main.time * 0.03f, 1, w)));
                    bars.Add(new VertexInfo2(veclaser[k] + normalDir * -width * 2, Color.White, new Vector3(factor * 1.5f + (float)Main.time * 0.03f, 0, w)));
                    //Main.NewText($"{veclaser[k] + normalDir * width}");
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

                    //sb.AdditiveBegin();
                    sb.End();
                    sb.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                    RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                    //RasterizerState rasterizerState = new RasterizerState();
                    //rasterizerState.CullMode = CullMode.None;
                    //rasterizerState.FillMode = FillMode.WireFrame;
                    //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                    //Main.graphics.GraphicsDevice.Textures[0] = maskTex;
                    var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);//正交投影
                    var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));
                    

                    //var shader = AssetHelper.Trail;
                    

                    // 把变换和所需信息丢给shader
                    AssetHelper.Trail.Parameters["uTransform"].SetValue(model * projection);
                    AssetHelper.Trail.Parameters["uTime"].SetValue(-(float)Main.time * 0.1f);

                    Main.graphics.GraphicsDevice.Textures[0] = colorTex;
                    Main.graphics.GraphicsDevice.Textures[1] = shapeTex;
                    Main.graphics.GraphicsDevice.Textures[2] = maskTex;
                    Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                    Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                    Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                    //Main.graphics.GraphicsDevice.Textures[0] = (Texture)TextureAssets.MagicPixel;
                    //Main.graphics.GraphicsDevice.Textures[1] = (Texture)TextureAssets.MagicPixel;
                    //Main.graphics.GraphicsDevice.Textures[2] = (Texture)TextureAssets.MagicPixel;

                    AssetHelper.Trail.CurrentTechnique.Passes[0].Apply();
                    Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);
                    sb.GraphicsDevice.RasterizerState = originalState;
                    sb.End();
                    sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
                    //sb.VanillaBegin();
                }
            }
            //base.PostDraw(lightColor);
        }
    }
}

