using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Dialogs;
using VisualRedactor.Controls;
using VisualRedactor.Properties;

namespace VisualRedactor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ReplicControls = new List<ReplicControl>();

            createToolStripMenuItem.Click += OnCreateReplic;
            this.ContextMenuStrip = contextMenuStrip1;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnReplicControlMouseUp;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (MovingControl != null)
                MovingControl.Location = new Point(e.X, e.Y);
        }
        private void OnReplicControlMouseDown(object sender, MouseEventArgs e)
        {
            MovingControl = (Control)sender;
        }
        private void OnReplicControlMouseUp(object sender, MouseEventArgs e)
        {
            MovingControl = null;
        }



        private void OnCreateReplic(object sender, EventArgs e)
        {
            ReplicControl r = new ReplicControl();
            r.Location = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
            r.ControlMouseDown += OnReplicControlMouseDown;
            r.ControlMouseUp += OnReplicControlMouseUp;
            this.Controls.Add(r);
            ReplicControls.Add(r);

        }


        private Control MovingControl { get; set; }
        private Dialog Dialog { get; set; }
        private List<ReplicControl> ReplicControls { get; set; }

        private void OnCreateReplicItemClick(object sender, EventArgs e)
        {

        }
    }
}
