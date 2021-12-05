using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Engine
{
    public class State
    {
        private ResourceManager resourceManager;
        public ResourceManager ResourceManager { get => resourceManager; }
        public State()
        {
            resourceManager = new ResourceManager(this);
        }

        public void Init()
        {

        }

        public void Update(float deltaTime)
        {

        }
    }
}
