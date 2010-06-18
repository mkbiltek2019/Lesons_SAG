using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioWindowsGame
{
    class Block
    {
        private Texture2D texture;
        public Rectangle rectangle;

        private int frameWidth;
        private int frameHeight;

        private int curentFrame;
        private int timeEclapsed;
        private int timeForFreme = 100;

        int FrameCount { get { return texture.Width/frameWidth; } }

        public Block(Rectangle rectangle,Texture2D texture2D)
        {
            texture = texture2D;
            this.rectangle = rectangle;
            frameWidth = frameHeight = texture.Height;
        }
        public void Update(GameTime gameTime)
        {
            timeEclapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (timeEclapsed > timeForFreme)
            {
                curentFrame = (curentFrame + 1)%FrameCount;
                timeEclapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle r = new Rectangle(curentFrame * frameWidth, 0, frameWidth, frameHeight);
            Rectangle screnRect = MarioGame.GetScrenRect(rectangle);
            spriteBatch.Draw(texture, screnRect,r, Color.White);
        }
    }
}
