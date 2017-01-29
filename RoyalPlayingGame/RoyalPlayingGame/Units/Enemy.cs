using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Items;

namespace RoyalPlayingGame.Units
{
    public class Enemy:Unit
    {
        public Enemy(int health, int intellegence, int strength, int agility, int physicalDamageReduction, int magicalDamegeReduction):base()
        {
            Health = RealHealth = health;
            Strength = RealStrength = strength;
            Intelligence = RealIntelligence = intellegence;
            Agility = RealAgility = agility;
            PhysicalDamageReduction = RealPhysicalDamageReduction = physicalDamageReduction;
            MagicalDamageReduction = RealMagicalDamageReduction = magicalDamegeReduction;
            Loot = new List<Item>();
        }
        
        public Enemy():base()
        {
            Health = RealHealth = 30;
            Strength = RealStrength = 3;
            Intelligence = RealIntelligence = 4;
            Agility = RealAgility = 4;
            PhysicalDamageReduction = RealPhysicalDamageReduction = 5;
            MagicalDamageReduction = RealMagicalDamageReduction = 8;
            Loot = new List<Item>();
        }

       
        
    }
}
