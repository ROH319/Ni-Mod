using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using TemplateMod2.Utils;

namespace Ni.Projectiles
{
    public class ThunderKunaiProj : BaseRotateProj
    {
        public override void SetDefaults()
        {
            QuickSD(20, 14, 8, DamageClass.Ranged, 4f, true, false, -1, 4, -1, 1f, 6 * 60, false, false, true, true);
            Projectile.penetrate = -1;
            Projectile.rotation = 0;
            base.SetDefaults();
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 length = Projectile.velocity;
            length.Normalize();
            length *= Projectile.height / 2;
            int width = Projectile.width / 2;

            //return NiUtil.CheckAABBvLineColliding(Projectile.Center - length, Projectile.Center + length, width, targetHitbox);
            return NiUtil.CheckAABBvLineColliding(Projectile, targetHitbox);
        }
        public override void AI()
        {
            //Projectile.Center = player.Center;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void PostDraw(Color lightColor)
        {
            base.PostDraw(lightColor);
        }

        public override void Kill(int timeLeft)
        {
            //Main.NewText($"{Projectile.width}");
            for(int i = 0; i < 10; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.Silver);
            }
            base.Kill(timeLeft);
        }
    }
}

