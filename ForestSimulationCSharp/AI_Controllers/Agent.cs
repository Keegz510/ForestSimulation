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
        protected Vector2 velocity = new Vector2();
        protected Vector2 force = new Vector2();

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            force = new Vector2(0, 0);

            // TODO: Update Behaviours

            velocity += (force * deltaTime);
            localPosition += (velocity * deltaTime);
        }
    }
}
