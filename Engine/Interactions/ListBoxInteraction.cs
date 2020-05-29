using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // class representing an event (or a chain of events) that will be executed at some map location
    // listbox interaction means that the player can choose options displayed in a listboc form

    [Serializable]
    abstract class ListBoxInteraction : Interaction
    {
        public ListBoxInteraction(GameSession ses) : base(ses) { }
        public override void Run()
        {
            parentSession.StopMoving();
            RunContent();
            parentSession.StartMoving();
        }

        // this is where all events should happen
        // refer to GameSessionPublicLogic for the possible ways of interacting with user and game
        protected abstract void RunContent();

        // an additional method just for this interaction type - send listbox choices to the screen
        // and get the answer as int (number on the list)
        protected int GetListBoxChoice(List<string> choices)
        {
            return parentSession.ListBoxInteractionChoice(choices);
        }
    }
}
