using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Spell
{
    public class Spell
    {
        public uint ManaCost { get; set; }
        public uint CastTime { get; set; }
        public uint CoolDown { get; set; }
        public Spell( uint manaCost, uint castTime, uint coolDown)
        {
            ManaCost = manaCost;
            CastTime = castTime;
            CoolDown = coolDown;
        }
    }
}
