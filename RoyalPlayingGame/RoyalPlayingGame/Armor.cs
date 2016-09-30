using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    enum ArmorType{ Cloth, Leather, Mail, Plate }
    enum ArmorSlot { Head, Sholders, Back, Chest, Hands, Belt, Legs, Boots, Ring1, Ring2}
    public class Armor: Item
    {
        public bool CheckRequirementStats(Player player)
        {
            return true;
        }
    }
}
