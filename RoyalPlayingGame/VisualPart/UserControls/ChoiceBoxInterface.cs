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
    public partial class ChoiceBoxInterface : UserControl
    {
        public ChoiceBoxInterface()
        {
            InitializeComponent();

            Labels = new List<AdvancedLabel>();
            Labels.Add(advancedLabel1);
            Labels.Add(advancedLabel2);
            Labels.Add(advancedLabel3);

            //tlp1.Click += OnTableLayoutPanelClick;
            //tlp1.MouseClick += OnTableLayoutPanelMouseClick;

            advancedLabel1.Click += OnLabelClick;
            advancedLabel2.Click += OnLabelClick;
            advancedLabel3.Click += OnLabelClick;
        }

        private void OnLabelClick(object sender, EventArgs e)
        {
            AdvancedLabel l = sender as AdvancedLabel;
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
            int count = Choice != null ? Choice.Answers.Count : 0;
            ClearLabelsText();
            int j = 0;
            int i = 0;
            while (i < count && j < Labels.Count)
            {
                Labels[j].Text = "";
                try
                {
                    if (Choice.Answers[i].IsHidden)
                    {
                        i++;
                        continue;
                    }
                    Labels[j].Text = Choice.Answers[i].PlayerPhrases[0];
                }
                catch { }
                j++;
                i++;
            }
            this.Refresh();
        }
        private void ClearLabelsText()
        {
            foreach (AdvancedLabel l in Labels)
                l.Text = string.Empty;
        }
        private List<AdvancedLabel> Labels
        {
            get; set;
        }
    }
}
