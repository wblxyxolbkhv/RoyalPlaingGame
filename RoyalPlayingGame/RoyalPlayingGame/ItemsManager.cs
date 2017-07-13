using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Items;
using System.IO;
using System.Drawing;
using RoyalPlayingGame.Exceptions;

namespace RoyalPlayingGame
{
    public delegate void ShowHint(string message, int time);
    public delegate void SomeItemAdded();
    public delegate void BagSlotsChanged(int slots);
    public delegate void MoneyAmountChanged(int amount);
    /// <summary>
    /// основная задача класса - подгружать итемы
    ///  и возвращать по id обьект итема
    /// </summary>
    public static class ItemsManager
    {
        //public static Item GetItem(int id)
        //{
        //    // заготовка, здесь должен быть парсер и выбор из коллекции
        //    Item item = null;
        //    if (id == 1000)
        //        item = new Item(id, "wizard_hat", 1, 1, 1);
        //    return item;
        //}
        public static void Init()
        {
            LoadItemImageList();
            Item ultraHat = new Item("ultra_hat", "Ультра-шляпа", 1, 1, 0, ItemType.Armor);
            CustomItems.Add(ultraHat);
            ImageList.Add("ultra_hat", GetItemImage("hat"));
        }

        public static Dictionary<string, Bitmap> ImageList { get; set; } = new Dictionary<string, Bitmap>();
        private static List<Item> CustomItems { get; set; } = new List<Item>();

        /// <summary>
        /// Загрузка изображений предметов в базу
        /// </summary>
        public static void LoadItemImageList()
        {
            string[] imageNames = Directory.GetFiles("ItemImages");
            foreach(string ID in imageNames)
            {
                string newID = Path.GetFileName(ID);
                newID = newID.Split('.')[0];
                Bitmap b = (Bitmap)Image.FromFile(ID);
                ImageList.Add(newID, b);
                
            }
        }

        /// <summary>
        /// Выбор соответствующего предмету изображения
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static Bitmap GetItemImage(string itemID)
        {
            foreach(KeyValuePair<string,Bitmap> pair in ImageList)
            {
                if (pair.Key == itemID)
                {
                    return pair.Value;
                }
            }
            return null;
        }
        public static Item GetCustomItem(string itemName)
        {
            foreach (Item item in CustomItems)
            {
                if (item.ID == itemName)
                    return item;
            }
            return null;
        }

        public static event BagSlotsChanged SlotsChanged;
        public static void ChangeSlots(int slots)
        {
            SlotsChanged?.Invoke(slots);
        }
        public static event SomeItemAdded ItemAdded;
        public static void AddItem()
        {
            ItemAdded?.Invoke();
        }
        public static event ShowHint FullBag;
        public static void BagFull(string message, int time)
        {
            FullBag?.Invoke(message,time);
        }
        public static event MoneyAmountChanged MoneyChanged;
        public static void ChangeMoneyAmount(int amount)
        {
            MoneyChanged?.Invoke(amount);
        }
        
        
    }
}
