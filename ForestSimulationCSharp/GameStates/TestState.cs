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
                Size buttonSize = new Size
                {
                    Width = 32,
                    Height = 32
                };

                Button btn = new Button(buttonSize, "TestButton");
                btn.SetPosition(new Framework.Maths.Vector2(100, 100));
                
                sprite = resourceManager.LoadSprite("Images/Square32x32.png");
                sprite.SetParent(btn);
                sprite.SetPosition(new Framework.Maths.Vector2(0, 0));
                sprite.SetTint(Color.GREEN);
               
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

        }
    }
}
