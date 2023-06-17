using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using System.Data.Common;
using Ni.Projectiles;
using Terraria.GameContent.Creative;

namespace Ni.Items.Weapons
{
    public abstract class BaseWeapon : BaseItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        /// <summary>
        /// 武器物品的SD
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="damage"></param>
        /// <param name="damageClass"></param>
        /// <param name="crit"></param>
        /// <param name="useTime">使用时间</param>
        /// <param name="useAnimation">动画时间</param>
        /// <param name="itemUseStyleID">物品使用类型ID：None->无 Swing->挥舞 EatFood->吃食物<para />Thrust->伞刺出 HoldUp->举起（生命水晶/魔镜）Shoot->远程、魔法武器、悠悠球<para />DrinkLong->回忆药水 DrinkLiquid->药水 Rapier->短剑，星光</param>
        /// <param name="channel"></param>
        /// <param name="knockBack"></param>
        /// <param name="itemRarityID">稀有度ID：Quest：任务物品，染料植物和任务鱼 Gray：灰色 White：白色，大多数家具、建筑材料、早期装备、制作材料 Blue：蓝色，早期掉落物品，药水 Green：绿色，肉前中期，死灵盔甲、星星炮等<para />Orange：橙色，肉前后期，地狱、丛林装备 LightRed：浅红色，肉后早期 Pink：粉红色，肉后中期，神圣套以及罕见掉落物 LightPurple：浅紫色，包括世花前最罕见的物品 Lime：青柠色，世花石巨、肉后丛林掉落物<para />Yellow：黄色，花后教徒前掉落物 Cyan：青色，月亮碎片，月总部分掉落物，开发者物品 Red：红色，月亮事件和月总产物 Purple：紫色，原版无例子 Expert：专家，彩虹色 Master：大师，火红色</param>
        /// <param name="consumable"></param>
        /// <param name="material"></param>
        /// <param name="noMelee">贴图不造成伤害</param>
        /// <param name="noUseGraphic">没有使用时贴图</param>
        public virtual void QuickSDWe(int width, int height, int damage, DamageClass damageClass, int crit, int useTime, int useAnimation, int itemUseStyleID, bool channel, float knockBack, int itemRarityID, bool consumable, bool material, bool noMelee, bool noUseGraphic, int sellpricebygold)
        {
            QuickSD(width, height, damage, damageClass, crit, itemUseStyleID, channel, knockBack, 1, itemRarityID, material, consumable, false, noMelee, noUseGraphic, Item.sellPrice(0, sellpricebygold));
            Item.useTime = useTime;
            Item.useAnimation = useAnimation;
        }


        public virtual void SpawnHeldProj(Player player, int type)
        {
            Projectile projectile;
            if (player.ownedProjectileCounts[type] < 1)
            {
                projectile = Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), player.Center, Vector2.Zero, type, Item.damage, Item.knockBack,player.whoAmI, 0, 0);
            }
        }
    }
}

