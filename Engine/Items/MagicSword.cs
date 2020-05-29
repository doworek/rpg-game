using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class MagicSword : Sword
    {
        public MagicSword() : base("item0010")
        {
            StrMod = 8;
            PrMod = 7;
            MgcMod = 10;
            GoldValue = 50;
            PublicTip = "each 5 points of magic power are converted into 1 point of bonus strenght; extra 20 % reduction of magic damage";
            PublicName = "Magical Sword";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.StrengthBuff += StrMod + currentPlayer.MagicPower / 5;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "fire" || pack.DamageType == "water" || pack.DamageType == "air" || pack.DamageType == "earth")
            {
                pack.HealthDmg = 80 * pack.HealthDmg / 100;
            }
            return pack;
        }
    }
}
