using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Dialogs
{
    public abstract class Replic
    {
        public string Number
        {
            get;set;
        }
        public string Next
        {
            get; set;
        }
        public int Duration
        {
            get; set;
        } = 1000;
        public int CurrentDuration
        {
            get; set;
        } = 0;
        public int? GiveQuest { get; set; } = null;
        public int? ReceiveQuest { get; set; } = null;
        public abstract Replic GetNextReplic();
    }
}
