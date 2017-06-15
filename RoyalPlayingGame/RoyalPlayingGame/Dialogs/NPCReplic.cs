using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Назначение: Реплика NPC
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame.Dialogs
{
    public delegate void QuestHandler(int questID);
    /// <summary>
    /// реплика NPC
    /// </summary>
    public class NPCReplic : Replic
    {
        public NPCReplic() : base()
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
