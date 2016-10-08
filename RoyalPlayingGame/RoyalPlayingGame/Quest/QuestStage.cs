using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quest
{
    public enum QuestStageType { GetToPoint, KillUnit, CollectItem, Complex }
    public class QuestStage
    {
        public QuestStage()
        {

        }
        public int QuestStageMoneyReward { get; set; }
        public List<Item> QuestStageItemReward { get; set; }
        public List<Item> QuestStageItems { get; set; }
        public int QuestStageExperienceReward { get; set; }
        public string QuestStageName { get; set; }
        public string QuestStageDescription { get; set; }
        
        public QuestStageType QuestStageType { get; set; }
        public Unit QuestReciver { get; set; }
        public Unit QuestStageUnit { get; set; }

    }
}
