
using SFML.Graphics;
using SFML.System;

namespace SnakeGame
{
    internal class GameBoard
    {
        public Snake Snake { get; }
        public Apple Apple { get; }
        private uint _width;
        private uint _height;

        public GameBoard(uint width, uint height)
        {
            Snake = new Snake();
            Apple = new Apple(width, height);
        }

        public void CheckCollision()
        {
            if (Apple.Shape.Position == Snake.Position)
            {
                Apple.GenerateNewPosition(_width, _height);
            }
        }
    }
}
