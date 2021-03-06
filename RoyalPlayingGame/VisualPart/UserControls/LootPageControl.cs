﻿using System;
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
using RoyalPlayingGame.Exceptions;

namespace VisualPart.UserControls
{
    public partial class LootPageControl : UserControl
    {
        public LootPageControl()
        {
            InitializeComponent();
            button1.Click += ChangeVisibility;
            button2.Click += OnPickAllButtonClick;
        }

        private void LootPageControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Location = new Point(Cursor.Position.X - Parent.Location.X + Location.X, Cursor.Position.Y - Parent.Location.Y+Location.Y);
            //Parent.Location.X;
            //Location = new Point(Cursor.Position.X - Parent.Location.X-12, Cursor.Position.Y - Parent.Location.Y-40);
            MouseButtonDown = true;
            //Size s = Screen.PrimaryScreen.WorkingArea.Size;
            //int x = Screen.PrimaryScreen.WorkingArea.;
        }

        private void OnPickAllButtonClick(object sender, EventArgs e)
        {
            for (int i=lootList.Count;i>=lootList.Count && lootList.Count > 0; i--)
            {
                try
                {
                    Inventory.AddItem(lootList[lootList.Count-i]);
                    lootList.Remove(lootList[lootList.Count-i]);
                    splitContainer1.Panel2.Controls.Clear();
                    Update(lootList);
                }
                catch (FullBagException fbe)
                {
                    ItemsManager.BagFull(fbe.Message, 1000);
                }
            }
            
        }

        private bool MouseButtonDown { get; set; }
        private List<Item> lootList { get; set; }
        public Inventory Inventory { get; set; }
        public ItemDescriptionControl IDC { get; set; }

        /// <summary>
        /// Скрытие контрола и очистка контейнера с LootPageElement'ами 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeVisibility(object sender, EventArgs e)
        {
            Visible = false;
            splitContainer1.Panel2.Controls.Clear();
        }

        /// <summary>
        /// Обновление данных контрола
        /// </summary>
        /// <param name="loot"></param>
        public void Update(List<Item> loot)
        {
            if (lootList == null)
                lootList = new List<Item>();
            lootList = loot;
            int x = 2;
            int y = 2;
            foreach(Item item in lootList)
            {
                LootPageElement lpe = new LootPageElement();
                lpe.DoubleClick += OnDoubleClick;
                lpe.MouseMove += OnMouseMove;
                lpe.MouseLeave += OnMouseLeave;
                lpe.Update(item);
                lpe.SetBitmapImage(ItemsManager.GetItemImage(item.ID));
                lpe.Location = new Point(x, y);
                splitContainer1.Panel2.Controls.Add(lpe);
                y += 50;
            }
            if(!Visible)
            Location = new Point(Cursor.Position.X - Parent.Location.X - 8, Cursor.Position.Y - Parent.Location.Y - 30);

        }

        public void OnMouseLeave(object sender, EventArgs e)
        {
            IDC.Visible = false;
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            IDC.Show((sender as LootPageElement).CurItem);
            IDC.Location = new Point(Location.X+150, Location.Y);
            IDC.Visible = true;
        }

        /// <summary>
        /// Добавление лута плееру по даблклику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDoubleClick(object sender, EventArgs e)
        {
            foreach(Item item in lootList)
            {
                if(item == (sender as LootPageElement).CurItem)
                {
                    try
                    {
                        Inventory.AddItem(item);
                        lootList.Remove(item);
                        splitContainer1.Panel2.Controls.Clear();
                        Update(lootList);
                        IDC.Visible = false;
                        break;
                    }
                    catch(FullBagException fbe)
                    {
                        ItemsManager.BagFull(fbe.Message, 1000);
                    }
                }
            }
        }

        private void SplitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(MouseButtonDown)
                Location = new Point(Cursor.Position.X - Parent.Location.X - 12, Cursor.Position.Y - Parent.Location.Y - 40);
        }

        private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseButtonDown = false;
        }
    }
}
