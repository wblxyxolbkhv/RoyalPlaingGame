using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
   public class Player:Unit
    {
        public Player()
        {
            ArmorSet = new List<Armor>();
            WeaponSet = new List<Weapon>();
            Potions = new List<Potion>();
            SpellBook = new List<Spell>();
            QuestJournal = new List<Quest>();
            Effects = new List<Effect>();
            Experience = 0;
            Health = RealHealth = 50;
            Agility = RealAgility = 4;
            Intelligence = RealIntelligence = 5;
            Strength = RealStrength = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 10;
            MagicalDamageReduction = RealMagicalDamageReduction = 15;
        }
        public List<Quest> QuestJournal { get; set; }
        public int Experience { get; set; }
        public void EquipWeapon(Weapon weapon)
        {
            if (CheckRequiredLvl(weapon))
            {
                WeaponSet.Add(weapon);
            }
        }
        public void EquipArmor(Armor armor)
        {
            if(CheckRequiredLvl(armor))
            {
                ArmorSet.Add(armor);
            }
        }
        public bool CheckRequiredLvl(Item item)
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

        public Spell CastSpell()
        {
         NegativeSpells.FireBall fireball = new NegativeSpells.FireBall(RealIntelligence,RealAgility);
          return fireball ;
        }

    }
}
