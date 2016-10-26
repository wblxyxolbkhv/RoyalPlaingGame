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
            int index = Labels.IndexOf(l);
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
            for (int i = 0; i < Labels.Count; i++)
            {
                Labels[i].Text = "";
                try
                {
                    Labels[i].Text = Choice.Answers[i].PlayerPhrases[0]; 
                }
                catch { }
            }
            this.Refresh();
        }
        private List<Label> Labels
        {
            get;set;
        }
    }
}
