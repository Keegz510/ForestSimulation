using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;

namespace Framework.Debug
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogError(string message, bool pauseGame = false)
        {
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
    }
}
