﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class Spell
    {
        Unit unit;
        public uint ManaCost { get; set; }
        public uint CastTime { get; set; }
        public uint CoolDown { get; set; }
        public Spell(Unit unit, uint manaCost, uint castTime, uint coolDown)
        {
            this.unit = unit;
            ManaCost = manaCost;
            CastTime = castTime;
            CoolDown = coolDown;
        }
    }
}
