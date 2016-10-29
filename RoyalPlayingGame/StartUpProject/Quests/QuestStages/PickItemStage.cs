using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Item;
using RoyalPlayingGame.Units;

namespace StartUpProject.Quests.QuestStages
{
    public class PickItemStage : QuestStage
    {
        public PickItemStage(int moneyReward, int experieneReward, List<Item> itemReward, string name, string description, int index)
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

        private List<Item> PickedQuestItems { get; set; }

        public void AddQuestItem(int ID, string name, int maxAmount)
        {
            Item item = new Item(name, ID, maxAmount);
            PickedQuestItems.Add(item);
        }

        public void RemoveQuestItem()
        {

        }
        private void OnItemDroped(int ID)
        {
            foreach(Item item in PickedQuestItems)
            {
                if (item.ID == ID)
                if (item.Amount > 0)
                     item.Amount--;
            }
        }

        private void OnItemPicked(int ID)
        {
         foreach (Item item in PickedQuestItems)
            {
                if (item.ID == ID)
                    item.Amount++;
            }
         foreach(Item item in PickedQuestItems)
            {
                if (item.Amount < item.MaxAmount)
                    return;
            }
            CallQSCEvent();
        }

    }
}
