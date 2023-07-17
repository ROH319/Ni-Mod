using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;

namespace Ni.Dusts
{
    public class ElecCyan : ModDust
    {
        public override string Texture => "Ni/Images/ElecDust_Yellow1";

        public override void SetStaticDefaults()
        { 
            UpdateType = MyDustId.ElectricCyan;
            base.SetStaticDefaults();
        }

        public override bool Update(Dust dust)
        {
            if (dust.noLight)
            {
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), TorchID.Yellow, 1f);
            }
            return true;
        }
        public override bool PreDraw(Dust dust)
        {
            SpriteBatch sb = Main.spriteBatch;
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X - 1000, (int)Main.screenPosition.Y - 1050, Main.screenWidth + 2000, Main.screenHeight + 2100);
            sb.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.Transform);
            float num5 = Math.Abs(dust.velocity.X) + Math.Abs(dust.velocity.Y);
            num5 *= 0.3f;
            num5 *= 10f;
            if (num5 > 10f)
                num5 = 10f;

            for (int n = 0; n < num5; n++)
            {
                Vector2 velocity5 = dust.velocity;
                Vector2 value5 = dust.position - velocity5 * n;
                float scale6 = dust.scale * (1f - n / 10f);
                Color color5 = Lighting.GetColor((int)(dust.position.X + 4.0) / 16, (int)(dust.position.Y + 4.0) / 16);
                color5 = dust.GetAlpha(color5);
                sb.Draw(AssetHelper.ElecCyan_Dust, value5 - Main.screenPosition, dust.frame, color5, dust.rotation, new Vector2(4f, 4f), scale6, SpriteEffects.None, 0f);
            }
            Color newColor = Lighting.GetColor((int)(dust.position.X + 4.0) / 16, (int)(dust.position.Y + 4.0) / 16);
            newColor = dust.GetAlpha(newColor);
            sb.Draw(AssetHelper.ElecCyan_Dust, dust.position - Main.screenPosition, dust.frame, newColor, dust.GetVisualRotation(), new Vector2(4f, 4f), dust.scale, SpriteEffects.None, 0f);
            sb.End();
            return base.PreDraw(dust);
        }
    }
}

