using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quest.QuestStages;

namespace StartUpProject.Quests.ComplexQuestStages
{
    public class ComplexCollectItem : ComplexQuestStage
    {
        public ComplexCollectItem(CollectItem questStage) : base(questStage) { }

        public override bool IsComplexQuestStageCompleted()
        {
            return QuestStage.IsQuestStageCompleted();
        }
    }
}
