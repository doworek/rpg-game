using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Dragon : Monster
    {
        public Dragon(int dragonLevel)
        {
            Health = 30 + 8 * dragonLevel;
            Strength = 10 + dragonLevel;
            Armor = 15;
            Precision = 100;
            MagicPower = 20;
            Stamina = 120;
            XPValue = 70 + dragonLevel;
            Name = "monster0004";
            BattleGreetings = "Raawr! I'm a dragon!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 15;
                return new List<StatPackage>() { new StatPackage("fire", 10 + MagicPower, "Dragon uses Fire! (" + (10 + MagicPower) + " fire damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Dragon has no energy to attack anymore!") };
            }
        }
    }
}
