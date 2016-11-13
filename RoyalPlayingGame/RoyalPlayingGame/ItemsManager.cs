using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Items;

namespace RoyalPlayingGame
{
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
    }
}
