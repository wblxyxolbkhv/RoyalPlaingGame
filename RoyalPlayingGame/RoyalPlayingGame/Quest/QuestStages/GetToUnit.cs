using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quest.QuestStages
{
    public class GetToUnit : QuestStage
    {
        public GetToUnit(int moneyReward, int experienceReward, List<Item.Item> itemReward,
            string description, string name, int index) : base(moneyReward, experienceReward, itemReward, name, description)
        {
            QuestStageIndex = index;
        }
        public Unit questUnit { get; set; }
        //public override bool IsQuestStageCompleted()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

    



