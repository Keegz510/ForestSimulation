using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Framework.Engine
{
    public struct WindowSettings
    {
        public int WindowWidth;
        public int WindowHeight;
        public bool bIsFullscreen;
        public string WindowTitle;
    }

    public class Game
    {
        /// Reference to the current windows settings
        private WindowSettings windowSettings;
        
        /// Frames Per Second
        private float deltaTime;
        public float DeltaTime { get { return deltaTime; } }

        public Game()
        {
            
        }

        /// <summary>
        /// Initialize the game & creates a new window
        /// </summary>
        /// <param name="window">Game window settings</param>
        public void Initialize(WindowSettings window)
        {
            windowSettings = window;

            InitWindow(windowSettings.WindowWidth, windowSettings.WindowHeight, windowSettings.WindowTitle);
            SetTargetFPS(60);
        }

        public void Update()
        {
            deltaTime = GetFrameTime();

            while(!WindowShouldClose())
            {
                // === UPDATE GAME HERE === //

                BeginDrawing();
                ClearBackground(Color.RAYWHITE);
                // === DRAW GAME HERE === //
                DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);
                EndDrawing();
               
            }

            CloseWindow();

        }

    }
}
