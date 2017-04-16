using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
using VisualPart.UserControls;
using RoyalPlayingGame.Items;

namespace StartUpProject
{
    /// <summary>
    /// Обеспечивает взаимодействие между 
    /// инвентарем игрока и соотв. контролом
    /// </summary>
    public class InventoryManager
    {
        //public InventoryManager()
        //{
            
        //}

        public Player Player { get; set; }
        //public InventoryControl InventoryControl
        //{
        //    get
        //    { return inventControl; }
        //    set
        //    {
        //        inventControl = value;
        //        inventControl.ItemList = Player.Inventory.GetItemList();
        //        //inventControl.SlotsAmount = Player.Inventory.Slots;
        //    }
        //}
        public PlayerInventoryControl PIC
        {
            get
            {
                return pic;
            }
            set
            {
                pic = value;
                pic.PlayerInventory = Player.Inventory;
                pic.PlaceButtons(Player.Inventory.Slots);
            }
        }
        //InventoryControl inventControl;
        PlayerInventoryControl pic;

        //public void OnBagOpen()
        //{

        //}
        
        //public void OnRefresh()
        //{
        //    //InventoryControl.SlotsAmount = Player.Inventory.Slots;
        //    //InventoryControl.ItemList = Player.Inventory.GetItemList();
        //}
        public void ChangeVisibility()
        {
            //InventoryControl.PlacePictureBoxes();
            //InventoryControl.Refresh();
            //if (InventoryControl.Visible)
            //{
            //    InventoryControl.Visible = false;
            //}
            //else InventoryControl.Visible = true;
            PIC.Refresh();
            if (PIC.Visible)
            {
                PIC.Visible = false;
            }
            else PIC.Visible = true;
        }
        //public void Hide()
        //{
        //    InventoryControl.Visible = false;
        //}
        //public void Show()
        //{
        //    InventoryControl.PlacePictureBoxes();
        //    InventoryControl.Refresh();
        //    InventoryControl.Visible = true;
        //}
        
    }
}
