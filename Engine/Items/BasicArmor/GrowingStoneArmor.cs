using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.BasicArmor
{
    [Serializable]
    class GrowingStoneArmor : Item
    {
        // armor with magic crystals that can grow stronger from the user's magic aura
        public GrowingStoneArmor() : base("item0008") 
        { 
            PublicName = "GrowingStoneArmor";
            PublicTip = "each 4 points of magic power are converted into 1 point of bonus armor";
            GoldValue = 40;
            ArMod = 20;
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            currentPlayer.ArmorBuff += ArMod + currentPlayer.MagicPower / 4;
        }
    }
}
