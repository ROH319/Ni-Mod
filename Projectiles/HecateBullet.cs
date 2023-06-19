using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class HecateBullet : BaseRotateProj
    {
        public static Texture2D tex = NiUtils.GetTex("Ni/Projectiles/HecateBullet");
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 70;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            QuickSD(9, 5, 100, DamageClass.Ranged, 8f, true, false, -1, 19, -1, 1, 3 * 60, false, false, true, true);
            Projectile.penetrate = -1;
            base.SetDefaults();
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return NiUtils.CheckAABBvLineColliding(Projectile,targetHitbox);
        }
        public override void AI()
        {
            #region ²ÐÓ°»æÖÆÂß¼­
            for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
            {
                Projectile.oldPos[i] = Projectile.oldPos[i - 1];
                Projectile.oldRot[i] = Projectile.oldRot[i - 1];
            }
            Projectile.oldPos[0] = Projectile.Center;
            Projectile.oldRot[0] = Projectile.rotation;
            #endregion
            base.AI();
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.velocity != Vector2.Zero)
            {
                sb.AdditiveBegin();
                for (int i = Projectile.oldPos.Length - 1; i >= 0; i -= 1)
                {
                    Vector2 oldcenter = Projectile.oldPos[i] + Projectile.Center - Projectile.position;
                    float factor = 1 - (float)i / Projectile.oldPos.Length;
                    sb.Draw(tex, oldcenter - Main.screenPosition, null, Projectile.GetAlpha(Color.White) * factor * 1f, Projectile.rotation, tex.Size() / 2, 1, 0, 0);
                }
                sb.VanillaBegin();
            }
            return base.PreDraw(ref lightColor);
        }
        /*
        public override void PostDraw(Color lightColor)
        {
            Texture2D tex2 = NiUtil.GetTex("Ni/Projectiles/TestProj");
            sb.AdditiveBegin();
            float length = Projectile.oldPos.Length;
            for(int i= 0; i < length; i++)
            {
                sb.Draw(tex, Projectile.oldPos[i] - Main.screenPosition, null, Color.White, Projectile.oldRot[i], tex.Size() / 2, MathHelper.Lerp(1f, 0f, i / length), 0, 0f);
            }
            
            float traillength = Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y);
            traillength *= 0.3f;
            traillength *= 10f;
            if (traillength > 120f)
                traillength = 120f;

            for (int n = 0; n < traillength; n++)
            {
                Vector2 pos = Projectile.Center - Projectile.velocity * n / 3;
                float scale = 0.5f * (1f - n / 120f);
                Color poscolor =  Projectile.GetAlpha(lightColor);
                sb.Draw(tex, pos - Main.screenPosition, null, poscolor, Projectile.rotation + MathHelper.PiOver2, new Vector2(36f, 36f), scale, SpriteEffects.None, 0f);
            }
            Color newColor = Projectile.GetAlpha(lightColor);
            sb.Draw(tex2, Projectile.Center - Main.screenPosition, null, newColor, Projectile.rotation, new Vector2(3f, 5f), Projectile.scale, SpriteEffects.None, 0f);
            
            sb.VanillaBegin();
        }
        */
    }
}

