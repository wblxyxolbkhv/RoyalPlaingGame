using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell.PositiveSpells
{
    public class UpLift:PositiveSpell
    {
        public const string name = "uplift";
        public const int castTime = 1;
        public const int manaCost = 0;
        public const int coolDown = 10;
        public UpLift(int realIntelligence) : base(realIntelligence, manaCost, castTime, coolDown, name)
        {
            effect.DMana = 100;
        }
        
        public Effect.Effect effect { get; set; }

        
    }
}
