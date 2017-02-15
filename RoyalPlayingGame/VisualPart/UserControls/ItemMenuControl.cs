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
            label1.MouseClick += OnMouseClick;
            labelUse.MouseClick += OnMouseClick;
            label3.MouseClick += OnMouseClick;
            label4.MouseClick += OnMouseClick;
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (sender as Label == labelUse)
                UseItemMenuClick?.Invoke(this, e);
        }

        public event MouseEventHandler UseItemMenuClick;
        public Item Item;

        
    }
}
