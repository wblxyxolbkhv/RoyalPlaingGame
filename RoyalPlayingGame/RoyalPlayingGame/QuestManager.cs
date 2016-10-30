using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public delegate void QuestHandler(int questID); 
    public static class QuestManager
    {
        public static event QuestHandler QuestGave;
        public static event QuestHandler QuestReceived;
        public static void GiveQuest(int questID)
        {
            QuestGave(questID);
        }
        public static void ReceiveQuest(int questID)
        {
            QuestReceived(questID);
        }
    }
}
