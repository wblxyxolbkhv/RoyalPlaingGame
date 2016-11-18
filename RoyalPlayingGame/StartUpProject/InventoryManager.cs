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
        public InventoryManager()
        {
            //InventoryControl.Visible = false;
        }
        public Player Player { get; set; }
        public InventoryControl InventoryControl
        {
            get
            { return inventControl; }
            set
            {
                inventControl = value;
                inventControl.ItemList = Player.Inventory.GetItemList();
                inventControl.SlotsAmount = Player.Inventory.Slots;
            }
        }

        InventoryControl inventControl;
        public void OnBagOpen()
        {

        }
        public void OnRefresh()
        {
            //InventoryControl.SlotsAmount = Player.Inventory.Slots;
            //InventoryControl.ItemList = Player.Inventory.GetItemList();
        }
        public void Show()
        {
            InventoryControl.PlacePictureBoxes();
            InventoryControl.Refresh();
            InventoryControl.Visible = true;
        }
        public void Hide()
        {
            InventoryControl.Visible = false;
        }
    }
}
