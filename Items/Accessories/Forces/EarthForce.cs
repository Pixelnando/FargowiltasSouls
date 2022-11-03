using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Toggler;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Forces
{
    public class EarthForce : BaseForce
    {
        public static int[] Enchants => new int[]
        {
            ModContent.ItemType<CobaltEnchant>(),
            ModContent.ItemType<PalladiumEnchant>(),
            ModContent.ItemType<MythrilEnchant>(),
            ModContent.ItemType<OrichalcumEnchant>(),
            ModContent.ItemType<AdamantiteEnchant>(),
            ModContent.ItemType<TitaniumEnchant>()
        };

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Force of Earth");

            Tooltip.SetDefault(
$"[i:{ModContent.ItemType<CobaltEnchant>()}] Grants an explosion jump and you explode on hit\n" +
$"[i:{ModContent.ItemType<MythrilEnchant>()}] Stop attacking to gradually increase attack speed for up to 5 seconds\n" +
$"[i:{ModContent.ItemType<PalladiumEnchant>()}] Grants Rapid Healing after striking an enemy and spawn life orbs based on healing\n" +
$"[i:{ModContent.ItemType<OrichalcumEnchant>()}] Attacks spawn flower petals and damaging debuffs deal 4x damage\n" +
$"[i:{ModContent.ItemType<AdamantiteEnchant>()}] Every weapon shot will split into 3, deal 50% damage and have 50% less iframes\n" +
$"[i:{ModContent.ItemType<TitaniumEnchant>()}] Attacks generate titanium shards, reaching max grants Titanium Shield\n" +
"'Gaia's blessing shines upon you'");

            string tooltip_ch =
@"[i:{0}] 额外获得一次爆炸二段跳，受击时你会剧烈爆炸（译者注：大地之力只有受击爆炸效果，没有爆炸跳跃效果）
[i:{2}] 在一段时间不攻击后开始攻击会短暂地提高武器使用速度
[i:{2}] 使用速度加成会在攻击5秒后消失，并在5秒不攻击后恢复
[i:{1}] 击中敌人后大幅增加生命恢复速度
[i:{1}] 你每恢复80点生命值便会生成一个会造成伤害的生命能量球
[i:{3}] 花瓣将飞向你的攻击目标，造成额外伤害
[i:{3}] 伤害性减益造成的伤害×5
[i:{4}] 你发射的所有弹幕都会分裂成两个，造成50%伤害且伤害频率翻倍，弹幕增加与其一半伤害相等的护甲穿透
[i:{5}] 攻击生成钛金碎片防御屏障
“盖亚的祝福照耀着你”";
            Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, string.Format(tooltip_ch, Enchants[0], Enchants[1], Enchants[2], Enchants[3], Enchants[4], Enchants[5]));

            string tooltip_pt =
@"[i:{0}] Oferece um pulo explosivo e você explode ao ser atingido
[i:{2}] Pare de atacar para aumentar gradualmente a velocidade do ataque por até 5 segundos
[i:{1}] Concede Cura rápida depois de atacar um inimigo e invoca esferas de cura baseada na cura
[i:{3}] Ataques invocam pétalas de flores e efeitos negativos causam 4x o dano
[i:{4}] Toda arma disparada se dividirá em 3, causará 50% de dano e terá 50% menos quadros de imunidade
[i:{5}] Ataques geram fragmentos de titânio, atingir o máximo concede Escudo de Titânio
'A bênção de Gaia brilha sobre você'";
            Tooltip.AddTranslation((int)GameCulture.CultureName.Portuguese, string.Format(tooltip_pt, Enchants[0], Enchants[1], Enchants[2], Enchants[3], Enchants[4], Enchants[5]));
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoSoulsPlayer modPlayer = player.GetModPlayer<FargoSoulsPlayer>();
            modPlayer.EarthForce = true;
            //mythril
            MythrilEnchant.MythrilEffect(player, Item);
            //shards
            modPlayer.CobaltEnchantItem = Item;
            //regen on hit, heals
            PalladiumEnchant.PalladiumEffect(player, Item);
            //fireballs and petals
            OrichalcumEnchant.OrichalcumEffect(player, Item);
            AdamantiteEnchant.AdamantiteEffect(player, Item);
            TitaniumEnchant.TitaniumEffect(player, Item);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            foreach (int ench in Enchants)
                recipe.AddIngredient(ench);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
            recipe.Register();
        }
    }
}
