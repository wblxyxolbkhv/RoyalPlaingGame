using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Назначение: Ответ игрока в диалоге
 * Автор: Никитенко А.В.
 */

namespace RoyalPlayingGame.Dialogs
{
    /// <summary>
    /// один из ответов игрока в диалоге
    /// </summary>
    public class Answer : Replic
    {
        public Answer() : base()
        {
            PlayerPhrases = new List<string>();
        }
        public NPCReplic NextReplic
        {
            get;
            set;
        }
        /// <summary>
        /// набор фраз, говоримые подряд персонажем
        /// </summary>
        public List<string> PlayerPhrases
        {
            get;
        }
        public override Replic GetNextReplic()
        {
            return NextReplic;
        }
    }
}
