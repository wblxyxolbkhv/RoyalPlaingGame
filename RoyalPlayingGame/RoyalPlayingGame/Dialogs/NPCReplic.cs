﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame.Dialogs
{
    public delegate void QuestHandler(int questID);
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
        public int? GiveQuest { get; set; } = null;
        public int? ReceiveQuest { get; set; } = null;
    }
}
