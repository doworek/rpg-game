using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class DragonFactory : MonsterFactory
    {
        // this factory produces dragons

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber <= 3)
            {
                encounterNumber++;
                return new Dragon(playerLevel);
            }
            else if (encounterNumber == 4)
            {
                encounterNumber++;
                return new DragonEvolved(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber <= 3) return new Dragon(0).GetImage();
            else if (encounterNumber == 4) return new DragonEvolved(0).GetImage();
            else return null;
        }
    }
}
