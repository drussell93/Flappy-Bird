using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    class UpperPipe : Pipe
    {
        public UpperPipe()
        {
            _height = 9;
        }

        public override int RandomizePosition()
        {
            _position = rand.Next(900, 1100); 
            return _position; 
        }
        public override int RandomizeHeight()
        {
            _height = rand.Next(-200, 0);
            return _height;
        }
    }
}
