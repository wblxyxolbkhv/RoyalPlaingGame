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
using RoyalPlayingGame;

namespace VisualPart.UserControls
{
    public partial class PlayerInventoryControl : UserControl
    {
        public PlayerInventoryControl()
        {
            InitializeComponent();
            this.MouseClick += OnMouseClick;
            itemMenuControl1.UseItemMenuClick += OnItemMenuClick;
            int x = 2;
            int y = 10;
            itemMenuControl1.Visible = false;
            PlaceLabel(ref x, ref y, "All");
            PlaceLabel(ref x, ref y, "Armor");
            PlaceLabel(ref x, ref y, "Weapon");
            PlaceLabel(ref x, ref y, "Potion");
            PlaceLabel(ref x, ref y, "Other");
        }

        private void OnItemMenuClick(object sender, MouseEventArgs e)
        {
            itemMenuControl1.Item?.Use();
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {

            }
            else
            {
                if (itemMenuControl1.Visible)
                    itemMenuControl1.Visible = false;          
                itemMenuControl1.Item = GetItem(e.X, e.Y);
                if (itemMenuControl1.Item != null)
                {
                    itemMenuControl1.Location = new Point(e.X, e.Y);
                    itemMenuControl1.Visible = true;
                }  
            }
        }

        //Image DefaultImage { get; set; } = Properties.Resources.NullSlotImage;
        //SplitContainer sc { get; set; } = new SplitContainer();
        public Inventory PlayerInventory { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(Properties.Resources.BagBackGround, new Point(0, 33));
            int x = 10;
            int y = 42;
            for (int i = 0; i < PlayerInventory?.Slots; i++)
            {

                Bitmap icon;
                try
                {
                    icon = ItemsManager.GetItemImage(PlayerInventory[i].ID);
                    e.Graphics.DrawImage(icon ?? Properties.Resources.NullSlotImage, new Point(x, y));
                }
                catch
                {
                    e.Graphics.DrawImage(Properties.Resources.NullSlotImage, new Point(x, y));
                }
                x += 50;
                if (x > 258)
                {
                    y += 50;
                    x = 2;
                }
            }
        }

        private Item GetItem(int x, int y)
        {
            Item playerItem = null;
            int row = (y - 40) / 50;
            int column = x / 50;
            int position = column + row * 5;
            try
            {
                playerItem = PlayerInventory[position];
            }
            catch
            {
                return null;
            }
            return playerItem;
        }

        private void PlaceLabel(ref int x, ref int y, string labelText)
        {
            Label l1 = new Label();
            l1.Location = new Point(x, y);
            l1.Text = labelText;
            Controls.Add(l1);
            l1.Width = 50;
            l1.MouseClick += OnLabelMouseClick;
            if(labelText == "All")
            {
                l1.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                l1.BorderStyle = BorderStyle.FixedSingle;
            }
            x += 50;
        }

        private void OnLabelMouseClick(object sender, MouseEventArgs e)
        {
            foreach(Control c in Controls)
            {
                Label l1 = c as Label;
                if (l1 == null)
                    continue;
                l1.BorderStyle = BorderStyle.FixedSingle;
            }
            (sender as Label).BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
