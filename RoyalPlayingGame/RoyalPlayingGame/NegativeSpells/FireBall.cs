using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spells
{
    public class FireBall :Spell
    {
        public FireBall(uint manaCost, uint castTime, uint coolDown, Unit unit):base(unit, manaCost, castTime, coolDown)
        {

        }
    }
}
