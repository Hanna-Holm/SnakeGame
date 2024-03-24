using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SnakeGame
{
    internal class Snake
    {
        private const float Speed = 120f;
        private Direction _startingDirection = Direction.Right;
        private Vector2f _startingPosition = new Vector2f(100, 200);
        private List<Segment> _body = new List<Segment>();
        private Direction _headDirection;
        public Vector2f HeadPosition;

        public Snake()
        {
            _body.Add(new Segment(_startingPosition, _startingDirection));
            _headDirection = _body[0].Direction;
            HeadPosition = _body[0].Shape.Position;
        }

        public void Move(float deltaTime)
        {
            HandleDirectionChange();
            KeepGoingInCurrentDirection(deltaTime);
            HeadPosition = _body[0].Shape.Position;
        }

        private void HandleDirectionChange()
        {
            if (_body[0].Direction == Direction.Left || _body[0].Direction == Direction.Right)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    _body[0].Direction = Direction.Up;
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    _body[0].Direction = Direction.Down;
            }
            else if (_body[0].Direction == Direction.Down || _body[0].Direction == Direction.Up)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    _body[0].Direction = Direction.Right;
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    _body[0].Direction = Direction.Left;
            }
        }

        public void KeepGoingInCurrentDirection(float deltaTime)
        {
            float distance = Speed * deltaTime;

            switch (_body[0].Direction)
            {
                case Direction.Left:
                    for (int i = 0; i < _body.Count; i++)
                    {
                        float oldxValue = _body[i].Shape.Position.X;
                        float newxValue = oldxValue - distance;
                        Vector2f newPosition = new Vector2f(newxValue, _body[i].Shape.Position.Y);
                        _body[i].Shape.Position = newPosition;
                    }
                    break;
                case Direction.Right:
                    for (int i = 0; i < _body.Count; i++)
                    {
                        float oldxValue = _body[i].Shape.Position.X;
                        float newxValue = oldxValue + distance;
                        Vector2f newPosition = new Vector2f(newxValue, _body[i].Shape.Position.Y);
                        _body[i].Shape.Position = newPosition;
                    }
                    break;
                case Direction.Up:
                    for (int i = 0; i < _body.Count; i++)
                    {
                        float oldyValue = _body[i].Shape.Position.Y;
                        float newyValue = oldyValue - distance;
                        Vector2f newPosition = new Vector2f(_body[i].Shape.Position.X, newyValue);
                        _body[i].Shape.Position = newPosition;
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < _body.Count; i++)
                    {
                        float oldyValue = _body[i].Shape.Position.Y;
                        float newyValue = oldyValue + distance;
                        Vector2f newPosition = new Vector2f(_body[i].Shape.Position.X, newyValue);
                        _body[i].Shape.Position = newPosition;
                    }
                    break;
            }
        }

        public void IncreaseLength()
        {
            // Current approach: creating a new rectangleshape that will be the _body, but with 10 longer x-axis
            //Length += 10;
            //_body = new RectangleShape(new Vector2f(Length, 10))
            //{
            //    FillColor = Color.Green
            //};

            // New approach: Add new RectangleShape after the last element in _body list<RectangleShape>
            // Get last element in _body list
            // Get that element´s position and direction
            // Set same direction. _direction is for the first element in the list, the following elements gets set to same direction as the previous.
            // All of the elements position needs to be updated for each frame!
            // Depending on the direction for the current element, the position should be updated accordingly

        }

        public void Render(RenderWindow window)
        {
            foreach (var segment in _body)
            {
                window.Draw(segment.Shape);
            }
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
