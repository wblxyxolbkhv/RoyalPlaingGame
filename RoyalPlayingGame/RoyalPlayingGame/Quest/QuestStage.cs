using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quest
{
    //public enum QuestStageType { GetToPoint, KillUnit, CollectItem, Complex }
    public abstract class QuestStage
    {
        public QuestStage(int moneyReward, int experieneReward, List<Item.Item> itemReward, string name, string description)
        {
            QuestStageName = name;
            QuestStageDescription = description;
            //QuestStageItems = items;
            QuestStageExperienceReward = experieneReward;
            QuestStageItemReward = itemReward;
            QuestStageMoneyReward = moneyReward;
            IsActive = true;
        }
        public bool IsActive { get; set; }
        public int QuestStageMoneyReward { get; set; }
        public List<Item.Item> QuestStageItemReward { get; set; }
        //public List<Item.Item> QuestStageItems { get; set; }
        public int QuestStageExperienceReward { get; set; }
        public string QuestStageName { get; set; }
        public string QuestStageDescription { get; set; }
        public int QuestStageIndex { get; set; }
        
        //public QuestStageType QuestStageType { get; set; }
        //public Units.Unit QuestReciver { get; set; }
        //public Units.Unit QuestStageUnit { get; set; } 

        public abstract bool IsQuestStageCompleted();
       
    }
}
