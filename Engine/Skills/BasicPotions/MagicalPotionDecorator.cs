using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class MagicalPotionDecorator : SkillDecorator
    {
        // decorator for MagicalPotion class
        public MagicalPotionDecorator(Skill skill) : base("MagicalPotion", 10, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Magical Potion: damage [earth] and magic damage AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
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
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
