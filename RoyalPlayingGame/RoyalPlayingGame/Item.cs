using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Item
    {
        public Item(string name, ushort maxAmount, ushort amount, uint itemLvl, Effect effect)
        {
            this.ItemName = name;
            this.ItemLvl = itemLvl;
            this.MaxAmount = maxAmount;
            this.Amount = amount;
            this.ItemEffect = effect;
        }
        public Item(string name, ushort maxAmount, ushort amount, uint itemLvl)
        {
            this.ItemName = name;
            this.MaxAmount = maxAmount;
            this.ItemLvl = itemLvl;
            this.Amount = amount;
        }
        public string ItemName { get; set; }
        public ushort MaxAmount { get; set; }
        public ushort Amount { get; set; }
        public uint ItemLvl { get; set; }
        public Effect ItemEffect { get; set; }
    }
}
