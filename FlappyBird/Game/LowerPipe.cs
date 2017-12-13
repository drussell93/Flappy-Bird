using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    class LowerPipe : Pipe
    {
        public LowerPipe()
        {
            _height = 327; 
        }

        public override int RandomizePosition()
        {
            _position = rand.Next(500, 700); 
            return _position;
        }

        public override int RandomizeHeight()
        {
            _height = rand.Next(187, 327);
            return _height;
        }
    }
}
