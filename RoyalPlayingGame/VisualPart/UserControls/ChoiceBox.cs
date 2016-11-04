using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Dialogs;

namespace VisualPart.UserControls
{
    public delegate void AnswerChoosenHandler(Answer a);
    public partial class ChoiceBox : UserControl
    {
        public ChoiceBox()
        {
            InitializeComponent();

            Labels = new List<Label>();
            Labels.Add(label1);
            Labels.Add(label2);
            Labels.Add(label3);

            //tlp1.Click += OnTableLayoutPanelClick;
            //tlp1.MouseClick += OnTableLayoutPanelMouseClick;

            label1.Click += OnLabelClick;
            label2.Click += OnLabelClick;
            label3.Click += OnLabelClick;
        }

        private void OnLabelClick(object sender, EventArgs e)
        {
            Label l = sender as Label;
            int index = 0;
            foreach (Answer a in Choice.Answers)
                if (a.PlayerPhrases[0] == l.Text)
                    index = Choice.Answers.IndexOf(a);
            if (index < Choice.Answers.Count)
                AnswerChoosen?.Invoke(Choice.Answers[index]);
        }

        //private void OnTableLayoutPanelMouseClick(object sender, MouseEventArgs e)
        //{
            
        //}

        //private void OnTableLayoutPanelClick(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < tlp1.RowCount; i++)
        //    {
        //        if (tlp1.Controls[i] is Label && tlp1.Controls[i].Focused)
        //        {
        //            Label l = tlp1.Controls[i] as Label;
        //            int index = Labels.IndexOf(l);
        //            AnswerChoosen?.Invoke(Choice.Answers[index]);
        //        }
        //    }
        //}

        public event AnswerChoosenHandler AnswerChoosen; 
        public PlayerChoice Choice
        {
            get { return choice; }
            set
            {
                choice = value;
                SetLabelsText();
            }
        }
        private PlayerChoice choice;
        public void SetLabelsText()
        {
            int count = Choice != null ? Choice.Answers.Count : Labels.Count;
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                Labels[j].Text = "";
                try
                {
                    if (Choice.Answers[i].IsHidden)
                        continue;
                    Labels[j].Text = Choice.Answers[i].PlayerPhrases[0]; 
                }
                catch { }
                j++;
            }
            this.Refresh();
        }
        private List<Label> Labels
        {
            get;set;
        }
    }
}
