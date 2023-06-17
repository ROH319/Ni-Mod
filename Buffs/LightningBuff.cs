using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.NiModPlayer;
using Ni.Projectiles.Minions;

namespace Ni.Buffs
{
    public class LightningBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<LightningOrb>()] > 0)
            {
                player.buffTime[buffIndex] = 114514;
            }

            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}

