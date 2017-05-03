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
    public partial class InventoryButton : UserControl
    {
        public InventoryButton()
        {
            InitializeComponent();
            button1.MouseMove += OnMouseMove;
            button1.MouseLeave += OnMouseLeave;
            button1.MouseDown += OnButtonClick;
            label1.MouseMove += OnMouseMove;
            label1.MouseLeave += OnMouseLeave;
            label1.MouseDown += OnButtonClick;
        }

        public Item CurItem { get; set; }

        public void SetButtonImage(Bitmap bm)
        {
            button1.Image = bm;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Parent != null)
                (Parent as PlayerInventoryControl).OnMouseMove(this, e);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (Parent != null)
                (Parent as PlayerInventoryControl).OnMouseLeave(this, e);
        }

        private void OnButtonClick(object sender, MouseEventArgs e)
        {
            if (Parent != null)
                (Parent as PlayerInventoryControl).OnButtonClick(this, e);
        }

        public void LabelUpdate()
        {
            label1.Text = CurItem.Amount.ToString();
            label1.Visible = true;
        }
    }
}
