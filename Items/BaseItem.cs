using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.Items
{
    public abstract class BaseItem : ModItem
    {
        public SpriteBatch sb => Main.spriteBatch;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="damage"></param>
        /// <param name="damageClass"></param>
        /// <param name="crit"></param>
        /// <param name="itemUseStyleID">物品使用类型ID：None->无 Swing->挥舞 EatFood->吃食物<para />Thrust->伞刺出 HoldUp->举起（生命水晶/魔镜）Shoot->远程、魔法武器、悠悠球<para />DrinkLong->回忆药水 DrinkLiquid->药水 Rapier->短剑，星光</param>
        /// <param name="channel"></param>
        /// <param name="knockBack"></param>
        /// <param name="maxStack">最大堆叠数</param>
        /// <param name="itemRarityID">稀有度ID：Quest：任务物品，染料植物和任务鱼 Gray：灰色 White：白色，大多数家具、建筑材料、早期装备、制作材料 Blue：蓝色，早期掉落物品，药水 Green：绿色，肉前中期，死灵盔甲、星星炮等<para />Orange：橙色，肉前后期，地狱、丛林装备 LightRed：浅红色，肉后早期 Pink：粉红色，肉后中期，神圣套以及罕见掉落物 LightPurple：浅紫色，包括世花前最罕见的物品 Lime：青柠色，世花石巨、肉后丛林掉落物<para />Yellow：黄色，花后教徒前掉落物 Cyan：青色，月亮碎片，月总部分掉落物，开发者物品 Red：红色，月亮事件和月总产物 Purple：紫色，原版无例子 Expert：专家，彩虹色 Master：大师，火红色</param>
        /// <param name="material"></param>
        /// <param name="consumable"></param>
        /// <param name="accessory"></param>
        /// <param name="noMelee"></param>
        /// <param name="noUseGraphic">没有使用时贴图</param>
        public virtual void QuickSD(int width,int height,int damage,DamageClass damageClass,int crit,int itemUseStyleID,bool channel,float knockBack,int maxStack,int itemRarityID,bool material,bool consumable, bool accessory,bool noMelee,bool noUseGraphic,int sellprice)
        {
            Item.width = width;
            Item.height = height;
            Item.accessory = accessory;
            Item.damage = damage;
            Item.DamageType = damageClass;
            Item.crit = crit;
            Item.useStyle = itemUseStyleID;
            Item.maxStack = maxStack;
            Item.rare = itemRarityID;
            Item.material = material;
            Item.channel = channel;
            Item.consumable = consumable;
            Item.knockBack = knockBack;
            Item.noMelee = noMelee;
            Item.noUseGraphic = noUseGraphic;
            Item.value = sellprice;
        }
        
    }

}

