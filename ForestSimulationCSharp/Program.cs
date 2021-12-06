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
                WindowWidth = 700,
                WindowHeight = 450,
                bIsFullscreen = false,
                WindowTitle = "Forest Simulator"
            };

            game.Initialize(window);
            game.LoadState(new TestState());
            game.Update();
        }
    }
}