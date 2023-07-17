
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Ni.DownWell
{
    public class DownwellPlayer : ModPlayer
    {
        public static ModKeybind JumpKey;
        public Rectangle TestRect = new Rectangle(0, 0, 1, 1);
        public int FireBufferFrame;
        public bool KeyUpJump;
        public bool JustPressedJump;
        public bool JumpInAir;
        public float Jumpvel;
        public float Downvel;
        public float Charger;
        public float MaxCharger;
        public int Combo;
        public Vector2 Backlashvel = new Vector2(0,-20);
        public bool Timevoid;

        public bool FreeShoot;
        public override void Load()
        {
            JumpKey = KeybindLoader.RegisterKeybind(Mod, "JumpKey", Microsoft.Xna.Framework.Input.Keys.Space);
            Terraria.On_Player.CheckCrackedBrickBreak += On_Player_CheckCrackedBrickBreak;
            Terraria.On_Player.JumpMovement += On_Player_JumpMovement;
            base.Load();
        }

        private void On_Player_JumpMovement(On_Player.orig_JumpMovement orig, Player self)
        {
            if (DownWellWorldGen.DownWellWorld && !Collision.SolidCollision(self.position + new Vector2(0, self.height), self.width, 2) && !TileID.Sets.Platforms[Main.tile[(self.position + new Vector2(0,self.height)).ToTileCoordinates()].TileType] && JumpKey != null)
            {
                Tile tile1 = Main.tile[(self.position + new Vector2(0, self.height)).ToTileCoordinates()];
                Tile tile2 = Main.tile[(self.position + new Vector2(self.width, self.height)).ToTileCoordinates()];

                if (!JumpKey.JustReleased)
                {
                    //return;
                }
            }
            orig(self);
        }

        private void On_Player_CheckCrackedBrickBreak(On_Player.orig_CheckCrackedBrickBreak orig, Player self)
        {
            if (!DownWellWorldGen.DownWellWorld)
            {
                orig(self);
            }
        }
        public override void Unload()
        {
            JumpKey = null;
            Terraria.On_Player.CheckCrackedBrickBreak -= On_Player_CheckCrackedBrickBreak;
            Terraria.On_Player.JumpMovement -= On_Player_JumpMovement;
            base.Unload();
        }
        public override void OnEnterWorld()
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                Combo = 0;
                MaxCharger = 8;
                Charger = MaxCharger;
                Player.statLifeMax = 100;

                int posleftx = Main.spawnTileX - 10;
                int poslefty = Main.spawnTileY;
                int posrightx = Main.spawnTileX + 10;
                int length = Main.ActiveWorldFileData.WorldSizeY * 2 / 3;

                void ClearDungeon()
                {
                    for(int offsetx = 1; offsetx < 19; offsetx++)
                    {
                        for(int offsety = 0;offsety < length; offsety++)
                        {
                            Main.tile[posleftx + offsetx, poslefty + offsety].ClearEverything();
                        }
                    }
                }
                ClearDungeon();
                for (int offsetx = 0; offsetx < 20; offsetx++)
                {
                    if(offsetx>6 && offsetx < 14)
                    {
                        WorldGen.PlaceTile(posleftx + offsetx, poslefty, TileID.CrackedGreenDungeonBrick);
                        continue;
                    }
                    WorldGen.PlaceTile(posleftx + offsetx, poslefty, TileID.BlueDungeonBrick);
                }
                for (int offsety = 0; offsety < length; offsety++)
                {
                    WorldGen.PlaceTile(posleftx, poslefty + offsety, TileID.BlueDungeonBrick);
                    WorldGen.PlaceTile(posrightx, poslefty + offsety, TileID.BlueDungeonBrick);
                }

            }
            base.OnEnterWorld();
        }
        public override void PreSavePlayer()
        {
            base.PreSavePlayer();
        }
        
        public override void OnRespawn()
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                Combo = 0;
                MaxCharger = 10;
                Charger = MaxCharger;
            }
            base.OnRespawn();
        }
        public override void OnHurt(Player.HurtInfo info)
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                
                info.Damage = 20;
            }
            base.OnHurt(info);
        }
        public override void PreUpdate()
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                Player.AddBuff(BuffID.NoBuilding, 2);
            }
            base.PreUpdate();
        }
        public override void UpdateLifeRegen()
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                //Player.lifeRegen = 0;
                Player.lifeRegenCount = 0;
            }
            base.UpdateLifeRegen();
        }
        
        public override void PostUpdate()
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                if (Player.controlUseItem)
                {
                    Player.itemRotation = MathHelper.ToRadians(90);
                }
            }
            base.PostUpdate();
        }
        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();
        }
        public override void PreUpdateMovement()
        {
            if (DownWellWorldGen.DownWellWorld)
            {

                #region 在地上时刷新弹夹并结算连击
                //if (Collision.SolidCollision(Player.position + new Vector2(0, Player.height), Player.width, 2))
                if(Collision.TileCollision(Player.position, Player.velocity, Player.width, Player.height).Y == 0)
                {
                    
                    RefreshCharger();
                    AccountCombo();
                }
                #endregion
                if (true)
                {
                    
                    var tileloc = (Player.Center + new Vector2(0, 1)).ToTileCoordinates();
                    //Main.NewText($"SolidColli:{Collision.SolidCollision(Player.position + new Vector2(0, Player.height), Player.width, 2)}");
                    
                    #region 空中跳跃转射击
                    var velY = Collision.TileCollision(Player.position, Player.velocity, Player.width, Player.height).Y;

                    if (Collision.SolidCollision(Player.position + new Vector2(0, Player.height), Player.width, 2))
                    {
                        JumpInAir = false;
                    }
                    else
                    {
                        JumpInAir = true;
                    }
                    if (JumpKey.JustPressed && JumpKey.JustReleased)
                    {
                        JustPressedJump = true;
                    }
                    bool pressedJump = PlayerInput.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.W);
                    if (Charger > 0 && JumpKey.JustPressed && !Collision.SolidCollision(Player.position + new Vector2(0, Player.height), Player.width, 2) && JumpInAir)
                    {
                        Player.controlUseItem = true;
                        //Player.legFrame.Y = Player.legFrame.Height * 1;
                        //Player.gravDir = 0;
                        //Player.gravity = 0;
                        //Player.velocity.Y = 0;
                    }
                    if (JumpKey.JustPressed && Collision.SolidCollision(Player.position + new Vector2(0, Player.height), Player.width, 2) && !JumpInAir)
                    {
                        //Player.position.Y -= Player.jumpSpeedBoost * Player.jumpHeight;
                        JumpInAir = true;
                    }
                    if (JumpKey.JustPressed)
                    {
                        Player.controlJump = true;
                    }

                    #endregion
                }

                #region 踩人
                Rectangle rect1 = Player.getRect();
                Rectangle rect = new Rectangle(
                    rect1.X, 
                    rect1.Y + rect1.Height - 3, 
                    rect1.Width, 
                    (int)(MathHelper.Lerp(6, 20, Math.Abs(Player.velocity.Y) / 10))
                    );
                TestRect = rect;
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    if (!npc.active || npc.dontTakeDamage || npc.friendly || !Player.CanNPCBeHitByPlayerOrPlayerProjectile(npc))
                    {
                        continue;
                    }

                    Rectangle npcrect = npc.getRect().Modified(0, 0, 0, -npc.height * 2 / 3);
                    if (rect.Intersects(npcrect) && (npc.noTileCollide || Collision.CanHit(Player.position, Player.width, Player.height, npc.position, npc.width, npc.height)))
                    {
                        int direction = Player.direction;
                        if (Player.velocity.X < 0f)
                            direction = -1;

                        if (Player.velocity.X > 0f)
                            direction = 1;

                        if (Player.whoAmI == Main.myPlayer)
                            npc.StrikeInstantKill();
                        
                        //Player.velocity.Y = -3f;
                        Player.GiveImmuneTimeForCollisionAttack(3);
                        Bounce();//踩人效果
                        return;
                    }
                }
                #endregion

                if (FireBufferFrame > 0)
                {
                    Player.velocity.Y = 2 - FireBufferFrame / 2;
                    FireBufferFrame--;
                }
                //Player.velocity.Y = 2;
                base.PreUpdateMovement();
            }
        }
        public override void ResetEffects()
        {
            if (DownWellWorldGen.DownWellWorld)
            {
                JustPressedJump = false;
                Player.defaultItemGrabRange *= 2;
                #region 移动属性设置
                Player.runSlowdown *= 4f;
                Player.runAcceleration *= 2.5f;
                Player.accRunSpeed *= 2.5f;
                Player.noFallDmg = true;
                Player.jumpSpeedBoost += 5f;
                Player.maxFallSpeed *= 1f;
                Player.gravity *= 1f;
                #endregion
            }
        }
        public void Bounce()
        {
            Player.velocity.Y = -8f;
            RefreshCharger();
        }
        public void RefreshCharger() => Charger = MaxCharger;
        public void AccountCombo()
        {
            if (Combo > 8)
            {
                Item.NewItem(Player.GetSource_FromThis(), Player.getRect(), ItemID.GoldCoin, 10, noGrabDelay: true);
            }
            if (Combo > 15)
            {
                MaxCharger += 1;
            }
            if (Combo > 25)
            {
                Player.Heal(20);
            }
            Combo = 0;
        }
    }
}
