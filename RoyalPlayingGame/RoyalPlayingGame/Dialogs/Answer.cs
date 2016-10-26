﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Dialogs
{
    /// <summary>
    /// один из ответов игрока в диалоге
    /// </summary>
    public class Answer : Replic
    {
        public Answer()
        {
            PlayerPhrases = new List<string>();
        }
        public NPCReplic NextReplic
        {
            get;
            set;
        }
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
