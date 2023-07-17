using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles;
using Terraria.GameContent;
using ReLogic.Graphics;
using Ni.Helpers;

namespace Ni.DownWell
{
    public class DownWellLogicProj : BaseRotateProj
    {
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
            QuickSD(1, 1, 0, DamageClass.Default, 0f, true, false, -1);
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.timeLeft++;
            Projectile.Center = player.Center;
            if (!DownWellWorldGen.DownWellWorld)
            {
                Projectile.Kill();
            }
            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            player.TryGetModPlayer<DownwellPlayer>(out DownwellPlayer dwplr);
            sb.DrawString(FontAssets.MouseText.Value, $"{dwplr.Combo}", player.position - Main.screenPosition + new Vector2(5, -20), Color.White);
            base.PostDraw(lightColor);
        }
    }
}

