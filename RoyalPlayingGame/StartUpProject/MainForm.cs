using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplePhysicalEngine;
using SimplePhysicalEngine.NonPhysicalComponents;

namespace StartUpProject
{
    public partial class MainForm : Form
    {
        public MainForm(GameLevel Level)
        {
            InitializeComponent();

            Level.PlayerMenuManager.VisualMenu = this.playerMenu1;
            Level.PlayerMenuManager.ScaleHP = this.scaleHP;
            Level.PlayerMenuManager.ScaleMP = this.scaleMP;
            
            Level.DialogManager.ChoiceBox = choiceBox1;
            Level.InventoryManager.InventoryControl = inventoryControl1;
            Level.ActiveQuestManager.ActiveQuestControl = activeQuestControl1;
            Level.QuestJournalManager.Journal = journalControl1;
            Level.LootPageManager.LootPage = lootPageControl1;
            Level.LootPageManager.ItemDescription = itemDescriptionControl1;
            Level.InventoryManager.PIC = playerInventoryControl1;
           
            #region Инициализация меню, событий





            Level.WorkAreaHeight = pictureBox1.Height;
            Level.WorkAreaWidth = pictureBox1.Width;
            this.KeyDown += Level.OnKeyDownExternal;
            this.KeyDown += Level.PlayerMenuManager.OnKeyDownExternal;
            this.KeyUp += Level.OnKeyUpExternal;
            pictureBox1.Paint += Level.OnPrintAllObjects;
            this.KeyPreview = true;


            pictureBox1.MouseClick += Level.OnMouseClick;


            #endregion


            playerInventoryControl1.Visible = false;
        }


        public void T_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
        public void SetControlVisible(bool turn)
        {
            if (turn)
            {
                activeQuestControl1.Visible = turn;
                skillPanel1.Visible = turn;
                scaleHP.Visible = turn;
                scaleMP.Visible = turn;
                return;
            }
            scaleHP.Visible = turn;
            scaleMP.Visible = turn;
            activeQuestControl1.Visible = turn;
            fastAccessControl1.Visible = turn;
            inventoryControl1.Visible = turn;
            itemDescriptionControl1.Visible = turn;
            journalControl1.Visible = turn;
            lootPageControl1.Visible = turn;
            skillPanel1.Visible = turn;
            choiceBox1.Visible = turn;
        }

        private void playerInventoryControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
