using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    [Serializable]
    class QuestCompleteStrategy : IQuestStrategy
    {
        private bool active = true;
        public void Execute(GameSession parentSession, QuestInteraction chest)
        {
            chest.OpenChest();
            if (active)
            {
                parentSession.SendText("\nCongratulations!!! Quest-chest completed! You get 200 gold");
                parentSession.UpdateStat(8, 200);
                parentSession.SendText("\nPress ENTER exit");
            }
            else
            {
                parentSession.SendText("\nThis quest has ended. Go on your next adventure!");
            }
            string key = parentSession.GetValidKeyResponse(new List<string>() { "Return" }).Item1;
            if (key == "Return")
            {
                active = false;
                return;
            }
        }
    }
}