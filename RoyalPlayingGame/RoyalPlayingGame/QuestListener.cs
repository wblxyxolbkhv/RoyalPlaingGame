﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public delegate void QuestHandler(int questID);
    public delegate void ReplicVisibleChange(int replicID);
    public static class QuestListener
    {
        // события и методы для дачи/принятия квеста
        public static event QuestHandler QuestGave;
        public static event QuestHandler QuestReceived;
        public static void GiveQuest(int questID)
        {
            QuestGave?.Invoke(questID);
        }
        public static void ReceiveQuest(int questID)
        {
            QuestReceived?.Invoke(questID);
        }

        // события и методы для скрытия/открытия квеста
        public static event ReplicVisibleChange ReplicHidden;
        public static event ReplicVisibleChange ReplicShown;
        public static void ReplicHide(int replicID)
        {
            ReplicHidden?.Invoke(replicID);
        }
        public static void ReplicShow(int replicID)
        {
            ReplicShown?.Invoke(replicID);
        }
    }
}