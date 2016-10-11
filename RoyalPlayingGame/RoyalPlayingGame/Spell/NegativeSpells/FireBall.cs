using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell.NegativeSpells
{
    public class FireBall: NegativeSpell
    {
        public const string name = "fireball";
        public const int castTime = 1;
        public const int manaCost = 20;
        public const int coolDown = 5;

        public FireBall(int realIntelligence,int realAgility):base(realIntelligence,realAgility, name, castTime, manaCost, coolDown) { }

        public FireBall(int realIntelligence, int realAgility, int castTime, int manaCost, int coolDown) : base(realIntelligence, realAgility, name, castTime, manaCost, coolDown) { }
    
    }
}
