using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quest;
using SimplePhysicalEngine;

namespace StartUpProject.Quests
{
    public abstract class ComplexQuestStage
    {
        public ComplexQuestStage(QuestStage questStage)
        {
            QuestStage = questStage;
            ComplexQuestStageIndex = questStage.QuestStageIndex;
        }
        public QuestStage QuestStage { get; set; }
        public int ComplexQuestStageIndex { get; set; }
        public abstract bool IsComplexQuestStageCompleted();

    }
}
