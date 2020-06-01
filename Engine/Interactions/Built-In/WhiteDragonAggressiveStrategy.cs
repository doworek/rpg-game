using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Game.Engine.Monsters;
using Game.Engine.Monsters.MonsterFactories;

namespace Game.Engine.Interactions.Built_In
{
    //when you stole gold from Gnome
    class WhiteDragonAggressiveStrategy : IWhiteDragonStrategy
    {
        public void Execute(GameSession parentSession, PrincessEncounter princess)
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
                    parentSession.SendText("A key? I've heard you stole gold from a Gnome. You want my gold too, don't you? You won't leave here alive!");
                    parentSession.FightThisMonster(whiteDragonFight);
                    parentSession.SendText("\nYou defeated White Dragon! But...there's no key.");
                    princess.Strategy = new PrincessGratefulStrategy();
                    break;
                case 1:
                    parentSession.SendText("You'll regret it!");
                    parentSession.FightThisMonster(whiteDragonFight);
                    parentSession.SendText("\nYou defeated White Dragon! But...there's no key.");
                    princess.Strategy = new PrincessGratefulStrategy();
                    parentSession.UpdateStat(8, 100);
                    break;
                default:
                    parentSession.SendText("Wait, you're that one who stole gold from a Gnome, huh? You want my gold too, don't you? You won't leave here alive!");
                    parentSession.FightThisMonster(whiteDragonFight);
                    parentSession.SendText("\nYou defeated White Dragon! But...there's no key.");
                    princess.Strategy = new PrincessGratefulStrategy();
                    break;
            }
        }
    }
}