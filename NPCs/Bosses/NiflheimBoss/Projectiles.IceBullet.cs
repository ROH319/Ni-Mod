using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;
using Ni.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Ni.NPCs.Bosses.NifelheimBoss
{
    public class IceBullet : BaseRotateProj
    {
        public override string Texture => AssetHelper.NiflheimPath + GetType().Name;
        public override string GlowTexture => AssetHelper.NiflheimPath + "IceBullet_Glow";
        public Texture2D glowTex;
        public override void SetStaticDefaults()
        {
            glowTex = AssetHelper.GetTex(AssetHelper.NiflheimPath + "IceBullet_Glow");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            QuickSD(9, 18, 50, DamageClass.Default, 5f, false, true, scale: 0.75f, timeLeft: 6 * 60, tileCollide: true);
            base.SetDefaults();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return base.OnTileCollide(oldVelocity);
        }
        public override void AI()
        {
            Projectile.rotation = (float)(Projectile.velocity.ToRotation() - Math.PI / 2);
            if (Main.GameUpdateCount % 3 == 0)
            {
                //var d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.BlueIce, Projectile.velocity.X, Projectile.velocity.Y);
                var d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.BlueIce, 0, 0);
                //d.scale *= 0.75f;
                d.noGravity = true;
            }
            base.AI();
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                var d = Dust.NewDustDirect(Projectile.position, (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), 
                    MyDustId.BlueIce, Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1), 0, Color.White, Main.rand.NextFloat(0.5f, 1f));
                d.scale = 0.5f;
            }
            base.Kill(timeLeft);
        }
        public override void PostDraw(Color lightColor)
        {
            //sb.Draw(glowTex, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, glowTex.Size() / 2, Projectile.scale, 0, 0);
            base.PostDraw(lightColor);
        }
    }
}
