using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        public int Length = 10;
        private bool _isAlive = true;

        private void Eat(IEdible edible)
        {
            edible.GetEatenBy(this);
        }

        
    }
}
