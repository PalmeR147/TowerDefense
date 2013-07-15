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

namespace TDPalm
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            IsMouseVisible = true;

            base.Initialize();
        }

        KeyboardState currentKey;
        MouseState mouse;
        public static Enemy e;

        public static int money = 1500;

        public SpriteFont StatsFont;

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tiles.content = Content;
            Tiles.CreateMap();

            e = new Enemy(25, 5, Content);
            StatsFont = Content.Load<SpriteFont>("Stats");

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            e.Update();

            currentKey = Keyboard.GetState();
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                double dX = mouse.X / 32;
                double dY = mouse.Y / 32;
                int x = (int)dX;
                int y = (int)dY;
                int id = 5;

                //Förhindrar outofbounds (att muspekaren går utanför skärmen)
                if (x >= 25)
                    x = 24;
                if (x < 0)
                    x = 0;
                if (y >= 15)
                    y = 14;
                if (y < 0)
                    y = 0;

                if (Tiles.Towers[y, x] == null)
                {
                    Tiles.AddTower(x, y, id, 5);
                }
            }
            if (mouse.RightButton == ButtonState.Pressed)
            {
                double dX = mouse.X / 32;
                double dY = mouse.Y / 32;
                int x = (int)dX;
                int y = (int)dY;

                //Förhindrar outofbounds (att muspekaren går utanför skärmen)
                if (x >= 25)
                    x = 24;
                if (x < 0)
                    x = 0;
                if (y >= 15)
                    y = 14;
                if (y < 0)
                    y = 0;

                if (Tiles.Towers[y, x] != null)
                {
                    Tiles.RemoveTower(x, y);
                }
            }

            Tiles.Update(gameTime);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            Tiles.DrawTiles(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            Tiles.DrawTowers(spriteBatch);
            e.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(StatsFont, money.ToString() + " Dollars", new Vector2(GraphicsDevice.Viewport.Width - 200, 5), Color.DarkRed);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
