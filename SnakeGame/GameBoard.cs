
using SFML.Graphics;
using SFML.System;

namespace SnakeGame
{
    internal class GameBoard
    {
        public Snake Snake { get; }
        public Apple Apple { get; }
        public Vector2i Position { get; private set; }


        public GameBoard(uint width, uint height)
        {
            Snake = new Snake();
            Apple = new Apple(width, height);
        }
    }
}
