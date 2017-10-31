using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Items
{
    public delegate void EquipmentChanged(bool action, Dictionary<string, int> stats);
    public class Equipment : IEnumerable, IEnumerator
    {
        public Equipment()
        {
            Equip = new Dictionary<int, Item>();
        }
        
        private Dictionary<int, Item> Equip { get; set; }
        public int PlayerLevel { get; private set; }
        public event EquipmentChanged EquipChanged;
        public void SetPlayerLevel(int level)
        {
            PlayerLevel = level;
        }

        #region Энумератор
        private int Index { get; set; }
        public object Current { get { return Equip[Index]; } }

        public IEnumerator GetEnumerator()
        {
            return Equip.GetEnumerator();
        }

        public void Reset()
        {
            Index = -1;
        }

        public bool MoveNext()
        {
            if (Index == Equip.Count - 1)
            {
                Reset();
                return false;
            }
            Index++;
            return true;
        }
        #endregion
        #region Индексатор
        public Item this[int i] { get { return Equip[i]; } }
        #endregion 

        public Item EquipItem(Item item)
        {
            if (item.Lvl <= PlayerLevel)
            {
                Item unequipedItem;
                if (item is Armor)
                {
                    foreach (KeyValuePair<int, Item> pair in Equip)
                    {
                        if (pair.Key == Convert.ToInt32(((item as Armor).ASlot)))
                        {
                            unequipedItem = pair.Value;
                            Equip.Remove(pair.Key);
                            EquipChanged?.Invoke(false, ItemsManager.GetItemStats(unequipedItem));
                            Equip.Add(Convert.ToInt32(((item as Armor).ASlot)), item);
                            EquipChanged?.Invoke(true, ItemsManager.GetItemStats(item));
                            return unequipedItem;
                        }
                    }
                    Equip.Add(Convert.ToInt32(((item as Armor).ASlot)), item);
                    EquipChanged?.Invoke(true, ItemsManager.GetItemStats(item));
                    return null;
                }
                if (item is Weapon)
                {
                    foreach (KeyValuePair<int, Item> pair in Equip)
                    {
                        if (pair.Key == 6)
                        {
                            unequipedItem = pair.Value;
                            Equip.Remove(pair.Key);
                            EquipChanged?.Invoke(false, ItemsManager.GetItemStats(unequipedItem));
                            Equip.Add(6, item);
                            EquipChanged?.Invoke(true, ItemsManager.GetItemStats(item));
                            return unequipedItem;
                        }
                    }
                    Equip.Add(6, item);
                    EquipChanged?.Invoke(true, ItemsManager.GetItemStats(item));
                    return null;
                }
                else throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }

        public void UnEquipItem(Item item)
        {
            foreach(KeyValuePair<int, Item> pair in Equip)
            {
                if(pair.Value == item)
                {
                    try
                    {
                        Equip.Remove(pair.Key);
                        EquipChanged?.Invoke(false, ItemsManager.GetItemStats(item));
                        break;
                    }
                    catch(Exceptions.FullBagException)
                    {

                    }
                }
            }
        }
    }
}
