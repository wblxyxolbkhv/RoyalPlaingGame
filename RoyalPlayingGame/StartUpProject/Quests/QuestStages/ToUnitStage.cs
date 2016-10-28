using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;

namespace StartUpProject.Quests.QuestStages
{
    public class ToUnitStage : QuestStage
    {
        public ToUnitStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index) 
            : base(moneyReward, experieneReward, itemReward, name, description, index)
        {

        }

        public ToUnitStage(string name, string description, int index):base(name,description,index)
        {

        }
    }
}
