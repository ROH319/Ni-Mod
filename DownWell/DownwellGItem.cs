using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.DownWell;
using Ni.Items.Weapons;
using Terraria.Graphics.CameraModifiers;

namespace Ni.DownWell
{
    public class DownwellGItem : GlobalItem
    {
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (DownWellWorldGen.DownWellWorld && item.type != ModContent.ItemType<Ä£°å½£>())
            {
                DownwellPlayer dwplayer = player.GetModPlayer<DownwellPlayer>();
                if (dwplayer.Charger <= 0)
                {
                    return false;
                }
                Main.NewText($"Shoot{player.itemAnimation} {player.itemTime}");
                ChargerCost(player);
                item.autoReuse = true;
                item.reuseDelay = 1;
                dwplayer.FireBufferFrame = 7;
                var length = velocity.Length();
                velocity = new Vector2(length, 0).RotatedBy(MathHelper.ToRadians(90));
                var proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
                proj.scale *= 2;
                proj.position = proj.Center;
                proj.width *= 2;
                proj.height *= 2;
                proj.Center = proj.position;

                
                var strength = Main.rand.Next(8, 10);
                var directionVector = new Vector2(0, (Main.rand.NextBool(2) ? -1 : 1) * 6);
                PunchCameraModifier modifier = new(player.Center, directionVector, strength * 0.1f, 5f, 5, 600f, "NiCM");
                
                Main.instance.CameraModifiers.Add(modifier);
                return false;
            }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            base.ModifyShootStats(item, player, ref position, ref velocity, ref type, ref damage, ref knockback);
        }
        public static void ChargerCost(Player player)
        {
            DownwellPlayer dwplayer = player.GetModPlayer<DownwellPlayer>();
            if (dwplayer.FreeShoot)
            {
                dwplayer.FreeShoot = false;
                return;
            }
            float cost = 1f;
            switch (player.HeldItem.type)
            {
                case ItemID.Megashark://¾ÞÊÞöè
                    break;
                default:
                    break;
            }

            dwplayer.Charger -= cost;
        }
        
    }
}

