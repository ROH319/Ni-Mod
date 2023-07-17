using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Audio;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class LightningProj : BaseRotateProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
            QuickSD(1, 1, 50, DamageClass.Summon, 5f, true, false, -1, 0, -1, 1f, 5, false, false, false, true);
            //Projectile.rotation += MathHelper.Pi;
            ProjectileID.Sets.DrawScreenCheckFluff[Projectile.type] = 3000;
            base.SetDefaults();
        }
        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(AssetHelper.LightningOrb_Passive, Main.projectile[(int)Projectile.localAI[0]].Center);
            base.OnSpawn(source);
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return NiUtils.CheckAABBvLineColliding(Projectile.Center,new Vector2(ai0,ai1), (int)(40 * Projectile.scale), targetHitbox);
        }

        public override void AI()
        {
            Projectile.penetrate = -1;
            Projectile.frame++;
            ShouldFilp = Main.rand.NextBool(2);
            for (int i = 0; i < 20; i++)
            {
                Lighting.AddLight(Vector2.Lerp(Projectile.Center, new Vector2(ai0, ai1), (float)i / 20), TorchID.Yellow);
            }
            base.AI();
        }
        public bool ShouldFilp = false;
        public override void PostDraw(Color lightColor)
        {
            Vector2 target = new Vector2(ai0, ai1);
            Vector2 toplr = Projectile.Center - player.Center;
            toplr.Normalize();
            if (Projectile.frame > 5)
            {
                Projectile.frame = 0;
            }
            sb.AdditiveBegin();
            sb.Draw(
                AssetHelper.LightningProj, 
                new Rectangle((int)(Projectile.Center.X - Main.screenPosition.X), (int)(Projectile.Center.Y - Main.screenPosition.Y), (int)(44 * Projectile.scale), (int)Vector2.Distance(Projectile.Center, target) ), 
                new Rectangle(Projectile.frame * 85, 13, 85, 482), 
                Color.White, 
                Projectile.rotation, 
                new Vector2(42, 0), 
                ShouldFilp?SpriteEffects.FlipVertically : 0, 
                0);
            sb.VanillaBegin();
        }
    }
}

