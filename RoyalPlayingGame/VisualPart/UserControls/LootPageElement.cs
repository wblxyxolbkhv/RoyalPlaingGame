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
    public partial class LootPageElement : UserControl
    {
        public LootPageElement()
        {
            InitializeComponent();
            pictureBox1.MouseMove += OnMouseMove;
            pictureBox1.MouseLeave += OnMouseLeave;
            label1.MouseMove += OnMouseMove;
            label1.MouseLeave += OnMouseLeave;
        }
        public Item CurItem { get; set; }

        public void Update(Item item)
        {
            CurItem = item;
            label1.Text = item.Name;
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {
            if(Parent.Parent.Parent as LootPageControl != null)
            (Parent.Parent.Parent as LootPageControl).OnDoubleClick(this, e);
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Parent.Parent.Parent as LootPageControl != null)
                (Parent.Parent.Parent as LootPageControl).OnMouseMove(this, e);
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (Parent.Parent.Parent as LootPageControl != null)
                (Parent.Parent.Parent as LootPageControl).OnMouseLeave(this, e);
        }
    }
}
