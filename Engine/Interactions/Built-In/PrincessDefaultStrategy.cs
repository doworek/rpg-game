using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    //Princess strategy when you haven't met dragon yet

    [Serializable]
    class PrincessDefaultStrategy : IPrincessStrategy
    {
        public void Execute(GameSession parentSession, QuestInteraction quest)
        {
            parentSession.SendText("You can't meet Princess");
        }
    }
}
