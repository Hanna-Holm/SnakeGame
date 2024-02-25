using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SnakeGame
{
    internal class Snake
    {
        private float _moveSpeed = 100f;
        private Direction _movementDirection = Direction.Right;
        private Vector2f _position = new Vector2f(100, 200);
        public RectangleShape Body;
        public int LengthInSegments = 1;
        public bool IsAlive;
        private readonly Clock _clock = new Clock();
        public float deltaTime;

        // metoder: SetDirection, IncreaseLength, Eat, CheckCollision -> food / walls, Lose, Reset

        //public Vector2f Position = new Vector2f(100, 200);
        //public RectangleShape Body = new RectangleShape(new Vector2f(10, 10));
        //public int Length = 10;
        //private bool _isAlive = true;
        //private Direction _direction;

        public Snake()
        {
            IsAlive = true;
            Body = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Green,
                Position = _position
            };
        }

        public void Move()
        {
            deltaTime = _clock.Restart().AsSeconds();
            CheckDirection();
            Body.Position = _position;
            HandleInput();

            // handle collisions with apple and walls
        }

        public void CheckDirection()
        {
            switch (_movementDirection)
            {
                case Direction.Left:
                    MoveLeft();
                    break;
                case Direction.Right:
                    MoveRight();
                    break;
                case Direction.Up:
                    MoveUp();
                    break;
                case Direction.Down:
                    MoveDown();
                    break;
            }
        }

        private void MoveDown()
        {
            _position.Y += _moveSpeed * deltaTime;
        }

        private void MoveUp()
        {
            _position.Y -= _moveSpeed * deltaTime;
        }

        private void MoveRight()
        {
            _position.X += _moveSpeed * deltaTime;
        }

        private void MoveLeft()
        {
            _position.X -= _moveSpeed * deltaTime;
        }

        private void HandleInput()
        {
            if (_movementDirection == Direction.Left || _movementDirection == Direction.Right)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    _movementDirection = Direction.Up;
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    _movementDirection = Direction.Down;
            }
            else if (_movementDirection == Direction.Down || _movementDirection == Direction.Up)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    _movementDirection = Direction.Right;
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    _movementDirection = Direction.Left;
            }
        }


        //private void Eat(IEdible edible)
        //{
        //    edible.GetEatenBy(this);
        //}

    }

    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}
