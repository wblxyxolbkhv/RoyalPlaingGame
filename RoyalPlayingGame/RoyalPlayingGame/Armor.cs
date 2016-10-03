using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public enum ArmorType{ Cloth, Leather, Mail, Plate }
    public enum ArmorSlot { Head, Sholders, Back, Chest, Hands, Belt, Legs, Boots, Ring1, Ring2}
    public class Armor: Item
    {
        public Armor(string name, ArmorType AType, ArmorSlot ASlot, Effect effect, uint armorLvl)
        {
            this.ASlot = ASlot;
            this.AType = AType;
            base.ItemName = name;
            base.ItemEffect = effect;
            base.ItemLvl = armorLvl;
            base.MaxAmount = 1;
        }
        public ArmorSlot ASlot { get; private set; }
        public ArmorType AType { get; private set; }
    }
}
