using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoyalPlayingGame.Quests;
using RoyalPlayingGame.Quests.QuestStages;


namespace VisualPart.UserControls
{
    public partial class ActiveQuestControl : UserControl
    {
        public ActiveQuestControl()
        {
            InitializeComponent();

            BackColor = Color.Transparent;

        }



        public Quest ActiveQuest { get; set; }
        
        public void RefreshLables()
        {
            if (ActiveQuest != null)
            {
                labelQuestName.Text = ActiveQuest.Name;
                label1.Text = ActiveQuest.CurrentQuestStage.Name;
            }
            else
            {
                labelQuestName.Text = "";
                label1.Text = "";
                label2.Text = "";
                return;
            }

            if (ActiveQuest.CurrentQuestStage.IsCompleted)
            {
                label2.Text = string.Format("Задание выполнено");
                return;
            }
            if (ActiveQuest.CurrentQuestStage is KillUnitStage)
            {
                KillUnitStage kus = ActiveQuest.CurrentQuestStage as KillUnitStage;
                KillUnitStageGroup k = kus.GetCurrentTarget();
                label2.Text = string.Format("{0} {1}/{2}", k.Objective, k.CurrentAmount, k.RequiredAmount);
            } 
            else if (ActiveQuest.CurrentQuestStage is ToPointStage)
            {
                ToPointStage tps = ActiveQuest.CurrentQuestStage as ToPointStage;
                ToPointStageGroup t = tps.GetCurrentPoint();
                label2.Text = string.Format("{0} 0/1", t.Objective);
            }
        }

    }
}
