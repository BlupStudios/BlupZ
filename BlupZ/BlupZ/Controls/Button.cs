﻿using System;
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
    class Button
    {
        private Vector2 pos { get; set; }
        private int width { get; set; }
        private int height { get; set; }
        private string text { get; set; }
        private string fontName { get; set; }
        Texture2D textrue;
        SpriteFont font;
        Rectangle rec;

        public Button()
        {
            this.pos = Vector2.Zero;
            this.width = 0;
            this.height = 0;
            this.text = "";
            fontName = "buttonFont";
        }
        public Button(Vector2 pos, int width, int height, string text)
        {
            this.pos = pos;
            this.width = width;
            this.height = height;
            this.text = text;
            fontName = "buttonFont";
        }

        public Button(Vector2 firstPos, Vector2 endPos, string text)
        {
            this.pos = firstPos;
            this.width = (int)(endPos.X - firstPos.X);
            this.height = (int)(endPos.Y - firstPos.Y);
            this.text = text;
            fontName = "buttonFont";
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
            sprite.DrawString(font, text, new Vector2(pos.X + (width / 2 - font.MeasureString(text).X / 2), pos.Y + (height / 2 - font.MeasureString(text).Y / 2)), Color.White);
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
