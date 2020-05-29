using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class BasicPotionFactory : SkillFactory
    {
        // this factory produces skills from BasicPotion directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the BasicSpells category are known by the player already
            if (known == null) // no BasicSpells known - we will return one of them
            {
                FloodPotion s1 = new FloodPotion();
                MagicalPotion s2 = new MagicalPotion();
                SuperStrengthPotion s3 = new SuperStrengthPotion();
                // only include elligible potions
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                FloodPotionDecorator s1 = new FloodPotionDecorator(known);
                MagicalPotionDecorator s2 = new MagicalPotionDecorator(known);
                SuperStrengthPotionDecorator s3 = new SuperStrengthPotionDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of BasicSpells has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is FloodPotion || skill is MagicalPotion || skill is SuperStrengthPotion || skill is FloodPotionDecorator || skill is MagicalPotionDecorator || skill is SuperStrengthPotionDecorator) return skill;
            }
            return null;
        }

    }
}
