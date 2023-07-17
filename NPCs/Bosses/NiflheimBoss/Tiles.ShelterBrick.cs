using Microsoft.Xna.Framework;
using Ni.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class ShelterBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            MinPick = 114514;
            DustType = MyDustId.BlueIce;
            AddMapEntry(new Color(100, 153, 232));

            base.SetStaticDefaults();
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            base.ModifyLight(i, j, ref r, ref g, ref b);
        }
    }
}
