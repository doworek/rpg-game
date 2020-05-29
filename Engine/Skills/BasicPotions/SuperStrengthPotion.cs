using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class SuperStrengthPotion : Skill
    {
        // Super Strength Potion: you need to use an axe
        public SuperStrengthPotion() : base("Super Strength Potion", 25, 1)
        {
            PublicName = "Super Strength Potion [requires axe]: 5 + 0.5*Str + 0.2*Pr damage [incised]";
            RequiredItem = "Axe";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.HealthDmg = 5 + (int)(0.5 * player.Strength) + (int)(0.2 * player.Precision);
            response.CustomText = "You use Super Strength Potion! (" + (5 + ((int)(0.5 * player.Strength) + (int)(0.2 * player.Precision))) + " incised damage)";
            return new List<StatPackage>() { response };
        }
    }
}
