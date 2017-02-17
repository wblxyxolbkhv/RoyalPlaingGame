﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Quests.QuestStages
{
    public class ToPointStageGroup
    {
        public ToPointStageGroup()
        {

        }
        public ToPointStageGroup(string ID, string objective)
        {
            this.ID = ID;
            Objective = objective;
        }
        public string ID { get; set; }
        public string Objective { get; set; }
    }
}
