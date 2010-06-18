using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioWindowsGame
{
    class Coin
    {
        //private Texture2D texture;
        public Vector2 Position { get; set; }
        public Animation coin;
        public AnimationPlayer sprite;

        public bool IsAlive{ get; set;}

        private Rectangle localBounds;

        public Rectangle BoundingRectangle
        {
            get
            {
                int left = (int)Math.Round(Position.X - sprite.Origin.X) + localBounds.X;
                int top = (int)Math.Round(Position.Y - sprite.Origin.Y) + localBounds.Y;

                return new Rectangle(left, top, localBounds.Width, localBounds.Height);
            }
        }

        public Coin(Texture2D texture2D, Vector2 position)
        {
            coin = new Animation(texture2D, 0.1f, true);
            Position = position;
            sprite.PlayAnimation(coin);

            int width = (int)(coin.FrameWidth * 0.35);
            int left = (coin.FrameWidth - width) / 2;
            int height = (int)(coin.FrameWidth * 0.7);
            int top = coin.FrameHeight - height;
            localBounds = new Rectangle(left, top, width, height);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!IsAlive)
            sprite.Draw(gameTime, spriteBatch, Position, SpriteEffects.None);
        }
    }
}
