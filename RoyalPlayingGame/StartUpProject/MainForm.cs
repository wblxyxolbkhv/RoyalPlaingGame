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

            SetLevel(Level);
        }
        

        private void PrintLoadingWindow(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width, pictureBox1.Height);
            e.Graphics.DrawString("Loading...", new Font("Arial", 20), Brushes.White, new PointF(pictureBox1.Width / 2 - 100, pictureBox1.Height / 2));
        }


        public void T_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }


        public void ResetLevel(GameLevel PrevLevel)
        {
            if (PrevLevel != null)
            {

                #region Инициализация меню, событий





                PrevLevel.WorkAreaHeight = pictureBox1.Height;
                PrevLevel.WorkAreaWidth = pictureBox1.Width;
                this.KeyDown -= PrevLevel.OnKeyDownExternal;
                this.KeyDown -= PrevLevel.PlayerMenuManager.OnKeyDownExternal;
                this.KeyUp -= PrevLevel.OnKeyUpExternal;
                pictureBox1.Paint -= PrevLevel.OnPrintAllObjects;
                this.KeyPreview = true;


                pictureBox1.MouseClick -= PrevLevel.OnMouseClick;


                #endregion

            }


            pictureBox1.Paint += PrintLoadingWindow;
        }
        public void SetLevel(GameLevel Level)
        {
            

            Level.PlayerMenuManager.VisualMenu = this.playerMenu1;
            Level.PlayerMenuManager.ScaleHP = this.scaleHP;
            Level.PlayerMenuManager.ScaleMP = this.scaleMP;

            Level.DialogManager.ChoiceBox = choiceBox1;
            Level.ActiveQuestManager.ActiveQuestControl = activeQuestControl1;
            Level.QuestJournalManager.Journal = journalControl1;
            Level.LootPageManager.LootPage = lootPageControl1;
            Level.LootPageManager.ItemDescription = itemDescriptionControl1;
            Level.InventoryManager.PIC = playerInventoryControl1;
            Level.Background = pictureBox1.BackgroundImage;

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


            pictureBox1.Paint -= PrintLoadingWindow;

            playerInventoryControl1.Visible = false;
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
            itemDescriptionControl1.Visible = turn;
            journalControl1.Visible = turn;
            lootPageControl1.Visible = turn;
            skillPanel1.Visible = turn;
            choiceBox1.Visible = turn;
            playerInventoryControl1.Visible = turn;
        }
        
    }
}
