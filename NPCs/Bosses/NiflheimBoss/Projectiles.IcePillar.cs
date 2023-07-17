using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles;
using Microsoft.Xna.Framework;
using Ni.Helpers;
using Terraria.ID;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class IcePillar : SMNPC
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
            NPC.width = 45;
            NPC.height = 12;
            NPC.damage = 0;
            NPC.lifeMax = 200;
            NPC.defense = 10;
            NPC.scale = 2f;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.npcSlots = 2;
            CustomDrawSelf = true;
            base.SetDefaults();
        }
        public override void Initialize()
        {
            ;
        }

        public override void AIBefore()
        {
            base.AIBefore();
        }
        public override bool CheckDead()
        {
            NPC.life = 1;
            NPC.dontTakeDamage = true;
            SetState<DyingState>();
            return false;
        }
        public class AppearState : NPCState
        {
            public override int FrameSpeed() => 5;
            public override int FrameTotal(SMNPC npc, NPC nPC) => 19;
            public override Texture2D[] SelfTex(SMNPC npc) => AssetHelper.IcePillar;
            public override void AI(SMNPC npc, NPC nPC)
            {

            }
        }
        public class DyingState : NPCState
        {
            public override int FrameSpeed() => 5;
            public override int FrameTotal(SMNPC npc, NPC nPC) => 3;
            public override Texture2D[] SelfTex(SMNPC npc) => AssetHelper.IcePillarDestroy;
            public override void AI(SMNPC npc, NPC nPc)
            {
                nPc.dontTakeDamage = true;
                if (npc.Timer >= FrameSpeed() * FrameTotal(npc,nPc) - 1)
                {
                    nPc.life = 0;
                    nPc.active = false;
                }
            }
        }
    }

}
