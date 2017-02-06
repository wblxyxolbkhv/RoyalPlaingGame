using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quests.QuestStages
{   /// <summary>
    /// единица для стадии достижения конкретной точки, содержит в себе 
    /// айди точки
    /// </summary>
    public class ToPointStageGroup
    {
        public ToPointStageGroup()
        {

        }
        public ToPointStageGroup(int ID, string objective)
        {
            this.ID = ID;
            Objective = objective;
        }
        public int ID { get; set; }
        /// <summary>
        /// описание цели, необходимо для отображения в контроле
        /// </summary>
        public string Objective { get; set; }
    }
}
