using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using TemplateMod2.Utils;

namespace Ni.Projectiles
{
    //public class Shiv : BaseRotateProj
    //{
    //    public override void SetDefaults()
    //    {
    //        QuickSD(24, 10, 10, DamageClass.Generic, 5f, true, false, -1, 4, -1, 1f, 10 * 60, false, false, true);
    //        base.SetDefaults();
    //    }

    //    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
    //    {
    //        return NiUtil.CheckAABBvLineColliding2(Projectile, targetHitbox);
    //    }
    //    public override void Kill(int timeLeft)
    //    {
    //        //Main.NewText($"{Projectile.width}");
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, MyDustId.Silver);
    //        }
    //        base.Kill(timeLeft);
    //    }
    //}
}

