using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using MarioWindowsGame.Helpers;

namespace MarioWindowsGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MarioGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D ide;
        private Texture2D run;
        private Texture2D jump;
        private Texture2D blockTexture;
        private Texture2D bricksTexture;
        private Texture2D questioTexture;
        private Texture2D coinTexuture;
        private AnimationPlayer Play ;
        private AnimateSprite hero;
        public static  int Width = 1280;
        public  static int Height = 720;
        private List<Block> blocks;
        private List<Coin> coins;
        private KeyboardState oldState;
        private int curentLevel = -1;

        static int ScrollX;
        private int levelLenght;

        private Level level;

        public static GameState State = GameState.MainMenu;
        private MainMenu mainMenu;

        public MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            //graphics.IsFullScreen = true;
            mainMenu = new MainMenu();
        }

        public bool  CollidesWithCoin(Rectangle rectangle)
        {
            foreach (Coin coin1 in coins)
            {
                if (coin1.BoundingRectangle.Intersects(rectangle))
                {
                    coin1.IsAlive = true;
                    return true;
                    
                }
            }
            return false;

        }

        public bool CollidesWithLevel(Rectangle rectangle)
        {
            foreach (Block block1 in blocks)
            {
                if (block1.rectangle.Intersects(rectangle))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollidesWithExit(Rectangle rectangle)
        {
            return level.CollidesWithExit(rectangle);
        }

        public void Scroll(int dx)
        {
            if (ScrollX + dx >= 0 && ScrollX + dx <= levelLenght - Width)
                ScrollX += dx;

        }
        public static Rectangle GetScrenRect(Rectangle rectangle)
        {
            Rectangle screnRect = rectangle;
            screnRect.Offset(-ScrollX, 0);
            return screnRect;

        }
        public static int GetScrollX()
        {
            return -ScrollX;
        }

        public void CreateLevel()
        {
            int size;
            curentLevel++;
            if (curentLevel > 2)
                curentLevel = 0;
            blocks = new List<Block>();
            coins = new List<Coin>();
            level =new Level(this);
            string[] s = File.ReadAllLines(string.Format("content/Levels/level{0}.txt", curentLevel));
            size = Height / s.Count();
            levelLenght = size * s[0].Length;
            int x = 0;
            int y = 0;

            foreach (string str in s)
            {
                foreach (char c in str)
                {
                    level.CreateLevel(c, x + size / 2, y + size);
                    Rectangle rectangle = new Rectangle(x, y, size, size);
                    if (c == '#')
                        blocks.Add(new Block(rectangle, blockTexture));
                    if (c == 'B')
                        blocks.Add(new Block(rectangle, bricksTexture));
                    if (c == 'Q')
                        blocks.Add(new Block(rectangle, questioTexture));
                    if (c == 'C')
                        coins.Add(new Coin(coinTexuture,new Vector2(x+size/2,y+size)));
                    x += size;
                }
                x = 0;
                y += size;
            }
        }
        public void ResetPosition()
        {
            ScrollX = 0;
            Rectangle rectangle = new Rectangle(100, Height - run.Height / 4 - 400, run.Height / 5, run.Height / 5);
            hero = new AnimateSprite(rectangle, ide, run, jump, this);
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {

            LoadHelper.Load(Content);
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ide = Content.Load<Texture2D>("Player/ide");
            run = Content.Load<Texture2D>("Player/run");
            jump = Content.Load<Texture2D>("Player/jump");
            blockTexture = Content.Load<Texture2D>("Texture/block");
            bricksTexture = Content.Load<Texture2D>("Texture/bricks");
            questioTexture = Content.Load<Texture2D>("Texture/q");
            coinTexuture = Content.Load<Texture2D>("Texture/coin");
            Rectangle rectangle = new Rectangle(100, Height - run.Height / 4 - 400, run.Height / 5, run.Height / 5);
            CreateLevel();
            hero = new AnimateSprite(rectangle, ide, run, jump, this);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
              if (State == GameState.MainMenu)
            {
                mainMenu.Update();
            }
            if (State == GameState.Exit)
            {
                this.Exit();
            }
            if (State == GameState.Game)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
                hero.Update(gameTime);
                foreach (Block block in blocks)
                    block.Update(gameTime);
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Left))
                    hero.StartRun(false);
                else if (keyboardState.IsKeyDown(Keys.Right))
                    hero.StartRun(true);
                else
                    hero.Stop();
                if (keyboardState.IsKeyDown(Keys.Space))
                    hero.Jump();
                if (keyboardState.IsKeyDown(Keys.N) && oldState.IsKeyUp(Keys.N))
                {
                    CreateLevel();
                }
                Rectangle heroScrenRect = GetScrenRect(hero.rect);

                if (heroScrenRect.Left < Width/2)
                    Scroll(-3*gameTime.ElapsedGameTime.Milliseconds/10);
                if (heroScrenRect.Left > Width/2)
                    Scroll(3*gameTime.ElapsedGameTime.Milliseconds/10);

                oldState = keyboardState;


                if (keyboardState.IsKeyDown(Keys.Escape))
                    State = GameState.MainMenu;

            } 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

             if (State == GameState.MainMenu)
            {
                mainMenu.Draw(spriteBatch);
            }
             if (State == GameState.Game)
             {
                 spriteBatch.Begin();
                 foreach (Block block in blocks)
                     block.Draw(spriteBatch);

                 foreach (Coin coin in coins)
                     coin.Draw(gameTime, spriteBatch);
                 level.Draw(spriteBatch,gameTime);
                 spriteBatch.End();
                 hero.Draw(spriteBatch);
             }
            base.Draw(gameTime);
        }
    }
}
