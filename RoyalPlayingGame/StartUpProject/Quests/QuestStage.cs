using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;

namespace StartUpProject.Quests
{
    public abstract class QuestStage
    {
        public QuestStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index)
        {
            QuestStageName = name;
            QuestStageDescription = description;
            QuestStageIndex = index;
            QuestStageExperienceReward = experieneReward;
            QuestStageItemReward = itemReward;
            QuestStageMoneyReward = moneyReward;
        }
        public QuestStage(string name, string description, int index)
        {
            QuestStageName = name;
            QuestStageDescription = description;
            QuestStageIndex = index;
            QuestStageMoneyReward = 0;
            QuestStageExperienceReward = 10;
            QuestStageItemReward = new List<Item>();
        }

        public QuestStage()
        {
            QuestStageMoneyReward = 0;
            QuestStageExperienceReward = 10;
            QuestStageItemReward = new List<Item>();
        }
        public static event Action QuestStageCompleted;
        public int QuestStageMoneyReward { get; set; }
        public List<Item> QuestStageItemReward { get; set; }
        public int QuestStageExperienceReward { get; set; }
        public string QuestStageName { get; set; }
        public string QuestStageDescription { get; set; }
        public int QuestStageIndex { get; set; }

        public void CallQSCEvent()
        {
            QuestStageCompleted?.Invoke();
        }
    }
}
