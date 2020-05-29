using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class FloodPotionDecorator : SkillDecorator
    {
        // decorator for Flood Potion class
        public FloodPotionDecorator(Skill skill) : base("Flood Potion", 12, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Flood Potion: 6 + 0.2*MP damage [water] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("water");
            response.HealthDmg = 6 + (int)(0.2 * player.MagicPower);
            response.CustomText = "You use Wind Gust! (" + (6 + (int)(0.2 * player.MagicPower)) + " water damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
