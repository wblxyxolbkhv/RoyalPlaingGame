using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Quests;

namespace RoyalPlayingGame.Journal
{
    public class JournalNote
    {
        public string Name { get; set; }
        public string Month { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public Quest LinkedQuest { get; set; }
        
    }
}
