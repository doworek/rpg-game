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
    class PrincessEncounter : ListBoxInteraction
    {
        public IPrincessStrategy Strategy { get; set; } // store strategy 
        private QuestInteraction quest;
        public PrincessEncounter(GameSession ses, QuestInteraction quest) : base(ses)
        {
            Enterable = false;
            Name = "interaction0010";
            Strategy = new PrincessDefaultStrategy(); // start with default strategy
            this.quest = quest;
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, quest); // execute strategy
        }
    }
}

