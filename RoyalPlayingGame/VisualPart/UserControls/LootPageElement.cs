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
    }
}
