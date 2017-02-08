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
using RoyalPlayingGame.Exceptions;

namespace VisualPart.UserControls
{
    public partial class LootPageControl : UserControl
    {
        public LootPageControl()
        {
            InitializeComponent();
            button1.Click += ChangeVisibility;          
        }

        private List<Item> lootList { get; set; }
        public Inventory Inventory { get; set; }
        public ItemDescriptionControl IDC { get; set; }
        private void ChangeVisibility(object sender, EventArgs e)
        {
            Visible = false;
            splitContainer1.Panel2.Controls.Clear();
        }

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
                lpe.SetBitmapImage(ItemsManager.GetItemImage(item.Name));
                lpe.Location = new Point(x, y);
                splitContainer1.Panel2.Controls.Add(lpe);
                y += 50;
            }
            if(Visible != true)
            Location = new Point(Cursor.Position.X - 240, Cursor.Position.Y - 240);

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
                        break;
                    }
                    catch(FullBagException fbe)
                    {
                        ItemsManager.BagFull(fbe.Message, 1000);
                    }
                }
            }
        }
    }
}
