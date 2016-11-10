using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Journal;
using System.Xml;

namespace RoyalPlayingGame
{
    public static class JournalNotesPublisher
    {
        static JournalNotesPublisher()
        {
            Notes = new List<JournalNote>();
            QuestListener.QuestStageComplited += OnQuestStageComplited
            LoadJournalNotes("PigeonQuestNotes.xml");
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
        private static void LoadJournalNotes(string path)
        {
            XmlDocument journalNotesXml = new XmlDocument();
            journalNotesXml.Load(path);

            XmlElement rootElement = journalNotesXml.DocumentElement;
            foreach(XmlNode xnode in rootElement)
            {
                string noteName = xnode.Attributes.GetNamedItem("name").Value;
                string linkedStageID = xnode.Attributes.GetNamedItem("id").Value;
                string time = xnode.Attributes.GetNamedItem("time").Value;
                string descriprion = xnode.LastChild.Value;
                JournalNote note = new JournalNote(noteName, descriprion, time, linkedStageID);
                Notes.Add(note);
            }
        }
    }
}
