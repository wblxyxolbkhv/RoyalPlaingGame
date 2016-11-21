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
    /// Инвентарь юнита
    /// </summary>
    public class Inventory : IEnumerable, IEnumerator
    {
        public Inventory(int slots)
        {
            Bag = new List<Item>(slots);
            Slots = slots;
        }

        private List<Item> Bag { get; set; }
        public int Slots { get { return slots; } set { slots = value; ItemsManager.ChangeSlots(value); ; } }
        int slots;
        

        #region Энумератор
        private int Index { get; set; }
        public object Current { get { return Bag[Index]; } }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public void Reset()
        {
            Index = -1;
        }

        public bool MoveNext()
        {
            if (Index == Bag.Count-1)
            {
                Reset();
                return false;
            }
            Index++;
            return true;
        }
        #endregion

        /// <summary>
        /// добавление предметов в инвентарь
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            
            foreach (Item bagItem in Bag)
            {
                if(bagItem.ID == item.ID)
                {
                    if(bagItem.Amount!= bagItem.MaxAmount)
                    {
                        bagItem.Amount += item.Amount;
                        if (bagItem.Amount > bagItem.MaxAmount)
                        {
                            item.Amount = bagItem.Amount - bagItem.MaxAmount;
                            bagItem.Amount = bagItem.MaxAmount;
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                }
                    
            }
            if (Bag.Count == Bag.Capacity)
            {
                throw new FullBagException();
            }

            if (item.Amount > 0)
            {
                Bag.Add(item);
                //ItemsManager.AddItem();
            }
            

        }

        /// <summary>
        /// метод для расширения числа слотов 
        /// в сумке
        /// </summary>
        /// <param name="size"></param>
        public void ChangeBagSize(int size)
        {
            Bag.Capacity = size;
            Slots = size;
        }

        /// <summary>
        /// метод для удаления предметов 
        /// из инвентаря
        /// </summary>
        public void RemoveItem(Item item)
        {

        }
        public List<Item> GetItemList()
        {
            return Bag;
        }
    }
}
