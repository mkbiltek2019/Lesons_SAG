using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioWindowsGame
{
    class AnimateSprite
    {
        public Rectangle rect;
        private Texture2D ide;
        private Texture2D run;
        private Texture2D jump;

        private bool isRuning;
        private bool isRuningRight;
        private bool isJumping;
        private int frameWidth;
        private int frameHeight;

        public int FrameCountRun { get { return run.Width / frameWidth; } }
        public int FrameCountIde { get { return ide.Width / frameWidth; } }
        public int FrameCountJump { get { return jump.Width / frameWidth; } }

        private float yVelocity;
        private float g = 0.2f;
        private float maxYVElocity = 10;

        private int curentFrame;
        private int timeEclapsed;
        private int timeForFreme = 100;
        private MarioGame game;
        public AnimateSprite(Rectangle rect, Texture2D ide, Texture2D run, Texture2D jump, MarioGame game)
        {
            this.run = run;
            this.ide = ide;
            this.rect = rect;
            this.jump = jump;
            frameWidth = frameHeight = run.Height;
            this.game = game;
        }

        public void StartRun(bool isRight)
        {
            if (!isRuning)
            {
                isRuning = true;
                curentFrame = 0;
                timeEclapsed = 0;

            }
            isRuningRight = isRight;
        }
        public void Stop()
        {
            if (isRuning)
            {
                isRuning = false;
                curentFrame = 0;
                timeEclapsed = 0;
            }
            
        }
        public void Jump()
        {
            if (!isJumping && yVelocity==0.0f)
            {
                isJumping = true;
                curentFrame = 0;
                timeEclapsed = 0;
                yVelocity = maxYVElocity;
            }
        }
        public void ApplyGravity(GameTime gameTime)
        {
            yVelocity = yVelocity - g * gameTime.ElapsedGameTime.Milliseconds / 10;
            float dy = yVelocity * gameTime.ElapsedGameTime.Milliseconds / 10;

            Rectangle nexPosition = rect;
            nexPosition.Offset(0, -(int)dy);

          

            Rectangle boudingRect = GetBoundingRect(nexPosition);
            if (boudingRect.Top > 0 && boudingRect.Bottom < MarioGame.Height && !game.CollidesWithLevel(boudingRect))
                rect = nexPosition;
            game.CollidesWithCoin(boudingRect);
            game.CollidesWithExit(boudingRect);
            bool collideOnFailDown = (game.CollidesWithLevel(boudingRect) && yVelocity<0);

            if (boudingRect.Bottom > MarioGame.Height || collideOnFailDown)
            {
                yVelocity = 0;
                isJumping = false;
            }

        }

        public void Update(GameTime gameTime)
        {
            timeEclapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (isRuning)
            {
                if (timeEclapsed > timeForFreme)
                {
                    if(!isJumping)
                        curentFrame = (curentFrame + 1) % FrameCountRun;
                    else
                        curentFrame = (curentFrame + 1) % FrameCountJump;
                    timeEclapsed = 0;
                }
                int dx = 3 * gameTime.ElapsedGameTime.Milliseconds / 10;
                if (!isRuningRight)
                    dx = -dx;
                Rectangle nextPosition = rect;
                nextPosition.Offset(dx, 0);

                Rectangle boundingRect = GetBoundingRect(nextPosition);
                Rectangle screnRect = MarioGame.GetScrenRect(boundingRect);

                if (screnRect.Left > 0 && screnRect.Right < MarioGame.Width && !game.CollidesWithLevel(boundingRect))
                    rect = nextPosition;
            }
            else
            {
                if (timeEclapsed > timeForFreme)
                {
                    System.Diagnostics.Debug.WriteLine("FrameCountIde="+ FrameCountIde);
                    curentFrame = (curentFrame + 1) % FrameCountIde;
                    timeEclapsed = 0;
                }
            }
            ApplyGravity(gameTime);
        }

        private Rectangle GetBoundingRect(Rectangle rectangle)
        {
            int width = (int)(rectangle.Width * 0.4f);
            int x = rectangle.Left + (int)(rectangle.Width * 0.2f);

            return new Rectangle(x, rectangle.Top, width, rectangle.Height);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle r = new Rectangle(curentFrame * frameWidth, 0, frameWidth, frameHeight);
            SpriteEffects spriteEffects = SpriteEffects.None;

            spriteBatch.Begin();
            Rectangle screnRect = MarioGame.GetScrenRect(rect);
            if (!isRuningRight)
                spriteEffects = SpriteEffects.FlipHorizontally;
            if (isJumping)
                spriteBatch.Draw(jump, screnRect, r, Color.White, 0, Vector2.Zero, spriteEffects, 0);
            else
                if (isRuning)
                    spriteBatch.Draw(run, screnRect, r, Color.White, 0, Vector2.Zero, spriteEffects, 0);
                else
                    spriteBatch.Draw(ide, screnRect, r, Color.White, 0, Vector2.Zero, spriteEffects, 0);

            spriteBatch.End();
        }
    }
}
