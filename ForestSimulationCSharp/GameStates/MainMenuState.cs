using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;
using Framework.Maths;
using Framework;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace ForestSim
{
    public class MainMenuState : GameState
    {
        public MainMenuState() : base()
        { }

        public override void Init()
        {
            base.Init();
            Size buttonSize = new Size
            {
                Width = 170,
                Height = 50
            };

            Button newSimBtn = new Button(buttonSize, LoadSim, "LoadSimBtn");

            Sprite newSimSprite = resourceManager.LoadSprite("Images/Button_Background.png");

            resourceManager.LoadGameObject(newSimSprite);

            newSimSprite.SetParent(newSimBtn);

            newSimBtn.SetPosition(new Vector2(30, 70));


            resourceManager.LoadGameObject(newSimBtn);
            
        }

        

        public void LoadSim()
        {

        }

        public void ExitSim()
        {

        }
    }
}
