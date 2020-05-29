using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class GoldenSword : Sword
    {
        public GoldenSword() : base("item0011")
        {
            StrMod = 20;
            PrMod = 10;
            MgcMod = 6;
            GoldValue = 100;
            PublicTip = "each 5 points of strength are converted into 1 point of bonus magic power; extra 10 % reduction of magic damage and 15% reduction of physical damage";
            PublicName = "Golden Sword";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.MagicPowerBuff += MgcMod + currentPlayer.Strength / 5;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "fire" || pack.DamageType == "water" || pack.DamageType == "air" || pack.DamageType == "earth")
            {
                pack.HealthDmg = 90 * pack.HealthDmg / 100;

            } else if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg = 85 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}
