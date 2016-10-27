using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Interfaces;

namespace RoyalPlayingGame.Quest.QuestStages
{
    public class KillTargetObjectStructure
    { 
        public KillTargetObjectStructure(ITargetObject target, int reqAmount)
        {
            Target = target;
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
        }
        public ITargetObject Target { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
    }
}
