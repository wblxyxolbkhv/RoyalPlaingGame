using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Units
{
    public class Enemy:Unit
    {
        public Enemy(int health, int intellegence, int strength, int agility, int physicalDamageReduction, int magicalDamegeReduction)
        {
            Health = RealHealth = health;
            Strength = RealStrength = strength;
            Intelligence = RealIntelligence = intellegence;
            Agility = RealAgility = agility;
            PhysicalDamageReduction = RealPhysicalDamageReduction = physicalDamageReduction;
            MagicalDamageReduction = RealMagicalDamageReduction = magicalDamegeReduction;
            Loot = new List<Item.Item>();
        }
        
        public Enemy()
        {
            Health = RealHealth = 30;
            Strength = RealStrength = 3;
            Intelligence = RealIntelligence = 4;
            Agility = RealAgility = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 5;
            MagicalDamageReduction = RealMagicalDamageReduction = 8;
            Loot = new List<Item.Item>();
        }

        protected List<Item.Item> Loot;

        public void AddLoot(Item.Item item)
        {
            Loot.Add(item);
        }
        
    }
}
