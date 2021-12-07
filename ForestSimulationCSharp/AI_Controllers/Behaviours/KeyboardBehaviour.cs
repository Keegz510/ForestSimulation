using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Maths;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace ForestSim
{
    public class KeyboardBehaviour : IBehavior
    {
        private float movementSpeed = 50.0f;

        public void Update(Agent agent, float deltaTime)
        {
            Vector2 force = new Vector2();

            if (IsKeyDown(KeyboardKey.KEY_W)) force.y = -movementSpeed;
            if(IsKeyDown(KeyboardKey.KEY_S)) force.y = movementSpeed;
            if (IsKeyDown(KeyboardKey.KEY_A)) force.x = -movementSpeed;
            if(IsKeyDown(KeyboardKey.KEY_D)) force.x =movementSpeed

            agent.AddForce(force);
        }
    }
}
