using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Items;

namespace VisualPart.UserControls
{

    public partial class ItemMenuControl : UserControl
    {
        public ItemMenuControl()
        {
            InitializeComponent();

            this.MouseClick += OnMouseClick;
            //label1.MouseClick += OnMouseClick;
            labelUse.MouseClick += OnMouseClick;
            label3.MouseClick += OnMouseClick;
            label4.MouseClick += OnMouseClick;

            labelUse.MouseMove += OnMouseMove;
            labelUse.MouseLeave += OnMouseLeave;
            //label1.MouseMove += OnMouseMove;   
            label3.MouseMove += OnMouseMove;
            label4.MouseMove += OnMouseMove;
            //label1.MouseLeave += OnMouseLeave;
            label3.MouseLeave += OnMouseLeave;
            label4.MouseLeave += OnMouseLeave;

            this.MouseMove += OnParentMouseMove;
        }

        private void OnParentMouseMove(object sender, MouseEventArgs e)
        {
            foreach (Label l1 in Controls)
            {
                l1.BorderStyle = BorderStyle.None;
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            foreach (Label l1 in Controls)
                l1.BorderStyle = BorderStyle.None;
            //(sender as Label).BorderStyle = BorderStyle.None;    
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Label l = (sender as Label);
            foreach (Label l1 in Controls)
            {
                if (l1 == l)
                {
                    l.BorderStyle = BorderStyle.FixedSingle;
                    continue;
                }
                l1.BorderStyle = BorderStyle.None;
            }
            //(sender as Label).BorderStyle = BorderStyle.FixedSingle;            
        }
        



        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (sender as Label == labelUse)
                UseItemMenuClick?.Invoke(this, e);
            Visible = false;
        }

        public event MouseEventHandler UseItemMenuClick;
        public Item Item;

        
    }
}
