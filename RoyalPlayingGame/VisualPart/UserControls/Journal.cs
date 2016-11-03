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
    public partial class Journal : UserControl
    {
        public Journal()
        {
            InitializeComponent();
        }
        
      public List<Quest> QuestList { get; set; }
      public void RefreshLabels()
        {
            if (QuestList != null)
            {
                labelQuestName.Text = QuestList[0].Name;
                labelQuestDescription.Text = QuestList[0].Description;
                labelStageName.Text = QuestList[0].CurrentQuestStage.Name;
                labelStageDescription.Text = QuestList[0].CurrentQuestStage.Description;
            }
            else
            {
                return;
            }
            if (QuestList[0].CurrentQuestStage is KillUnitStage)
            {
                KillUnitStage kus = QuestList[0].CurrentQuestStage as KillUnitStage;
                KillUnitStageGroup k = kus.GetCurrentTarget();
                labelStageObjective.Text = string.Format("{0} {1}/{2}", k.Objective, k.CurrentAmount, k.RequiredAmount);
            }
            else if (QuestList[0].CurrentQuestStage is ToPointStage)
            {
                ToPointStage tps = QuestList[0].CurrentQuestStage as ToPointStage;
                ToPointStageGroup t = tps.GetCurrentPoint();
                labelStageObjective.Text = string.Format("{0} 0/1", t.Objective);
            }
        }
        
    }
}
