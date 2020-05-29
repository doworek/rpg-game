using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Game.Engine.Monsters;
using Game.Engine.Monsters.MonsterFactories;

namespace Game.Engine.Interactions.Built_In
{
    // White Dragon strategy when you haven't met Gnome yet

    [Serializable]
    class WhiteDragonDefaultStrategy : IWhiteDragonStrategy
    {
        public void Execute(GameSession parentSession)
        {
            Dragon dragon = new Dragon(parentSession.currentPlayer.Level);
            parentSession.SendText("Don't bother me!");
            parentSession.FightThisMonster(dragon);
        }
    }
}