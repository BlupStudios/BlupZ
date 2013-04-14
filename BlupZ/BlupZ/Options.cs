using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BlupZ
{
    class Options
    {
        private Hashtable buttons = new Hashtable();

        public void Load()
        {
            ContentManager content = Game1.getInstance().Content;
            GraphicsDeviceManager graphics = Game1.getInstance().graphics;

            int lineHeight = 50;
            buttons.Add("play", new Button(new Vector2(graphics.PreferredBackBufferWidth / 2 - 100, 50 + 2 * lineHeight), 200, 40, "Play"));
            buttons.Add("options", new Button(new Vector2(graphics.PreferredBackBufferWidth / 2 - 100, 50 + 3 * lineHeight), 200, 40, "options"));
            buttons.Add("exit", new Button(new Vector2(graphics.PreferredBackBufferWidth / 2 - 100, 50 + 4 * lineHeight), 200, 40, "Exit"));

            foreach (DictionaryEntry b in buttons)
            {
                (b.Value as Button).Load();
            }
            //(buttons["play"] as Button).ButtonPress += PlayPress;
            //(buttons["options"] as Button).ButtonPress += OptionsPress;
            //(buttons["exit"] as Button).ButtonPress += ExitPress;
        }

        public void update()
        {
            foreach (DictionaryEntry b in buttons)
                (b.Value as Button).update();
        }

        public void draw()
        {
            SpriteBatch sprite = Game1.getInstance().spriteBatch;
            foreach (DictionaryEntry b in buttons)
                (b.Value as Button).draw();
        }
    }
}
