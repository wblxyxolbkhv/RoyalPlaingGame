using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Dialogs
{
    /// <summary>
    /// реплика NPC
    /// </summary>
    public class NPCReplic : Replic
    {
        public NPCReplic()
        {
            Phrases = new List<string>();
        }
        public List<string> Phrases
        {
            get;
        }
        public PlayerChoice NextChoice
        {
            get;set;
        }
        public override Replic GetNextReplic()
        {
            return NextChoice;
        }
    }
}
