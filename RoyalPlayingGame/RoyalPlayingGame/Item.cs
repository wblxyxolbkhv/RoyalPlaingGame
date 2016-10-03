using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Item
    {
        public string ItemName { get; protected set; }
        public ushort MaxAmount { get; protected set; }
        public ushort Amount { get; protected set; }
        public uint ItemLvl { get; protected set; }
        public Effect ItemEffect { get; protected set; }
    }
}
