using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;
using RoyalPlayingGame.Units;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class PickItemStage : QuestStage
    {
        public PickItemStage(int moneyReward, int experieneReward, List<Item.Item> itemReward, string name, string description, int index)
            : base(moneyReward, experieneReward, itemReward, name, description, index)
        {
            Unit.QuestItemPicked += OnItemPicked;
            Unit.QuestItemDroped += OnItemDroped;
        }

        public PickItemStage(string name,string description, int index):base(name,description,index)
        {
            Unit.QuestItemPicked += OnItemPicked;
            Unit.QuestItemDroped += OnItemDroped;
        }

        public PickItemStage():base()
        {
            Unit.QuestItemPicked += OnItemPicked;
            Unit.QuestItemDroped += OnItemDroped;
        }

        private List<PickItemStageGroup> PickedQuestItems { get; set; }

        public void AddQuestItem(int ID, string name, int maxAmount, string objective)
        {
            Item.Item item = new Item.Item(name, ID, maxAmount);
            PickItemStageGroup pisg = new PickItemStageGroup(item, objective);
            PickedQuestItems.Add(pisg);
        }

        public void RemoveQuestItem(PickItemStageGroup pisg)
        {
            PickedQuestItems.Remove(pisg);
        }

        private void OnItemDroped(int ID)
        {
            foreach(PickItemStageGroup pisg in PickedQuestItems)
            {
                if (pisg.Item.ID == ID)
                if (pisg.Item.Amount > 0)
                        pisg.Item.Amount--;
            }
        }

        private void OnItemPicked(int ID)
        {
         foreach (PickItemStageGroup pisg in PickedQuestItems)
            {
                if (pisg.Item.ID == ID)
                    pisg.Item.Amount++;
            }
         foreach(PickItemStageGroup pisg in PickedQuestItems)
            {
                if (pisg.Item.Amount < pisg.Item.MaxAmount)
                    return;
            }
            CallQSCEvent();
        }

    }
}
