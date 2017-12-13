using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    
    class GameObject
    {
        // Private variables 
        private int _gravity = 0;

        // Protected variables 
        protected int _speed = 0; 

        // Constructor 
        public GameObject()
        { }

        // Mutators 
        public int Gravity
        {
            get { return _gravity; }
            set { _gravity = value;  }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        // Functions 
        public virtual void IncreaseSpeed()
        {
            _speed += 1; 
        }

    }  
}


