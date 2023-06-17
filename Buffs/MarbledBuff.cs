using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.NiGlobalNPC;
using Ni.Items.AccEffects;

namespace Ni.Buffs
{
    public class MarbledBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = false;
            Main.debuff[Type] = true;
            base.SetStaticDefaults();
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.TryGetGlobalNPC<MarblesGNPC>(out MarblesGNPC gnpc);
            gnpc.Marbled = true;
            base.Update(npc, ref buffIndex);
        }
    }
}

