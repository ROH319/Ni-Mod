using Microsoft.Xna.Framework;
using Ni.Helpers;
using Ni.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class IceSpear : BaseRotateProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
            QuickSD(15, 111, 60, DamageClass.Default, 5f, false, true, scale: 2f);
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
            if (Projectile.frame > 12)
            {
                Projectile.frame = 12;
            }
            Projectile.frameCounter++;
            #endregion

            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            sb.Draw(AssetHelper.IceSpear[Projectile.frame], Projectile.Center - Main.screenPosition, null, Color.White,
                Projectile.rotation, AssetHelper.IceSpear[Projectile.frame].Size() / 2, Projectile.scale, 0, 0);
            base.PostDraw(lightColor);
        }
    }
}
