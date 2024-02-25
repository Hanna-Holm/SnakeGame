using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SnakeGame
{
    internal class Game
    {
        private RenderWindow _window;
        private Snake _snake;

        public Game()
        {
            // Setup window
            _window = new RenderWindow(new VideoMode(800, 600), "Snake game");
            _snake = new Snake();
        }

        public void Run()
        {

            // Main game loop
            while (_window.IsOpen)
            {
                // Handle events
                _window.DispatchEvents();

                // Get elapsed time since clock was restarted.
                // float deltaTime = _clock.Restart().AsSeconds();

                // Game logic
                _snake.Move();


                Render();
            }

        }

        private void Render()
        {
            // Clear the window
            _window.Clear(Color.Black);

            // Draw game elements
            _window.Draw(_snake.Body);

            // Display the contents of the window
            _window.Display();
        }
    }

    
}
