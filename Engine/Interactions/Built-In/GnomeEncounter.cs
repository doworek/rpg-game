using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // Quest1: Gnome

    [Serializable]
    class GnomeEncounter : ListBoxInteraction
    {
        private QuestInteraction questChest; // store reference to quest
        private WhiteDragonEncounter whiteDragon;
        private int stolen = 0;
        private bool badEvent = false; //bad thing happend

        public GnomeEncounter(GameSession ses, QuestInteraction questChest, WhiteDragonEncounter whiteDragon) : base(ses)
        {
            Enterable = false;
            Name = "interaction0007";
            this.questChest = questChest;
            this.whiteDragon = whiteDragon;
        }
        protected override void RunContent()
        {
            if (badEvent) // already visited this place and bad things happened 
            {
                parentSession.SendText("\nYou again? Give me back my gold!");
                parentSession.SendText("Gnome takes back " + stolen + " gold from you.");
                parentSession.UpdateStat(8, -stolen);
                return;
            }

            if (questChest.visited)
            {
                parentSession.SendText("\nSo you want to know where to find a key? Maybe I know...or maybe I don't. Let's play a game:");
                parentSession.SendText("Let's roll a dice. If you get 5 or more I'll tell. If you lose, you'll pay me 10 gold.");
                parentSession.SendText("You can also pay me 5 gold for every guaranteed point. So? What you say?");
                // get player choice
                int choice = GetListBoxChoice(new List<string>() { "Sure, let's play.", "I don't feel like playing games. Bye!" });
                switch (choice)
                {
                    case 0:
                        if (parentSession.currentPlayer.Gold >= 15)
                        {
                            parentSession.SendText("\nDo you want to buy some points?");
                            int choice2 = GetListBoxChoice(new List<string>() { "Yes", "No, I feel lucky today" });
                            if (choice2 == 0)
                            {
                                BuyPoints();
                            }
                            else DiceGame(0);
                        }
                        else
                        {
                            parentSession.SendText("\nYou need at least 15 gold to play.");
                            return;
                        }
                        break;
                    default:
                        parentSession.SendText("\nGo away then.");
                        break;
                }
            }
            else
            {
                // standard encounter
                parentSession.SendText("\nWho are you? Nevermind, I'm busy.");
            }
        }

        private void DiceGame(int points)
        {
            parentSession.SendText("\nLet's start a game then!");
            int result = Index.RNG(1, 7) + points;
            parentSession.SendText("Your score: " + result);
            if (result >= 5)
            {
                parentSession.SendText("\nYou won! That can't be...but fine. Go find a White Dragon next. He has a lot of gold things and a key should be one them.");
                // get player choice
                int choice = GetListBoxChoice(new List<string>() { "Thanks, bye!", "[steal some gold before you go]" });
                switch (choice)
                {
                    case 1:
                        parentSession.SendText("\nYou thief! Come back!");
                        stolen = Index.RNG(5, 20);
                        parentSession.UpdateStat(8, stolen);
                        parentSession.SendText("\nYou stole " + stolen + " gold.");
                        whiteDragon.Strategy = new WhiteDragonAggressiveStrategy();
                        badEvent = true;
                        break;
                    default:
                        parentSession.SendText("\nBye, bye");
                        whiteDragon.Strategy = new WhiteDragonNormalStrategy();
                        break;
                }

            }
            else
            {
                parentSession.SendText("\nYou lost. Ahahaha. Now pay. Maybe next time you'll be more lucky.");
                parentSession.UpdateStat(8, -10);
            }
        }

        private void BuyPoints()
        {
            parentSession.SendText("\nHow many points do you want to buy?");
            parentSession.SendText("Press 1, 2 or 3");
            string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", "1", "2", "3" }).Item1;
            if (key == "Return")
            {
                return;
            }
            if (key == "1")
            {
                if (parentSession.currentPlayer.Gold >= 5)
                {
                    parentSession.UpdateStat(8, -5);
                    DiceGame(1);
                }
                else parentSession.SendText("Sorry, you don't have enough gold! Go away!");
            }
            else if (key == "2")
            {
                if (parentSession.currentPlayer.Gold >= 10)
                {
                    parentSession.UpdateStat(8, -10);
                    DiceGame(2);
                }
                else parentSession.SendText("Sorry, you don't have enough gold! Go away!");
            }
            else if (key == "3")
            {
                if (parentSession.currentPlayer.Gold >= 15)
                {
                    parentSession.UpdateStat(8, -15);
                    DiceGame(3);
                }
                else parentSession.SendText("Sorry, you don't have enough gold! Go away!");
            }
        }

    }
}