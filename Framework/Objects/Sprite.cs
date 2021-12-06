using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Framework;

namespace Framework
{
    public class Sprite : GameObject, IDrawable
    {
        protected TextureDetails textureDetails;

        protected Color tint;

        public bool IsVisible;

        public Sprite()
        { }

        public Sprite(TextureDetails details)
        {
            textureDetails = details;
        }


        public void Draw()
        {
            if (!IsVisible || !bIsActive) return;

            if(textureDetails.TexturePath != "")
            {
                DrawTextureEx(textureDetails.Texture, new System.Numerics.Vector2(GlobalPosition.x, GlobalPosition.y), Rotation, Scale, tint);
            } else
            {
                Debug.LogWarning("No image has been loaded");
            }
        }

        public Texture2D GetTexture() => textureDetails.Texture;

        public void SetTexture(TextureDetails details) => textureDetails = details;
    }
}
