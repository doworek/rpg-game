using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game.Engine.Interactions.Built_In
{
    //Princess strategy when you didn't fight with a dragon

    [Serializable]
    class PrincessNormalStrategy : IPrincessStrategy
    {
        public void Execute(GameSession parentSession, QuestInteraction quest)
        {
            GoldenKey goldenKey = new GoldenKey();
            int GetListBoxChoice(List<string> choices)
            {
                return parentSession.ListBoxInteractionChoice(choices);
            }

            parentSession.SendText("Welcome! You're looking for a key? I'm not sure if I should give it to you...what can you do to change my mind?");
            int choice = GetListBoxChoice(new List<string>() { "I'm a very brave knight, so I deserve a key.", "How about we play a game?", "Just give me the key!" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\nOoooh? We will see then!");
                    for (int i = 0; i < 3; i++)
                    {
                        parentSession.FightRandomMonster();
                    }
                    parentSession.SendText("\nAmazing! Here is the key.");
                    parentSession.AddThisItem(goldenKey);
                    quest.Strategy = new QuestCompleteStrategy();
                    break;
                case 1:
                    parentSession.SendText("\nActually I'm suuuuper bored. So let's play.");
                    WarGame();
                    break;
                default:
                    parentSession.SendText("\nSuch a rude fellow...! Go away then!");
                    break;
            }

            void WarGame()
            {
                parentSession.SendText("\nYou need to get a higher number than princess. If you win 2 out of 3 rounds you win.");
                int yourScore = 0;

                for (int i = 0; i < 3; i++)
                {
                    int princessResult = Index.RNG(1, 7);
                    int yourResult = Index.RNG(1, 7);
                    parentSession.SendText("Press 1 to continue or ENTER to quit");
                    string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", "1" }).Item1;
                    if (key == "Return") { return; }
                    if (key == "1")
                    {
                    parentSession.SendText("\nPrincess score: " + princessResult);
                    parentSession.SendText("Your score: " + yourResult);
                        if (yourResult > princessResult)
                        {
                            parentSession.SendText("\nYou won round " + (i + 1));
                            yourScore++;
                        }
                        else if (yourResult == princessResult)
                        {
                            parentSession.SendText("\nIt's a draw. One more time");
                            i--;
                        }
                        else
                        {
                            parentSession.SendText("\nYou lost round " + (i + 1));
                        }
                    }
                }
                if (yourScore >= 2)
                {
                    parentSession.SendText("\nYou won! Ok, here is the key.");
                    parentSession.AddThisItem(goldenKey);
                    quest.Strategy = new QuestCompleteStrategy();
    }
                else
                {
                    parentSession.SendText("\nHahaha, you loser. Maybe next time you'll be more lucky.");
                }
            }
        }
    }
}
