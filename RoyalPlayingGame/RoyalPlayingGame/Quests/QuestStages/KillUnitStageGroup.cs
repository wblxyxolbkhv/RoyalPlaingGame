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
        public KillUnitStageGroup(Unit target, int reqAmount,string objective)
        {
            Target = target;
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
            Objective = objective;
        }
        public KillUnitStageGroup(int ID, int reqAmount,string objective)
        {
            Target = new Unit(ID);
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
            Objective = objective;
        }
        public Unit Target { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
        public string Objective { get; set; }
    }
}
