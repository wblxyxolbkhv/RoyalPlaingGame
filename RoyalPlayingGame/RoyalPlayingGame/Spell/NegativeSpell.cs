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

        public NegativeSpell(int realIntelligence, int realAgility, string spellName):base (20,2,10,spellName)
        {
            SpellCriticalChance = new Random();
            BasicSpellDamage = 10;
            UnitIntellegence = realIntelligence;
            UnitAgility = realAgility;
        }

        public NegativeSpell(int realIntelligence, int realAgility, string spellName, int castTime, int manaCost, int coolDown):base(manaCost,castTime,coolDown,spellName)
        {
            SpellCriticalChance = new Random();
            BasicSpellDamage = 10;
            UnitIntellegence = realIntelligence;
            UnitAgility = realAgility;
        } 

        public Random SpellCriticalChance { get; set; }
        public int BasicSpellDamage { get; set; }
        public int BasicSpellCriticalChance { get; set; }
        public double SpellDamage { get; set; }
        public int UnitIntellegence { get; set; }
        public int UnitAgility { get; set; }
        public int DealtDamage(out bool CriticalStrike)
        {
            SpellDamage = BasicSpellDamage + (UnitIntellegence* 0.5);
            BasicSpellCriticalChance = 20 + (int)(UnitIntellegence * 0.05) + (int)(UnitAgility * 0.02);
            if (SpellCriticalChance.Next(100) < BasicSpellCriticalChance)
            {
                CriticalStrike = true;
                return (int)SpellDamage * 2;
            }
            else
            {
                CriticalStrike = false;
                return (int)SpellDamage;
            }
        }

    }

}
