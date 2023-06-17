using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using ReLogic.Content;

namespace Ni.Buffs
{
    public class PenNibBuff : ModBuff
    {
        int Alpha = 255;
        public Texture2D tex;
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            if (Main.netMode != NetmodeID.Server)
            {
                // 不! 要! 在服务器上加载材质!
                tex = AssetLoader.GetTex("Ni/Buffs/PenNibBuff");
            }
        }
        public override void Update(Player player, ref int buffIndex)
        {
            Alpha -= 6;
            if(Alpha < 110)
            {
                Alpha = 255;
            }
            base.Update(player, ref buffIndex);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            drawParams.DrawColor = new Color(drawParams.DrawColor.R + 100, drawParams.DrawColor.G + 100, drawParams.DrawColor.B + 100, Alpha);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            spriteBatch.Draw(tex, drawParams.Position, drawParams.DrawColor);
            //spriteBatch.Draw(tex, drawParams.MouseRectangle, new Color(drawParams.DrawColor.R + 50, drawParams.DrawColor.G + 50, drawParams.DrawColor.B + 50, Alpha));
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            return true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, int buffIndex, BuffDrawParams drawParams)
        {
            spriteBatch.AdditiveBegin();
            //spriteBatch.Draw(drawParams.Texture, drawParams.Position, new Color(drawParams.DrawColor.R + 100, drawParams.DrawColor.G + 100, drawParams.DrawColor.B +100, Alpha));
            spriteBatch.MyBegin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            base.PostDraw(spriteBatch, buffIndex, drawParams);
        }
        public override void Unload()
        {
            tex = null;
            base.Unload();
        }
    }
}

