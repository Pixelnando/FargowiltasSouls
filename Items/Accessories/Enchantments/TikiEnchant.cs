﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class TikiEnchant : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Tiki Enchantment");
            Tooltip.SetDefault(
@"You may continue to summon temporary minions and sentries after maxing out on your slots
Reduces attack speed of summon weapons when effect is activated
'Aku Aku!'");
            //             DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "提基魔石");
            //             Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese,
            // @"在召唤栏用光后你仍可以召唤临时的哨兵和仆从
            // 'Aku Aku!'");
        }

        protected override Color nameColor => new Color(86, 165, 43);
        public override string wizardEffect => "";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Lime;
            Item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoSoulsPlayer>().TikiEffect(hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.TikiMask)
            .AddIngredient(ItemID.TikiShirt)
            .AddIngredient(ItemID.TikiPants)
            //leaf wings
            .AddIngredient(ItemID.Blowgun)
            //toxic flask
            .AddIngredient(ItemID.PygmyStaff)
            .AddIngredient(ItemID.PirateStaff)
            //kaledoscope
            //.AddIngredient(ItemID.TikiTotem);

            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}
