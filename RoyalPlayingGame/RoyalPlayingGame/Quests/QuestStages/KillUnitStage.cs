using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame;
using RoyalPlayingGame.Items;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quests.QuestStages
{
    /// <summary>
    /// стадия на убийство цели
    /// </summary>
    public class KillUnitStage:QuestStage
    {
        public KillUnitStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index)
            : base(moneyReward, experieneReward, itemReward, name, description, index)
        {
            Targets = new List<KillUnitStageGroup>();
            DeadUnitListener.DeathSomeUnit += OnSomeUnitDeath;
        }
        public KillUnitStage(string name, string description, int index):base(name,description,index)
        {
            Targets = new List<KillUnitStageGroup>();
            DeadUnitListener.DeathSomeUnit += OnSomeUnitDeath;
        }

        public KillUnitStage():base()
        {
            Targets = new List<KillUnitStageGroup>();
            DeadUnitListener.DeathSomeUnit += OnSomeUnitDeath;
        }

        private List<KillUnitStageGroup> Targets { get; set; }
        
        // сраный костыль, надо исправить
        public KillUnitStageGroup GetCurrentTarget()
        {
            return Targets[0];
        }

        public void AddTarget(Unit target, int reqAmount, string objective)
        {
            KillUnitStageGroup kusg = new KillUnitStageGroup(target, reqAmount,objective);
            Targets.Add(kusg);
        }
        public void AddTarget(int ID,int reqAmount,string objective)
        {
            KillUnitStageGroup kusg = new KillUnitStageGroup(ID, reqAmount,objective);
            Targets.Add(kusg);
        }
        public void AddTarget(KillUnitStageGroup kusg)
        {
            Targets.Add(kusg);
        }
        private void OnSomeUnitDeath(Unit unit)
        {
            if (!IsCurrent)
                return;
            foreach(KillUnitStageGroup kusg in Targets)
            {
                if (kusg.Target.ID == unit.ID)
                    kusg.CurrentAmount++;
            }
            foreach(KillUnitStageGroup kusg in Targets)
            {
                if (kusg.CurrentAmount < kusg.RequiredAmount)
                    return;
            }
            CallQSCEvent();
        }
    }
}
