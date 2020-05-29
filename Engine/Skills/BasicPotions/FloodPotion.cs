using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class FloodPotion : Skill
    {
        // Flood Potion (water attack): 6 + 0.2*MP damage [water]
        public FloodPotion() : base("Flood Potion", 12, 2)
        {
            PublicName = "Flood Potion: 6 + 0.2*MP damage [water]";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("water");
            response.HealthDmg = 6 + (int)(0.2 * player.MagicPower);
            response.CustomText = "You use Wind Gust! (" + (6 + (int)(0.2 * player.MagicPower)) + " water damage)";
            return new List<StatPackage>() { response };
        }
    }
}
