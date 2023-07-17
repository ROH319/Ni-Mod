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
using Ni.NPCs.Bosses.NifelheimBoss;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class IceCrystal : BaseRotateProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetStaticDefaults()
        {
            //Main.projFrames[Type] = 21;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            QuickSD(31, 36, 50, DamageClass.Default, 5f, false, false, scale: 2f, timeLeft: 5 * 21);
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
            if (Projectile.frame > 20)
            {
                Projectile.frame = 0;
            }
            Projectile.frameCounter++;
            #endregion

            if (Projectile.frame > 13) Projectile.hostile = true;
            if (Projectile.frame > 17) Projectile.hostile = false;

            if(Projectile.frame > 16 && ai1 != -1)
            {
                SpawnProj();
                ai1 = -1;
            }
            base.AI();
        }

        public override void PostDraw(Color lightColor)
        {
            sb.Draw(AssetHelper.IceCryStal[Projectile.frame], Projectile.Center - Main.screenPosition, null, Color.White, 
                Projectile.rotation, AssetHelper.IceCryStal[Projectile.frame].Size() / 2, Projectile.scale, 0, 0);
            base.PostDraw(lightColor);
        }

        public void SpawnProj()
        {
            for(int i = 0; i < 6; i++)
            {
                var p = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.Center + new Vector2(-11, -20), 
                    new Vector2(1, 0).RotatedBy(Math.PI / 6).RotatedBy(i * Math.PI / 3) * 11f, ModContent.ProjectileType<IceBullet>(), Projectile.damage, Projectile.knockBack, Main.LocalPlayer.whoAmI);
            }
        }
    }
}
