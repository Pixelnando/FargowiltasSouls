﻿using FargowiltasSouls.Projectiles.Minions;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSouls.Buffs.Minions
{
    public class TwinsEX : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twins EX");
            Description.SetDefault("The real Twins will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<OpticRetinazer>()] > 0)
            {
                player.GetModPlayer<FargoSoulsPlayer>().TwinsEX = true;
                player.buffTime[buffIndex] = 2;
            }
        }
    }
}