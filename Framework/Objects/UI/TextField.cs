
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

namespace Framework
{
    public class TextField : GameObject, IDrawable
    {
        public string Text = "";
        public int FontSize = 32;
        public int fontSpacing = 2;
        protected Font font;
        protected Color tint;
        

        public TextField() : base()
        { }

        public TextField(string text, Font font, string name = "TextField") : base(name)
        {
            Text = text;
            this.font = font;
        }

        public void Draw()
        {
            if (!bIsActive) return;

            DrawTextEx(font, Text, new Vector2(globalPosition.x, globalPosition.y), FontSize, fontSpacing, tint);
        }

        public Texture2D GetTexture()
        {
            // LEFT BLANK
            return default;
        }

        public void SetTexture(TextureDetails details)
        {
            // LEFT BLANK
        }

        public void SetTint(Color newTint)
        {
            tint = newTint;
        }

        /// Set the font of this text field
        public void SetFont(Font newFont) => font = newFont;
    }
}
