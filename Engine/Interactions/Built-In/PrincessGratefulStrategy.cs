using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game.Engine.Interactions.Built_In
{
    //Princess strategy when you defeated a dragon

    [Serializable]
    class PrincessGratefulStrategy : IPrincessStrategy
    {
        public void Execute(GameSession parentSession, QuestInteraction quest)
        {
            GoldenKey goldenKey = new GoldenKey();
            parentSession.SendText("You defeated dragon? Thanks a lot! Of course I will give you the key, my savior.");
            parentSession.AddThisItem(goldenKey);
            quest.Strategy = new QuestCompleteStrategy();
        }
    }
}
