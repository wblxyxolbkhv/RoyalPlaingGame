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
            CurrentAmount = new List<int>();
            Amount = new List<int>();
            MustBeKilledTargets = new List<ITargetObject>();
        }
        public List<int> CurrentAmount { get; set; }
        public List<int> Amount { get; set; }
        public List<ITargetObject> MustBeKilledTargets { get; set; }

        public void AddTarget(ITargetObject target, int amount)
        {
            MustBeKilledTargets.Add(target);
            Amount.Add(amount);
            CurrentAmount.Add(0);
        }
        public override bool QuestStageCompleted()
        {
            bool flag = false;
            for(int i=0;i<Amount.Count;i++)
            {
                if (CurrentAmount[i] == Amount[i])
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                return true;
            else return false;         
        }
    }
}
