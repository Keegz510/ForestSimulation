using Framework.Engine;
namespace ForestSim
{
    public static class Program
    {
        public static void Main()
        {
            Game game = new Game();
            WindowSettings window = new WindowSettings
            {
                WindowWidth = 1200,
                WindowHeight = 850,
                bIsFullscreen = false,
                WindowTitle = "Forest Simulator"
            };

            game.Initialize(window);
            game.LoadState(new MainMenuState());
            game.Update();
        }
    }
}