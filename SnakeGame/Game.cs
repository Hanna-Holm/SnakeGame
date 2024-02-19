using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Drawing;

namespace SnakeGame
{
    internal class Game
    {
        private RenderWindow _window;
        private RectangleShape _snake;
        private Vector2f _position = new Vector2f(100, 200);
        private float _moveSpeed = 100f;
        private const float TimePerFrame = 1f / 60f; // 60 frames per second
        private readonly Clock _clock = new Clock();

        public Game()
        {
            // Setup window
            _window = new RenderWindow(new VideoMode(800, 600), "Snake game");

            _snake = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = SFML.Graphics.Color.Cyan,
                Position = _position
            };
        }

        public void Run()
        {
            // Main game loop
            while (_window.IsOpen)
            {
                // Handle events
                _window.DispatchEvents();

                // Get elapsed time since clock was restarted.
                float deltaTime = _clock.Restart().AsSeconds();

                // Update game logic here

                //_position.X += _moveSpeed * deltaTime;
                //_snake.Position = _position;

                Render();


                // Be able to give input to move snake
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    _snake.Position -= new Vector2f(100 * deltaTime, 0);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    _snake.Position += new Vector2f(100 * deltaTime, 0);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    _snake.Position -= new Vector2f(0, 100 * deltaTime);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    _snake.Position += new Vector2f(0, 100 * deltaTime);
                }

                // handle collisions with apple and walls
            }

        }

        private void Render()
        {
            // Clear the window
            _window.Clear(SFML.Graphics.Color.Black);

            // Draw game elements
            _window.Draw(_snake);

            // Display the contents of the window
            _window.Display();
        }
    }
}
