using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quests;

namespace RoyalPlayingGame.Journal
{
    /// <summary>
    /// Запись в журнале игрока, автор: Жифарский Д.А.
    /// </summary>
    public class JournalNote
    {
        public JournalNote(string name, string description, string time, string linkedStageID)
        {
            Name = name;
            Description = description;
            Time = time;
            LinkedQuestStageID = linkedStageID;
        }
        public string Name { get; set; }
        public string Month { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        //public Quest LinkedQuest { get; set; }
        public string LinkedQuestStageID { get; set; }

    }
}
