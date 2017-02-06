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
    public delegate void SomeItemAdded();
    public delegate void BagSlotsChanged(int slots);
    /// <summary>
    /// основная задача класса - подгружать итемы
    ///  и возвращать по id обьект итема
    /// </summary>
    public static class ItemsManager
    {
        public static Item GetItem(int id)
        {
            // заготовка, здесь должен быть парсер и выбор из коллекции
            Item item = null;
            if (id == 1000)
                item = new Item(id, "wizard_hat", 1, 1, 1);
            return item;
        }

        public static Dictionary<string,Bitmap> ImageList { get; set; }

        /// <summary>
        /// Загрузка изображений предметов в базу
        /// </summary>
        public static void LoadItemImageList()
        {
            string[] imageNames = Directory.GetFiles("ItemImages");
            foreach(string name in imageNames)
            {
                ImageList.Add(name, (Bitmap)Image.FromFile(Path.Combine("ItemImages", name)));//"ItemImages\\" + name));
            }
        }

        /// <summary>
        /// Выбор соответствующего предмету изображения
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static Bitmap GetItemImage(string itemName)
        {
            foreach(KeyValuePair<string,Bitmap> pair in ImageList)
            {
                if (pair.Key == itemName)
                {
                    return pair.Value;
                }
            }
            throw new ImageNotFoundException();
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
    }
}
