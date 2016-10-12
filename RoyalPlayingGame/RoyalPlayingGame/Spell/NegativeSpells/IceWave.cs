using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell.NegativeSpells
{
    public class IceWave:NegativeSpell
    {
        public const string name = "icewave";
        public const int castTime = 2;
        public const int manaCost = 30;
        public const int coolDown = 6;

        public IceWave(int realIntelligence, int realAgility):base(realIntelligence,realAgility,name,castTime,manaCost,coolDown)
        {
            BasicSpellDamage = 20;
        }
    }
}
