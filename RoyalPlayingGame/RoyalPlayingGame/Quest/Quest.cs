using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quest
{
    public class Quest
    {
        public Quest()
        {
            
        }
        List<QuestStage> QuestStages { get; set; }
        public QuestStage CurrentQuestStage { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public Units.Unit QuestGiver { get; set; }

        public void AddQuestStage(QuestStage questStage)
        {
            QuestStages.Add(questStage);
        }

        public void NextStage()
        {
            if (CurrentQuestStage.QuestStageCompleted()) 
            {
                if (CurrentQuestStage.QuestStageIndex < QuestStages.Count())
                CurrentQuestStage = QuestStages[CurrentQuestStage.QuestStageIndex+1];
            }
        }
    }
}
