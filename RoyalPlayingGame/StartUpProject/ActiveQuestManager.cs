using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualPart.UserControls;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Units;
using RoyalPlayingGame;
/* Назначение: Менеджер для контрола, показывающего текущий квест
 * Автор: Никитенко А.В.
 */
namespace StartUpProject
{
    
    public class ActiveQuestManager
    {
        public ActiveQuestManager()
        {
            QuestListener.QuestReceived += ReceiveQuest;
        }





        public Player Player { get; set; }
        public Quest ActiveQuest
        {
            get
            {
                foreach (Quest q in Player.QuestJournal.ActiveQuests)
                {
                    if (q.IsActive)
                        return q;
                }
                return null;
            }
        }
        public ActiveQuestControl ActiveQuestControl
        {
            get
            {
                return activeQuestControl;
            }
            set
            {
                activeQuestControl = value;
                ActiveQuestControl.ActiveQuest = ActiveQuest;
            }
        }
        ActiveQuestControl activeQuestControl;
        public void OnRefresh()
        {
            ActiveQuestControl.ActiveQuest = ActiveQuest;
            ActiveQuestControl.RefreshLables();
        }

        private void ReceiveQuest(string id)
        {
            if (id == "1000")
            {
                Quest q = new Quest();
                q.LoadQuest("PigeonQuest.xml");
                Player.AddQuest(q);
                q.IsActive = true;
            }
        }
    }
}
