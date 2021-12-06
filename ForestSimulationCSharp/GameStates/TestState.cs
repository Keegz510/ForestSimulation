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

        public TestState() : base()
        { }

        public override void Init()
        {
            base.Init();





            // ==== TEST OBJECT === //
            {
                Font font = LoadFont("Fonts/Pergola.otf");
                TextField field = new TextField("Test Field", font, "TestTextField");
                field.SetTint(Color.BLACK);
                field.SetPosition(new Framework.Maths.Vector2(200, 200));
                resourceManager.AddDrawable(field);
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
