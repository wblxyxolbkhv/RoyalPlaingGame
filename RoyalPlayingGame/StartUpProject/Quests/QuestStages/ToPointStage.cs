using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;
using SimplePhysicalEngine;

namespace StartUpProject.Quests.QuestStages
{
    public class ToPointStage : QuestStage
    {
        public ToPointStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index) 
            : base(moneyReward, experieneReward, itemReward, name, description, index)
        {
            TriggersColiisionsListener.TriggerCollisionDetected += OnTriggerDetected;
        }

        public ToPointStage(string name,string description, int index):base(name,description,index)
        {
            TriggersColiisionsListener.TriggerCollisionDetected += OnTriggerDetected;
        }

        private List<int> PointsID { get; set; }

        public void AddPoint(int ID)
        {
            PointsID.Add(ID);
        }

        private void OnTriggerDetected(int TriggerID)
        {
            foreach (int ID in PointsID)
            {
                if (ID == TriggerID)
                {
                    CallQSCEvent();
                }
            }
        }
    }
}
