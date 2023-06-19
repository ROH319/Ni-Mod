using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using Terraria.Audio;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class KillingDeckProj : BaseRotateProj
    {
        Texture2D tex = AssetHelper.GetTex("Ni/Projectiles/KillingDeckProj");
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 50;
            ProjectileID.Sets.TrailingMode[Type] = 3;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            QuickSD(12, 16, 40, DamageClass.Ranged, 5f, true, false, -1, 3, -1, 1f, 30 * 60, false, false, true, true);
            Projectile.penetrate = -1;
            base.SetDefaults();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(AssetHelper.Card_Hit, Projectile.Center);
            Projectile.velocity = Vector2.Zero;
            ai1 = 1;
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (ai1 != 1)
            {
                Projectile.velocity = Vector2.Zero;
                Projectile.damage = 0;
                tiedto = target;
                offset = target.Center - Projectile.Center;
                SoundEngine.PlaySound(AssetHelper.Card_Hit, Projectile.Center);
            }
            ai1 = 1;
        }
        NPC tiedto = null;
        Vector2 offset = Vector2.Zero;
        Vector2 toplr = Vector2.Zero;
        bool canback;
        public override void AI()
        {
            toplr = player.Center - Projectile.Center;
            toplr.Normalize();
            if (ai0 == 0)
            {
                Projectile.rotation += (ai1 == 0) ? 0.1f : 0f;
                if (Main.time % 2 == 0)
                {
                    Projectile.velocity *= 0.99f;
                }
                if (tiedto != null)
                {
                    Projectile.Center = tiedto.Center - offset;
                    if (!tiedto.active)
                    {
                        Projectile.Kill();
                    }
                }
            }
            else if(ai0 == 1)
            {
                Projectile.damage = (int)player.GetTotalDamage(DamageClass.Ranged).ApplyTo(Projectile.originalDamage);
                Projectile.CritChance = 100;
                Projectile.tileCollide = false;
                if (canback)
                {
                    Projectile.velocity = toplr * 6f;
                    if (Vector2.Distance(player.Center, Projectile.Center) < 5f)
                    {
                        Projectile.Kill();
                    }
                }
                canback = true;
            }

            #region ??????
            for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
            {
                Projectile.oldPos[i] = Projectile.oldPos[i - 1];
                Projectile.oldRot[i] = Projectile.oldRot[i - 1];
            }
            Projectile.oldPos[0] = Projectile.Center;
            Projectile.oldRot[0] = Projectile.rotation;
            #endregion
        }

        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.velocity != Vector2.Zero)
            {
                sb.AdditiveBegin(SpriteSortMode.Deferred);
                for (int i = Projectile.oldPos.Length - 1; i >= 0; i -= 1)
                {
                    //Vector2 oldpos = Projectile.oldPos[i] + Projectile.Center - Projectile.position;
                    float factor = 1 - (float)i / Projectile.oldPos.Length;
                    sb.Draw(tex, Projectile.oldPos[i] - Main.screenPosition, null, Projectile.GetAlpha(Color.White) * factor * 0.6f, Projectile.rotation, tex.Size() / 2, 1, 0, 0);
                }
                sb.VanillaBegin();
            }
            return base.PreDraw(ref lightColor);
        }
        public override void PostDraw(Color lightColor)
        {
            /*
            sb.AdditiveBegin();
            float traillength = Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y);
            traillength *= 0.3f;
            traillength *= 10f;
            if (traillength > 80f)
                traillength = 80f;

            for (int n = 0; n < traillength; n++)
            {
                Vector2 pos = Projectile.Center - Projectile.velocity * n / 3;
                float scale = 0.5f * (1f - n / 120f);
                Color poscolor = Projectile.GetAlpha(lightColor);
                sb.Draw(tex, pos - Main.screenPosition, null, poscolor, Projectile.rotation + MathHelper.PiOver2, tex.Size() / 2, scale, SpriteEffects.None, 0f);
            }
            //Color newColor = Projectile.GetAlpha(lightColor);
            //sb.Draw(tex, Projectile.Center - Main.screenPosition, null, newColor, Projectile.rotation, new Vector2(3f, 5f), Projectile.scale, SpriteEffects.None, 0f);

            sb.VanillaBegin();
            */
        }

    }
}

