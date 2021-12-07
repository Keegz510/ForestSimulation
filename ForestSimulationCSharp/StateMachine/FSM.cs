using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSim
{
    public class FSM
    {
        protected List<State> states = new List<State>();
        protected List<Transition> transitions = new List<Transition>();
        protected List<ICondition> conditions = new List<ICondition>();
        protected State currentState = null;
        FSM()
        { }

        public State AddState(State state)
        {
            states.Add(state);
            return state;
        }

        public Transition AddTransition(Transition trans)
        {
            transitions.Add(trans);
            return trans;
        }

        public ICondition AddCondition(ICondition condition)
        {
            conditions.Add(condition);
            return condition;
        }

        public void SetCurrentState(State state) => currentState = state;

        public virtual void Update(Agent agent, float deltaTime)
        {
            if(currentState != null)
            {
                Transition transition = currentState.GetTriggeredTransition(agent);
                if(transition != null)
                {
                    currentState.Exit(agent);
                    currentState = transition.GetTargetState();
                    currentState.Init(agent);
                }

                currentState.Update(agent, deltaTime);
            }
        }


        
    }
}
