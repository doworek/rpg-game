using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills
{
    [Serializable]
    abstract class SkillDecorator : Skill
    {
        // decorate skills with other skills
        protected SkillDecorator(string name, int stamina, int minLevel, Skill skill) : base(name, stamina, minLevel)
        {
            StaminaCost += skill.StaminaCost;
            decoratedSkill = skill;
        }
    }
}
