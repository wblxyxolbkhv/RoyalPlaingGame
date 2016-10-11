using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell.NegativeSpells
{
    public class FrostDragonHead: NegativeSpell
    {
        public const string name = "frostdragonhead";
        public const int castTime = 2;
        public const int manaCost = 40;
        public const int coolDown = 8;

        public FrostDragonHead(int realIntelligence, int realAgility):base(realIntelligence,realAgility, name, castTime, manaCost, coolDown) { BasicSpellDamage = 30; }

        public FrostDragonHead(int realIntelligence, int realAgility, int castTime, int manaCost, int coolDown) : base(realIntelligence, realAgility, name, castTime, manaCost, coolDown) { BasicSpellDamage = 30; }
    }
}
