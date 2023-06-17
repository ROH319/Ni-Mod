using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Ni.Items.Weapons;

namespace Ni.Projectiles
{
    public abstract class BaseHeldProj : BaseProj
    {
        /// <summary>
        /// 这个弹幕对应的武器
        /// </summary>
        public virtual int Weapon => 0;
        public Item hItem => (player.HeldItem.type == Weapon) ? player.HeldItem : null;
        
        /// <summary>
        /// 能否造成伤害
        /// </summary>
        public virtual bool Damagable => false;
        /// <summary>
        /// 只在使用时造成伤害
        /// </summary>
        public virtual bool DamagableOnlyInUse => false;
        /// <summary>
        /// 不能造成伤害的弹幕的SD
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public virtual void QuickSDHELD1(int width,int height,int damage,DamageClass damageClass)
        {
            QuickSD(width, height, damage, damageClass, 0f, true, false, -1);
        }
        /// <summary>
        /// 能造成伤害的弹幕的SD
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="damage"></param>
        /// <param name="damageClass"></param>
        /// <param name="knockBack"></param>
        /// <param name="extraUpdates"></param>
        /// <param name="timeLeft"></param>
        public virtual void QuickSDHELD2(int width,int height,int damage,DamageClass damageClass,float knockBack,int extraUpdates,int timeLeft = 1145141919)
        {
            QuickSD(width, height, damage, damageClass, knockBack, true, false, -1, extraUpdates, -1, 1, timeLeft);
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (Damagable)
            {
                if (DamagableOnlyInUse)
                {
                    if (!player.ItemAnimationActive)
                    {
                        return false;
                    }
                }
                /*float point = 0f;
                Vector2 endPoint = Projectile.Center + Projectile.rotation.ToRotationVector2() * (Projectile.width / 2);
                Vector2 startPoint = Projectile.Center - Projectile.rotation.ToRotationVector2() * (Projectile.width / 2);
                return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), startPoint, endPoint, Projectile.height, ref point);*/
                return NiUtil.CheckAABBvLineColliding(Projectile, targetHitbox);
            }
            return false;
        }
        public override bool PreAI()
        {
            if (player.HeldItem.type != Weapon)
            {
                Projectile.Kill();
            }
            player.heldProj = Projectile.whoAmI;
            player.ChangeDirEX(false);
            
            return true;
        }
    }
}

