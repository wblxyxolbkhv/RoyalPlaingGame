using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Item
{
    public class Item
    {
        public Item(int iD, string name, ushort maxAmount, ushort amount, uint itemLvl, Effect.Effect effect)
        {
            ID = iD;
            ItemName = name;
            ItemLvl = itemLvl;
            MaxAmount = maxAmount;
            Amount = amount;
            ItemEffect = effect;
            IsAQuestItem = false;
        }
        public Item(int iD, string name, ushort maxAmount, ushort amount, uint itemLvl)
        {
            ID = iD;
            ItemName = name;
            MaxAmount = maxAmount;
            ItemLvl = itemLvl;
            Amount = amount;
            IsAQuestItem = false;
        }
        public Item(string name, int iD)
        {
            ID = iD;
            ItemName = name;
            Amount = 1;
            IsAQuestItem = true;
        }
        public int ID { get; set; }
        public string ItemName { get; set; }
        public ushort MaxAmount { get; set; }
        public ushort Amount { get; set; }
        public uint ItemLvl { get; set; }
        public bool IsAQuestItem { get; set; }
        public Effect.Effect ItemEffect { get; set; }
    }
}
