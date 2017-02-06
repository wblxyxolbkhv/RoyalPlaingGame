using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualPart.UserControls;

namespace VisualPart.UserControls
{
    public partial class FastAccessControl : UserControl
    {
        public FastAccessControl()
        {
            InitializeComponent();
        }

        public JournalControl JournalControl { get; set; }
        public InventoryControl InventoryControl { get; set; }
        private void buttonInventory_Click(object sender, EventArgs e)
        {
            if (InventoryControl.Visible)
            {
                InventoryControl.Visible = false;
            }
            else
            {
                InventoryControl.Refresh();
                InventoryControl.Visible = true;
                
            }
        }

        private void buttonJournal_Click(object sender, EventArgs e)
        {
            if (JournalControl.Visible)
            {
                JournalControl.Visible = false;
            }
            else
            {
                JournalControl.Refresh();
                JournalControl.Visible = true;

            }
        }
    }
}
