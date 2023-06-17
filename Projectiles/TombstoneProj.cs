using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Ni.Projectiles
{/*
    public class TombstoneProj : BaseRotateProj
    {

        Vector2 inidir = Vector2.Zero;
        public int offscale = 0;
        public override void SetDefaults()
        {
            QuickSD(36, 60, 40, DamageClass.Melee, 7f, true, false, -1, 1, -1, 1f, 60, false, false, false, true, true, 40);
            Projectile.penetrate = -1;
            base.SetDefaults();
        }
        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
        }
        public override void AI()
        {
            inidir = new Vector2(Projectile.localAI[0], Projectile.localAI[1]);
            if (offscale < 40)
            {
                offscale += 5;
            }
            Projectile.scale = offscale / 40;
            Projectile.rotation = (Projectile.Center - player.Center).ToRotation() + MathHelper.PiOver2;
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation + MathHelper.Pi);
            switch (ai0)
            {
                case 0:
                    //Main.NewText($"{inidir.ToRotation()}");
                    if (!inidir.IsLeftQuadrant())
                    {
                        Projectile.Center = player.Center + new Vector2(offscale, 0).RotatedBy(inidir.ToRotation() + MathHelper.Lerp(MathF.PI / 2, -MathF.PI / 2, Projectile.timeLeft / 60f));
                    }
                    else
                    {
                        Projectile.Center = player.Center + new Vector2(offscale, 0).RotatedBy(inidir.ToRotation() - MathHelper.Lerp(MathF.PI / 2, -MathF.PI / 2, Projectile.timeLeft / 60f));
                    }
                    break;
                case 1:
                    if (!inidir.IsLeftQuadrant())
                    {
                        Projectile.Center = player.Center + new Vector2(offscale, 0).RotatedBy(inidir.ToRotation() + MathHelper.Lerp(-MathF.PI / 2, MathF.PI / 2, Projectile.timeLeft / 60f));
                    }
                    else
                    {
                        Projectile.Center = player.Center + new Vector2(offscale, 0).RotatedBy(inidir.ToRotation() + MathHelper.Lerp(MathF.PI / 2, -MathF.PI / 2, Projectile.timeLeft / 60f));
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            base.AI();
        }
        public override void Kill(int timeLeft)
        {
            base.Kill(timeLeft);
        }
    }*/
}

