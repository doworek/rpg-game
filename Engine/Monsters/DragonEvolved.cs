using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class DragonEvolved : Monster
    {
        public DragonEvolved(int dragonLevel)
        {
            Health = 50 + 5 * dragonLevel;
            Strength = 10 + dragonLevel;
            Armor = 20;
            Precision = 130;
            MagicPower = 50;
            Stamina = 120;
            XPValue = 90 + dragonLevel;
            Name = "monster0005";
            BattleGreetings = "Raaaaaaawr! I am fire! I am ... death!"; // Smaug
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 15;
                return new List<StatPackage>()
                { 
                    new StatPackage("stab", 20 + Strength, "Dragon uses Bite! ("+ (20 + Strength) +" stab damage)"),
                    new StatPackage("fire", 20 + MagicPower, "Dragon uses Fire! (" + (20 + MagicPower) + " fire damage)")
                };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Dragon has no energy to attack anymore!") };
            }
        }
    }
}
