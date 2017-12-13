using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    class Pipe : GameObject
    {
        protected int _height; 
        protected int _position = 1000;
       
        public Random rand = new Random();

        // Constructor
        public Pipe()
        {
            Speed = 5; 
        }
     
        // Mutators 
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public override void IncreaseSpeed()
        {
            _speed += 1;
        }

        public virtual int RandomizePosition()
        {
            //_position = rand.Next(400, 900); // 700 - 1200
            return _position; 
        }

        public virtual int RandomizeHeight()
        {
           //_height = rand.Next(187, 327);
            return _height; 
        }

    }
}
