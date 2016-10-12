using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell.NegativeSpells
{
    public class DragonBreath:NegativeSpell
    {
        public const string name = "fireball";
        public const int castTime = 2;
        public const int manaCost = 50;
        public const int coolDown = 10;
        public DragonBreath(int realIntelligence, int realAgility):base(realIntelligence,realAgility,name,castTime,manaCost,coolDown)
        {
            BasicSpellDamage = 50;
        }
    }
}
