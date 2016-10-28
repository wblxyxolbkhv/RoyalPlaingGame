using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoyalPlayingGame.Quest
{
    public class Quest
    {
        public Quest(string name, string description, Units.Unit giver, Units.Player player)
        {
            Player = player;
            QuestName = name;
            QuestDescription = description;
            QuestGiver = giver;
            QuestStages = new List<QuestStage>();
            IsActive = true;
        }
        public event Action QuestCompleted;
        public bool IsActive { get; set; }
        private Units.Player Player { get; set; }
        public List<QuestStage> QuestStages { get; set; }
        public QuestStage CurrentQuestStage { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public Units.Unit QuestGiver { get; set; }

        public void AddQuestStage(QuestStage questStage)
        {
            QuestStages.Add(questStage);
            if (questStage.QuestStageIndex ==0)
            {
                CurrentQuestStage = questStage;
            }
        }

        public void NextStage()
        {
            if (CurrentQuestStage.IsQuestStageCompleted()) 
            {
                Player.Experience += CurrentQuestStage.QuestStageExperienceReward;
                Player.MoneyAmount += CurrentQuestStage.QuestStageMoneyReward;
                if (CurrentQuestStage.QuestStageItemReward!=null)
                foreach (Item.Item item in CurrentQuestStage.QuestStageItemReward)
                {
                    Player.Inventory.Add(item);
                }
                if (CurrentQuestStage.QuestStageIndex < QuestStages.Count())
                {
                    CurrentQuestStage.IsActive = false;
                    CurrentQuestStage = QuestStages[CurrentQuestStage.QuestStageIndex + 1];
                }
                else
                {
                    CurrentQuestStage.IsActive = false;
                    IsActive = false;
                    QuestCompleted?.Invoke();
                }
            }
        }
    }
}
