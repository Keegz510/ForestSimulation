using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using Raylib_cs;
using static Raylib_cs.Raylib;

public struct TextureDetails
{
    public string TextureID;
    public string TexturePath;
    public Texture2D Texture;
    public bool bIsLoaded;

    public static bool operator==(TextureDetails lhs, TextureDetails rhs)
    {
        if(lhs.TextureID == rhs.TextureID)
        {
            return true;
        }

        return false;
    }

    public static bool operator!=(TextureDetails lhs, TextureDetails rhs)
    {
        if(lhs == rhs)
        {
            return false;
        }

        return false;
    }
}


namespace Framework.Engine
{
    public class ResourceManager
    {
        /// List of ID's been used
        private List<string> usedIDs = new List<string>();
        /// List of game objects in the resource manager
        private List<IObject> gameObjects = new List<IObject>();
        /// Stores all the loaded textures
        private List<TextureDetails> loadedTextures = new List<TextureDetails>();
        /// List of loaded sprites that we want to render
        private List<IDrawable> sprites = new List<IDrawable>();
        
        /// State this this resource manager belongs to
        private GameState owningState;
        public GameState OwningState { get => owningState; }

        public ResourceManager(GameState owner)
        {
            owningState = owner;
        }

        public void LoadGameObject(IObject go)
        {
            if(go != null && !gameObjects.Contains(go))
            {
                gameObjects.Add(go);
                go.SetID(GenerateID());
                go.SetManager(this);
                go.Init();
            }
        }

        public void UnloadGameObject(IObject go)
        {
            if(go != null && gameObjects.Contains(go))
            {
                usedIDs.Remove(go.GetID());
                gameObjects.Remove(go);
            }
        }

        public Sprite LoadSprite(string texturePath)
        {
            if(texturePath != "")
            {
                // Loop through each texture to see if we have loaded it,
                // if it has been loaded than return a new sprite
                foreach(var textures in loadedTextures)
                {
                    if (textures.TexturePath == texturePath)
                        return new Sprite(textures);
                }

                // Create a new texture
                {
                    // Create a new texture details
                    TextureDetails details = new TextureDetails();
                    // Set the texture path
                    details.TexturePath = texturePath;
                    // Attempt to load the texture
                    details.Texture = Raylib.LoadTexture(texturePath);

                    // Check if the texture loaded successfully
                    if (details.Texture.id > 0)
                    {
                        // Generate an ID for the texture
                        details.TextureID = GenerateID();
                        // Set the texture to loaded
                        details.bIsLoaded = true;
                        // Add the loaded texture to the resource manager
                        loadedTextures.Add(details);

                        // Create a new sprite
                        Sprite sprite = new Sprite(details);
                        sprites.Add(sprite);
                        return sprite;
                    }
                }
                
            }

            // Log an error and pause the game if we're unable to load a texture
            Debug.LogError("Unable To Load Image @ Path: " + texturePath, true);
            // Return empty
            return null;
        }

        public void UnloadSprite(Sprite sprite)
        {
            if(sprite != null && sprites.Contains(sprite))
            {
                sprites.Remove(sprite);
            }
        }

        public void UnloadTexture(TextureDetails texture)
        {
            if (loadedTextures.Contains(texture))
            {
                loadedTextures.Remove(texture);
            }
        }

        public void Update(float deltaTime)
        {
            foreach(var go in gameObjects)
            {
                go.Update(deltaTime);
            }
        }

        public void Draw()
        {
            if(sprites.Count > 0)
            {
                foreach(var sprite in sprites)
                {
                    sprite.Draw();
                }
            }
        }

        private string GenerateID()
        {
            string[] characters = { "a", "b", "c", "d", "e", "f", "g", "0", "1", "2", "3", "4", "5", "!", "@", "#", "$", "%" };

            bool bIsValid = false;

            do
            {
                var idLength = Raylib_cs.Raylib.GetRandomValue(6, 15);
                var newID = "";

                for (int i = 0; i < idLength; ++i)
                {
                    newID += characters[Raylib_cs.Raylib.GetRandomValue(0, characters.Length - 1)];
                }

                if (!usedIDs.Contains(newID))
                {
                    bIsValid = true;
                    usedIDs.Add(newID);
                    return newID;
                }
            } while (!bIsValid);

            return "";
        }
    }
}
