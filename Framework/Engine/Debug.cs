using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;

namespace Framework
{
    public static class Debug
    {
        public static bool isDebugMode = true;

        public static void LogMsg(string message)
        {
            if (!isDebugMode) return;

            Console.WriteLine(message);
        }

        public static void LogWarning(string message)
        {
            if (!isDebugMode) return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogError(string message, bool pauseGame = false)
        {
            if (!isDebugMode) return;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            if(pauseGame)
            {
                foreach (var state in Game.Instance.LoadedStates)
                {
                    state.bIsStateActive = false;
                }
            }
        }

        public static void LogCustom(string message, ConsoleColor textColor, bool pauseGame)
        {
            if (!isDebugMode) return;

            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            if (pauseGame) PauseGame();
        }

        public static void PauseGame()
        {
            if (!isDebugMode) return;

            foreach (var state in Game.Instance.LoadedStates)
            {
                state.bIsStateActive = false;
            }
           
        }
    }
}
