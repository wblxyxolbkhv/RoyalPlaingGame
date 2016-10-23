using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quest.QuestStages
{
   public class GetToPoint:QuestStage
    {
        public GetToPoint(int moneyReward, int experienceReward, List<Item.Item> itemReward,
            string description, string name, int index):base(moneyReward,experienceReward, itemReward, name,description)
        {
            QuestStageIndex = index;
        }
        public int X { get; set; }
        public Unit QuestReciver { get; set; }
        public override bool QuestStageCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
