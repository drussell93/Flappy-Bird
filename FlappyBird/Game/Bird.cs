using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    class Bird : GameObject
    {
        // Private variables 
        private bool _jumping = false;
        private int _score = 0;
        private string _name = "Anonymous";

        // Constructor
        public Bird()
        {
            Gravity = 5;
            Speed = 0; 
        }

        // Mutators 
        public bool Jumping
        {
            get { return _jumping; }
            set { _jumping = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
