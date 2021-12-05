using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Engine
{
    public class GameState
    {
        protected ResourceManager resourceManager;
        public ResourceManager ResourceManager { get => resourceManager; }

        public bool bIsStateActive = true;
        public GameState()
        {
            resourceManager = new ResourceManager(this);
        }

        public virtual void Init()
        {

        }

        public virtual void Update(float deltaTime)
        {
            if(resourceManager != null)
            {
                resourceManager.Update(deltaTime);
            }
        }

        public virtual void DeInit()
        {

        }
    }
}
