using Ni.NiModPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Ni.Projectiles;
using static System.Formats.Asn1.AsnWriter;

namespace Ni.NiGlobalProj
{
    public class NiGProj:GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public IEntitySource entitySource;
        public bool Carbine = false;
        public bool Barried = false;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            Player player = Main.player[projectile.owner];
            player.TryGetModPlayer(out NiPlayer niPlayer);
            entitySource = source;
            //Main.projectile[0].ai[0] += 0;
            #region 保存玩家拥有的召唤物
            if (projectile.minion && projectile.minionSlots > 0)
            {
                niPlayer.OwnedMinions.Add(projectile);
            }
            #endregion
            #region 魔法放大镜
            if (niPlayer.Magnifier && !projectile.hostile)
            {
                projectile.position = projectile.Center;
                projectile.scale *= 2f;
                //projectile.width += projectile.width;
                //projectile.height += projectile.height;
                projectile.width *= 2;
                projectile.height *= 2;
                projectile.Center = projectile.position;
                projectile.damage = (int)(projectile.damage * 1.5);
            }
            #endregion
            
        }
        public override bool PreAI(Projectile projectile)
        {
            #region 音速卡宾枪效果
            if (Carbine && projectile.numHits > 0)
            {
                projectile.CritChance = 100;
            }
            #endregion
            return base.PreAI(projectile);
        }
    }
}
