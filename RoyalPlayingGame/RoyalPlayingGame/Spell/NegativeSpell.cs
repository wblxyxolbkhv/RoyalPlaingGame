using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell
{
    public class NegativeSpell :Spell
    {
   //доработать
        //public NegativeSpell( Unit unit, uint manaCost, uint castTime, uint coolDown, uint basicDamage):base(unit, manaCost, castTime, coolDown)
        //{
        //    SpellCriticalChance = new Random();
            
        //    BasicSpellDamage = basicDamage;
        //}

        public NegativeSpell(uint realIntellegence, uint realAgility):base (20,2,10)
        {
            SpellCriticalChance = new Random();
            BasicSpellDamage = 10;
            UnitIntellegence = realIntellegence;
            UnitAgility = realAgility;
        }

        public Random SpellCriticalChance { get; set; }
        public uint BasicSpellDamage { get; set; }
        public int BasicSpellCriticalChance { get; set; }
        public double SpellDamage { get; set; }
        public uint UnitIntellegence { get; set; }
        public uint UnitAgility { get; set; }
        public int DealtDamage()
        {
            SpellDamage = BasicSpellDamage + (UnitIntellegence* 0.5);
            BasicSpellCriticalChance = 5 + (int)(UnitIntellegence * 0.05) + (int)(UnitAgility * 0.02);
            if (SpellCriticalChance.Next(100) < BasicSpellCriticalChance)
            {
                return (int)SpellDamage * 2;
            }
            else
            {
                return (int)SpellDamage;
            }
        }

    }

}
