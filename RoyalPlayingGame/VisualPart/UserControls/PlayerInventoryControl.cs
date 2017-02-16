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
    public partial class PlayerInventoryControl : UserControl
    {
        public PlayerInventoryControl()
        {
            InitializeComponent();
            //Size = new Size(400, 400);
            //Location = new Point(200, 200);
            //sc.Panel2.Paint += OnSCPaint;
            //Controls.Add(sc);
            //sc.Orientation = Orientation.Vertical;
            //sc.Size = new Size(400, 400);
            //sc.SplitterDistance = 200;
            //sc.Location = new Point(0, 0);
            //Label l1 = new Label();
            //sc.Panel2.Controls.Add(l1);
            //l1.Location = new Point(0, 0);
            //l1.Text = "qwerty";
            //PictureBox pb1 = new PictureBox();
            //sc.Panel2.Controls.Add(pb1);
            //pb1.Image = DefaultImage;
            this.MouseClick += PlayerInventoryControl_MouseClick;
            itemMenuControl1.UseItemMenuClick += OnItemMenuClick;
            //PlayerInventory = new Inventory(10);
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

        private void PlayerInventoryControl_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {

            }
            else
            {
                itemMenuControl1.Visible = true;
                itemMenuControl1.Item = GetItem(e.X, e.Y);
                itemMenuControl1.Location = new Point(e.X, e.Y);

            }
            
 
        }

        //Image DefaultImage { get; set; } = Properties.Resources.NullSlotImage;
        //SplitContainer sc { get; set; } = new SplitContainer();
        public Inventory PlayerInventory {get;set;}// = new Inventory(10);
        //public List<int> PlayerInventory = new List<int>(10);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int x = 2;
            int y = 42;
            for (int i = 0; i < PlayerInventory?.Slots; i++)
            {
                e.Graphics.DrawImage(Properties.Resources.NullSlotImage, new Point(x, y));
                x += 50;
                if (x > 250)
                {
                    y += 50;
                    x = 2;
                }
            }

        }

        private void PlaceImages(Image image, int x, int y)
        {

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
            foreach(Label l1 in Controls)
            {
                l1.BorderStyle = BorderStyle.FixedSingle;
            }
            (sender as Label).BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
