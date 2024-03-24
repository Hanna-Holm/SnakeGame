
namespace SnakeGame
{
    internal class GameBoard
    {
        public Snake Snake { get; }
        public Apple Apple { get; }
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

            if (Snake.HeadPosition.X >= Apple.Shape.Position.X - _collisionRange &&
                Snake.HeadPosition.X <= Apple.Shape.Position.X + _collisionRange &&
                Snake.HeadPosition.Y >= Apple.Shape.Position.Y - _collisionRange &&
                Snake.HeadPosition.Y <= Apple.Shape.Position.Y + _collisionRange)
            {
                return true;
            }

            return false;
        }
    }
}
