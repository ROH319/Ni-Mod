using Ni.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;
using Terraria;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class Icicle : BaseRotateProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
            QuickSD(27, 40, 50, DamageClass.Default, 0f, false, true, scale: 2f, timeLeft: 10 * 60);
            base.SetDefaults();
        }
        public override void AI()
        {
            #region 绘制逻辑
            if (Projectile.frameCounter > 5)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (ai0 == 0f)
            {
                if (Projectile.frame > 9)
                {
                    Projectile.frame = 9;
                }
            }
            else if (ai0 == 1f)
            {
                Projectile.frame = 0;
                ai0++;
            }
            else if (ai0 == 2f)//播放完死亡动画再似
            {
                if (Projectile.frame > 2)
                {
                    Projectile.Kill();
                }
            }
            Projectile.frameCounter++;
            #endregion

            if (Projectile.timeLeft < 8.5 * 60)
            {
                Projectile.velocity.Y += 0.08f;
            }
            if (Projectile.velocity.Y > 15)
            {
                Projectile.velocity = Vector2.Zero;
                ai0++;
            }
            base.AI();
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                var d = Dust.NewDustDirect(Projectile.position, (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), MyDustId.BlueIce, Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-4, 4));
            }
            base.Kill(timeLeft);
        }
        public override void PostDraw(Color lightColor)
        {
            if (ai0 == 1f)
            {
                sb.Draw(AssetHelper.Icicle[Projectile.frame], Projectile.Center - Main.screenPosition,
                    null, Color.White, Projectile.rotation, AssetHelper.Icicle[Projectile.frame].Size() / 2, Projectile.scale, 0, 0);
            }
            else
            {
                //死亡动画
                sb.Draw(AssetHelper.IcicleDestroy[Projectile.frame], Projectile.Center - Main.screenPosition,
                    null, Color.White, Projectile.rotation, AssetHelper.IcicleDestroy[Projectile.frame].Size() / 2, Projectile.scale, 0, 0);
            }
            base.PostDraw(lightColor);
        }

    }
}
