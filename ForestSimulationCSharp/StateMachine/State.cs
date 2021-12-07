using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSim
{
    public abstract class State
    {
        protected List<Transition> transitions;
        State()
        { }

        public abstract void Update(Agent agent, float dt);
        public virtual void Init() { }
        public virtual void Exit() { }

        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }

        public Transition GetTriggeredTransition(Agent agent)
        {
            for(var t in transitions)
            {
                if(t.HasTriggered(agent))
                {
                    return t;
                }
            }

            return null;
        }

    }
}
