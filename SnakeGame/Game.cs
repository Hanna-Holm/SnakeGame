using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SnakeGame
{
    internal class Game
    {
        private RenderWindow _window;
        private RectangleShape _snake;

        public Game()
        {
            // Setup window
            _window = new RenderWindow(new VideoMode(800, 600), "SFML Window");
            _snake = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Green,
                Position = new Vector2f(100, 200)
            };
        }

        public void Run()
        {
            // Main game loop
            while (_window.IsOpen)
            {
                // Handle events
                _window.DispatchEvents();

                // Update game logic here

                // Clear the window
                _window.Clear(Color.Black);

                // Draw game elements here
                _window.Draw(_snake);

                // Display the contents of the window
                _window.Display();
            }

            // Add snake

            // Make snake move every frame
            // Be able to give input to move snake
            // handle collisions with apple and walls


        }
    }
}
