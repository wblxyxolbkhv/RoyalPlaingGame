using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
   public class Player:Unit
    {
        public List<Armor> armorSet;
        public List<Weapon> weaponSet;
        public List<Potion> potions;
        public Player()
        {
            armorSet = new List<Armor>();
            weaponSet = new List<Weapon>();
            potions = new List<Potion>();
            Experience = 0;
            Health = RealHealth = 50;
            Agility = RealAgility = 4;
            Intelligence = RealIntelligence = 5;
            Strength = RealStrength = 4;
        }
        public int Experience { get; set; }
        public void EquipWeapon(Weapon weapon)
        {
            if (CheckRequiredLvl(weapon))
            {
                weaponSet.Add(weapon);
            }
        }
        public void EquipArmor(Armor armor)
        {
            if(CheckRequiredLvl(armor))
            {
                armorSet.Add(armor);
            }
        }
        public bool CheckRequiredLvl(Item item)
        {
            if (item.ItemLvl >= base.Level)
                return true;
            else return false;
        }
        public void AddPotion(Potion potion)
        {
            foreach (Potion addedPotion in potions)
            {
                if (addedPotion.ItemName == potion.ItemName)
                {
                    addedPotion.Amount = +1;
                }
                else
                {
                    potions.Add(potion);
                }
            }
        }
        public void AddPotion(Potion potion, int amount)
        {
            //реализовать
        }

    }
}
