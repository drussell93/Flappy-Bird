using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    // Delegate 
    public delegate void CollisionOccurrenceEventHandler(object sender, CollisionOccurrenceEventArgs e);

    public class EndGame
    {
        private bool _collision;
                   
        // Event declaration  
        public event CollisionOccurrenceEventHandler CollisionOccurrence;

        public EndGame()
        {
            _collision = false; 
        }

        // Mutators 
        public bool Collision
        {
            get { return _collision; }
            set { _collision = value; }
        }

        // On collision, raise event
        public void didCollide()
        {
            if(Collision == true)
            {
                CollisionOccurrenceEventArgs e = new CollisionOccurrenceEventArgs(_collision);
                OnCollisionOccurrence(e);
            }
        }

        protected virtual void OnCollisionOccurrence(CollisionOccurrenceEventArgs e)
        {
            if (CollisionOccurrence != null)
            {
                CollisionOccurrence(this, e);//Raise the event
            }
        }
    }

    public class CollisionOccurrenceEventArgs : EventArgs
    {
        private bool _collision;
        public CollisionOccurrenceEventArgs(bool status)
        {
            this._collision = status;
        }
        public bool CollisionOccurrence
        {
            get
            {
                return _collision;
            }
        }
    }
}
