﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using static Raylib_cs.Raymath;
namespace Framework.Engine
{
    public class ResourceManager
    {
        /// List of ID's been used
        private List<string> usedIDs = new List<string>();
        /// List of game objects in the resource manager
        private List<IObject> gameObjects = new List<IObject>();
        // TODO: Add Owning State

        public ResourceManager()
        {

        }

        public void LoadGameObject(IObject go)
        {
            if(go != null && !gameObjects.Contains(go))
            {
                gameObjects.Add(go);
                go.SetID(GenerateID());
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
                    newID += characters[Raylib_cs.Raylib.GetRandomValue(0, characters.Length)];
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
