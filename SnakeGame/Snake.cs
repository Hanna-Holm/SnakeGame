using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SnakeGame
{
    internal class Snake
    {
        private const float Speed = 100f;
        private Direction _direction = Direction.Right;
        public Vector2f Position => _position;
        private Vector2f _position = new Vector2f(100, 200);
        private RectangleShape _body;
        public int LengthInSegments { get; private set; } = 10;
        public bool IsAlive;

        public Snake()
        {
            IsAlive = true;
            _body = new RectangleShape(new Vector2f(LengthInSegments, 10))
            {
                FillColor = Color.Green,
                Position = new Vector2f(100, 200)
            };
        }

        public void Move(float deltaTime)
        {

            HandleDirectionChange();
            KeepGoingInCurrentDirection(deltaTime);
        }

        public void KeepGoingInCurrentDirection(float deltaTime)
        {
            switch (_direction)
            {
                case Direction.Left:
                    _position.X -= Speed * deltaTime;
                    break;
                case Direction.Right:
                    _position.X += Speed * deltaTime;
                    break;
                case Direction.Up:
                    _position.Y -= Speed * deltaTime;
                    break;
                case Direction.Down:
                    _position.Y += Speed * deltaTime;
                    break;
            }

            _body.Position = _position;
        }

        private void HandleDirectionChange()
        {
            if (_direction == Direction.Left || _direction == Direction.Right)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    _direction = Direction.Up;
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    _direction = Direction.Down;
            }
            else if (_direction == Direction.Down || _direction == Direction.Up)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    _direction = Direction.Right;
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    _direction = Direction.Left;
            }
        }

        public void IncreaseLength()
        {
            LengthInSegments += 10;
            _body = new RectangleShape(new Vector2f(LengthInSegments, 10))
            {
                FillColor = Color.Green
            };
        }

        //private void Eat(IEdible edible)
        //{
        //    edible.GetEatenBy(this);
        //}

        public void Render(RenderWindow window)
        {
            window.Draw(_body);
        }
    }

    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}
