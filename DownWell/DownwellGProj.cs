using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using rail;
using static Humanizer.In;
using Terraria.Audio;

namespace Ni.DownWell
{
    public class DownwellGProj : GlobalProjectile
    {
        public override bool PreAI(Projectile projectile)
        {
            Main.player[Main.myPlayer].TryGetModPlayer<DownwellPlayer>(out DownwellPlayer downwellplayer);
            if (downwellplayer.Timevoid)
            {
                return false;
            }
            return base.PreAI(projectile);
        }
        public override bool PreKill(Projectile projectile, int timeLeft)
        {
            if (!projectile.noDropItem)
            {
                if (projectile.type >= 736 && projectile.type <= 738)//µØÀÎËé×©
                {
                    SoundEngine.PlaySound(SoundID.Item127, projectile.position);
                    for (int num978 = 0; num978 < 3; num978++)
                    {
                        Dust.NewDust(projectile.position, 16, 16, projectile.type - 736 + 275);
                    }

                    int projx = (int)(projectile.Center.X / 16f);
                    int projy = (int)(projectile.Center.Y / 16f) + 1;
                    if (Main.myPlayer == projectile.owner && Main.tile[projx, projy].HasTile && TileID.Sets.CrackedBricks[Main.tile[projx, projy].TileType] && Main.rand.NextBool(2))
                    {
                        WorldGen.KillTile(projx, projy);
                        if (Main.netMode != NetmodeID.SinglePlayer)
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 20, projx, projy);
                    }
                }
            }
            return base.PreKill(projectile, timeLeft);
        }
    }
}

