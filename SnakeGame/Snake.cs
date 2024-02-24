using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        public Vector2f Position = new Vector2f(100, 200);
        public RectangleShape Body = new RectangleShape(new Vector2f(10, 10));
        public int Length = 10;
        private bool _isAlive = true;
        private Direction _direction;

        public Snake()
        {
            _direction = Direction.Right;
            Body.FillColor = SFML.Graphics.Color.Green;
        }

        private void Eat(IEdible edible)
        {
            edible.GetEatenBy(this);
        }

        public void SetDirection(Direction newDirection)
        {
            // Prevent the snake from immediately reversing its direction
            if ((_direction == Direction.Left && newDirection != Direction.Right) ||
                (_direction == Direction.Right && newDirection != Direction.Left) ||
                (_direction == Direction.Up && newDirection != Direction.Down) ||
                (_direction == Direction.Down && newDirection != Direction.Up))
            {
                _direction = newDirection;
            }
        }
    }
}
