using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class KillUnitStageGroup
    {
        public KillUnitStageGroup(Unit target, int reqAmount)
        {
            Target = target;
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
        }
        public KillUnitStageGroup(int ID, int reqAmount)
        {
            Target = new Unit(ID);
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
        }
        public Unit Target { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
    }
}
