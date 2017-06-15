using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Items
{
    /// <summary>
    /// Базовый класс для всех предметов в игре, автор: Жифарский Д.А.
    /// </summary>
    public class Item
    {
        public Item(string ID, string name, int maxAmount, int amount, uint itemLvl, Effect.Effect effect)
        {
            this.ID = ID;
            Name = name;
            Lvl = itemLvl;
            MaxAmount = maxAmount;
            Amount = amount;
            ItemEffect = effect;
            IsAQuestItem = false;
        }
        public Item(string ID, string name, int maxAmount, int amount, uint itemLvl)
        {
            this.ID = ID;
            Name = name;
            MaxAmount = maxAmount;
            Lvl = itemLvl;
            Amount = amount;
            IsAQuestItem = false;
        }
        /// <summary>
        /// конструктор для квестовых предметов
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <param name="maxAmount"></param>
        public Item(string ID, string name,  int maxAmount)
        {
            this.ID = ID;
            Name = name;
            MaxAmount = maxAmount;
            Amount = 0;
            IsAQuestItem = true;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxAmount { get; protected set; }
        public int Amount { get; set; }
        public uint Lvl { get; set; }
        public bool IsAQuestItem { get; set; }
        public string Description { get; set; }
        public Effect.Effect ItemEffect { get; set; }
        public Action UseItemExternal { get; set; }


        public virtual void Use()
        {
            UseItemExternal?.Invoke();
        }
    }
}
