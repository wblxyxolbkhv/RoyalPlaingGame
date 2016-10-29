using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame
{
    public delegate void DeathSomeUnitHandler(Unit unit);
    public static class DeadUnitListener
    {
        public static event DeathSomeUnitHandler DeathSomeUnit;
        public static void SomeUnitDeath(Unit unit)
        {
            DeathSomeUnit?.Invoke(unit);
        }
    }
}
