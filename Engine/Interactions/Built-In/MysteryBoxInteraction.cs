using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    //mistery box with 50% chance to get some random item

    [Serializable]
    class MysteryBoxInteraction : ConsoleInteraction
    {

        public MysteryBoxInteraction(GameSession ses) : base(ses)
        {
            Enterable = false;
            Name = "interaction0009";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nYou found a Mystery Box. What's inside?");
            Look();
        }
        private void Look()
        {
            if (parentSession.currentPlayer.Level >= 1)
            {
                    int result = Index.RNG(1, 3);
                    parentSession.SendText("\nChoose 1 or 2. If you guess correctly - you'll get a random item.");
                    string key = parentSession.GetValidKeyResponse(new List<string>() { "Return", "1", "2" }).Item1;
                    if (key == "Return") { return; }
                    if ((key == "1" && result == 1) || (key == "2" && result == 2))
                    {
                        parentSession.SendText("\nCongratulations!");
                        parentSession.AddRandomItem();
                    }
                    else
                    {
                        parentSession.SendText("\nThere's nothing...come back again");
                    }
            }
                else
                {
                    parentSession.SendText("\nYou need to have at lest level 3 to get an item.");
                }
            }
        }

    }