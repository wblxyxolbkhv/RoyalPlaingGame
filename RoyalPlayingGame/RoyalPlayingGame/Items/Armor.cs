using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Назначение: Класс для брони
 * Автор: Жифарский Д.А.
 */
namespace RoyalPlayingGame.Items
{
    
    //public enum ArmorType { Cloth, Leather, Mail, Plate }
    public enum ArmorSlot { Head, Back, Chest, Hands, Belt, Boots, Ring1, Ring2, Neck }
    /// <summary>
    /// Броня юнита, автор: Жифарский Д.А.
    /// </summary>
    public class Armor : Item
    {
        Random randomArmorGeneration;
        public Armor(string ID, string name, ArmorSlot ASlot, Effect.Effect effect, uint armorLvl) : base(ID, name, 1, 1, armorLvl, effect)
        {
            this.ASlot = ASlot;
        }
        public Armor(string ID, string name, ArmorSlot ASlot, uint armorLvl, int minValue, int maxValue) : base(ID, name, 1, 1, armorLvl)
        {
            Effect.Effect effect = new Effect.Effect();
            randomArmorGeneration = new Random();
            effect.DAgility = randomArmorGeneration.Next(minValue, maxValue);
            effect.DIntelligence = randomArmorGeneration.Next(minValue, maxValue);
            effect.DStrength = randomArmorGeneration.Next(minValue, maxValue);
            ItemEffect = effect;
            this.ASlot = ASlot;
        }
        public ArmorSlot ASlot { get; private set; }
    }
}
