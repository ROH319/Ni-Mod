using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent;
using Ni.NiGlobalProj;

namespace Ni.Buffs
{
    public class FlameBarrierBuff : ModBuff
    {
        Player plr = null;
        public float scale;
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = false;
            base.SetStaticDefaults();
        }

        public override void Update(Player player, ref int buffIndex)
        {
            plr = player;

            if (player.buffTime[buffIndex] > 60)
            {
                if (scale < 1f)
                {
                    scale += 0.05f;
                }
                else
                {
                    scale = 1f;
                }
            }
            else
            {
                scale -= 0.016f;
                if(scale < 0.01f)
                {
                    player.DelBuff(buffIndex);
                    buffIndex--;
                }
            }

            base.Update(player, ref buffIndex);
        }
    }
}

