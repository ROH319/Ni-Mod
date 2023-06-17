using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.Items.AccEffects
{
    public class AccNoMercy : BaseAcc
    {

        public bool NoMercy;
        public override void PostUpdate()
        {
            if (NoMercy)
            {
                foreach (NPC npc in Main.npc)
                {
                    if (npc.lifeMax != 0
                        && npc.active
                        && (float)((float)npc.life / npc.lifeMax) <= (npc.IsBoss() ? 0.05 : 0.15)
                        && !npc.immortal
                        && npc.type != NPCID.GolemHead
                        )
                    {
                        if (Vector2.Distance(Player.Center, npc.Center) < 1200)
                        {
                            //怒了，CombatText怎么还有上限
                            CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), Color.DarkRed, npc.IsBoss() ? "处决BOSS！" : "处决！");
                            npc.life = 0;
                            npc.checkDead();
                        }
                    }
                }
            }
            base.PostUpdate();
        }
        public override void ResetEffects()
        {
            NoMercy = false;
            base.ResetEffects();
        }
        
    }
}

