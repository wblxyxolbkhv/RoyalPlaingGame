using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Exceptions;

namespace RoyalPlayingGame.Items
{
    /// <summary>
    /// Инвентарь юнита, автор: Жифарский Д.А.
    /// </summary>
    public class Inventory : IEnumerable, IEnumerator
    {
        //конструктор для игрока
        public Inventory(int slots)
        {
            Bag = new Dictionary<int, Item>(slots);
            Slots = slots;
        }

        //конструктор для всех остальных юнитов
        public Inventory()
        {
            Bag = new Dictionary<int, Item>();
        }

        private Dictionary<int, Item> Bag { get; set; }
        public int Slots {
            get
            {
                return slots;
            }
            private set
            {
                slots = value;
                ItemsManager.ChangeSlots(value);
            }
        }

        int slots;
        
        public int Count { get { return Bag.Count; } }

        #region Энумератор
        private int Index { get; set; }
        public object Current { get { return Bag[Index]; } }

        public IEnumerator GetEnumerator()
        {
            return Bag.GetEnumerator();
        }

        public void Reset()
        {
            Index = -1;
        }

        public bool MoveNext()
        {
            if (Index == Bag.Count - 1)
            {
                Reset();
                return false;
            }
            Index++;
            return true;
        }
        #endregion
        #region Индексатор
        public Item this[int i] { get { return Bag[i]; } }
        #endregion 

        /// <summary>
        /// добавление предметов в инвентарь
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {           
            foreach (KeyValuePair<int,Item> pair in Bag)
            {
                if(pair.Value.ID == item.ID)
                {
                    if(pair.Value.Amount!= pair.Value.MaxAmount)
                    {
                        pair.Value.Amount += item.Amount;
                        if (pair.Value.Amount > pair.Value.MaxAmount)
                        {
                            item.Amount = pair.Value.Amount - pair.Value.MaxAmount;
                            pair.Value.Amount = pair.Value.MaxAmount;
                        }
                        else
                        {
                            return;
                        }
                        
                    }
                }
                    
            }
            if (Bag.Count == Slots)
            {
                throw new FullBagException();
            }

            if (item.Amount > 0)
            {
                int nextItemPosition = 0;
                //Bag.Add(item);
                for (int i = 0; i < Slots; i++)
                {
                    int condition = nextItemPosition;
                    foreach (KeyValuePair<int,Item> pair in Bag)
                    {               
                        if (pair.Key == nextItemPosition)
                        {
                            nextItemPosition++;
                            break;
                        }
                    }
                    if (condition == nextItemPosition)
                        break;
                }
                //item.Position = nextItemPosition;
                Bag.Add(nextItemPosition, item);
                ItemsManager.AddItem();

            }
            

        }

        //public void AddItemForUnit(Item item)
        //{
        //    foreach (Item bagItem in Bag)
        //    {
        //        if (bagItem.ID == item.ID)
        //        {
        //            if (bagItem.Amount != bagItem.MaxAmount)
        //            {
        //                bagItem.Amount += item.Amount;
        //                if (bagItem.Amount > bagItem.MaxAmount)
        //                {
        //                    item.Amount = bagItem.Amount - bagItem.MaxAmount;
        //                    bagItem.Amount = bagItem.MaxAmount;
        //                }
        //                else
        //                {
        //                    return;
        //                }

        //            }
        //        }

        //    }
        //    if (Bag.Count == Slots)
        //    {
        //       // throw new FullBagException();
        //    }

        //    if (item.Amount > 0)
        //    {
        //        Bag.Add(item);
        //        //ItemsManager.AddItem();
        //    }


        //}
        /// <summary>
        /// метод для расширения числа слотов 
        /// в сумке
        /// </summary>
        /// <param name="size"></param>
        public void ChangeBagSize(int size)
        {
            Slots = size;
        }

        /// <summary>
        /// метод для удаления предметов 
        /// из инвентаря
        /// </summary>
        public void RemoveItem(Item item)
        {
            foreach(KeyValuePair<int, Item> pair in Bag)
            {
                if (pair.Value == item)
                {
                    Bag.Remove(pair.Key);
                    break;
                }
            }              
        }

        public void RemoveItem(Item item, int amount)
        {
            foreach(KeyValuePair<int, Item> pair in Bag)
            {
                if (pair.Value.ID == item.ID)
                {
                    pair.Value.Amount -= item.Amount;
                    break;
                }
            }
        }


        public void ChangeKey(Item item, int newPosition)
        {
            foreach(KeyValuePair<int,Item> pair in Bag)
            { 
                if(pair.Value == item)
                {
                    Bag.Remove(pair.Key);
                    Bag.Add(newPosition, item);
                    break;
                }
            }
        }

        public Dictionary<int, Item> GetItemList()
        {
            return Bag;
        }

        public int GetKey(Item item)
        {
            foreach(KeyValuePair<int,Item> pair in Bag)
            {
                if (pair.Value == item)
                    return pair.Key;
            }
            return 0;
        }
    }
}
