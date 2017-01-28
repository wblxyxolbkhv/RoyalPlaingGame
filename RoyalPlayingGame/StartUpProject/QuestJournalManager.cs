using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualPart.UserControls;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Units;
using RoyalPlayingGame;
using RoyalPlayingGame.Quests.QuestStages;

namespace StartUpProject
{
    public class QuestJournalManager
    {
        public QuestJournalManager()
        {
            QuestListener.QuestPassed += OnQuestPassed;
            QuestListener.QuestStageComplited += OnQuestStageComplited;
            QuestListener.QuestCompleted += OnQuestCompleted;
        }

        private void OnQuestCompleted(string questID)
        {
            foreach (Quest quest in Journal.Journal.ActiveQuests)
            {
                if(quest.ID == questID)
                {
                    Journal.SetObjective("Задание выполнено");
                }
            }
        }
    

        private void OnQuestStageComplited(string stageID)
        {
            // выдача награды
            foreach (Quest quest in Player.QuestJournal.ActiveQuests)
            {
                foreach (QuestStage stage in quest.QuestStages)
                {
                    if (stage.ID == stageID)
                    {
                        Player.Experience += stage.ExperienceReward;
                    }
                }
            }
        }

        private void OnQuestPassed(string questID)
        {
            Quest passedQuest = null;
            foreach(Quest quest in Player.QuestJournal.ActiveQuests)
            {
                if (quest.ID == questID)
                {
                    passedQuest = quest;
                    break;
                }
            }
            Player.QuestJournal.ActiveQuests.Remove(passedQuest);
            Player.QuestJournal.CompletedQuests.Add(passedQuest);
            Journal.RemoveListBoxItem(passedQuest);
        }

        public Player Player { get; set; }
        public JournalControl Journal { get { return journal; }  set { journal = value; } }
        JournalControl journal; 
        public void OnRefresh()
        {
            Journal.Journal = Player.QuestJournal;
            Journal.RefreshLabels();
            Journal.RefreshLinkedNotes();
            Journal.RefreshNotes();
        }

        
        //public void Show()
        //{
        //    Journal.RefreshListBox();
        //    Journal.Visible = true;
        //}
        //public void Hide()
        //{
        //    journal.Visible = false;
        //}
        public void ChangeVisibility()
        {
            if (Journal.Visible)
            {
                Journal.Visible = false;
            }
            else
            {
                Journal.RefreshListBox();
                Journal.Visible = true;
            }
        }
    }
}
