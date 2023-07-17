using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria;
using Microsoft.Xna.Framework;

namespace Ni.Helpers
{
    public static class WorldGenHelper
    {
        public static void Texture2TileGenerate(int x, int y, int tileType, int tileStyle = 0, bool active = true, bool removeLiquid = true, bool silent = false, bool sync = true)
        {
            try
            {
                Console.WriteLine($"{x} {y} {tileType}");
                Tile t = Main.tile[x, y];
                t.ClearEverything();
                if (tileType > 0)
                {
                    Console.WriteLine("PlaceTile" + "\n");
                    WorldGen.PlaceTile(x, y, tileType, style: tileStyle);
                }

                //Tile Mtile = Main.tile[x, y];

                //if (!WorldGen.InWorld(x, y))
                //    return;
                //TileObjectData data = tileType <= -1 ? null : TileObjectData.GetTileData(tileType, tileStyle);
                //int width = data == null ? 1 : data.Width;
                //int height = data == null ? 1 : data.Height;
                //int tileWidth = tileType == -1 || data == null ? 1 : data.Width;
                //int tileHeight = tileType == -1 || data == null ? 1 : data.Height;
                //byte oldSlope = (byte)Main.tile[x, y].Slope;
                //bool oldHalfBrick = Main.tile[x, y].IsHalfBlock;
                //if (tileType != -1)
                //{
                //    WorldGen.destroyObject = true;
                //    if (width > 1 || height > 1)
                //    {
                //        int xs = x;
                //        int ys = y;
                //        Vector2 newPos = TileHelper.FindTopLeft(xs, ys);    //找到左上角
                //        for (int x1 = 0; x1 < width; x1++)      //把原有物块清了
                //            for (int y1 = 0; y1 < height; y1++)
                //            {
                //                int x2 = (int)newPos.X + x1;
                //                int y2 = (int)newPos.Y + y1;
                //                if (x1 == 0 && y1 == 0 && Main.tile[x2, y2].TileType == 21)
                //                    KillChestAndItems(x2, y2);
                //                Main.tile[x, y].TileType = 0;
                //                if (!silent)
                //                    WorldGen.KillTile(x, y, false, true, true);
                //                if (removeLiquid)
                //                    GenerateLiquid(x2, y2, 0, true, 0, false);
                //            }
                //        for (int x1 = 0; x1 < width; x1++)      //帧图
                //            for (int y1 = 0; y1 < height; y1++)
                //            {
                //                int x2 = (int)newPos.X + x1;
                //                int y2 = (int)newPos.Y + y1;
                //                WorldGen.SquareTileFrame(x2, y2);
                //                WorldGen.SquareWallFrame(x2, y2);
                //            }
                //    }
                //    else if (!silent)
                //        WorldGen.KillTile(x, y, false, true, true);
                //    WorldGen.destroyObject = false;
                //    if (active)
                //    {
                //        if (tileWidth <= 1 && tileHeight <= 1 && !Main.tileFrameImportant[tileType])        //直接放置没有帧图的物块
                //        {
                //            Main.tile[x, y].TileType = (ushort)tileType;
                //            Mtile.HasTile = true;
                //            WorldGen.SquareTileFrame(x, y);
                //        }
                //        else
                //        {
                //            WorldGen.destroyObject = true;
                //            if (!silent)
                //            {
                //                for (int x1 = 0; x1 < tileWidth; x1++)
                //                    for (int y1 = 0; y1 < tileHeight; y1++)
                //                        WorldGen.KillTile(x + x1, y + y1, false, true, true);
                //            }
                //            WorldGen.destroyObject = false;
                //            int genX = x;
                //            int genY = tileType == 10 ? y : y + height;
                //            WorldGen.PlaceTile(genX, genY, tileType, true, true, -1, tileStyle);    //放置有帧图的物块
                //            for (int x1 = 0; x1 < tileWidth; x1++)
                //                for (int y1 = 0; y1 < tileHeight; y1++)
                //                    WorldGen.SquareTileFrame(x + x1, y + y1);
                //        }
                //    }
                //    else
                //        Mtile.HasTile = false;
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Ni WorldGen Error");
            }

        }

        public static bool KillChestAndItems(int x, int y)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (Main.chest[i] != null && Main.chest[i].x == x && Main.chest[i].y == y)
                {
                    Main.chest[i] = null;
                    return true;
                }
            }
            return false;
        }

        public static void GenerateLiquid(int x, int y, int liquidType, bool updateFlow = true, int liquidHeight = 255, bool sync = true)
        {
            Tile Mtile = Main.tile[x, y];

            if (!WorldGen.InWorld(x, y))
                return;

            liquidHeight = (int)MathHelper.Clamp(liquidHeight, 0, 255);
            Main.tile[x, y].LiquidAmount = (byte)liquidHeight;

            if (liquidType == 0)
                Mtile.LiquidType = LiquidID.Water;
            else if (liquidType == 1)
                Mtile.LiquidType = LiquidID.Lava;
            else if (liquidType == 2)
                Mtile.LiquidType = LiquidID.Honey;
            if (updateFlow)
                Liquid.AddWater(x, y);
            if (sync && Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, x, y, 1);
        }

    }
}
