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

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }
        private void RefreshLables()
        {
            labelQuestName.Text = ActiveQuest.QuestName;

            label1.Text = ActiveQuest.CurrentQuestStage.QuestStageName;

            if (ActiveQuest.CurrentQuestStage is KillUnitStage)
            {
                label2.Text = string.Format("Убито {0}/{1}");
            }
        }

    }
}
