using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Engine
{
    public class GameState
    {
        private ResourceManager resourceManager;
        public ResourceManager ResourceManager { get => resourceManager; }
        public GameState()
        {
            resourceManager = new ResourceManager(this);
        }

        public void Init()
        {

        }

        public virtual void Update(float deltaTime)
        {
            if(resourceManager != null)
            {
                resourceManager.Update(deltaTime);
            }
        }
    }
}
