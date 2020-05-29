using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;
using Game.Engine.Monsters.MonsterFactories;

namespace Game.Engine.Interactions.Built_In
{
    class WhiteDragonNormalStrategy : IWhiteDragonStrategy
    {
        GoldenSword goldenSword = new GoldenSword();
        public void Execute(GameSession parentSession)
        {
            int GetListBoxChoice(List<string> choices)
            {
                return parentSession.ListBoxInteractionChoice(choices);
            }

            parentSession.SendText("\nWhat do you want?");
            DragonEvolved whiteDragonFight = new DragonEvolved(parentSession.currentPlayer.Level);
            // get player choice
            int choice = GetListBoxChoice(new List<string>() { "I'm looking for a key. Do you have one?", "I've heard you have a lot of gold. Let's fight!", "N-n-n-nothing, bye!" });
                switch (choice)
                {
                    case 0:
                    parentSession.SendText("\nMaybe I have...or maybe I don't. How about a little exchange? I really want a golden sword. Bring it to me and I'll give you a key.");
                        int choice2 = GetListBoxChoice(new List<string>() { "Ok", "No way! I won't give you anything!" });
                    if (choice2 == 0)
                    {
                        if (parentSession.TestForItem("item0011"))
                        {
                            parentSession.SendText("\nThanks human. A key? Hahahaha, I don't have it! One cheeky princess took it from me long time ago. Find her if you want a key.");
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        parentSession.SendText("Then I won't let you go!");
                        parentSession.FightThisMonster(whiteDragonFight);
                        parentSession.SendText("\nYou defeated White Dragon! But...there's no key.");
                    }
                    break;
                    case 1:
                    parentSession.SendText("You'll regret it!");
                    parentSession.FightThisMonster(whiteDragonFight);
                    parentSession.SendText("\nYou defeated White Dragon! You take all the gold but...there's no key.");
                    parentSession.UpdateStat(8, 100);
                    break;
                    default:
                        parentSession.SendText("What a weird human.");
                        break;
                }
        }
    }
}