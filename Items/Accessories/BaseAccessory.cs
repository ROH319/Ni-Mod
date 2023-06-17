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
        /// ��Ʒ��Ʒ��SD
        /// </summary>
        /// <param name="itemRarityID">ϡ�ж�ID��Quest��������Ʒ��Ⱦ��ֲ��������� Gray����ɫ White����ɫ��������Ҿߡ��������ϡ�����װ������������ Blue����ɫ�����ڵ�����Ʒ��ҩˮ Green����ɫ����ǰ���ڣ�������ס������ڵ�<para />Orange����ɫ����ǰ���ڣ�����������װ�� LightRed��ǳ��ɫ��������� Pink���ۺ�ɫ��������ڣ���ʥ���Լ����������� LightPurple��ǳ��ɫ����������ǰ�������Ʒ Lime������ɫ������ʯ�ޡ������ֵ�����<para />Yellow����ɫ�������ͽǰ������ Cyan����ɫ��������Ƭ�����ܲ��ֵ������������Ʒ Red����ɫ�������¼������ܲ��� Purple����ɫ��ԭ�������� Expert��ר�ң��ʺ�ɫ Master����ʦ�����ɫ</param>
        /// <param name="material">�Ƿ�Ϊ����</param>
        public virtual void QuickSDAc(int itemRarityID, bool material, int sellpricebygold)
        {
            QuickSD(24, 24, 0, DamageClass.Default, 0, 0, false, 0, 1, itemRarityID, material, false, true, true, true, Item.sellPrice(0, sellpricebygold));
        }
    }
}

