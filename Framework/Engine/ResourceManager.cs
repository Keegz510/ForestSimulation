using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using Framework.Maths;
using Raylib_cs;
using static Raylib_cs.Raylib;




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


        /// List of active timers
        private List<Maths.Timer> timers = new List<Maths.Timer>();
        
        /// State this this resource manager belongs to
        private GameState owningState;
        /// Returns the owning State
        public GameState OwningState { get => owningState; }

        public ResourceManager(GameState owner)
        {
            owningState = owner;
        }

        /// <summary>
        /// Loads a new game object into this resource manager
        /// </summary>
        /// <param name="go">Game Object to add</param>
        public void LoadGameObject(IObject go)
        {
            // Ensure the object isn't null & not already loaded
            if(go != null && !gameObjects.Contains(go))
            {
                gameObjects.Add(go);
                go.SetID(GenerateID());
                go.SetManager(this);
                go.Init();
            }
        }

        /// <summary>
        /// handles removing a game object
        /// </summary>
        /// <param name="go">Game object to remove</param>
        public void UnloadGameObject(IObject go)
        {
            // Ensure the object isn't null and that it has been loaded
            if(go != null && gameObjects.Contains(go))
            {
                usedIDs.Remove(go.GetID());             // Remove the ID from the used ids so it can be used again
                gameObjects.Remove(go);                 // Remove the game obejct
            }
        }

        /// <summary>
        /// Handles Loading a new sprite
        /// </summary>
        /// <param name="texturePath">Location of the texture</param>
        /// <returns>The created sprite</returns>
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

                        // Create a new sprite & add to the list
                        Sprite sprite = new Sprite(details);
                        sprites.Add(sprite);
                        gameObjects.Add(sprite);
                        sprite.SetManager(this);
                        return sprite;
                    }
                }
                
            }

            // Log an error and pause the game if we're unable to load a texture
            Debug.LogError("Unable To Load Image @ Path: " + texturePath, true);
            // Return empty
            return null;
        }

        /// Adds a new object that can be drawn
        public void AddDrawable(IDrawable drawable) => sprites.Add(drawable);

        /// <summary>
        /// Handle Removes the sprite from the resource manager
        /// </summary>
        /// <param name="sprite"></param>
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

        public void AddTimer(Maths.Timer newTimer)
        {
            if (newTimer != null && !timers.Contains(newTimer))
            {
                timers.Add(newTimer);
                newTimer.SetManager(this);
            }
        }

        public void RemoveTimer(Maths.Timer timer)
        {
            if(timer != null && timers.Contains(timer))
            {
                timers.Remove(timer);
            }
        }

        public void Update(float deltaTime)
        {
            foreach(var go in gameObjects)
            {
                go.Update(deltaTime);
            }

            foreach(var timer in timers)
            {
                timer.Update(deltaTime);
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
