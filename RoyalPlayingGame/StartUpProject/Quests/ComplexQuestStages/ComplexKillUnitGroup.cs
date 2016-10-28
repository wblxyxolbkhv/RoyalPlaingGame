using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace StartUpProject.Quests.ComplexQuestStages
{
    public class ComplexKillUnitGroup
    {
        public ComplexKillUnitGroup(Unit target, int reqAmount)
        {
            Target = target;
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
        }
        public Unit Target { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
    }
}
