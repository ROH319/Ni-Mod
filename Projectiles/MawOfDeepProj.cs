using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Ni.NiModPlayer;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.Projectiles
{
    /*
    public class MawOfDeepProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Projectile.width = 81;
            Projectile.height = 45;
            //Projectile.usesLocalNPCImmunity = true;
            //Projectile.localNPCHitCooldown = 10;
            Projectile.penetrate = -1;
            Projectile.netUpdate = true;
            Projectile.tileCollide = false;
            Projectile.damage = 50;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 2;
            Projectile.scale = 1.5f;
            Projectile.friendly = true;
        }
        
        public int Timer
        {
            get { return (int)Projectile.ai[0]; }
            set { Projectile.ai[0] = value; }
        }
        
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            player.TryGetModPlayer(out NiPlayer niPlayer);
            Item item = player.HeldItem;
            //Projectile.Center = player.Center;
            Vector2 top = player.Center + new Vector2(-50, -60);
            Vector2 bottom = player.Center + new Vector2(-20, 60);
            Vector2 tex = player.Center + new Vector2(200, 0);
            /*if(Timer == -1)
            {
                Projectile.rotation -= MathHelper.Pi / 675;
                //Timer++;
            }
            Timer++;
            if (Timer > 60)
            {
                Projectile.Kill();
            }
            //Projectile.rotation = ((60 - Timer) * MathHelper.Pi * 2 / 3 * (-1) + Timer * MathHelper.Pi * 2 / 3) / 1800;
            Projectile.rotation += MathHelper.Pi / 45;
            player.SetCompositeArmFront(true, player.compositeFrontArm.stretch, Projectile.rotation);
            Projectile.Center = ((60 - Timer) * (60 - Timer) * top + 2 * Timer * (60 - Timer) * tex + Timer * Timer * bottom) / 3600;
            //Main.NewText($"{Projectile.Center} {player.Center}");
        }
    */

    
}

