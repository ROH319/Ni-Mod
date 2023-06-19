using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;

namespace Ni.Buffs
{
    public class ElectronicWhipDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            base.SetStaticDefaults();
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Main.rand.NextBool(8))
            {
                var d = Dust.NewDustPerfect(npc.Center, MyDustId.ElectricCyan, Helpers.NiUtils.Vector2RandUnit(5, 0, MathHelper.TwoPi), 0, default, 0.5f);
                d.noGravity = true;
            }
            base.Update(npc, ref buffIndex);
        }

    }
}

