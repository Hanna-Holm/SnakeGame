
using SFML.Graphics;
using SFML.System;

namespace SnakeGame
{
    internal class Segment
    {
        public RectangleShape Shape { get; set; }
        public Direction Direction;

        public Segment(Vector2f position, Direction direction)
        {
            Shape = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Green,
                Position = position
            };

            Direction = direction;
        }
    }
}
