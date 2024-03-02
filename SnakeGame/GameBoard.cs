
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
        private float _collisionRange = 7f;

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
                Snake.IncreaseLength();
            }
        }

        private bool areColliding()
        {

            if (Snake.Position.X >= Apple.Shape.Position.X - _collisionRange &&
                Snake.Position.X <= Apple.Shape.Position.X + _collisionRange &&
                Snake.Position.Y >= Apple.Shape.Position.Y - _collisionRange &&
                Snake.Position.Y <= Apple.Shape.Position.Y + _collisionRange)
            {
                return true;
            }

            return false;
        }
    }
}
