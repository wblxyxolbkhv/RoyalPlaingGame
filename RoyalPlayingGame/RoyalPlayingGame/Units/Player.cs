using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Units
{
   public class Player:Unit
    {
        public Player()
        {
            ArmorSet = new List<Item.Items.Armor>();
            WeaponSet = new List<Item.Items.Weapon>();
            Potions = new List<Item.Items.Potion>();
            SpellBook = new List<Spell.Spell>();
            QuestJournal = new List<Quest.Quest>();
            Effects = new List<Effect.Effect>();
            Experience = 0;
            Health = RealHealth = 50;
            Agility = RealAgility = 4;
            Intelligence = RealIntelligence = 5;
            Strength = RealStrength = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 10;
            MagicalDamageReduction = RealMagicalDamageReduction = 15;
        }
        public List<Quest.Quest> QuestJournal { get; set; }
        public int Experience { get; set; }
        public void EquipWeapon(Item.Items.Weapon weapon)
        {
            if (CheckRequiredLvl(weapon))
            {
                WeaponSet.Add(weapon);
            }
        }
        public void EquipArmor(Item.Items.Armor armor)
        {
            if(CheckRequiredLvl(armor))
            {
                ArmorSet.Add(armor);
            }
        }
        public bool CheckRequiredLvl(Item.Item item)
        {
            if (item.ItemLvl >= Level)
                return true;
            else return false;
        }
        
        public void LvlUP()
        {
            if (Experience>=200)
            {
                Experience = Experience - 200;
                Level += 1;
            }
        }


    }
}
