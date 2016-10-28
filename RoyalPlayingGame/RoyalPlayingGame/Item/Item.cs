using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Item
{
    public class Item
    {
        public Item(int ID, string name, int maxAmount, int amount, uint itemLvl, Effect.Effect effect)
        {
            this.ID = ID;
            ItemName = name;
            ItemLvl = itemLvl;
            MaxAmount = maxAmount;
            Amount = amount;
            ItemEffect = effect;
            IsAQuestItem = false;
        }
        public Item(int ID, string name, int maxAmount, int amount, uint itemLvl)
        {
            this.ID = ID;
            ItemName = name;
            MaxAmount = maxAmount;
            ItemLvl = itemLvl;
            Amount = amount;
            IsAQuestItem = false;
        }
        public Item(string name, int ID, int maxAmount)
        {
            this.ID = ID;
            ItemName = name;
            MaxAmount = maxAmount;
            Amount = 0;
            IsAQuestItem = true;
        }
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int MaxAmount { get; set; }
        public int Amount { get; set; }
        public uint ItemLvl { get; set; }
        public bool IsAQuestItem { get; set; }
        public Effect.Effect ItemEffect { get; set; }
    }
}
