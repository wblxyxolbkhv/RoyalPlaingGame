using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quests.QuestStages
{
    /// <summary>
    /// единица для стадии убийства цели, включает в себя 
    /// таргет, требуемое количество и текущее количество
    /// </summary>
    public class KillUnitStageGroup
    {
        public KillUnitStageGroup(Unit target, int reqAmount,string objective)
        {
            Target = target;
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
            Objective = objective;
        }
        public KillUnitStageGroup(int ID, int reqAmount,string objective)
        {
            Target = new Unit(ID);
            RequiredAmount = reqAmount;
            CurrentAmount = 0;
            Objective = objective;
        }
        public Unit Target { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
        /// <summary>
        /// описание цели, необходимо для отображения в контроле
        /// </summary>
        public string Objective { get; set; }
    }
}
