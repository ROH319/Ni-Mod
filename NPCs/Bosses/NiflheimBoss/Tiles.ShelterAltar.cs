using Ni.NPCs.Bosses.NifelheimBoss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Ni.NPCs.Bosses.NiflheimBoss
{
    public class ShelterAltar : ModTile
    {
        public override void SetStaticDefaults()
        {
            //Main.tileSolid[Type] = false;
            //Main.tileSolidTop[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            MinPick = 114514;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            base.SetStaticDefaults();
        }
        public override bool RightClick(int i, int j)
        {
            if (!Main.npc.Any<NPC>(npc => npc.type == ModContent.NPCType<Niflheim>() && npc.active))
            {
                var boss = NPC.NewNPCDirect(new AEntitySource_Tile(i, j, null), new Point16(i, j).ToWorldCoordinates(),
                    ModContent.NPCType<Niflheim>(), 0, 0, 0, 0, 0, Main.LocalPlayer.whoAmI);
                return true;
            }
            return base.RightClick(i, j);
        }
        public override bool Slope(int i, int j)
        {
            return false;
        }
    }
}
