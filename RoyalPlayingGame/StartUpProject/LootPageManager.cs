using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualPart.UserControls;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Units;
using RoyalPlayingGame;
using RoyalPlayingGame.Items;
namespace StartUpProject
{
    public class LootPageManager
    {
        public LootPageManager()
        {
            
        }
        public Player Player { get; set; }
        public LootPageControl LootPage { get; set; }
        public ItemDescriptionControl ItemDescription { get; set; }

        public void Show(List<Item> loot)
        {
            LootPage.IDC = ItemDescription;
            LootPage.Inventory = Player.Inventory;
            LootPage.Update(loot);
            LootPage.Visible = true;
        }
        
    }
}
