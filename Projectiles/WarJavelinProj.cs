using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class WarJavelinProj : BaseProj
    {
        public override void SetDefaults()
        {
            QuickSD(20, 20, 200, DamageClass.Ranged, 1f, true, false, -1, 0, -1, 1, 114514, false, false, true, true);
        }
        Vector2 plrpos = new Vector2(0,0);
        public override void Kill(int timeLeft)
        {
            Projectile logicproj = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.position + new Vector2(0, 20), Vector2.Zero, ModContent.ProjectileType<WarJavelin_Tele>(), Projectile.damage, 0f, player.whoAmI, player.Center.X, player.Center.Y);
            plrpos = player.Center;
            for (int i = 0; i < 100; i++)
            {
                Dust d = Dust.NewDustPerfect(player.Center + new Vector2(40, 0).RotatedBy(MathHelper.TwoPi / 100 * i), MyDustId.YellowFx);
                d.noGravity = true;
            }
            player.Teleport(Collision.SolidTiles(Projectile.position + new Vector2(0, 20), 16, 16) ? Projectile.position + new Vector2(0,-20) : Projectile.position, 6);//6是无特效传送
            for (int i = 0; i < 50; i++)
            {
                Dust d = Dust.NewDustPerfect(player.Center, MyDustId.YellowFx1, null, 0, default, 1.3f);
                d.velocity = new Vector2(10, 0).RotatedBy(MathHelper.TwoPi / 50 * i);
                d.noGravity = true;
            }
            SoundEngine.PlaySound(AssetHelper.WarJavelin_Tp, player.Center);
            base.Kill(timeLeft);
        }
        public override void AI()
        {
            if(player.altFunctionUse == 2)
            {
                Projectile.Kill();
            }
            Projectile.penetrate = -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 + MathHelper.PiOver2;
            Projectile.Fall(0.999f, 0.02f, 10f);
        }
    }
}

