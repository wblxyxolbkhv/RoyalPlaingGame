using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;
using SimplePhysicalEngine;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ToPointStage : QuestStage
    {
        public ToPointStage(int moneyReward, int experieneReward, List<Item.Item> itemReward, string name, string description, int index) 
            : base(moneyReward, experieneReward, itemReward, name, description, index)
        {
            Points = new List<ToPointStageGroup>();
            TriggersColiisionsListener.TriggerCollisionDetected += OnTriggerDetected;
        }

        public ToPointStage(string name,string description, int index):base(name,description,index)
        {
            Points = new List<ToPointStageGroup>();
            TriggersColiisionsListener.TriggerCollisionDetected += OnTriggerDetected;
        }

        public ToPointStage():base()
        {
            Points = new List<ToPointStageGroup>();
            TriggersColiisionsListener.TriggerCollisionDetected += OnTriggerDetected;
        }

        private List<ToPointStageGroup> Points { get; set; }

        public ToPointStageGroup GetCurrentPoint()
        {
            return Points[0];
        }
        public void AddPoint(ToPointStageGroup tpsg)
        {
            Points.Add(tpsg);
        }
        public void AddPoint(int ID, string objective)
        {
            ToPointStageGroup tpsg = new ToPointStageGroup(ID, objective);
            Points.Add(tpsg);
        }

        private void OnTriggerDetected(int TriggerID)
        {
            foreach (ToPointStageGroup tpsg in Points)
            {
                if (tpsg.ID == TriggerID)
                {
                    CallQSCEvent();
                }
            }
        }
    }
}
