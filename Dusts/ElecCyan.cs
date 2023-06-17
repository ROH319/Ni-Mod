using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using TemplateMod2.Utils;

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

    }
}

