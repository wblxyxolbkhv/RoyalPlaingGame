using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
using RoyalPlayingGame.Item;

namespace StartUpProject.Quests
{
    public class Quest
    {
        public Quest(int ID, string name, string description, Unit giver, Player player)
        {
            Player = player;
            this.ID = ID;
            QuestName = name;
            QuestDescription = description;
            QuestGiver = giver;
            QuestStages = new List<QuestStage>();
            IsActive = true;
            QuestStage.QuestStageCompleted += OnNextStage;
        }

        private void OnNextStage()
        {
            if (CurrentQuestStage.QuestStageIndex < QuestStages.Count)
                CurrentQuestStage = QuestStages[CurrentQuestStage.QuestStageIndex + 1];
            else QuestCompleted?.Invoke();
        }

        public int ID { get; set; }
        public bool IsActive { get; set; }
        public static event Action QuestCompleted;
        private Player Player { get; set; }
        public List<QuestStage> QuestStages { get; set; }
        public QuestStage CurrentQuestStage { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public Unit QuestGiver { get; set; }

        public void AddQuestStage(QuestStage questStage)
        {
            QuestStages.Add(questStage);
            if (questStage.QuestStageIndex == 0)
            {
                CurrentQuestStage = questStage;
            }
        }


    }
}

