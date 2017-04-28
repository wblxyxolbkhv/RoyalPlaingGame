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
            //MouseClick += OnMouseClick;
            itemMenuControl1.UseItemMenuClick += OnItemMenuClick;
            int x = 2;
            int y = 10;
            itemMenuControl1.Visible = false;
            PlaceLabel(ref x, ref y, "All");
            PlaceLabel(ref x, ref y, "Armor");
            PlaceLabel(ref x, ref y, "Weapon");
            PlaceLabel(ref x, ref y, "Potion");
            PlaceLabel(ref x, ref y, "Other");
            MouseDown += OnMouseDown;          
            ItemsManager.SlotsChanged += PlaceButtons;
            ItemsManager.ItemAdded += UdpateButtons;

        }

        private void UdpateButtons()
        {
            for (int i = 0; i < PlayerInventory.Count; i++)
            {
                foreach (Control c in Controls)
                {
                    InventoryButton ib1 = c as InventoryButton;
                    if (ib1 == null)
                        continue;
                    if (PlayerInventory[i] != null)
                    {
                        if (i == Convert.ToInt32(ib1.Name))
                        {
                            ib1.CurItem = PlayerInventory[i];
                            ib1.SetButtonImage(ItemsManager.GetItemImage(ib1.CurItem.ID));
                            ib1.LabelUpdate();
                            break;
                        }
                    }

                }                   
            }
        }

        public void PlaceButtons(int slots)
        {
            foreach (Control c in Controls)
            {
                Button b1 = c as Button;
                if (b1 == null)
                    continue;
                if (b1.AccessibleName == "Кнопка с предметом") 
                    Controls.Remove(b1);
            }
            int x = 25;
            int y = 42;
            PlaceInventoryButtons(x, y, slots);

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if ((sender as InventoryButton).CurItem != null) 
            {
                itemDescriptionControl1.Show((sender as InventoryButton).CurItem);
                itemDescriptionControl1.Location = new Point((sender as InventoryButton).Location.X + 50, (sender as InventoryButton).Location.Y+25);
                if (itemMenuControl1.Visible)
                    itemDescriptionControl1.Visible = false;
                else
                    itemDescriptionControl1.Visible = true;
            }
        }

        public void OnMouseLeave(object sender, EventArgs e)
        {
            itemDescriptionControl1.Visible = false;
        }

        private void OnItemMenuClick(object sender, MouseEventArgs e)
        {
            itemMenuControl1.Item?.Use();
        }

        public void OnButtonClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {
                
                if (itemDescriptionControl1.Visible)
                    itemDescriptionControl1.Visible = false;
                itemMenuControl1.Item = (sender as InventoryButton).CurItem;
                if (itemMenuControl1.Item != null)
                {
                    if (itemMenuControl1.Visible)
                        itemMenuControl1.Visible = false;
                    else
                        itemMenuControl1.Visible = true;
                    itemMenuControl1.Location = new Point((sender as InventoryButton).Location.X + 25, (sender as InventoryButton).Location.Y + 25);
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

            //int x = 25;
            //int y = 42;
            //for (int i = 0; i < PlayerInventory?.Slots; i++)
            //{
            //    Bitmap icon;
            //    try
            //    {
            //        icon = ItemsManager.GetItemImage(PlayerInventory[i].ID);
            //        e.Graphics.DrawImage(icon ?? Properties.Resources.NullSlotImage, new Point(x, y));
            //    }
            //    catch
            //    {
            //        e.Graphics.DrawImage(Properties.Resources.NullSlotImage, new Point(x, y));
            //    }
            //    x += 50;
            //    if (x > 258)
            //    {
            //        y += 50;
            //        x = 25;
            //    }
            //}
        }

        //private Item GetItem(int x, int y)
        //{
        //    Item playerItem = null;
        //    int row = (y - 42) / 50;
        //    int column = (x - 25) / 50;
        //    if ((x - 25) < 0 || (y - 42) < 0)
        //        return null;
        //    int position = column + row * 5;
        //    try
        //    {
        //        playerItem = PlayerInventory[position];
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return playerItem;
        //}

        private void PlaceLabel(ref int x, ref int y, string labelText)
        {
            Label l1 = new Label();
            l1.Location = new Point(x, y);
            l1.Text = labelText;
            l1.AccessibleName = "Вкладки";
            Controls.Add(l1);
            l1.Width = 50;
            l1.MouseClick += OnLabelMouseClick;
            if (labelText == "All")
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
            foreach (Control c in Controls)
            {
                Label l1 = c as Label;
                if ((l1 == null)|| (l1.AccessibleName != "Вкладки"))
                    continue;   
                l1.BorderStyle = BorderStyle.FixedSingle;
            }
            (sender as Label).BorderStyle = BorderStyle.Fixed3D;
        }

        private void PlaceInventoryButtons(int x1, int y1, int slots)
        {
            int count = 0;
            for (int i = 0; i < slots; i++)
            {
                InventoryButton itemButton = new InventoryButton();
                itemButton.AccessibleName = "Кнопка с предметом";
                itemButton.Name = count++.ToString();
                itemButton.Location = new Point(x1, y1);
                //itemButton.Size = new Size(48, 48);
                //itemButton.MouseDown += OnButtonClick;
                //itemButton.MouseMove += OnMouseMove;
                //itemButton.MouseLeave += OnMouseLeave;
                Controls.Add(itemButton);

                try
                {
                    itemButton.SetButtonImage(ItemsManager.GetItemImage(PlayerInventory[i].ID));
                    itemButton.CurItem = PlayerInventory[i];
                }
                catch
                {
                    itemButton.SetButtonImage(Properties.Resources.NullSlotImage);
                }
                x1 += 50;
                if (x1 > 258)
                {
                    y1 += 50;
                    x1 = 25;
                }
            }
        }

        
    }
}
