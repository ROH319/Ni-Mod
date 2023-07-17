using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;

namespace Ni.Items.AccEffects
{
    public class AccNoMercy : BaseAcc
    {
        public bool NoMercy;
        public override void PostUpdate()
        {
            if (!NoMercy) return;
            foreach (NPC npc in Main.npc)
            {
                if (!CanExecute(npc)) return;
                npc.life = 0;
                npc.checkDead();
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), Color.DarkRed, npc.IsBoss() ? "处决BOSS！" : "处决！");
            }
            base.PostUpdate();
        }
        public bool CanExecute(NPC npc) => npc.lifeMax != 0 && npc.active && (float)((float)npc.life / npc.lifeMax) <= (npc.IsBoss() ? 0.05 : 0.15) && !npc.immortal && npc.type != NPCID.GolemHead && Vector2.Distance(Player.Center, npc.Center) < 1200;
        public override void ResetEffects()
        {
            NoMercy = false;
            base.ResetEffects();
        }
        
    }
}

