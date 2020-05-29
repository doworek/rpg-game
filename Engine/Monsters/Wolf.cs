using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Wolf : Monster
    {
        // monster: wolf
        public Wolf(int wolfLevel)
        {
            Health = 30 + 6 * wolfLevel;
            Strength = 20 + wolfLevel;
            Armor = 0;
            Precision = 80;
            MagicPower = 0;
            Stamina = 90;
            XPValue = 40 + wolfLevel;
            Name = "monster0003";
            BattleGreetings = "Auuuu! I'm a wolf.";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 12;
                // a simple bite move
                return new List<StatPackage>() { new StatPackage("stab", 10 + Strength, "Wolf uses Bite! (" + (10 + Strength) + " stab damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Wolf has no energy to attack anymore!") };
            }
        }
    }
}
