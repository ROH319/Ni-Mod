using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Ni.Core;

namespace Ni.Projectiles.Minions
{
    public abstract class BaseMinion : BaseProj
    {
        public virtual int BuffType => 0;
        public virtual bool CheckActive(ref bool check)
        {
            return check;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
        }
        public virtual void QuickMinion(int width, int height, int damage, float knockBack, float scale, int minionSlots)
        {
            QuickSD(width, height, damage, DamageClass.Summon, knockBack, true, false, -1, 0, -1, scale, 114514, false, true, true, true);
            Projectile.netImportant = true;
            Projectile.minionSlots = minionSlots;
            Projectile.ContinuouslyUpdateDamageStats = true;
        }

    }
}

