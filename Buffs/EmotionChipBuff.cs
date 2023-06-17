using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.Buffs
{
    public class EmotionChipBuff: ModBuff
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.GetCritChance(DamageClass.Summon) += 100f;
            base.Update(player, ref buffIndex);
        }
    }
}

