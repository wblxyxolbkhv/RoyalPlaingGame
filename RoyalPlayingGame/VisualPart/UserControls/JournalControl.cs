using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Quests.QuestStages;
using RoyalPlayingGame.Journal;

namespace VisualPart.UserControls
{
    public partial class JournalControl : UserControl
    {
        public JournalControl()
        {
            InitializeComponent();
            Visible = false;
            NoteControls = new List<JournalNoteControl>();
            LinkedNoteControls = new List<JournalNoteControl>();        
            listBoxQuests.SelectedIndexChanged += OnListBoxQuestSelectedItemChanged;
            //button1.Parent = listBoxQuests;
            ////button1.Size = new Size(100, 40);
            //listBoxQuests.Items.Add(button1);
            //listBoxQuests.ItemHeight = 40;
        }

        private void OnListBoxQuestSelectedItemChanged(object sender, EventArgs e)
        {
            LinkedNoteControls.Clear();
            splitContainer1.Panel2.Controls.Clear();
        }

        public PlayerJournal Journal { get; set; }
        public void RefreshListBox()
        {
            if (Journal!= null && Journal.ActiveQuests != null && Journal.ActiveQuests.Count>0)
                foreach (Quest q in Journal.ActiveQuests)
                {        
                    if (listBoxQuests.Items.Contains(q.Name))
                        break;
                    listBoxQuests.Items.Add(q.Name);
                }
        }
        public void RemoveListBoxItem(Quest quest)
        {
            if (listBoxQuests.Items.Contains(quest.Name))
                listBoxQuests.Items.Remove(quest.Name);
        }
        public void RefreshLabels()
        {
            if (Journal != null && Journal.ActiveQuests != null && Journal.ActiveQuests.Count > 0 && listBoxQuests.SelectedItem != null)
                { 
                    labelQuestName.Text = Journal.ActiveQuests[listBoxQuests.SelectedIndex].Name;
                    labelQuestDescription.Text = Journal.ActiveQuests[listBoxQuests.SelectedIndex].Description;
                    labelStageName.Text = Journal.ActiveQuests[listBoxQuests.SelectedIndex].CurrentQuestStage.Name;
                    labelStageDescription.Text = Journal.ActiveQuests[listBoxQuests.SelectedIndex].CurrentQuestStage.Description;
                
                    if (Journal.ActiveQuests[listBoxQuests.SelectedIndex].CurrentQuestStage is KillUnitStage)
                    {
                        KillUnitStage kus = Journal.ActiveQuests[listBoxQuests.SelectedIndex].CurrentQuestStage as KillUnitStage;
                        KillUnitStageGroup k = kus.GetCurrentTarget();
                        if(labelStageObjective.Text!="Задание выполнено")
                        labelStageObjective.Text = string.Format("{0} {1}/{2}", k.Objective, k.CurrentAmount, k.RequiredAmount);
                    }
                    else if (Journal.ActiveQuests[listBoxQuests.SelectedIndex].CurrentQuestStage is ToPointStage)
                    {
                        ToPointStage tps = Journal.ActiveQuests[listBoxQuests.SelectedIndex].CurrentQuestStage as ToPointStage;
                        ToPointStageGroup t = tps.GetCurrentPoint();
                        if (labelStageObjective.Text != "Задание выполнено")
                        labelStageObjective.Text = string.Format("{0} 0/1", t.Objective);
                    }
            }
            else
            {
                labelQuestDescription.Text = "";
                labelQuestName.Text = "";
                labelStageName.Text = "";
                labelStageDescription.Text = "";
                labelStageObjective.Text = "";
                return;
            }

            foreach (JournalNoteControl jnc in NoteControls)
                jnc.Refresh();
        }
        
        public void SetObjective(string objective)
        {
            labelStageObjective.Text = objective;
        }


        private List<JournalNoteControl> LinkedNoteControls { get; set; }
        public void RefreshLinkedNotes()
        {
            foreach (JournalNote note in Journal.Notes)
            {
                bool skipFlag = false;
                foreach (JournalNoteControl jnc in LinkedNoteControls)
                    if (jnc.Note == note)
                    {
                        skipFlag = true;
                        break;
                    }
                if (skipFlag || note.LinkedQuestStageID == null)
                    continue;
                string questID = note.LinkedQuestStageID.Substring(0, 4);
                if (Journal.ActiveQuests.Count == 0 || listBoxQuests.SelectedIndex == -1)
                    return;
                if (questID != Journal.ActiveQuests[listBoxQuests.SelectedIndex].ID)
                    continue;
                JournalNoteControl noteControl = new JournalNoteControl();
                noteControl.Note = note;
                if (LinkedNoteControls.Count > 0)
                {
                    JournalNoteControl prevControl = LinkedNoteControls[LinkedNoteControls.Count - 1];
                    noteControl.Location = new Point(10,
                        prevControl.Location.Y + prevControl.Height + 10);
                }
                else
                {
                    noteControl.Location = new Point(10, 20);
                }

                LinkedNoteControls.Add(noteControl);
                splitContainer1.Panel2.Controls.Add(noteControl);
            }

            foreach (JournalNoteControl jnc in LinkedNoteControls)
                jnc.Refresh();
        }
        private List<JournalNoteControl> NoteControls { get; set; }
        public void RefreshNotes()
        {
            foreach (JournalNote note in Journal.Notes)
            {
                bool skipFlag = false;
                foreach (JournalNoteControl jnc in NoteControls)
                    if (jnc.Note == note)
                    {
                        skipFlag = true;
                        break;
                    }
                if (skipFlag)
                    continue;
                JournalNoteControl noteControl = new JournalNoteControl();
                //noteControl.Size = new Size(100, 20);
                noteControl.Note = note;
                if (NoteControls.Count > 0)
                {
                    JournalNoteControl prevControl = NoteControls[NoteControls.Count - 1];
                    noteControl.Location = new Point(10, 
                        prevControl.Location.Y + prevControl.Height + 10);
                }
                else
                {
                    noteControl.Location = new Point(10, 20);
                }
                NoteControls.Add(noteControl);
                JournalNotes.Controls.Add(noteControl);
            }

        }
    }
}
