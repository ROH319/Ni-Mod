using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class arzunaProj: BaseRotateProj
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
            ProjectileID.Sets.TrailingMode[Type] = 3; 
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            QuickSD(16, 3, 40, DamageClass.Ranged, 6f, true, false, 1, 0, -1, 1f, 10 * 60, false, false, true, true, true, 20);
        }
        public override void OnSpawn(IEntitySource source)
        {
            if(!IsHomingIn)
            {
                Projectile.extraUpdates = 5;
                Projectile.penetrate = -1;
                return;
            }
            //追踪弹
            Projectile.CritChance = 100;
            Vector2 velocitytoadd = ToMouse.NormalizeV();
            VelocityToAddX = velocitytoadd.X;
            VelocityToAddY = velocitytoadd.Y;
            base.OnSpawn(source);
        }
        public bool IsHomingIn => ai0 == 1;
        public float VelocityToAddX {
            get { return (int)ai1; }
            set { ai1 = value; }
        }
        public float VelocityToAddY { 
            get { return (int)ai2; }
            set { ai2 = value; }
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            if(IsHomingIn && Main.time % 1 == 0)
            {
                Dust d = Dust.NewDustPerfect(Projectile.Center, MyDustId.TrailingBlue);
                d.scale /= 4;
                //d.scale *= 2;
                d.velocity = Vector2.Zero;
                d.noGravity = true;
                return;
            }
            //追踪弹
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
            Projectile.CritChance = 4;
            if (Projectile.timeLeft > 520) Projectile.velocity += new Vector2(VelocityToAddX, VelocityToAddY);

            NPC target = Projectile.FindTargetWithinRange(1000f, true);
            if (target == null) return;
            // 目标速度
            var targetVel = Vector2.Normalize(target.Center - Projectile.Center) * 20f;
            // 加权平均 1份目标速度和10份当前速度
            Projectile.velocity = (targetVel * 3 + Projectile.velocity * 8) / 11f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = AssetHelper.GetTex(Texture);
            sb.AdditiveBegin();
            sb.Draw(tex, Projectile.position - Main.screenPosition, null, Color.White, Projectile.rotation, tex.Size() / 2, Projectile.scale, 0, 0);
            sb.VanillaBegin();
            return false;
        }
    }
}

