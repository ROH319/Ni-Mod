using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles.Minions;

namespace Ni.Buffs
{
    public class SeeriBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            base.SetStaticDefaults();
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SeeriMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 114514;
            }

            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            base.Update(player, ref buffIndex);
        }
    }
}

