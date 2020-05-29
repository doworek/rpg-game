using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
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
        public QuestInteraction(GameSession ses) : base(ses)
        {
            Enterable = false;
            Name = "interaction0005";
            displayedImageName = "interaction0005display";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nOh-ho! You found a chest-quest!");
            parentSession.SendText("You need a key to open this chest.");
            parentSession.SendText("Your quest starts now: first find a Gnome.");
            visited = true;
        }
    }
}