using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using Framework.Maths;

namespace ForestSim
{
    public class Agent : GameObject
    {
        public Vector2 Velocity = new Vector2();
        public Vector2 Force = new Vector2();

        protected List<IBehavior> behaviours = new List<IBehavior>();

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Force = new Vector2(0, 0);
            Velocity.Zero();

            foreach(var b in behaviours)
            {
                b.Update(this, deltaTime);
            }

            Velocity += (Force * deltaTime);

            SetPosition(localPosition += (Velocity * deltaTime));
            
        }

        public void AddBehaviour(IBehavior behavior) => behaviours.Add(behavior);
        public void AddForce(Vector2 force) => Force += force;

    }
}
