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
    class QuestBeginStrategy : IQuestStrategy
    {
        public void Execute(GameSession parentSession, QuestInteraction chest)
        {
            parentSession.SendText("\nOh-ho! You found a chest-quest!");
            parentSession.SendText("You need a key to open this chest.");
            parentSession.SendText("Your quest starts now: first find a Gnome.");
            parentSession.SendText("\nPress ENTER to start a CHEST-QUEST");
            string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", }).Item1;
            if (key == "Return") { return; }
        }
    }
}