using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
/* Назначение: Глобаный слушатель всех смертей в игре
 * он уведомляет классы, которым это нужно, о смерти кого-то в игре
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame
{
    public delegate void DeathSomeUnitHandler(Unit unit);
    public static class DeadUnitListener
    {
        public static event DeathSomeUnitHandler DeathSomeUnit;
        public static void SomeUnitDeath(Unit unit)
        {
            if (unit == null)
                return;
            DeathSomeUnit?.Invoke(unit);
        }
    }
}
