using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    [Serializable]
    public abstract class Interaction : DisplayItem
    {
        protected GameSession parentSession;
        public bool Enterable { get; protected set; } = true; // display: can you enter this place?
        public Interaction(GameSession ses)
        {
            parentSession = ses;
        }

        // every interaction has to know how to run itself
        public abstract void Run();
    }
}
