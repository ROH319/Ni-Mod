using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;
using Ni.Items.Accessories;

namespace Ni.Buffs
{
    public class FlameCooldownDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
            base.SetStaticDefaults();
        }

        public override void Update(Player player, ref int buffIndex)
        {
            NiPlayer niPlayer = player.GetModPlayer<NiPlayer>();
            bool hasacc = false;
            //for(int i = 3; i < 10; i++)
            //{
            //    if (player.armor[i].type == ModContent.ItemType<FlameBarrier>())
            //    {
            //        hasacc = true;
            //        break;
            //    }
            //}
            //if (!hasacc)
            //{
            //    player.buffTime[buffIndex] += 1;
            //}
            //Main.NewText($"{niPlayer.FlameBarrier}");
            base.Update(player, ref buffIndex);
        }
    }
}

