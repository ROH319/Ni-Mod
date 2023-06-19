using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Ni.Items.Weapons;

namespace Ni.Projectiles
{
    /*
    public class HecateProj : BaseHeldProj
    {
        public override int Weapon => ModContent.ItemType<Hecate>();

        public override void SetDefaults()
        {
            QuickSDHELD1(64, 24,100,DamageClass.Ranged);
            DrawOriginOffsetX = -5f;
        }

        Vector2[] VecLaser = new Vector2[600];
        public override bool PreDraw(ref Color lightColor)
        {
            #region ��
            var tomouse = Main.MouseWorld - Projectile.Center;
            var ow = tomouse.IsLeftQuadrant() ? (tomouse.ToRotation() - MathHelper.Pi / 2).ToRotationVector2() : (tomouse.ToRotation() + MathHelper.Pi / 2).ToRotationVector2();
            //ow����ֱtomouse�����ƫ��
            ow.Normalize();
            var off = tomouse.ToRotation().ToRotationVector2();
            //off��tomouse�����ƫ��
            off.Normalize();
            //var recenter = player.Center + off * 18 - ow *14;
            var recenter = Projectile.Center - off*5 - ow *7;
            var rotation = (Main.MouseWorld - recenter).ToRotation() + MathHelper.Pi / 2;
            float interval = 4;//ȡ��ļ��
            int Count = 0;//������������ж���ײ�����ʣ�ĵ���
            Vector2 collipos = new Vector2(0, 0);
            //new Rectangle((int)(player.Center - new Vector2(0, interval).RotatedBy(rotation) * m).X, (int)(player.Center - new Vector2(0, interval).RotatedBy(rotation) * m).Y, 10, 10)
            for (int m = 0; m < 600; ++m)
            {
                if (Collision.SolidCollision(recenter - new Vector2(0, interval).RotatedBy(rotation) * m, 1, 1))
                {
                    collipos = recenter - new Vector2(0, interval).RotatedBy(rotation) * m;
                    //�������д��ײ���һЩЧ��������Draw����Чʲô��
                    break;
                }
                VecLaser[m] = recenter - new Vector2(0, interval).RotatedBy(rotation) * m;//����m����Щ����m�����Ӷ����죬��������ģ��һ��ֱ�ߵ�Ч����
                ++Count;
            }
            List<VertexInfo2> bars = new List<VertexInfo2>();
            for (int k = 1; k < Count; k++)
            {
                if (VecLaser[k] == Vector2.Zero) break;

                var normalDir = VecLaser[k - 1] - VecLaser[k];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                float factor = k / (float)Count;

                var color = new Color(255, 0, 0);

                var w = MathHelper.Lerp(1f, 0.05f, factor);
                float size = 1;
                if (k < 10)
                {
                    size = k / 10f;
                }
                float width = 6 * 1f * size;//����Ŀ��


                bars.Add(new VertexInfo2(VecLaser[k] + normalDir * width - Main.screenPosition, color, new Vector3(factor + (float)Main.time * 0.03f, 1, w)));
                bars.Add(new VertexInfo2(VecLaser[k] + normalDir * -width - Main.screenPosition, color, new Vector3(factor + (float)Main.time * 0.03f, 0, w)));
            }
            List<VertexInfo2> triangleList = new List<VertexInfo2>();
            if (bars.Count > 2)
            {
                //����˳������������
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

                sb.AdditiveBegin();

                if (collipos != new Vector2(0, 0))
                {
                    sb.Draw(AssetHelper.Ball, new Rectangle((int)((collipos - Main.screenPosition).X - 6), (int)((collipos - Main.screenPosition).Y - 6), 12, 12), Color.Red);
                    
                }
                Main.graphics.GraphicsDevice.Textures[0] = AssetHelper.Laser1;
                //Utils.DrawLine(Main.spriteBatch, player.Center.ToPoint(), (player.Center + (Main.MouseScreen - player.Center).ToRotation().ToRotationVector2() * 100).ToPoint(), Color.Red);
                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);
                //Main.spriteBatch.Draw(Ni.laser1, new Rectangle(0, 0, 2000, 1), new Rectangle(1, 1, 256, 256), Color.White, (Main.MouseWorld - player.Center).ToRotation(), new Vector2(0, 128),0,0f);
                
                sb.VanillaBegin();
                //DrawLine(Main.spriteBatch, Main.graphics.GraphicsDevice, Ni.laser1, PrimitiveType.TriangleList, triangleList);
            }
            #endregion
            return true;
        }

        public override void AI()
        {
            Vector2 toMouse = Main.MouseWorld - player.Center;
            Vector2 off = toMouse.ToRotation().ToRotationVector2();
            off.Normalize();
            Projectile.Center = player.Center + off * 22 +new Vector2(0,-8);
            if (toMouse.IsLeftQuadrant())
            {
                DrawOriginOffsetX = 5;
                Projectile.spriteDirection = -1;
                Projectile.rotation = toMouse.ToRotation() + MathHelper.Pi;
                player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Quarter, Projectile.rotation + MathHelper.Pi/2);
                player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.None, Projectile.rotation + MathHelper.Pi / 2);
            }
            else
            {
                DrawOriginOffsetX = -5;
                Projectile.spriteDirection = 0;
                Projectile.rotation = toMouse.ToRotation();
                player.SetCompositeArmFront(true, 0, Projectile.rotation - MathHelper.Pi / 2);
                player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.None, Projectile.rotation - MathHelper.Pi / 2);
            }
            //Main.NewText($"{Projectile.rotation}");
            //��һ���ޣ�0->��pi/2���ڶ����ޣ���pi/2->��pi���������ޣ�pi->pi/2���������ޣ�pi/2->0
        }
    }*/
}

