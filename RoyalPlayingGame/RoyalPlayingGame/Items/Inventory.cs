using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        private List<Item> Bag { get; set; }
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
        public void AddItem(Item item)
        {
            Bag.Add(item);
        }
    }
}
