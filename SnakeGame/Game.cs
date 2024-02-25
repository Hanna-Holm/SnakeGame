using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SnakeGame
{
    internal class Game
    {
        private RenderWindow _window;
        private RectangleShape _snake;
        private Vector2f _position = new Vector2f(100, 200);
        private float _moveSpeed = 100f;
        private readonly Clock _clock = new Clock();
        private State _movementDirection;

        public Game()
        {
            // Setup window
            _window = new RenderWindow(new VideoMode(800, 600), "Snake game");
            _movementDirection = State.MovingRight;
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
                _snake = new RectangleShape(new Vector2f(10, 10))
                {
                    FillColor = SFML.Graphics.Color.Green,
                    Position = _position
                };

                // Update state machine

                switch (_movementDirection)
                {
                    case State.MovingLeft:
                        _position.X -= _moveSpeed * deltaTime;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                            _movementDirection = State.MovingUp;
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                            _movementDirection = State.MovingDown;
                        break;
                    case State.MovingRight:
                        _position.X += _moveSpeed * deltaTime;

                        if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                            _movementDirection = State.MovingUp;
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                            _movementDirection = State.MovingDown;
                        break;
                    case State.MovingUp:
                        _position.Y -= _moveSpeed * deltaTime;

                        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                            _movementDirection = State.MovingLeft;
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                            _movementDirection = State.MovingRight;
                        break;
                    case State.MovingDown:
                        _position.Y += _moveSpeed * deltaTime;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                            _movementDirection = State.MovingLeft;
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                            _movementDirection = State.MovingRight;
                        break;
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

    enum State
    {
        MovingLeft,
        MovingRight,
        MovingUp,
        MovingDown
    }
}
