﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Items;

namespace RoyalPlayingGame.Units
{
    /// <summary>
    /// класс врага
    /// </summary>
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

<<<<<<< HEAD
        protected List<Item> Loot;

        /// <summary>
        /// добавление лута
        /// </summary>
        /// <param name="item"></param>
        public void AddLoot(Item item)
        {
            Loot.Add(item);
        }
=======
       
>>>>>>> 881abcde4b90231ce2b78540c2749caab82ab029
        
    }
}
