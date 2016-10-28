using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quest.QuestStages;
using RoyalPlayingGame.Quest;
using SimplePhysicalEngine;


namespace StartUpProject.Quests
{
    public class ComplexQuest
    {
        //public ComplexQuest(Quest quest)
        //{
        //    ComplexQuestStages = new List<ComplexQuestStage>();
        //    for(int i=0;i< quest.QuestStages.Count;i++)
        //    {
        //        if (quest.QuestStages[i] is CollectItem)
        //            ComplexQuestStages.Add(new ComplexQuestStages.ComplexCollectItem(quest.QuestStages[i] as CollectItem));
        //        if (quest.QuestStages[i] is KillTargetObject)
        //            ComplexQuestStages.Add(new ComplexQuestStages.ComplexKillTargetObject(quest.QuestStages[i] as KillTargetObject));
        //        //доделать
        //        if (quest.QuestStages[i] is GetToPoint)
        //            ComplexQuestStages.Add(new ComplexQuestStages.ComplexGetToPoint(quest.QuestStages[i] as GetToPoint));
        //        if (quest.QuestStages[i] is GetToUnit)
        //            ComplexQuestStages.Add(new ComplexQuestStages.ComplexGetToUnit(quest.QuestStages[i] as GetToUnit));
        //    }
        //}
        //public Quest Quest { get; set; }
        //public List<ComplexQuestStage> ComplexQuestStages { get; set; }
    }
}
