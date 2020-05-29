using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class MagicalPotion : Skill
    {
        // Magical Potion: [Pr]% chance to hit with 0.6*[Mp] damage and makes enemy weaker
        public MagicalPotion() : base("MagicalPotion", 10, 2)
        {
            PublicName = "Magical Potion: damage [earth] and magic damage";
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("earth");
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.6 * player.MagicPower);
                response.MagicPowerDmg = (int)(0.1 * player.MagicPower);
                response.CustomText = "You use Magical Potion! (" + (int)(0.6 * player.MagicPower) + " earth damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.MagicPowerDmg = (int)(0.1 * player.MagicPower);
                response.CustomText = "You missed but now enemy's weaker!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
