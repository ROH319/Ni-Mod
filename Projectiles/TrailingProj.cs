using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ni.Projectiles 
{
    public class TrailingProj : BaseRotateProj {
        public override string Texture => AssetLoader.TransparentImg;
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("神秘弹幕");
        }
        public override void SetDefaults() {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.1f;
            Projectile.timeLeft = 100000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;

            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;//记录30帧的位置信息
        }

        public override void AI() {
            if (Main.myPlayer == Projectile.owner) {
                var projectileToMouse = Vector2.Normalize(Main.MouseWorld - Projectile.Center) * 16;
                Projectile.velocity = projectileToMouse;

                for (int i = Projectile.oldPos.Length - 1; i > 0; --i)
                    Projectile.oldRot[i] = Projectile.oldRot[i - 1];
                Projectile.oldRot[0] = Projectile.rotation;
            }

            var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.Fire, -Projectile.velocity.X, -Projectile.velocity.Y, 100, Color.White, 1.5f);
            dust.position = Projectile.Center;
            dust.velocity *= 2;
            dust.noGravity = true;
        }


        public override void PostDraw(Color lightColor) {
            Texture2D MainColor = AssetLoader.Heatmap;
            Texture2D MainShape = AssetLoader.Laser1;
            Texture2D MaskColor = AssetLoader.TrailShape;
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < Projectile.oldPos.Length; ++i) {
                if (Projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = 30;//径向偏移量
                var normalDir = Projectile.oldPos[i - 1] - Projectile.oldPos[i];//从下一个点到这个点的向量
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));//求垂直方向的向量（法向量）

                var factor = i / (float)Projectile.oldPos.Length;//对于oldpos长度的插值（总插值）
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);//用根号会平滑一些？

                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2) {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(Projectile.velocity) * 30, Color.White,
                    new Vector3(0, 0.5f, 1));
                triangleList.Add(bars[1]);
                triangleList.Add(vertex);
                for (int i = 0; i < bars.Count - 2; i += 2) {
                    triangleList.Add(bars[i]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 1]);

                    triangleList.Add(bars[i + 1]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 3]);
                }


                sb.End();
                sb.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                // 干掉注释掉就可以只显示三角形栅格
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);//正交投影
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));
		        // 把变换和所需信息丢给shader
                AssetLoader.Trail.Parameters["uTransform"].SetValue(model * projection);
                AssetLoader.Trail.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MainColor;//颜色
                Main.graphics.GraphicsDevice.Textures[1] = MainShape;//形状
                Main.graphics.GraphicsDevice.Textures[2] = MaskColor;//蒙版
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = (Texture)TextureAssets.MagicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = (Texture)TextureAssets.MagicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = (Texture)TextureAssets.MagicPixel;

                AssetLoader.Trail.CurrentTechnique.Passes[0].Apply();

                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                sb.End();
                sb.Begin();
            }
        }


        // 自定义顶点数据结构，注意这个结构体里面的顺序需要和shader里面的数据相同
        private struct CustomVertexInfo : IVertexType {
            private static VertexDeclaration _vertexDeclaration = new VertexDeclaration(new VertexElement[3]
            {
                new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
                new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.TextureCoordinate, 0)
            });
            public Vector2 Position;
            public Color Color;
            public Vector3 TexCoord;

            public CustomVertexInfo(Vector2 position, Color color, Vector3 texCoord) {
                this.Position = position;
                this.Color = color;
                this.TexCoord = texCoord;
            }

            public VertexDeclaration VertexDeclaration {
                get {
                    return _vertexDeclaration;
                }
            }
        }

    }
}
