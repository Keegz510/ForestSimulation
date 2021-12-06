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
    public struct TextureDetails
    {
        public string TextureID;
        public string TexturePath;
        public Texture2D Texture;
        public bool bIsLoaded;

        public static bool operator ==(TextureDetails lhs, TextureDetails rhs)
        {
            if (lhs.TextureID == rhs.TextureID)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(TextureDetails lhs, TextureDetails rhs)
        {
            if (lhs == rhs)
            {
                return false;
            }

            return false;
        }
    }
    public class Sprite : GameObject, IDrawable
    {
        /// Reference to the details of the sprite
        protected TextureDetails textureDetails;

        /// Tint to display over the image
        protected Color tint = Color.WHITE;

        /// If we should render this sprite or not
        public bool IsVisible = true;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Sprite() : base()
        { }

        /// <summary>
        /// Sprite constructor with the texture details
        /// </summary>
        /// <param name="details">Texture Details</param>
        public Sprite(TextureDetails details)
        {
            textureDetails = details;
        }

        /// <summary>
        /// Handles rendering the sprite to the screen
        /// </summary>
        public void Draw()
        {
            // Don't render the object if it's not active or visible
            if (!IsVisible || !bIsActive) return;

            // Ensure if the image is loaded and render
            // If it's not loaded render a debugging message
            if(textureDetails.bIsLoaded)
            {
                DrawTextureEx(textureDetails.Texture, new System.Numerics.Vector2(GlobalPosition.x, GlobalPosition.y), Rotation, Scale, tint);
            } else
            {
                Debug.LogWarning("No image has been loaded");
            }
        }

        /// Returns the texture of this sprite
        public Texture2D GetTexture() => textureDetails.Texture;

        /// Sets the texture details for this sprite
        public void SetTexture(TextureDetails details) => textureDetails = details;

        /// Set the tint of the sprite
        public void SetTint(Color newTint) => tint = newTint;

        /// <summary>
        /// Handles removing the object from the game
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();

            manager.UnloadSprite(this);
        }
    }
}
