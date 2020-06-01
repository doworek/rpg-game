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
        private PrincessEncounter princess;
        public IWhiteDragonStrategy Strategy { get; set; } // store strategy 
        public WhiteDragonEncounter(GameSession ses, PrincessEncounter princess) : base(ses)
        {
            Enterable = false;
            Name = "interaction0008";
            Strategy = new WhiteDragonDefaultStrategy(); // start with default strategy
            this.princess = princess;
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, princess); // execute strategy
        }
    }
}