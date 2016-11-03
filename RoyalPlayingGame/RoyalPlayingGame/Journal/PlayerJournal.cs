using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quests;

namespace RoyalPlayingGame.Journal
{
    public class PlayerJournal
    {
        private List<Quest> ActiveQuests { get; set; }
        private List<Quest> CompletedQuests { get; set; }
        private List<JournalNote> Notes { get; set; }

        public void AddActiveQuest(Quest quest)
        {
            ActiveQuests.Add(quest);
        }
        public void AddCompletedQuest(Quest quest)
        {
            CompletedQuests.Add(quest);
        }
        public void AddNote(JournalNote note)
        {
            Notes.Add(note);
        }
    }
}
