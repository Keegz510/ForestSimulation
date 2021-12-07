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
        Button newSimBtn = null;
        Button ExitSimBtn = null;
        Sprite background = null;
        public MainMenuState() : base()
        { }

        public override void Init()
        {
            base.Init();

            background = resourceManager.LoadSprite("Images/MainMenuBackground.png");


            CreateNewSimBtn();
            CreateExitButton();
        }

        public void CreateNewSimBtn()
        {
            Size buttonSize = new Size
            {
                Width = 170,
                Height = 50
            };

            // Create the button and set the scale to be 2
            Button btn = new Button(buttonSize, LoadSim, "LoadSimBtn");
            btn.Scale = 2;

            // Set the position of the button
            btn.SetPosition(new Vector2(30, 70));

            Font font = LoadFont("Fonts/Pergola.otf");
            TextField btnText = new TextField("New Simulation", font, "NewSimText");
            resourceManager.AddDrawable(btnText);
            btnText.SetParent(btn);
            var textPos = new Vector2
            {
                x = buttonSize.Width / 2,
                y = buttonSize.Height / 2
            };
            btnText.SetPosition(textPos);
            btnText.SetTint(Color.BLACK);

            newSimBtn = btn;
        }

        public void CreateExitButton()
        {
            Size buttonSize = new Size
            {
                Width = 170,
                Height = 50
            };

            // Create the button and set the scale to be 2
            Button btn = new Button(buttonSize, LoadSim, "ExitSimBtn");
            btn.Scale = 2;
            // Handle loading the new game object
            resourceManager.LoadGameObject(btn);

            // Set the position of the button
            btn.SetPosition(new Vector2(30, 150));

            Font font = LoadFont("Fonts/Pergola.otf");
            TextField btnText = new TextField("Exit Simulation", font, "ExitSimText");
            resourceManager.AddDrawable(btnText);
            btnText.SetParent(btn);
            var textPos = new Vector2
            {
                x = buttonSize.Width / 2,
                y = buttonSize.Height / 2
            };
            btnText.SetPosition(textPos);
            btnText.SetTint(Color.BLACK);

            ExitSimBtn = btn;
        }

        public void LoadSim()
        {
            Debug.LogMsg("Test Message");
        }

        public void ExitSim()
        {

        }
    }
}
