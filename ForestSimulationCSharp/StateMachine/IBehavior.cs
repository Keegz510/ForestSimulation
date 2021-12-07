using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSim
{
    public interface IBehavior
    {
        public void Update(Agent agent, float deltaTime);
    }
}
