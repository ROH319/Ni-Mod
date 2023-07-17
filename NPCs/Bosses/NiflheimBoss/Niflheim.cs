using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ni;
using Ni.Helpers;
using Ni.NPCs.Bosses.NiflheimBoss;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ni.NPCs.Bosses.NifelheimBoss
{
    public class Niflheim : SMNPC
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            NPC.width = 42;
            NPC.height = 33;
            NPC.damage = 0;
            NPC.lifeMax = 9000;
            NPC.defense = 10;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.value = Item.buyPrice(0, 5, 50, 0);
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.npcSlots = 50;
            NPC.boss = true;
            NPC.scale = 2f;
            //Music = MusicLoader.GetMusicSlot("Ni/Sounds/Dungreed/FrozenTime");
            Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Dungreed/Music/FrozenTime");
            
            CustomDrawSelf = true;
            base.SetDefaults();
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            base.BossLoot(ref name, ref potionType);
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);
        }
        public override void Initialize()
        {
            RegisterState(new AppearState());
            RegisterState(new IdleState());
            RegisterState(new DyingState());
            RegisterState(new FaintState());
            RegisterState(new IceCrystalRandom());
            RegisterState(new IceCrystalRegular());
            RegisterState(new Icicle());
        }
        public float GlobalTimer { get => NPC.ai[2]; set => NPC.ai[2] = value; }
        public override void AIBefore()
        {
            //Main.NewText($"{Music}");
            GlobalTimer++;
            if(NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }
            Player player = Main.player[NPC.target];

            if (player.dead)
            {
                NPC.Opacity -= 0.005f;
            }
            if(NPC.Opacity < 0.005f)
            {
                NPC.active = false;
            }
            //Main.NewText($"{currentState} {Timer} {NPC.ai[3]}");
            base.AIBefore();
        }

        public override bool CheckDead()
        {
            NPC.life = 1;
            NPC.dontTakeDamage = true;
            SetState<DyingState>();
            
            return false;
        }
        public List<NPC> IcePillars = new();
        public abstract class NiState : NPCState
        {
            public static List<NPCState> RandomAttackState = new() { new IceCrystalRandom(), new IceCrystalRegular() };
        }
        public class AppearState : NiState
        {
            public override int FrameSpeed() => 5;
            public override int FrameTotal(SMNPC npc, NPC nPC) => 16;
            public override Texture2D[] SelfTex(SMNPC npc) => AssetHelper.NiflheimEnter;
            public override void AI(SMNPC npc, NPC nPc)
            {
                nPc.dontTakeDamage = true;
                if(npc.Timer > FrameSpeed() * FrameTotal(npc,nPc))
                {
                    nPc.dontTakeDamage = false;
                    npc.SetState<IdleState>();
                }
            }
            public override void PostDraw(SMNPC npc, SpriteBatch sb, Vector2 screenPos, Color drawColor)
            {
                base.PostDraw(npc, sb, screenPos, drawColor);
            }
        }
        public abstract class IdleFrameState : NiState
        {
            public override int FrameSpeed() => 5;
            public override int FrameTotal(SMNPC npc, NPC nPC) => 6;
            public override Texture2D[] SelfTex(SMNPC npc) => AssetHelper.NiflheimIdle;
        }
        public class IdleState : IdleFrameState
        {
            public override void AI(SMNPC npc, NPC nPc)
            {
                if(npc.Timer > FrameSpeed() * FrameTotal(npc, nPc) * 2)
                {

                    npc.SetState(RandomAttackState[Main.rand.Next(0, RandomAttackState.Count)]);
                }
            }
        }
        public class FaintState : IdleFrameState
        {
            public override void AI(SMNPC npc, NPC nPC)
            {
            }
            public override void PostDraw(SMNPC npc, SpriteBatch sb, Vector2 screenPos, Color drawColor)
            {

                base.PostDraw(npc, sb, screenPos, drawColor);
            }
        }
        public abstract class AttackFrameState : NiState
        {
            public override int FrameSpeed() => 5;
            public override int FrameTotal(SMNPC npc, NPC nPC)
            {
                if (nPC.ai[3] == 0f) return 11;
                return 6;
            }
            public override Texture2D[] SelfTex(SMNPC npc) => (npc.NPC.ai[3] == 0f) ? AssetHelper.NiflheimAttack : AssetHelper.NiflheimIdle;
            public override void OnShiftState(SMNPC npc, NPC nPC)
            {
                nPC.ai[3] = 0f;
                base.OnShiftState(npc, nPC);
            }
            public override void AI(SMNPC npc, NPC nPC)
            {
                if (npc.Timer > FrameSpeed() * FrameTotal(npc, nPC) - 1 && nPC.ai[3] == 0f)
                {
                    nPC.ai[3]++;
                    nPC.frame.Y = 0;
                }
            }
        }
        public class IceCrystalRandom : AttackFrameState
        {
            public override void AI(SMNPC npc, NPC nPC)
            {
                base.AI(npc, nPC);
                if(npc.Timer == 45)
                {
                    SpawnProj(npc, nPC, Main.rand.Next(3, 6));
                }
                if(npc.Timer > 46 + 2 * 60)
                {
                    npc.SetState<IdleState>();
                }
            }
            public void SpawnProj(SMNPC npc, NPC nPc, int maxProjs)
            {
                for(int i = 0; i < maxProjs; i++)
                {
                    var p = Projectile.NewProjectileDirect(nPc.GetSource_FromAI(), 
                        nPc.Center + new Vector2(Main.rand.NextFloat(-600, 600), Main.rand.NextFloat(-400, 400)), 
                        Vector2.Zero, ModContent.ProjectileType<IceCrystal>(), 50, 0f, Main.player[nPc.target].whoAmI);
                }
                 
            }
        }
        public class IceCrystalRegular : AttackFrameState
        {
            public override void AI(SMNPC npc, NPC nPC)
            {
                base.AI(npc, nPC);
                if(npc.Timer % 45 == 0)
                {
                    var p = Projectile.NewProjectileDirect(nPC.GetSource_FromAI(), Main.player[nPC.target].Center,
                        Vector2.Zero, ModContent.ProjectileType<IceCrystal>(), 50, 0f, Main.player[nPC.target].whoAmI);
                }
                if(npc.Timer > 4 * 60 + 1)
                {
                    npc.SetState<IdleState>();
                }
            }
        }
        public class Icicle : AttackFrameState
        {
            public override void AI(SMNPC npc, NPC nPC)
            {
            }
        }
        public class DyingState : NiState
        {
            public override int FrameSpeed() => 5;
            public override int FrameTotal(SMNPC npc, NPC nPC) => 30;
            public override Texture2D[] SelfTex(SMNPC npc) => AssetHelper.NiflheimDie;
            public override void AI(SMNPC npc, NPC nPc)
            {
                nPc.dontTakeDamage = true;
                if(npc.Timer >= FrameSpeed() * FrameTotal(npc,nPc) - 1)
                {
                    nPc.life = 0;
                    nPc.active = false;
                    nPc.NPCLoot();
                }
            }
        }
    }
}

    
