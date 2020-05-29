using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    [Serializable]
    class WhiteDragonEncounter : ListBoxInteraction
    {
        private int visited = 0; // how many times have you visited this place?
        public IWhiteDragonStrategy Strategy { get; set; } // store strategy 
        public WhiteDragonEncounter(GameSession ses) : base(ses)
        {
            Enterable = false;
            Name = "interaction0008";
            Strategy = new WhiteDragonDefaultStrategy(); // start with default strategy

        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession); // execute strategy

           
        }
    }
}