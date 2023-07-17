using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Ni.NPCs
{
    public abstract class NPCState
    {
        /// <summary>
        /// 帧图切换的速度，3就是每三帧切一次帧图
        /// </summary>
        public virtual int FrameSpeed() => 0;
        /// <summary>
        /// 贴图总帧数
        /// </summary>
        public virtual int FrameTotal(SMNPC npc, NPC nPC) => 0;
        public abstract void AI(SMNPC npc, NPC nPC);
        //public virtual void FindFrame(SMNPC npc) { }
        public virtual void OnShiftState(SMNPC npc, NPC nPC) { }
        public virtual void PostDraw(SMNPC npc, SpriteBatch sb, Vector2 screenPos, Color drawColor) { }
        public virtual void PreDraw(SMNPC npc, SpriteBatch sb, Vector2 screenPos, Color drawColor) { }
        public virtual Texture2D[] SelfTex(SMNPC npc) { return null; }
    }

    public abstract class SMNPC : ModNPC
    {
        public bool CustomDrawSelf = false;
        public NPCState currentState => npcStates[State - 1];
        private List<NPCState> npcStates = new List<NPCState>();
        private Dictionary<string, int> stateDict = new();
        
        private int State { get { return (int)NPC.ai[0]; } set { NPC.ai[0] = value; } }
        public int Timer { get { return (int)NPC.ai[1]; } set { NPC.ai[1] = value; } }

        /// <summary>
        /// 把当前状态变为指定的弹幕状态实例
        /// </summary>
        /// <typeparam name="T">注册过的<see cref="ProjState"/>类名</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public void SetState<T>() where T : NPCState
        {
            var name = typeof(T).FullName;
            SetStateInner(name);
        }

        public void SetState(NPCState state)
        {
            var name = state.GetType().FullName;
            SetStateInner(name);
        }

        private void SetStateInner(string name)
        {
            if (!stateDict.ContainsKey(name)) throw new ArgumentException("这个状态并不存在");
            State = stateDict[name];
            Timer = 0;
            NPC.frame.Y = 0;
            NPC.frameCounter = 0;
            currentState.OnShiftState(this, NPC);
        }

        /// <summary>
        /// 注册状态
        /// </summary>
        /// <typeparam name="T">需要注册的<see cref="ProjState"/>类</typeparam>
        /// <param name="state">需要注册的<see cref="ProjState"/>类的实例</param>
        /// <exception cref="ArgumentException"></exception>
        protected void RegisterState<T>(T state) where T : NPCState
        {
            var name = typeof(T).FullName;
            if (stateDict.ContainsKey(name)) throw new ArgumentException("这个状态已经注册过了");
            npcStates.Add(state);
            stateDict.Add(name, npcStates.Count);
        }

        /// <summary>
        /// 初始化函数，用于注册弹幕状态
        /// </summary>
        public abstract void Initialize();

        public sealed override void AI()
        {
            if(State == 0)
            {
                Initialize();
                State = 1;
            }
            AIBefore();
            if (CustomDrawSelf)
            {
                if (NPC.frameCounter > currentState.FrameSpeed())
                {
                    NPC.frame.Y++;
                    NPC.frameCounter = 0;
                }
                if (NPC.frame.Y > currentState.FrameTotal(this,NPC) - 1)
                {
                    NPC.frame.Y = 0;
                }
                NPC.frameCounter++;
            }
            //currentState.FindFrame(this);
            currentState.AI(this,NPC);
            AIAfter();
        }

        /// <summary>
        /// 在状态机执行之前要执行的代码，可以重写
        /// </summary>
        public virtual void AIAfter() { }
        /// <summary>
        /// 在状态机执行之后要执行的代码，可以重写
        /// </summary>
        public virtual void AIBefore() { Timer++; }
        public sealed override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            currentState.PostDraw(this, spriteBatch, screenPos, drawColor);
            base.PostDraw(spriteBatch, screenPos, drawColor);
        }
        public sealed override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            currentState.PreDraw(this, spriteBatch, screenPos, drawColor);
            if (CustomDrawSelf)
            {
                Texture2D selfTex = currentState.SelfTex(this)[NPC.frame.Y];
                spriteBatch.Draw(selfTex, NPC.Center - Main.screenPosition, null, Color.White, NPC.rotation, selfTex.Size() / 2, NPC.scale, 0, 0);
                return false;
            }
            return base.PreDraw(spriteBatch, screenPos, drawColor);
        }
    }
}
