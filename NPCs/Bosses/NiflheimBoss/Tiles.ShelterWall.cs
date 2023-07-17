using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class ShelterWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallLight[Type] = true;
            base.SetStaticDefaults();
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.55f;
            g = 0.76f;
            b = 1f;
            base.ModifyLight(i, j, ref r, ref g, ref b);
        }
    }
}
