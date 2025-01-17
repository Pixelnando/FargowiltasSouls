using Terraria;
using Terraria.ID;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class FlippedHallow : Flipped
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            base.Update(player, ref buffIndex);

            if (player.Center.Y / 16 <= Main.worldSurface) //above ground, purge debuff immediately
            {
                if (player.buffTime[buffIndex] > 2)
                    player.buffTime[buffIndex] = 2;
            }
        }
    }
}