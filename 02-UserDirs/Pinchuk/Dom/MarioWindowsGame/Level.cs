using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarioWindowsGame.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioWindowsGame
{
    class Level
    {
        //private List<Coin> coins;
        //private List<Texture2D>  texture;
        private List<LevelObject> levelObjects;
        private LevelObject Exit;
        public MarioGame game;
        public  Level(MarioGame game)
        {
            levelObjects = new List<LevelObject>();
            this.game = game;
        }
        public void CreateLevel(char levelSymbol, int x, int y)
        {
            switch (levelSymbol)

            {
                case 'X':
                    Exit =new LevelObject(LoadHelper.Textures[TextureEnum.Exit],new Vector2(x,y));
                    break;
                case 'L':
                    levelObjects.Add(new LevelObject(LoadHelper.Textures[TextureEnum.Clouds], new Vector2(x, y)));
                    break;
                    
            }
        }

        public void Upadate()
        {
        }

        public bool CollidesWithExit(Rectangle rectangle)
        {
                if(Exit.BoundingRectangle.Intersects(rectangle) )
                    NextLevel();
                return true;
            return false;
        }

        public void Draw( SpriteBatch spriteBatch,GameTime gameTime)
        {
            foreach (LevelObject levelObject in levelObjects)
                levelObject.Draw(gameTime, spriteBatch);
            Exit.Draw(gameTime, spriteBatch);
        }

        public void NextLevel()
        {
            game.CreateLevel();
            game.ResetPosition();
        }
    }
}
