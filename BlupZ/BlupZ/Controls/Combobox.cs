using System;
using System.Collections.Generic;
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
    class Combobox
    {
        private Vector2 pos { get; set; }
        private int width { get; set; }
        private int height { get; set; }
        private string[] Options { get; set; }
        private string fontName { get; set; }
        private string ShowString { get; set; }
        private bool isOpen { get; set; }
        Texture2D textrue;
        SpriteFont font;
        Rectangle rec;

        public Combobox(Vector2 pos, int width, int height, string[] options)
        {
            this.pos = pos;
            this.width = width;
            this.height = height;
            this.Options = options;
            fontName = "buttonFont";
            ShowString = Options[0];
            isOpen = false;
        }

        public Combobox(Vector2 firstPos, Vector2 endPos, string[] options)
        {
            this.pos = firstPos;
            this.width = (int)(endPos.X - firstPos.X);
            this.height = (int)(endPos.Y - firstPos.Y);
            this.Options = options;
            fontName = "buttonFont";
            ShowString = Options[0];
            isOpen = false;
        }

        public void Load()
        {
            GraphicsDeviceManager graphics = Game1.getInstance().graphics;
            ContentManager content = Game1.getInstance().Content;
            this.textrue = content.Load<Texture2D>(@"Textures/Button");
            font = content.Load<SpriteFont>(fontName);
            rec = new Rectangle((int)pos.X, (int)pos.Y, width, height);
        }


        public void draw()
        {
            SpriteBatch sprite = Game1.getInstance().spriteBatch;
            sprite.Draw(textrue, rec, Color.White);
            sprite.DrawString(font, ShowString, new Vector2(), Color.White);
        }

        public void update()
        {
            onHover();
            onPress();
        }

        public event EventHandler ButtonPress;

        public void onButtonPress()
        {
            if (ButtonPress != null)
            {
                ButtonPress(this, EventArgs.Empty);
            }
        }

        public void onHover()
        {
            ContentManager content = Game1.getInstance().Content;
            if (rec.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                this.textrue = content.Load<Texture2D>(@"Textures/OnButton");
            else
                this.textrue = content.Load<Texture2D>(@"Textures/Button");
        }

        public void onPress()
        {
            if (rec.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                onButtonPress();
            }
        }


    }
}
