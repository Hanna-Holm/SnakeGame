using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SnakeGame
{
    internal class Game
    {
        public RenderWindow Window { get; private set; }
        public uint Width = 800;
        public uint Height = 600;
        private GameBoard _gameBoard;
        private readonly Clock _clock = new Clock();
        public float deltaTime;

        public Game()
        {
            // Setup window
            Window = new RenderWindow(new VideoMode(Width, Height), "Snake game");
            _gameBoard = new GameBoard(Width, Height);
        }

        public void Run()
        {

            // Main game loop
            while (Window.IsOpen)
            {
                // Handle events
                Window.DispatchEvents();

                // Get elapsed time since clock was restarted.
                deltaTime = _clock.Restart().AsSeconds();

                // Game logic
                _gameBoard.Snake.Move(deltaTime);

                // CheckCollision
                //      -> Apple -->  Eat()  --> Snake: IncreaseLength(), Apple: GenerateNewPosition()
                //      -> walls --> Lose()


                Render();
            }
        }

        private void Render()
        {
            // Clear the window
            Window.Clear(Color.Black);

            // Draw game elements
            _gameBoard.Snake.Render(Window);
            _gameBoard.Apple.Render(Window);

            // Display the contents of the window
            Window.Display();
        }
    }

    
}
