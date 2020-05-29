using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class AncientSword : Sword
    {
        private int ancientBonus;
        public AncientSword() : base("item0009")
        {
            StrMod = 8;
            PrMod = 5;
            GoldValue = 20;
            PublicTip = "when you lose X health, receive a X/5 percentage bonus to physical damage you deal in this battle";
            PublicName = "Ancient Sword";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg = (100 + ancientBonus / 5) * pack.HealthDmg / 100;
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            ancientBonus += pack.HealthDmg;
            return pack;
        }
    }
}
