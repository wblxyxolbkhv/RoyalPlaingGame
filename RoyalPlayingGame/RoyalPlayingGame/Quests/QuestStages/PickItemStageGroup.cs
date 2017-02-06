using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoyalPlayingGame.Items;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quests.QuestStages
{
    /// <summary>
    /// единица для стадии сбора предмета
    /// </summary>
    public class PickItemStageGroup
    {
        public PickItemStageGroup()
        {

        }
        public PickItemStageGroup(Item item, string objective)
        {
            Item = item;
            Objective = objective;
        }
        public Item Item { get; set; }
        /// <summary>
        /// описание цели, необходимо для отображения в контроле
        /// </summary>
        public string Objective { get; set; }
    }
}
