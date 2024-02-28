
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
            if (areColliding())
            {
                Apple.GenerateNewPosition();
            }
        }

        private bool areColliding()
        {
            float collisionRange = 5f;

            if (Snake.Position.X >= Apple.Shape.Position.X - collisionRange &&
                Snake.Position.X <= Apple.Shape.Position.X + collisionRange &&
                Snake.Position.Y >= Apple.Shape.Position.Y - collisionRange &&
                Snake.Position.Y <= Apple.Shape.Position.Y + collisionRange)
            {
                return true;
            }
            return false;
        }
    }
}
