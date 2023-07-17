using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader.Core;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;

namespace Ni.Core.Systems.ParticleSystem
{
    public class ParticleSystem : ModSystem
    {
        public static List<BasicParticle> particles;
        public override void Load()
        {
            particles = new();
            foreach(Type type in AssemblyManager.GetLoadableTypes(Mod.Code))
            {
                if(type.IsSubclassOf(typeof(BasicParticle)) && !type.IsAbstract && type != typeof(BasicParticle))
                {
                    BasicParticle instance = (BasicParticle)FormatterServices.GetUninitializedObject(type);
                    instance.Register();
                }
            }
            Terraria.On_Main.DrawDust += On_Main_DrawDust;
            base.Load();
        }
        public override void Unload()
        {
            particles = null;
            Terraria.On_Main.DrawDust -= On_Main_DrawDust;
            base.Unload();
        }
        public static BasicParticle Create(BasicParticle newoneYourself)
        {
            if (Main.dedServ || Main.gamePaused || newoneYourself == null) return null;
            particles?.Add(newoneYourself);
            newoneYourself.OnSpawn();
            return newoneYourself;
        }
        public override void PostUpdateDusts()
        {
            foreach(BasicParticle p in particles)
            {
                p.BaseUpdate();
            }
            base.PostUpdateDusts();
        }
        public void On_Main_DrawDust(On_Main.orig_DrawDust orig, Main self)
        {
            orig(self);
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.Transform);
            DrawParticles(Main.spriteBatch);
            Main.spriteBatch.End();
        }

        public static void DrawParticles(SpriteBatch spriteBatch)
        {
            foreach(BasicParticle p in particles)
            {
                p.Draw();
            }
        }

    }
}

