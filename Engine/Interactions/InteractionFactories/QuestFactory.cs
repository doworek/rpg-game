using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class QuestFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            MysteryBoxInteraction mysteryBox = new MysteryBoxInteraction(parentSession);
            QuestInteraction quest = new QuestInteraction(parentSession);
            WhiteDragonEncounter whiteDragon = new WhiteDragonEncounter(parentSession);
            GnomeEncounter gnome = new GnomeEncounter(parentSession, quest, whiteDragon);
            return new List<Interaction>() {quest, gnome, whiteDragon, mysteryBox};
        }
    }
}
