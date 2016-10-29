using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Interfaces;

namespace RoyalPlayingGame.Quest.QuestStages
{
   public class KillTargetObject:QuestStage
    {
        public KillTargetObject(int moneyReward, int experienceReward, List<Item.Item> itemReward,
            string description, string name, int index):base(moneyReward,experienceReward, itemReward, name,description)
        {
            QuestStageIndex = index;
            MustBeKilledTargets = new List<KillTargetObjectStructure>();
        }

        public List<KillTargetObjectStructure> MustBeKilledTargets { get; set; }

        public void AddTarget(ITargetObject target, int reqAmount)
        {
            KillTargetObjectStructure ktos = new KillTargetObjectStructure(target,reqAmount);
            MustBeKilledTargets.Add(ktos);
        }
        public void AddTarget(KillTargetObjectStructure ktos)
        {
            MustBeKilledTargets.Add(ktos);
        }
        //public override bool IsQuestStageCompleted()
        //{
        //    foreach (KillTargetObjectStructure ktos in MustBeKilledTargets)
        //    {
        //        if (ktos.CurrentAmount == ktos.RequiredAmount)
        //            return true;
        //    }
        //    return false;  
        //}
    }
}
