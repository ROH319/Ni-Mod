using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class KatanaSwing : BaseRotateProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 6;
        }
        public override void SetDefaults()
        {
            QuickSD(70, 57, 50, DamageClass.Melee, 5f, true, false, -1, 0, -1, 1f, 14, false, ignoreWater: true);
            base.SetDefaults();
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float point = 0f;
            Vector2 endPoint = Projectile.Center + (Projectile.rotation + MathHelper.PiOver2).ToRotationVector2() * (Projectile.height * Projectile.scale / 2);
            Vector2 startPoint = Projectile.Center - (Projectile.rotation + MathHelper.PiOver2).ToRotationVector2() * (Projectile.height * Projectile.scale / 2);
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), startPoint, endPoint, (Projectile.width + 30) * Projectile.scale / 2, ref point);
        }
        public override void AI()
        {
            #region »æÖÆÂß¼­
            if (Projectile.frameCounter > 1)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 5)
            {
                Projectile.frame = 0;
            }
            Projectile.frameCounter++;
            #endregion
            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            sb.Draw(AssetHelper.KatanaSwing[Projectile.frame], Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, AssetHelper.KatanaSwing[Projectile.frame].Size() / 2,
                Projectile.scale, ai0 == 1 ? SpriteEffects.FlipHorizontally : 0, 0);
            base.PostDraw(lightColor);
        }
    }
}

