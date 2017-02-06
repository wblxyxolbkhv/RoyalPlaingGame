using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Journal;

namespace VisualPart.UserControls
{
    public partial class JournalNoteControl : UserControl
    {
        public JournalNoteControl()
        {
            InitializeComponent();
        }



        public JournalNote Note { get; set; }

        public override void Refresh()
        {
            UpdateLabels();
            base.Refresh();
        }
        private void UpdateLabels()
        {
            labelDate.Text = Note.Time;
            labelName.Text = Note.Name;
            labelDescription.Text = Note.Description;

            this.Size = new Size(
                labelDescription.Width + labelDescription.Location.X + 20,
                labelDescription.Height + labelDescription.Location.Y + 20);
            if (this.Width >= this.Parent.Width - 10)
                this.Size = new Size(Parent.Width - 10, Size.Height);
        }
    }
}
