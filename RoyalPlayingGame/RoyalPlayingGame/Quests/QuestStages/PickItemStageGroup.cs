using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class PickItemStageGroup
    {
        public PickItemStageGroup()
        {

        }
        public PickItemStageGroup(Item.Item item, string objective)
        {
            Item = item;
            Objective = objective;
        }
        public Item.Item Item { get; set; }
        public string Objective { get; set; }
    }
}
