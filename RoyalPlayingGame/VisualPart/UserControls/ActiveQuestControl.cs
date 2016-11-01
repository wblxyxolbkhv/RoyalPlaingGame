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

            if (ActiveQuest.CurrentQuestStage is KillUnitStage)
            {
                KillUnitStage kus = ActiveQuest.CurrentQuestStage as KillUnitStage;
                KillUnitStageGroup k = kus.GetCurrentTarget();
                label2.Text = string.Format("Убито минотавров {0}/{1}", k.CurrentAmount, k.RequiredAmount);
            } 
            else if (ActiveQuest.CurrentQuestStage is ToPointStage)
            {
                ToPointStage kus = ActiveQuest.CurrentQuestStage as ToPointStage;
                label2.Text = string.Format("Дойти до места 0/1");
            }
        }

    }
}
