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
        public virtual void Init(Agent agent) { }
        public virtual void Exit(Agent agent) { }

        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }

        public Transition GetTriggeredTransition(Agent agent)
        {
            foreach(var t in transitions)
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
