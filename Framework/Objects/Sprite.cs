using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Framework
{
    public class Sprite : GameObject, IDrawable
    {
        protected string texturePath;
        protected Texture2D texture;

        protected Color tint;

        public bool IsVisible;
        public void Draw()
        {
            if (!IsVisible || !bIsActive) return;

            if(texturePath != "")
            {
                DrawTextureEx(texture, new System.Numerics.Vector2(GlobalPosition.x, GlobalPosition.y), Rotation, Scale, tint);
            }
        }

        public Texture2D GetTexture() => texture;

        public void SetTexture(string texturePath, Texture2D texture)
        {
           
        }
    }
}
