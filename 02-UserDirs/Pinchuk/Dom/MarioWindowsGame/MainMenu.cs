using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MarioWindowsGame.Helpers;

namespace MarioWindowsGame
{
    class MainMenu
    {
        private int selected = 0;
        private bool arrowPressed = true;
        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (!arrowPressed)
            {
                if (keyboard.IsKeyDown((Keys.Up)))
                    selected = selected == 0 ? 1 : 0;
                if (keyboard.IsKeyDown((Keys.Down)))
                    selected = selected == 0 ? 1 : 0;
            }
            if (keyboard.IsKeyDown((Keys.Enter)))
                MarioGame.State = selected == 0 ? GameState.Game : GameState.Exit;

            if (keyboard.IsKeyUp((Keys.Up)) && keyboard.IsKeyUp((Keys.Down)))
                arrowPressed = false;
            else arrowPressed = true;


        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteBlendMode.AlphaBlend);
            spritebatch.Draw(LoadHelper.Textures[TextureEnum.Logo], new Rectangle(0, 0, MarioGame.Width, MarioGame.Height), Color.White);



            spritebatch.DrawString(LoadHelper.Fonts[FontEnum.Arial22],
            "Play game",
           new Vector2(600, 460), selected == 0 ? Color.WhiteSmoke : Color.DarkViolet);
            spritebatch.DrawString(LoadHelper.Fonts[FontEnum.Arial22],
            "Exit",
           new Vector2(600, 550), selected == 1 ? Color.WhiteSmoke : Color.DarkViolet);


            spritebatch.End();
        }
    }
}
