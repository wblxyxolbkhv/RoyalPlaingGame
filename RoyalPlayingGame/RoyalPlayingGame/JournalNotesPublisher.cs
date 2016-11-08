using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Journal;

namespace RoyalPlayingGame
{
    public static class JournalNotesPublisher
    {
         static JournalNotesPublisher()
        {
            QuestListener.QuestStageComplited += OnQuestStageComplited;
        }

        private  static void OnQuestStageComplited(string stageID)
        {
            foreach (JournalNote note in Notes)
            {
                if (note.LinkedQuestStageID == stageID)
                {
                    Journal.Notes.Add(note);
                }
            }
        }
        private static List<JournalNote> Notes { get; set; }
        public static PlayerJournal Journal { get; set; }
    }
}
