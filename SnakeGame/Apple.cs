using SFML.Graphics;
using SFML.System;

namespace SnakeGame
{
    internal class Apple
    {
        public RectangleShape Shape { get; }
        private uint _upperLimitWidth;
        private uint _upperLimitHeight;

        public Apple(uint gameBoardWidth, uint gameBoardHeight)
        {
            Shape = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Red,
            };

            _upperLimitWidth = gameBoardWidth;
            _upperLimitHeight = gameBoardHeight;

            GenerateNewPosition();
        }

        public void GenerateNewPosition()
        {
            int xPosition = new Random().Next(0, (int)_upperLimitWidth);
            int yPosition = new Random().Next(0, (int)_upperLimitHeight);
            Shape.Position = new Vector2f(xPosition, yPosition);
        }

        public void Render(RenderWindow window)
        {
            window.Draw(Shape);
        }
    }
}
