using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualPart.UserControls;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Units;
using RoyalPlayingGame;

namespace StartUpProject
{
    public class QuestJournalManager
    {

        public Player Player { get; set; }
        public Journal Journal { get { return journal; }  set { journal = value; } }
        public Journal journal; 
        public void OnRefresh()
        {
            Journal.RefreshLabels();
        }

        public void Show()
        {
            Journal.Visible = true;
        }
        public void Hide()
        {
            journal.Visible = false;
        }
    }
}
