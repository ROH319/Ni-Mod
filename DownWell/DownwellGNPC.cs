using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Runtime.CompilerServices;

namespace Ni.DownWell
{
    public class DownwellGNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool Spiked;
        public bool NoGravity;
        public override void Load()
        {
            Terraria.On_NPC.VanillaFindFrame += On_NPC_VanillaFindFrame;
            base.Load();
        }

        private void On_NPC_VanillaFindFrame(On_NPC.orig_VanillaFindFrame orig, NPC self, int num, bool isLikeATownNPC, int type)
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                switch (self.type)
                {
                    case 495:

                        self.frameCounter += 0.6;
                        if (self.frameCounter < 6)
                            self.frame.Y = 0;
                        else if (self.frameCounter < 12)
                            self.frame.Y = num;
                        else if (self.frameCounter < 18)
                            self.frame.Y = num * 2;
                        else if (self.frameCounter < 24)
                            self.frame.Y = num * 3;
                        else
                            self.frameCounter = 0;
                        return;
                    case 497:

                        self.frameCounter += 0.5;
                        if (self.frameCounter < 6)
                            self.frame.Y = 0;
                        else if (self.frameCounter < 12)
                            self.frame.Y = num;
                        else if (self.frameCounter < 18)
                            self.frame.Y = num * 2;
                        else if (self.frameCounter < 24)
                            self.frame.Y = num * 3;
                        else
                            self.frameCounter = 0;
                        return;
                    default:
                        break;
                }
            }
            orig(self, num, isLikeATownNPC, type);
        }

        public override void Unload()
        {
            Terraria.On_NPC.VanillaFindFrame -= On_NPC_VanillaFindFrame;
            base.Unload();
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                maxSpawns = 0;
            }
            base.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
        }
        public override void SetDefaults(NPC entity)
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                switch (entity.type)
                {
                    case 497:
                        entity.direction = 1;
                        entity.rotation = MathHelper.ToRadians(90);
                        entity.noGravity = true;
                        entity.knockBackResist = 0f;
                        break;
                    default:
                        break;
                }
            }
            base.SetDefaults(entity);
        }
        public override bool PreAI(NPC npc)
        {
            Main.player[Main.myPlayer].TryGetModPlayer<DownwellPlayer>(out DownwellPlayer downwellplayer);
            if (DownWellWorldGen.DownWellWorld)
            {
                if (downwellplayer.Timevoid)
                {
                    return false;
                }

                switch (npc.type)
                {
                    case 495:
                        npc.direction = (npc.velocity.X > 0) ? 1 : -1;
                        npc.spriteDirection = npc.direction;
                        Vector2 tilebottom = npc.position + new Vector2(npc.direction == 1 ? npc.width : 0, npc.height + 2);
                        if (npc.collideX)
                        {
                            npc.direction = -npc.direction;
                        }
                        else if (!Main.tile[tilebottom.ToTileCoordinates()].HasTile)
                        {
                            npc.direction = -npc.direction;

                        }
                        npc.velocity.X = 0.5f * npc.direction;
                        return false;
                    case 497:
                        
                        npc.direction = (npc.velocity.Y > 0) ? 1 : -1;
                        npc.spriteDirection = npc.direction;
                        npc.ai[0] = -1;
                        if (!npc.collideX)
                        {
                            npc.velocity.X = -3;
                        }
                        //npc.scale = 1.3f;
                        if (npc.collideY)
                        {
                            npc.directionY = -npc.directionY;
                        }

                        npc.velocity.Y = 0.2f * npc.directionY;
                        return false;
                    default:
                        break;
                }
            }
            return base.PreAI(npc);
        }
        public override void AI(NPC npc)
        {
            base.AI(npc);
        }
        public override void OnKill(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            DownwellPlayer dwplayer = player.GetModPlayer<DownwellPlayer>();
            dwplayer.Combo += 1;
            base.OnKill(npc);
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            DownwellPlayer dwplayer = Main.player[Main.myPlayer].GetModPlayer<DownwellPlayer>();
            //Utils.DrawRect(spriteBatch, dwplayer.TestRect, Color.Red);
            base.PostDraw(npc, spriteBatch, screenPos, drawColor);
        }
    }
}

