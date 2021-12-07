using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSim
{
    public class Transition
    {
        protected State target;
        protected ICondition condition;
        public Transition(State target, ICondition condition)
        {
            this.target = target;
            this.condition = condition;
        }

        public State GetTargetState() => target;
        public bool HasTriggered(Agent agent) => condition.Test(agent);
    }
}
