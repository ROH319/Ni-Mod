using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Items.Weapons;
using Terraria.DataStructures;
using Terraria.Audio;
using ReLogic.Content;
using Terraria.GameContent;
using ReLogic.Graphics;

namespace Ni.Projectiles
{
    public class KatanaProj : BaseHeldProj
    {
        //public override string Texture => AssetLoader.TransparentImg; 
        //public Texture2D image = AssetLoader.GetTex("Ni/Projectiles/KatanaProj");
        public override int Weapon => ModContent.ItemType<DashKatana>();
        public bool cooldowned;
        public int cooldowncounter;

        public int dashduration;
        public Vector2 dashvec;
        public Vector2 dashpre;
        public int maxStrength;
        public override void SetDefaults()
        {
            QuickSDHELD1(33, 10, 50, DamageClass.Melee);
            
            base.SetDefaults();
        }
        public override void OnSpawn(IEntitySource source)
        {
            cooldowned = true;
            dashvec = Vector2.Zero;
            dashduration = 11;
            base.OnSpawn(source);
        }
        public override void AI()
        {
            Projectile.damage = (int)player.GetTotalDamage(DamageClass.Melee).ApplyTo(player.HeldItem.damage);
            //Main.slimeRain = false;
            #region CheckActive
            if (player.dead)
            {
                Projectile.Kill();
            }
            #endregion
            maxStrength = (int)(7 + (player.GetTotalAttackSpeed(DamageClass.Melee) - 1) / 2 * 10);
            //player.velocity.Y = 1000;
            #region ≥Â¥Ã¬ﬂº≠
            float progress = dashduration < 6 ? dashduration * 1.5f / 10f : 1;
            if (dashduration == 0)
            {
                dashduration = 12;
                player.dashDelay = 22;
                dashvec = Vector2.Zero;
                //player.velocity = dashpre;//∏¥‘≠ÀŸ∂»
            }
            if(dashvec != Vector2.Zero)//≥Â¥Ã◊¥Ã¨
            {
                dashduration--;
                player.dashDelay = -1;
                player.velocity = dashvec * progress;
                player.gravity = 0;
            }
            if(player.altFunctionUse == 1 && player.dashDelay == 0 && !player.mount.Active)//∞¥œ¬”“º¸«“¿‰»¥Œ™0 ±
            {
                dashpre = player.velocity;
                dashvec = (Main.MouseWorld - player.Center).NormalizeV() * 45;
                if (ai1 < maxStrength)
                {
                    ai1 += 3;
                    if(ai1 > maxStrength)
                    {
                        ai1 = maxStrength;
                    }
                }
            }
            #endregion

            Projectile.scale = 2f;
            Projectile.Center = player.Center + new Vector2(0,5) + new Vector2(ToMouse.NormalizeV().X * -18, (int)(ToMouse.NormalizeV().Y * -10));
            Projectile.rotation = ToMouse.ToRotation();
            Projectile.direction = -1;

            ai0--;
            player.bodyFrame.Y = player.bodyFrame.Height * 6;
            if (cooldowncounter == 0)
            {
                cooldowned = true;
            }
            if (!cooldowned)
            {
                cooldowncounter--;
            }
            if(cooldowned && player.controlUseItem && player.altFunctionUse == 0)
            {
                SoundStyle sound = AssetLoader.Katana with { MaxInstances = 20 };
                SoundEngine.PlaySound(sound, player.Center);
                Projectile p = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), player.Center + ToMouse.NormalizeV() * 135, player.velocity, ModContent.ProjectileType<KatanaSwing>(), Projectile.damage + (ai1 > 0 ? 60 : 0), Projectile.knockBack, player.whoAmI, Main.rand.NextBool() ? 0 : 1);
                p.rotation = ToMouse.ToRotation() + MathHelper.PiOver2;
                p.scale = 4f;
                if(ai1 > 0)
                {
                    ai1--;
                }
                ai0 = 2;
                cooldowned = false;
                cooldowncounter = ai1 > 0 ? 4 : (int)(player.HeldItem.useTime * (1f - (player.GetTotalAttackSpeed(DamageClass.Melee) / 2 - 1)));
            }
            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            //sb.AdditiveBegin();
            if(ai0 > 0)
            {
                //…¡À∏
                sb.Draw(AssetLoader.KatanaFlash, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, AssetLoader.KatanaFlash.Size() / 2, Projectile.scale, 0, 0);
            }
            sb.Draw(AssetLoader.KatanaHUD, player.position - Main.screenPosition + new Vector2(10, 60), null, Color.White, 0f, AssetLoader.KatanaHUD.Size() / 2, 2f, 0, 0);
            sb.DrawString(FontAssets.MouseText.Value, $"{ai1}", player.position - Main.screenPosition + new Vector2(5, 60), Color.Lerp(Color.White, Color.Blue, ai1 / maxStrength));
            //Utils.DrawLine(sb,player.Center,player.Center + dashvec,Color.White);
            //Utils.DrawBorderStringFourWay
            //sb.VanillaBegin();
            base.PostDraw(lightColor);
        }
    }
}

