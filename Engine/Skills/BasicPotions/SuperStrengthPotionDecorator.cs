using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class SuperStrengthPotionDecorator : SkillDecorator
    {
        // Super Strength Potion: you need to use an axe
        public SuperStrengthPotionDecorator(Skill skill) : base("Super Strength Potion", 25, 1, skill)
        {
            PublicName = "Super Strength Potion [requires axe]: 5 + 0.5*Str + 0.2*Pr damage [incised] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Axe";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.HealthDmg = 5 + (int)(0.5 * player.Strength) + (int)(0.2 * player.Precision);
            response.CustomText = "You use Super Strength Potion! (" + (5 + ((int)(0.5 * player.Strength) + (int)(0.2 * player.Precision))) + " incised damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
