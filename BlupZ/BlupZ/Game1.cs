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

namespace BlupZ
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        menu menu;
        private static Game1 instance;
        gameState State;

        public enum gameState
        {
            Menu,
            Options,
            GamePlay
        }

        public Game1()
        {
            instance = this;
            IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Game1 getInstance()
        {
            return instance;
        }

        protected override void Initialize()
        {
            State = gameState.Menu;
            if (State == gameState.Menu)
            {
                menu = new menu();
            }
            else if (State == gameState.Options)
            {
                //do options things here
            }
            else if (State == gameState.GamePlay)
            {
                //Call the gameplay fuctions
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menu.Load(Content, graphics);
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Escape))
                this.Exit();
            menu.update(Content, spriteBatch);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            menu.draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}