using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ObjectData;

namespace Ni.Helpers
{
    public static class TileHelper
    {
        public static Vector2 FindTopLeft(int x,int y)
        {
            Tile tile = Main.tile[x, y];
            if (tile == null) return new Vector2(x, y);
            TileObjectData data = TileObjectData.GetTileData(tile.TileType, 0);
            x -= tile.TileFrameX / 18 % data.Width;
            y -= tile.TileFrameY / 18 % data.Height;
            return new Vector2(x, y);
        }
    }
}
