using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quest.QuestStages;
using RoyalPlayingGame;


namespace StartUpProject.Quests.ComplexQuestStages
{
    public class ComplexKillUnit
    {
        public (KillTargetObject questStage) : base(questStage)
        {
            DeadUnitListener.DeathSomeUnit += OnSomeUnitDeath;
        }

        private void OnSomeUnitDeath(RoyalPlayingGame.Units.Unit unit)
        {

        }
    }
}
