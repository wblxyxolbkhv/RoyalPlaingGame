﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Exceptions;

namespace RoyalPlayingGame.Quest.QuestStages
{
    public class CollectItem:QuestStage
    {
        public CollectItem(int moneyReward, int experienceReward, List<Item.Item> itemReward, 
            string description, string name, int index):base(moneyReward,experienceReward, itemReward, name,description)
        {
            QuestStageIndex = index;
            MustBeCollectedItems = new List<Item.Item>();
        }

        public List<Item.Item> MustBeCollectedItems { get; set; }

        public void AddMustBeCollectedItem(Item.Item item)
        {
            if (item.IsAQuestItem)
                MustBeCollectedItems.Add(item);
            else throw new NotAQuestItemException();
        }

        public override bool QuestStageCompleted()
        {
            bool flag = false;
            foreach (Item.Item item in MustBeCollectedItems)
            {
                if (item.Amount == item.MaxAmount)
                    flag = true;
                else
                {
                    flag = false;
                    break;
                }   
            }
            if (flag)              
                return true;
            else return false;
        }
    }
}
