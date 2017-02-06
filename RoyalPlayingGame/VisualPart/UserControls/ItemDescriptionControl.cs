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
    public partial class ItemDescriptionControl : UserControl
    {
        public ItemDescriptionControl()
        {
            InitializeComponent();
        }

        public Item Item { get; set; }

        public void Show(Item item)
        {
            Item = item;
            label1.Text = Item.Name;
            label2.Text = Item.Description;
        }
    }
}
