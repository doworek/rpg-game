using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class GoldenKey : Item
    {
        public GoldenKey() : base("item0012")
        {
            PublicName = "Key";
        }
    }
}
