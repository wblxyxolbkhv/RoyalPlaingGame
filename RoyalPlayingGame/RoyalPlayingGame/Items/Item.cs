using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Items
{
    public class Item
    {
        public Item(int ID, string name, int maxAmount, int amount, uint itemLvl, Effect.Effect effect)
        {
            this.ID = ID;
            Name = name;
            Lvl = itemLvl;
            MaxAmount = maxAmount;
            Amount = amount;
            ItemEffect = effect;
            IsAQuestItem = false;
        }
        public Item(int ID, string name, int maxAmount, int amount, uint itemLvl)
        {
            this.ID = ID;
            Name = name;
            MaxAmount = maxAmount;
            Lvl = itemLvl;
            Amount = amount;
            IsAQuestItem = false;
        }
        public Item(int ID, string name,  int maxAmount)
        {
            this.ID = ID;
            Name = name;
            MaxAmount = maxAmount;
            Amount = 0;
            IsAQuestItem = true;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxAmount { get; set; }
        public int Amount { get; set; }
        public uint Lvl { get; set; }
        public bool IsAQuestItem { get; set; }
        public string Description { get; set; }
        public Effect.Effect ItemEffect { get; set; }
    }
}
