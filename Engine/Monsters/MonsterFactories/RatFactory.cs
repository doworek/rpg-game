using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class RatFactory : MonsterFactory
    {
        // this factory produces rats (or evolved rats)

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0) // if this is the first time, return a Rat
            {
                encounterNumber++;
                return new Rat(playerLevel);
            }
            else if (encounterNumber == 1) // if this is the second time, return a RatEvolved
            {
                encounterNumber++;
                return new RatEvolved(playerLevel);
            }
            else return null; // no more rats to fight
        }
        public override System.Windows.Controls.Image Hint() 
        {
            if (encounterNumber == 0) return new Rat(0).GetImage();
            else if (encounterNumber == 1) return new RatEvolved(0).GetImage();
            else return null; 
        }
    }
}
