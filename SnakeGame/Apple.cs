using SFML.Graphics;
using SFML.System;

namespace SnakeGame
{
    internal class Apple
    {
        public RectangleShape Shape { get; }

        public Apple(uint gameBoardWidth, uint gameBoardHeight)
        {
            Shape = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Red,
            };
            
            GenerateNewPosition(gameBoardWidth, gameBoardHeight);
        }

        public void GenerateNewPosition(uint gameBoardWidth, uint gameBoardHeight)
        {
            int xPosition = new Random().Next(0, (int)gameBoardWidth);
            int yPosition = new Random().Next(0, (int)gameBoardHeight);
            Shape.Position = new Vector2f(xPosition, yPosition);
        }

        public void Render(RenderWindow window)
        {
            window.Draw(Shape);
        }
    }
}
