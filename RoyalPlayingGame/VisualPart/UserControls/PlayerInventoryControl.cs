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
            int x = 25;
            int y = 40;
            itemMenuControl1.Visible = false;
            PlaceLabel(ref x, ref y, "All");
            PlaceLabel(ref x, ref y, "Armor");
            PlaceLabel(ref x, ref y, "Weapon");
            PlaceLabel(ref x, ref y, "Potion");
            PlaceLabel(ref x, ref y, "Other");
            //MouseDown += OnMouseDown;          
            ItemsManager.SlotsChanged += PlaceButtons;
            ItemsManager.ItemAdded += UpdateButtons;
            ItemsManager.MoneyChanged += UpdateMoneyAmount;
            PlacePlayerItemSlots();
            PlacePlayerPB();
            PlaceMoneyControls();
        }

        private void UpdateMoneyAmount(int amount)
        {
            foreach (Control c in interfaceControl1.Controls)
            {
                Label l1 = c as Label;
                if (l1 == null)
                    continue;
                if(l1.Name == "Money")
                {
                    l1.Text = amount.ToString();
                }
            }

        }

        private Item ButtonDataItem { get; set; }
        private Bitmap ButtonDataImage { get; set; }
        public Inventory PlayerInventory { get; set; }
        public List<Item> PlayerEquipment { get; set; }

        private void UpdateButtons()
        {
            if (PlayerInventory != null)
                foreach (KeyValuePair<int, Item> pair in PlayerInventory)
                {
                    foreach (Control c in interfaceControl1.Controls)
                    {
                        InventoryButton ib1 = c as InventoryButton;
                        if (ib1 == null)
                            continue;
                        if (pair.Value != null)
                        {
                            if (ib1.AccessibleName == "Кнопка с экипировкой")
                                continue;
                            if ((Convert.ToInt32(ib1.Name) == pair.Key))
                            {
                                ib1.CurItem = pair.Value;
                                ib1.SetButtonImage(ItemsManager.GetItemImage(ib1.CurItem.ID));
                                ib1.LabelUpdate();
                                break;
                            }
                        }
                        if (ib1.CurItem == null)
                            ib1.SetButtonImage(Properties.Resources.NullSlotImage);

                    }
                }
            //for (int i = 0; i < PlayerInventory.Count; i++)
            //{
            //    foreach (Control c in interfaceControl1.Controls)
            //    {
            //        InventoryButton ib1 = c as InventoryButton;
            //        if (ib1 == null)
            //            continue;
            //        if (PlayerInventory[i] != null)
            //        {
            //            if (ib1.AccessibleName == "Кнопка с экипировкой")
            //                continue;
            //            if (i == Convert.ToInt32(ib1.Name))
            //            {
            //                ib1.CurItem = PlayerInventory[i];
            //                ib1.SetButtonImage(ItemsManager.GetItemImage(ib1.CurItem.ID));
            //                ib1.LabelUpdate();
            //                break;
            //            }
            //        }

            //    }                   
            //}
        }

        public void PlaceButtons(int slots)
        {
            foreach (Control c in interfaceControl1.Controls)
            {
                InventoryButton b1 = c as InventoryButton;
                if (b1 == null)
                    continue;
                if (b1.AccessibleName == "Кнопка с предметом") 
                    interfaceControl1.Controls.Remove(b1);
            }
            int x = 25;
            int y = 72;
            PlaceInventoryButtons(x, y, slots);
        }

        //private void OnMouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        var img = (sender as Button).Image;
        //        if (img == null) return;
        //        if(DoDragDrop(img,DragDropEffects.Move) == DragDropEffects.Move)
        //        {
        //            (sender as Button).Image = null;
        //        }
        //    }
        //}

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
                //DoDragDrop(sender, DragDropEffects.Move);
                var img = (sender as InventoryButton).ItemImage;
                if (img == null) return;
                if (DoDragDrop(sender, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    if (ButtonDataItem != null)
                    {
                        //(sender as InventoryButton).CurItem = ButtonDataItem;
                        //(sender as InventoryButton).CurItem.Position = Convert.ToInt32((sender as InventoryButton).Name);
                        //foreach (Item item in PlayerInventory)
                        //{
                        //    if (item == (sender as InventoryButton).CurItem)
                        //        item.Position = (sender as InventoryButton).CurItem.Position;
                        //}
                        (sender as InventoryButton).CurItem = ButtonDataItem;
                        PlayerInventory.ChangeKey((sender as InventoryButton).CurItem, Convert.ToInt32((sender as InventoryButton).Name));
                    }
                    else
                    {
                        (sender as InventoryButton).CurItem = null;
                        //(sender as InventoryButton).CurItem.Position = Convert.ToInt32((sender as InventoryButton).Name);
                    }
                    (sender as InventoryButton).SetButtonImage(ButtonDataImage);
                    (sender as InventoryButton).LabelUpdate();
                }
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
        

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
            //e.Graphics.DrawImage(Properties.Resources.BagBackGround, new Point(0, 33));

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
        //}

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
            interfaceControl1.Controls.Add(l1);
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
            foreach (Control c in interfaceControl1.Controls)
            {
                Label l1 = c as Label;
                if ((l1 == null)|| (l1.AccessibleName != "Вкладки"))
                    continue;   
                l1.BorderStyle = BorderStyle.FixedSingle;
            }
            (sender as Label).BorderStyle = BorderStyle.Fixed3D;
            switch ((sender as Label).Text)
            {
                case "All":
                    foreach (Control c in interfaceControl1.Controls)
                    {
                        InventoryButton ib1 = c as InventoryButton;
                        if (ib1 == null)
                            continue;
                        if (ib1.AccessibleName == "Кнопка с предметом")
                        {
                            ib1.CurItem = null;
                            ib1.SetButtonImage(Properties.Resources.NullSlotImage);
                            ib1.Visible = true;
                        }
                    }
                    UpdateButtons();
                        break;
                case "Armor": HideInventoryButtons(ItemType.Armor);
                    break;
                case "Weapon": HideInventoryButtons(ItemType.Weapon);
                    break;
                case "Potion": HideInventoryButtons(ItemType.Potion);
                    break;
                case "Other": HideInventoryButtons(ItemType.Other);
                    break;
            }
        }

        private void HideInventoryButtons(ItemType itemType)
        {
            int i = 0;
            foreach (KeyValuePair<int,Item> pair in PlayerInventory)
            {
                if (pair.Value.Type == itemType)
                {
                    foreach (Control c in interfaceControl1.Controls)
                    {
                        InventoryButton ib1 = c as InventoryButton;
                        if (ib1 == null)
                            continue;
                        {
                            if (ib1.AccessibleName == "Кнопка с экипировкой")
                                continue;
                            if (i == Convert.ToInt32(ib1.Name))
                            {
                                ib1.CurItem = pair.Value;
                                ib1.SetButtonImage(ItemsManager.GetItemImage(ib1.CurItem.ID));
                                ib1.LabelUpdate();
                                ib1.Visible = true;
                                i++;
                                break;
                            }
                        }

                    }
                }
            }
            foreach (Control c in interfaceControl1.Controls)
            {
                InventoryButton ib1 = c as InventoryButton;
                if (ib1 == null)
                    continue;
                if (ib1.AccessibleName == "Кнопка с предметом")
                    if ((ib1.CurItem == null) || (ib1.Name == i.ToString()))
                    {
                        ib1.Visible = false;
                        i++;
                    }
            }
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
                itemButton.MouseDown += OnButtonClick;
                //itemButton.MouseMove += OnMouseMove;
                //itemButton.MouseLeave += OnMouseLeave;
                itemButton.DragEnter += OnDrag;
                itemButton.DragDrop += OnDrop;
                itemButton.AllowDrop = true;
                interfaceControl1.Controls.Add(itemButton);
                
                //try
                //{
                //    itemButton.SetButtonImage(ItemsManager.GetItemImage(PlayerInventory[i].ID));
                //    itemButton.CurItem = PlayerInventory[i];
                //}
                //catch
                //{
                    itemButton.SetButtonImage(Properties.Resources.NullSlotImage);
                //}
                x1 += 50;
                if (x1 > 258)
                {
                    y1 += 50;
                    x1 = 25;
                }
            }
            if(PlayerInventory.Count>0)
            UpdateButtons();
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            ButtonDataItem = (sender as InventoryButton).CurItem;
            ButtonDataImage = (Bitmap)(sender as InventoryButton).ItemImage;
            InventoryButton ib = (InventoryButton)e.Data.GetData(e.Data.GetFormats()[0]);
            if(ib.CurItem!=null)
            (sender as InventoryButton).CurItem = ib.CurItem;
            //(sender as InventoryButton).CurItem.Position = Convert.ToInt32((sender as InventoryButton).Name);
            PlayerInventory.ChangeKey((sender as InventoryButton).CurItem, Convert.ToInt32((sender as InventoryButton).Name));
            (sender as InventoryButton).SetButtonImage((Bitmap)ib.ItemImage);
            (sender as InventoryButton).LabelUpdate();
        }

        private void OnDrag(object sender, DragEventArgs e)
        {
            //(sender as InventoryButton).SetButtonStyle(FlatStyle.System);
            e.Effect = DragDropEffects.Move;     
        }

        /// <summary>
        /// Добавление слотов под снаряжение игрока
        /// </summary>
        private void PlacePlayerItemSlots()
        {
            //Добавление слотов под доспехи
            int x = 310;
            int y = 40;
            for (int i = 0; i < 6; i++)
            {
                InventoryButton armorButton = new InventoryButton();
                armorButton.AccessibleName = "Кнопка с экипировкой";
                armorButton.Name = i.ToString();
                armorButton.Location = new Point(x, y);
                armorButton.MouseDown += OnButtonClick;
                interfaceControl1.Controls.Add(armorButton);
                armorButton.DragEnter += OnDrag;
                armorButton.DragDrop += OnDrop;
                armorButton.AllowDrop = true;
                y += 50;
                if (y>150)
                {
                    y = 40;
                    x = 512;
                }
            }
            //Добавление слота под оружие
            InventoryButton weaponButton = new InventoryButton();
            weaponButton.AccessibleName = "Кнопка с экипировкой";
            weaponButton.Name = 6.ToString();
            weaponButton.Location = new Point(411, 240);
            weaponButton.MouseDown += OnButtonClick;
            interfaceControl1.Controls.Add(weaponButton);
            weaponButton.DragEnter += OnDrag;
            weaponButton.DragDrop += OnDrop;
            weaponButton.AllowDrop = true;
        }


        /// <summary>
        /// Добавление пикчербокса с изображением игрока
        /// </summary>
        private void PlacePlayerPB()
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(360, 40);
            pb.Size = new Size(150, 200);
            interfaceControl1.Controls.Add(pb);
        }

        /// <summary>
        /// Добавление контролов, свзянных с отображением денег
        /// </summary>
        private void PlaceMoneyControls()
        {
            //Добавление на форму пикчербокса с монетой
            PictureBox pb = new PictureBox();
            pb.Size = new Size(15, 18);
            pb.Location = new Point(200, 15);
            pb.Image = Properties.Resources.coin;
            interfaceControl1.Controls.Add(pb);
            //Добавление лейбла с количеством денег у игрока
            Label lb = new Label();
            lb.Location = new Point(225, 15);
            lb.Size = new Size(50, 20);
            //lb.Text = PlayerMoneyAmount.ToString();
            interfaceControl1.Controls.Add(lb);
            lb.Name = "Money";
            lb.Font = new Font(lb.Font.FontFamily, 9.25F);
            lb.BorderStyle = BorderStyle.Fixed3D;
        }


    }
}
