using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Item
{
    public class Item
    {
        public Item(string name, ushort maxAmount, ushort amount, uint itemLvl, Effect.Effect effect)
        {
            ItemName = name;
            ItemLvl = itemLvl;
            MaxAmount = maxAmount;
            Amount = amount;
            ItemEffect = effect;
        }
        public Item(string name, ushort maxAmount, ushort amount, uint itemLvl)
        {
            ItemName = name;
            MaxAmount = maxAmount;
            ItemLvl = itemLvl;
            Amount = amount;
        }
        public string ItemName { get; set; }
        public ushort MaxAmount { get; set; }
        public ushort Amount { get; set; }
        public uint ItemLvl { get; set; }
        public Effect.Effect ItemEffect { get; set; }
    }
}
