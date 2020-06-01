using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class WolfFactory : MonsterFactory
    {
        // this factory produces wolf

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber <= 2)
            {
                encounterNumber++;
                return new Wolf(playerLevel);
            }
            else return null; // no more wolfs to fight
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber <= 2) return new Wolf(0).GetImage();
            else return null;
        }
    }
}
