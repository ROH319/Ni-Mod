using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Buffs;
using System.Collections.Generic;
using Ni.Core;
using Ni.Items.Accessories;
using Ni.Items.AccEffects;
using Ni.Helpers;
using Ni.Core.Systems;

namespace Ni.Projectiles.Minions
{
    public class SeeriMinion : BaseMinion
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override int BuffType => ModContent.BuffType<SeeriBuff>();
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.projPet[Type] = true;
            Main.projFrames[Type] = 8;
        }
        public override void SetDefaults()
        {
            QuickMinion(30, 21, 40, 5f, 2f, 0);
            Projectile.penetrate = -1;
        }
        public override void PostDraw(Color lightColor)
        {
            sb.Draw(AssetHelper.Seeri[Projectile.frame], Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, AssetHelper.Seeri[Projectile.frame].Size() / 2, 
                Projectile.scale, player.direction == -1 ? 0 : SpriteEffects.FlipHorizontally, 0);
        }
        public override void AI()
        {
            #region CheckActive
            if (player.dead || !player.active || !player.TryGetModPlayer<AccSeeri>(out AccSeeri se) && se.Seeri)
            {
                player.ClearBuff(BuffType);
                Projectile.Kill();
                return;
            }
            if (player.HasBuff(BuffType))
            {
                Projectile.timeLeft = 2;
            }
            #endregion
            ai1 = player.maxMinions - NiSystem.UsedMinionSlots;
            #region º∆À„–›œ¢Œª÷√”Î“∆∂Ø
            Vector2 restpos = new Vector2(player.Center.X - player.direction * 50, player.Center.Y - 20f);
            if(Vector2.Distance(Projectile.Center,restpos) > 5)
            {
                Projectile.Center = Vector2.Lerp(Projectile.Center, restpos, 0.07f);
            }
            #endregion
            #region ªÊ÷∆¬ﬂº≠
            if(Projectile.frameCounter > 5)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if(Projectile.frame > 7)
            {
                Projectile.frame = 0;
            }
            Projectile.frameCounter++;
            #endregion
            #region ∑¢…‰µØƒª
            if (ai0 > 60)
            {
                NPC target = Projectile.FindTargetWithinRange(1000f, true);
                if (target != null)
                {
                    Vector2 totarget = Vector2.Normalize(target.Center - Projectile.Center) * 10f;
                    ShootRocket(totarget, 1f + ai1 );
                    ai0 = 0;
                }
            }
            #endregion

            ai0++;
        }

        public void ShootRocket(Vector2 velocity,float damagemul)
        {
            if(MyPickAmmo(out int pickedprojID, out int damage))
            {
                Projectile projectile = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.Center, velocity, pickedprojID, (int)(player.GetTotalDamage(DamageClass.Summon).ApplyTo(damage * damagemul)), 4f, player.whoAmI);
                
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 10;
                projectile.TryGetGlobalProjectile<SeeriGProj>(out SeeriGProj se);
                se.Seeried = true;
            }
        }

        public bool MyPickAmmo(out int pickedprojID, out int damage)
        {
            pickedprojID = -1;
            damage = 40;
            Item item1 = null;
            for(int i = 3; i < 10; i++)
            {
                if(player.armor[i].type == ModContent.ItemType<Seeri>())
                {
                    item1 = player.armor[i];//’“seeri
                }
            }
            Item item = player.ChooseAmmo(item1);//’“ƒ‹…‰µƒµØ“©
            if (item != null)
            {
                damage = item.damage;
                if (AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.TryGetValue(ItemID.RocketLauncher, out Dictionary<int, int> value) && value.TryGetValue(item.type, out pickedprojID))
                {
                    return true;
                }
            }
            else
            {
                pickedprojID = 134;
                return true;
            }
            return false;
        }
    }
}

