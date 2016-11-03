using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;

namespace RoyalPlayingGame.Quests
{
    public abstract class QuestStage
    {
        public QuestStage(int moneyReward, int experieneReward, List<Item.Item> itemReward, string name, string description, int index)
        {
            Name = name;
            Description = description;
            ExperienceReward = experieneReward;
            ItemReward = itemReward;
            MoneyReward = moneyReward;
        }
        public QuestStage(string name, string description, int index)
        {
            Name = name;
            Description = description;
            MoneyReward = 0;
            ExperienceReward = 10;
            ItemReward = new List<Item.Item>();
        }

        public QuestStage()
        {
            MoneyReward = 0;
            ExperienceReward = 10;
            ItemReward = new List<Item.Item>();
        }
        //public List<string> Objective { get; set; }
        public event Action QuestStageCompleted;
        public int MoneyReward { get; set; }
        public List<Item.Item> ItemReward { get; set; }
        public int ExperienceReward { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void CallQSCEvent()
        {
            QuestStageCompleted?.Invoke();
        }
    }
}
