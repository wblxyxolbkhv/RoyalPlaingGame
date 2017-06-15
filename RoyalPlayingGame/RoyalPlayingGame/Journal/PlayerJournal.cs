using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quests;

namespace RoyalPlayingGame.Journal
{
    /// <summary>
    /// Журнал игрока, автор: Жифарский Д.А.
    /// </summary>
    public class PlayerJournal
    {
        public PlayerJournal()
        {
            ActiveQuests = new List<Quest>();
            CompletedQuests = new List<Quest>();
            Notes = new List<JournalNote>();
        }
        // активные квесты
        public List<Quest> ActiveQuests { get; set; }
        // завершенные квесты
        public List<Quest> CompletedQuests { get; set; }
        // неквестовые записи
        public List<JournalNote> Notes { get; set; }

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
        public void RemoveActiveQuest(Quest quest)
        {
            ActiveQuests.Remove(quest);
        }
        public void RemoveCompletedQuest(Quest quest)
        {
            CompletedQuests.Remove(quest);
        }
        public void RemoveNote(JournalNote note)
        {
            Notes.Remove(note);
        }
    }
}
