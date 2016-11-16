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

namespace VisualRedactor.Controls
{
    public delegate void DialogLinkHandler(string number);
    public partial class ReplicControl : UserControl
    {
        public ReplicControl()
        {
            InitializeComponent();

            pictureBoxNext.Click += OnNextClick;
            pictureBoxPrev.Click += OnPrevClick;
            groupBoxReplic.MouseDown += OnMouseDown;
            groupBoxReplic.MouseUp += OnMouseUp;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            this.ControlMouseDown?.Invoke(this, e);
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            this.ControlMouseUp?.Invoke(this, e);
        }

        public event MouseEventHandler ControlMouseDown;
        public event MouseEventHandler ControlMouseUp;
        public event DialogLinkHandler LinkNext;
        public event DialogLinkHandler LinkPrev;


        private void OnPrevClick(object sender, EventArgs e)
        {
            LinkPrev?.Invoke(textBoxNumber.Text);
        }

        private void OnNextClick(object sender, EventArgs e)
        {
            LinkNext?.Invoke(textBoxNumber.Text);
        }
        
        public NPCReplic Replic { get; set; }
        public void Save()
        {
            if (Replic == null)
                Replic = new NPCReplic();

            Replic.Number = textBoxNumber.Text;
            Replic.Duration = Convert.ToInt32(textBoxDuration.Text);

            if (!Replic.Phrases.Contains(richTextBoxReplic.Text))
                Replic.Phrases.Add(richTextBoxReplic.Text);
        }
    }
}
