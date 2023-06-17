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
        /// ������Ʒ��SD
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="damage"></param>
        /// <param name="damageClass"></param>
        /// <param name="crit"></param>
        /// <param name="useTime">ʹ��ʱ��</param>
        /// <param name="useAnimation">����ʱ��</param>
        /// <param name="itemUseStyleID">��Ʒʹ������ID��None->�� Swing->���� EatFood->��ʳ��<para />Thrust->ɡ�̳� HoldUp->��������ˮ��/ħ����Shoot->Զ�̡�ħ��������������<para />DrinkLong->����ҩˮ DrinkLiquid->ҩˮ Rapier->�̽����ǹ�</param>
        /// <param name="channel"></param>
        /// <param name="knockBack"></param>
        /// <param name="itemRarityID">ϡ�ж�ID��Quest��������Ʒ��Ⱦ��ֲ��������� Gray����ɫ White����ɫ��������Ҿߡ��������ϡ�����װ������������ Blue����ɫ�����ڵ�����Ʒ��ҩˮ Green����ɫ����ǰ���ڣ�������ס������ڵ�<para />Orange����ɫ����ǰ���ڣ�����������װ�� LightRed��ǳ��ɫ��������� Pink���ۺ�ɫ��������ڣ���ʥ���Լ����������� LightPurple��ǳ��ɫ����������ǰ�������Ʒ Lime������ɫ������ʯ�ޡ������ֵ�����<para />Yellow����ɫ�������ͽǰ������ Cyan����ɫ��������Ƭ�����ܲ��ֵ������������Ʒ Red����ɫ�������¼������ܲ��� Purple����ɫ��ԭ�������� Expert��ר�ң��ʺ�ɫ Master����ʦ�����ɫ</param>
        /// <param name="consumable"></param>
        /// <param name="material"></param>
        /// <param name="noMelee">��ͼ������˺�</param>
        /// <param name="noUseGraphic">û��ʹ��ʱ��ͼ</param>
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

