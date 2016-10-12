using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Spell
{
    public class PositiveSpell : Spell
    {
        public PositiveSpell(int realIntelligence, int manaCost, int castTime, int coolDown, string name):base(manaCost,castTime,coolDown,name)
        {
            BasikSpellPower = 10;
            
        }
        public Effect.Effect spellEffect { get; set; }
        public int BasikSpellPower { get; set; }
        public int UnitIntelligence { get; set; }
        public void AddEffect(Unit unit)
        {
            unit.AddEffect(spellEffect);
        }
    }
}
