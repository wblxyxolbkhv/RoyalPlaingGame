using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Item.Items
{
    public enum ArmorType { Cloth, Leather, Mail, Plate }
    public enum ArmorSlot { Head, Sholders, Back, Chest, Hands, Belt, Legs, Boots, Ring1, Ring2 }
    public class Armor : Item
    {
        Random randomArmorGeneration;
        public Armor(int ID, string name, ArmorType AType, ArmorSlot ASlot, Effect.Effect effect, uint armorLvl) : base(ID, name, 1, 1, armorLvl, effect)
        {
            this.ASlot = ASlot;
            this.AType = AType;
        }
        public Armor(int ID, string name, ArmorType AType, ArmorSlot ASlot, uint armorLvl, int minValue, int maxValue) : base(ID, name, 1, 1, armorLvl)
        {
            Effect.Effect effect = new Effect.Effect();
            randomArmorGeneration = new Random();
            effect.DAgility = randomArmorGeneration.Next(minValue, maxValue);
            effect.DIntelligence = randomArmorGeneration.Next(minValue, maxValue);
            effect.DStrength = randomArmorGeneration.Next(minValue, maxValue);
            ItemEffect = effect;
            this.AType = AType;
            this.ASlot = ASlot;
        }
        public ArmorSlot ASlot { get; private set; }
        public ArmorType AType { get; private set; }
    }
}
