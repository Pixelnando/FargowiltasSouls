﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FargowiltasSouls.PlayerDrawLayers
{
    public class PrecisionHurtboxDrawLayer : PlayerDrawLayer
    {
        public override bool IsHeadLayer => false;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) =>
            drawInfo.drawPlayer.whoAmI == Main.myPlayer
            && drawInfo.drawPlayer.active
            && !drawInfo.drawPlayer.dead
            && !drawInfo.drawPlayer.ghost
            && drawInfo.shadow == 0
            && drawInfo.drawPlayer.GetModPlayer<FargoSoulsPlayer>().PrecisionSealNoDashNoJump
            && drawInfo.drawPlayer.GetModPlayer<FargoSoulsPlayer>().PrecisionSealHurtbox;

        public override Position GetDefaultPosition() => new Between();

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;

            Texture2D hurtbox = ModContent.Request<Texture2D>("FargowiltasSouls/PlayerDrawLayers/PrecisionHurtboxDrawLayer", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            Rectangle rectangle = hurtbox.Bounds;

            float opacity = Main.mouseTextColor / 255f;
            opacity *= opacity;

            DrawData data = new DrawData(hurtbox, drawPlayer.Center - Main.screenPosition, rectangle, Color.White * opacity, 0f, rectangle.Size() / 2, 1f, SpriteEffects.None, 0);
            drawInfo.DrawDataCache.Add(data);
        }
    }
}
