using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using XPT.Core.Audio.MP3Sharp.Decoding.Decoders.LayerIII;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public abstract class BaseRotateProj:BaseProj
    {
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return NiUtils.CheckAABBvLineColliding(Projectile, targetHitbox);
        }
    }
}
