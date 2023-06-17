using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent.Creative;

namespace Ni.Items.Accessories
{
    public abstract class BaseAccessory : BaseItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        /// <summary>
        /// 饰品物品的SD
        /// </summary>
        /// <param name="itemRarityID">稀有度ID：Quest：任务物品，染料植物和任务鱼 Gray：灰色 White：白色，大多数家具、建筑材料、早期装备、制作材料 Blue：蓝色，早期掉落物品，药水 Green：绿色，肉前中期，死灵盔甲、星星炮等<para />Orange：橙色，肉前后期，地狱、丛林装备 LightRed：浅红色，肉后早期 Pink：粉红色，肉后中期，神圣套以及罕见掉落物 LightPurple：浅紫色，包括世花前最罕见的物品 Lime：青柠色，世花石巨、肉后丛林掉落物<para />Yellow：黄色，花后教徒前掉落物 Cyan：青色，月亮碎片，月总部分掉落物，开发者物品 Red：红色，月亮事件和月总产物 Purple：紫色，原版无例子 Expert：专家，彩虹色 Master：大师，火红色</param>
        /// <param name="material">是否为材料</param>
        public virtual void QuickSDAc(int itemRarityID, bool material, int sellpricebygold)
        {
            QuickSD(24, 24, 0, DamageClass.Default, 0, 0, false, 0, 1, itemRarityID, material, false, true, true, true, Item.sellPrice(0, sellpricebygold));
        }
    }
}

