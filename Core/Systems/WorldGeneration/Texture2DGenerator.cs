using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni.Core.Systems.WorldGeneration
{
    public class Texture2DGenerator
    {
        public int width, height;
        public TileInfos[,] tilegen;
        public Texture2DGenerator(int width,int height)
        {
            this.width = width;
            this.height = height;
            tilegen = new TileInfos[width, height];
        }
        public void Generate(int x,int y,bool sync)
        {
            for(int x1 = 0;x1 < width; x1++)
            {
                for(int y1 = 0;y1 < height; y1++)
                {
                    int current_x = x + x1;
                    int current_y = y + y1;
                    TileInfos info = tilegen[x1, y1];

                    if (info.tileID != -1)
                    {
                        WorldGenHelper.Texture2TileGenerate(current_x, current_y, info.tileID, info.tileStyle, info.tileID > -1, true, false, sync);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tileTex">读取的Texture2D</param>
        /// <param name="colorToTile">一个字典，对应的Vector2的X存储TileID，Y存储子ID（TileStyle属性）</param>
        /// <returns></returns>
        public static Texture2DGenerator GetTexGenerator(Texture2D tileTex, Dictionary<Color, Vector2> colorToTile)
        {
            Color[] tileData = new Color[tileTex.Width * tileTex.Height];
            tileTex.GetData(0, tileTex.Bounds, tileData, 0, tileTex.Width * tileTex.Height);
            int x, y;
            x = y = 0;
            Texture2DGenerator gen = new(tileTex.Width, tileTex.Height);
            for(int i = 0; i < tileData.Length; i++)
            {
                Color tileColor = tileData[i];
                int tileID = (int)(colorToTile.ContainsKey(tileColor) ? colorToTile[tileColor].X : -1);
                gen.tilegen[x, y] = new TileInfos(tileID, (int)(colorToTile.ContainsKey(tileColor) ? colorToTile[tileColor].Y : 0));
                x++;
                if(x >= tileTex.Width)
                {
                    x = 0;y++;
                }
                if (y >= tileTex.Height) break;
            }
            return gen;
        }
    }

    public class TileInfos
    {
        public int tileID = 0;
        public int tileStyle;
        public TileInfos(int tileID,int style)
        {
            this.tileID = tileID;
            tileStyle = style;
        }
    }
}
