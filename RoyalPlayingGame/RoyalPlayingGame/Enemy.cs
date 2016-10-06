using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Enemy:Unit
    {
        public Enemy(uint health, uint intellegence, uint strength, uint agility, uint physicalDamageReduction, uint magicalDamegeReduction)
        {
            Health = RealHealth = health;
            Strength = RealStrength = strength;
            Intelligence = RealIntelligence = intellegence;
            Agility = RealAgility = agility;
            PhysicalDamageReduction = RealPhysicalDamageReduction = physicalDamageReduction;
            MagicalDamageReduction = RealMagicalDamageReduction = magicalDamegeReduction;
            Effects = new List<Effect>();
            Loot = new List<Item>();
            SpellBook = new List<Spell>();
        }
        
        public Enemy()
        {
            Health = RealHealth = 30;
            Strength = RealStrength = 3;
            Intelligence = RealIntelligence = 4;
            Agility = RealAgility = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 5;
            MagicalDamageReduction = RealMagicalDamageReduction = 8;
            Effects = new List<Effect>();
            Loot = new List<Item>();
            SpellBook = new List<Spell>();
        }

        protected List<Item> Loot;

        public void AddLoot(Item item)
        {
            Loot.Add(item);
        }
        
    }
}
