using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Ni.NiModPlayer;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Ni.Projectiles;

namespace Ni.GlobalItems
{
    public class NiGItem:GlobalItem
    {
        public override bool InstancePerEntity => true;
        public bool Flowered;
        public override void SetDefaults(Item item)
        {
            //if(item.type == 4956)
            //{
            //    item.damage = 10000000;
            //}
            base.SetDefaults(item);
        }
        public override void HoldItem(Item item, Player player)
        {
            base.HoldItem(item, player);
        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            NiPlayer niPlayer = player.GetModPlayer<NiPlayer>();
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            player.TryGetModPlayer(out NiPlayer niPlayer);
            base.OnHitNPC(item, player, target, hit, damageDone);
        }

        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            player.TryGetModPlayer(out NiPlayer niPlayer);
        }


        public override void UpdateInventory(Item item, Player player)
        {
            NiPlayer niPlayer = player.GetModPlayer<NiPlayer>();
            base.UpdateInventory(item, player);
        }
        public override void PostUpdate(Item item)
        {
            base.PostUpdate(item);
        }
    }
}
