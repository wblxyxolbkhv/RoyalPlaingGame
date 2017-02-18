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
    public partial class InventoryControl : UserControl
    {
        public InventoryControl()
        {
            InitializeComponent();
            ItemList = new List<Item>();
            AllBagSlots = new List<PictureBox>();
            //ItemsManager.SlotsChanged += PlacePictureBoxes;
           // ItemsManager.ItemAdded += UpdateAllItemPictureBoxes;
        }

        public List<Item> ItemList { get; set; }
        public List<PictureBox> AllBagSlots { get; set; }
        public List<PictureBox> ArmorBagSlots { get; set; }
        public List<PictureBox> WeaponBagSlots { get; set; }
        public List<PictureBox> PotionsBagSlots { get; set; }
        public List<PictureBox> OtherBagSlots { get; set; }
        public int SlotsAmount { get; set; }

        //public override void Refresh()
        //{
        //    //PlacePictureBoxes();
        //    UpdateAllItemPictureBoxes();
        //    //UpdateItemPictureBox();
        //    base.Refresh();
        //}

        /// <summary>
        /// обновление пикчербокса для вкладки "все предметы"
        /// </summary>
        //public void UpdateAllItemPictureBoxes()
        //{
        //    if (AllBagSlots == null)
        //        return;
        //    if (ItemList.Count != 0)
        //    {
        //        for (int i = 0; i < ItemList.Count; i++)
        //        {
        //            //AllBagSlots[i].BackColor = Color.Black;
        //            AllBagSlots[i].Image = ItemsManager.GetItemImage(ItemList[i].ID);
        //        }
        //    }
        //}

        /// <summary>
        /// Расположение и заполнение пикчербоксов 
        /// на всех страницах
        /// </summary>
        //public void PlacePictureBoxes(int slots)
        //{
        //    SlotsAmount = slots;
        //    if (AllBagSlots == null)
        //    {
        //        AllBagSlots = new List<PictureBox>();
        //        ArmorBagSlots = new List<PictureBox>();
        //        WeaponBagSlots = new List<PictureBox>();
        //        PotionsBagSlots = new List<PictureBox>();
        //        OtherBagSlots = new List<PictureBox>();
        //    }
            
        //    int x1 = 25;
        //    int y1 = 20;
        //    for (int i = 0; i < SlotsAmount; i++)
        //    {
        //        LocatePictureBox(AllBagSlots, tabPageAll, ref x1, ref y1, Image.FromFile("NullSlotImage.png"));
        //    }
           // UpdateAllItemPictureBoxes();

            //НЕ УБИРАТЬ, РАСКОММЕНТИТЬ ПОСЛЕ ЗАПОЛНЕНИЯ СПИСКА ИЗОБРАЖЕНИЙ

            //foreach (Item item in ItemList)
            //{
            //    if (item is Weapon)
            //    {
            //        int x2 = 25;
            //        int y2 = 20;
            //        LocatePictureBox(WeaponBagSlots, tabPageWeapon, ref x2, ref y2, ItemsManager.GetItemImage(item.Name));
            //    }
            //    if (item is Armor)
            //    {
            //        int x3 = 25;
            //        int y3 = 20;
            //        LocatePictureBox(ArmorBagSlots, tabPageArmor, ref x3, ref y3, ItemsManager.GetItemImage(item.Name));
            //    }
            //    if (item is Potion)
            //    {
            //        int x4 = 25;
            //        int y4 = 20;
            //        LocatePictureBox(PotionsBagSlots, tabPagePotions, ref x4, ref y4, ItemsManager.GetItemImage(item.Name));
            //    }
            //    else
            //    {
            //        int x5 = 25;
            //        int y5 = 20;
            //        LocatePictureBox(OtherBagSlots, tabPageOther, ref x5, ref y5, ItemsManager.GetItemImage(item.Name));
            //    }

            //}
        }

        /// <summary>
        /// Располагает пикчербокс для предмета и добавляет его 
        /// в заданную коллекцию контролов
        /// </summary>
        /// <param name="bagSlots"></param>
        /// <param name="page"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        //private void LocatePictureBox(List<PictureBox> bagSlots, TabPage page, ref int x, ref int y, Image image)
        //{
        //    PictureBox itemPictureBox = new PictureBox();
        //    itemPictureBox.Size = new Size(48, 48);
        //    if (x >= tabPageAll.Width - 58)
        //    {
        //        x = 25;
        //        y += 49;
        //    }
        //    itemPictureBox.Location = new Point(x, y);
        //    x += 49;
        //    itemPictureBox.BorderStyle = BorderStyle.Fixed3D;
        //    itemPictureBox.Image = image;
        //    //itemPictureBox.BackColor = Color.Red;
        //    bagSlots.Add(itemPictureBox);
        //    page.Controls.Add(itemPictureBox);
        //}


    }


