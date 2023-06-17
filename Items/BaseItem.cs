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
        /// <param name="itemUseStyleID">��Ʒʹ������ID��None->�� Swing->���� EatFood->��ʳ��<para />Thrust->ɡ�̳� HoldUp->��������ˮ��/ħ����Shoot->Զ�̡�ħ��������������<para />DrinkLong->����ҩˮ DrinkLiquid->ҩˮ Rapier->�̽����ǹ�</param>
        /// <param name="channel"></param>
        /// <param name="knockBack"></param>
        /// <param name="maxStack">���ѵ���</param>
        /// <param name="itemRarityID">ϡ�ж�ID��Quest��������Ʒ��Ⱦ��ֲ��������� Gray����ɫ White����ɫ��������Ҿߡ��������ϡ�����װ������������ Blue����ɫ�����ڵ�����Ʒ��ҩˮ Green����ɫ����ǰ���ڣ�������ס������ڵ�<para />Orange����ɫ����ǰ���ڣ�����������װ�� LightRed��ǳ��ɫ��������� Pink���ۺ�ɫ��������ڣ���ʥ���Լ����������� LightPurple��ǳ��ɫ����������ǰ�������Ʒ Lime������ɫ������ʯ�ޡ������ֵ�����<para />Yellow����ɫ�������ͽǰ������ Cyan����ɫ��������Ƭ�����ܲ��ֵ������������Ʒ Red����ɫ�������¼������ܲ��� Purple����ɫ��ԭ�������� Expert��ר�ң��ʺ�ɫ Master����ʦ�����ɫ</param>
        /// <param name="material"></param>
        /// <param name="consumable"></param>
        /// <param name="accessory"></param>
        /// <param name="noMelee"></param>
        /// <param name="noUseGraphic">û��ʹ��ʱ��ͼ</param>
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

