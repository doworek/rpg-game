using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    //Quest - visit Gnome, White Dragon and a Princess to get a key

    [Serializable]
    class QuestInteraction : ImageInteraction
    {
        public bool visited = false; // has this place been visited?
        public IQuestStrategy Strategy { get; set; } // store strategy 
        public QuestInteraction(GameSession ses) : base(ses)
        {
            Enterable = false;
            Name = "interaction0005";
            Strategy = new QuestBeginStrategy();
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, this); // execute strategy
            visited = true;
        }
        public void OpenChest()
        {
            displayedImageName = "interaction0005display";
        }
    }
}