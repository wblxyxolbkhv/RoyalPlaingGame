using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public delegate void QuestHandler(string questID);
    public delegate void QuestStageHandler(string stageID);
    public delegate void ReplicVisibleChange(int replicID);
    public static class QuestListener
    {
        // события и методы для дачи/принятия квеста
        public static event QuestHandler QuestPassed;
        public static event QuestHandler QuestReceived;
        public static void PassQuest(string questID)
        {
            QuestPassed?.Invoke(questID);
        }
        public static void ReceiveQuest(string questID)
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

        // события и методы для отлова событий на окончание квестовой стадии
        public static event QuestStageHandler QuestStageComplited;
        public static void CompleteQuestStage(string stageID)
        {
            QuestStageComplited?.Invoke(stageID);
        }
    }
}
