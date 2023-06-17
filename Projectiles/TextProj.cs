using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Graphics;
using Ni.NiUtils;
using System.Collections.Generic;

namespace Ni.Projectiles
{
    public class TextProj : BaseRotateProj
    {
        public override string Texture => "Ni/Images/A";
        public override void SetDefaults()
        {
            Projectile.height = 1;
            Projectile.width = 1;
            Projectile.damage = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.knockBack = 0f;
            Projectile.localNPCHitCooldown = 10;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {

        }
        public static CombatText[] combatText = new CombatText[100];
        //Vector2[] veclaser = new Vector2[600];
        public override void PostDraw(Color lightColor)
        {
            sb.End();

            sb.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone, AssetLoader.MyColor, Main.GameViewMatrix.ZoomMatrix);
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
                int Count = 0;
                List<VertexInfo2> bars = new List<VertexInfo2>();
                //for(int i = 0; i < 600; ++i)
                //{
                //    Vector2 pos = new Vector2(400, 0).RotatedBy(i * Math.PI / 600f);
                //    //veclaser[i] = pos + (pos - player.Center).NormalizeV();
                //    bars.Add(new VertexInfo2(pos + (pos - player.Center).NormalizeV(),Color.White,new Vector3())
                //    ++Count;
                //}
                Main.graphics.GraphicsDevice.Textures[0] = AssetLoader.TrailLaser;
                Main.graphics.GraphicsDevice.Textures[1] = AssetLoader.Color_Yellow_Orange2;
                AssetLoader.MyColor.CurrentTechnique.Passes[0].Apply();

            }

            sb.VanillaBegin();
            base.PostDraw(lightColor);
        }
    }
}


