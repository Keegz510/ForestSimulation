using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;
using Framework;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace ForestSim
{
    public class TestState : GameState
    {

        Sprite sprite;
        Sprite tempBackground;

        public TestState() : base()
        { }

        public override void Init()
        {
            base.Init();


            {
                tempBackground = resourceManager.LoadSprite("Images/MainMenuBackground.png");
            }

            // Create the objects
            {
                var ag = new Agent();
                ag.SetPosition(new Framework.Maths.Vector2(100, 100));
                Sprite sp = resourceManager.LoadSprite("Images/Square32x32.png");
                sp.SetTint(Color.GREEN);
                sp.SetParent(ag);

                ag.SetPosition(new Framework.Maths.Vector2(100, 100));
                resourceManager.LoadGameObject(ag);

                var kb = new KeyboardBehaviour();

                ag.AddBehaviour(kb);
            }

        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

        }

        public void TestButton()
        {
            Debug.LogMsg("Button Clicked");
        }

        public void TestTimer()
        {
            Debug.LogCustom("Timer Completed", ConsoleColor.Yellow, false);
        }
    }
}
