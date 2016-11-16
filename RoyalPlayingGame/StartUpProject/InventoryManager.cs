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
           
        }
        public Player Player { get; set; }
        public InventoryControl InventoryControl { get; set; }
    }
}
