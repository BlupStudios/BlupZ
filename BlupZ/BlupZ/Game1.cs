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
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        Menu menu;
        private static Game1 instance;
        public gameState State;

        public enum gameState
        {
            Menu,
            Options,
            GamePlay
        }

        public void setState(gameState State)
        {
            this.State = State;
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
            menu = new Menu();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (State == gameState.Menu)
            {
                menu.Load();
            }
            else if (State == gameState.Options)
            {
                //Options stuff
            }
            else if (State == gameState.GamePlay)
            {
                //Call GamePlay
            }
        }

        public void DoUnload()
        {
            UnloadContent();
        }

        public void DoLoad()
        {
            LoadContent();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();
            //if (key.IsKeyDown(Keys.Escape))
            //    this.Exit();
            if (State == gameState.Menu)
            {
                menu.update();
            }
            else if (State == gameState.Options)
            {
                if (key.IsKeyDown(Keys.Escape))
                {
                    State = gameState.Menu;
                    LoadContent();
                }
            }
            else if (State == gameState.GamePlay)
            {
                if (key.IsKeyDown(Keys.Escape))
                {
                    State = gameState.Menu;
                    LoadContent();
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (State == gameState.Menu)
            {
                menu.draw();
            }
            else if (State == gameState.Options)
            {
                //Options stuff
            }
            else if (State == gameState.GamePlay)
            {
                //Call GamePlay
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}