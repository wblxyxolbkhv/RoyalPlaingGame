using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Units
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
            Effects = new List<Effect.Effect>();
            Loot = new List<Item.Item>();
            SpellBook = new List<Spell.Spell>();
        }
        
        public Enemy()
        {
            Health = RealHealth = 30;
            Strength = RealStrength = 3;
            Intelligence = RealIntelligence = 4;
            Agility = RealAgility = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 5;
            MagicalDamageReduction = RealMagicalDamageReduction = 8;
            Effects = new List<Effect.Effect>();
            Loot = new List<Item.Item>();
            SpellBook = new List<Spell.Spell>();
        }

        protected List<Item.Item> Loot;

        public void AddLoot(Item.Item item)
        {
            Loot.Add(item);
        }
        
    }
}
