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
        private readonly Clock _clock = new Clock();

        public Game()
        {
            // Setup window
            _window = new RenderWindow(new VideoMode(800, 600), "Snake game");
        }

        public void Run()
        {
            bool shouldGoLeft = false;
            bool shouldGoRight = false;
            bool shouldGoUp = false;
            bool shouldGoDown = false;

            // Main game loop
            while (_window.IsOpen)
            {
                // Handle events
                _window.DispatchEvents();

                // Get elapsed time since clock was restarted.
                float deltaTime = _clock.Restart().AsSeconds();

                // Update game logic here
                _snake = new RectangleShape(new Vector2f(10, 10))
                {
                    FillColor = SFML.Graphics.Color.Green,
                    Position = _position
                };

                // Update state machine

                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    shouldGoLeft = true;
                    shouldGoRight = false;
                    shouldGoUp = false;
                    shouldGoDown = false;

                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    shouldGoRight = true;
                    shouldGoLeft = false;
                    shouldGoUp = false;
                    shouldGoDown = false;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    shouldGoUp = true;
                    shouldGoRight = false;
                    shouldGoLeft = false;
                    shouldGoDown = false;

                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    shouldGoDown = true;
                    shouldGoRight = false;
                    shouldGoLeft = false;
                    shouldGoUp = false;
                }

                if (shouldGoLeft)
                {
                    _position.X -= _moveSpeed * deltaTime;
                }
                else if (shouldGoRight)
                {
                    _position.X += _moveSpeed * deltaTime;
                }
                else if (shouldGoUp)
                {
                    _position.Y -= _moveSpeed * deltaTime;
                }
                else if (shouldGoDown)
                {
                    _position.Y += _moveSpeed * deltaTime;
                }

                _snake.Position = _position;

                Render();

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
