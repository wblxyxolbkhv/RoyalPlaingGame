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
        public List<Item.Item> QuestStageItemReward { get; set; }
        public List<Item.Item> QuestStageItems { get; set; }
        public int QuestStageExperienceReward { get; set; }
        public string QuestStageName { get; set; }
        public string QuestStageDescription { get; set; }
        public int  QuestStageIndex { get; set; }
        
        public QuestStageType QuestStageType { get; set; }
        public Units.Unit QuestReciver { get; set; }
        public Units.Unit QuestStageUnit { get; set; }

        public bool QuestStageCompleted()
        {
            return true;
        }
    }
}
