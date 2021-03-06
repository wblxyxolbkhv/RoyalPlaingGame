﻿namespace StartUpProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playerInventoryControl1 = new VisualPart.UserControls.PlayerInventoryControl();
            this.itemDescriptionControl1 = new VisualPart.UserControls.ItemDescriptionControl();
            this.lootPageControl1 = new VisualPart.UserControls.LootPageControl();
            this.fastAccessControl1 = new VisualPart.UserControls.FastAccessControl();
            this.inventoryControl1 = new VisualPart.UserControls.InventoryControl();
            this.journalControl1 = new VisualPart.UserControls.JournalControl();
            this.activeQuestControl1 = new VisualPart.UserControls.ActiveQuestControl();
            this.skillPanel1 = new VisualPart.UserControls.SkillPanel();
            this.scaleMP = new VisualPart.UserControls.Scale();
            this.scaleHP = new VisualPart.UserControls.Scale();
            this.playerMenu1 = new VisualPart.UserControls.PlayerMenu();
            this.choiceBox1 = new VisualPart.UserControls.ChoiceBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 603);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // playerInventoryControl1
            // 
            this.playerInventoryControl1.Location = new System.Drawing.Point(200, 100);
            this.playerInventoryControl1.Name = "playerInventoryControl1";
            this.playerInventoryControl1.PlayerInventory = null;
            this.playerInventoryControl1.Size = new System.Drawing.Size(600, 300);
            this.playerInventoryControl1.TabIndex = 12;
            // 
            // itemDescriptionControl1
            // 
            this.itemDescriptionControl1.AutoSize = true;
            this.itemDescriptionControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.itemDescriptionControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.itemDescriptionControl1.Item = null;
            this.itemDescriptionControl1.Location = new System.Drawing.Point(712, 453);
            this.itemDescriptionControl1.Name = "itemDescriptionControl1";
            this.itemDescriptionControl1.Size = new System.Drawing.Size(119, 49);
            this.itemDescriptionControl1.TabIndex = 11;
            this.itemDescriptionControl1.Visible = false;
            // 
            // lootPageControl1
            // 
            this.lootPageControl1.AutoScroll = true;
            this.lootPageControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lootPageControl1.IDC = null;
            this.lootPageControl1.Inventory = null;
            this.lootPageControl1.Location = new System.Drawing.Point(860, 453);
            this.lootPageControl1.Name = "lootPageControl1";
            this.lootPageControl1.Size = new System.Drawing.Size(148, 150);
            this.lootPageControl1.TabIndex = 10;
            this.lootPageControl1.Visible = false;
            // 
            // fastAccessControl1
            // 
            this.fastAccessControl1.InventoryControl = null;
            this.fastAccessControl1.JournalControl = null;
            this.fastAccessControl1.Location = new System.Drawing.Point(598, 550);
            this.fastAccessControl1.Name = "fastAccessControl1";
            this.fastAccessControl1.Size = new System.Drawing.Size(216, 53);
            this.fastAccessControl1.TabIndex = 9;
            this.fastAccessControl1.Visible = false;
            // 
            // inventoryControl1
            // 
            this.inventoryControl1.AllBagSlots = null;
            this.inventoryControl1.ArmorBagSlots = null;
            this.inventoryControl1.ItemList = null;
            this.inventoryControl1.Location = new System.Drawing.Point(68, 63);
            this.inventoryControl1.Name = "inventoryControl1";
            this.inventoryControl1.OtherBagSlots = null;
            this.inventoryControl1.PotionsBagSlots = null;
            this.inventoryControl1.Size = new System.Drawing.Size(654, 357);
            this.inventoryControl1.SlotsAmount = 0;
            this.inventoryControl1.TabIndex = 8;
            this.inventoryControl1.Visible = false;
            this.inventoryControl1.WeaponBagSlots = null;
            // 
            // journalControl1
            // 
            this.journalControl1.Journal = null;
            this.journalControl1.Location = new System.Drawing.Point(273, 52);
            this.journalControl1.Name = "journalControl1";
            this.journalControl1.Size = new System.Drawing.Size(639, 420);
            this.journalControl1.TabIndex = 7;
            this.journalControl1.Visible = false;
            // 
            // activeQuestControl1
            // 
            this.activeQuestControl1.ActiveQuest = null;
            this.activeQuestControl1.BackColor = System.Drawing.Color.Transparent;
            this.activeQuestControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("activeQuestControl1.BackgroundImage")));
            this.activeQuestControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.activeQuestControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activeQuestControl1.Location = new System.Drawing.Point(410, 13);
            this.activeQuestControl1.Name = "activeQuestControl1";
            this.activeQuestControl1.Size = new System.Drawing.Size(244, 73);
            this.activeQuestControl1.TabIndex = 6;
            // 
            // skillPanel1
            // 
            this.skillPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skillPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skillPanel1.BackgroundImage")));
            this.skillPanel1.Location = new System.Drawing.Point(0, 561);
            this.skillPanel1.Name = "skillPanel1";
            this.skillPanel1.Size = new System.Drawing.Size(363, 42);
            this.skillPanel1.SpellHotKey1 = null;
            this.skillPanel1.SpellHotKey10 = null;
            this.skillPanel1.SpellHotKey2 = null;
            this.skillPanel1.SpellHotKey3 = null;
            this.skillPanel1.SpellHotKey4 = null;
            this.skillPanel1.SpellHotKey5 = null;
            this.skillPanel1.SpellHotKey6 = null;
            this.skillPanel1.SpellHotKey7 = null;
            this.skillPanel1.SpellHotKey8 = null;
            this.skillPanel1.SpellHotKey9 = null;
            this.skillPanel1.TabIndex = 4;
            // 
            // scaleMP
            // 
            this.scaleMP.BackColor = System.Drawing.Color.Black;
            this.scaleMP.CurrentValue = 100;
            this.scaleMP.Location = new System.Drawing.Point(11, 63);
            this.scaleMP.MaxValue = 100;
            this.scaleMP.Name = "scaleMP";
            this.scaleMP.ScaleColor = System.Drawing.Color.Blue;
            this.scaleMP.Size = new System.Drawing.Size(136, 19);
            this.scaleMP.TabIndex = 3;
            // 
            // scaleHP
            // 
            this.scaleHP.BackColor = System.Drawing.Color.Black;
            this.scaleHP.CurrentValue = 100;
            this.scaleHP.Location = new System.Drawing.Point(12, 38);
            this.scaleHP.MaxValue = 100;
            this.scaleHP.Name = "scaleHP";
            this.scaleHP.ScaleColor = System.Drawing.Color.Green;
            this.scaleHP.Size = new System.Drawing.Size(136, 19);
            this.scaleHP.TabIndex = 2;
            // 
            // playerMenu1
            // 
            this.playerMenu1.Agility = 0;
            this.playerMenu1.Intelegence = 0;
            this.playerMenu1.Location = new System.Drawing.Point(958, 113);
            this.playerMenu1.MaxHP = 1;
            this.playerMenu1.MaxMP = 1;
            this.playerMenu1.Name = "playerMenu1";
            this.playerMenu1.RealAgility = 0;
            this.playerMenu1.RealHP = 0;
            this.playerMenu1.RealIntelegence = 0;
            this.playerMenu1.RealMP = 0;
            this.playerMenu1.RealStrengh = 0;
            this.playerMenu1.Size = new System.Drawing.Size(596, 359);
            this.playerMenu1.Strengh = 0;
            this.playerMenu1.TabIndex = 1;
            this.playerMenu1.Visible = false;
            // 
            // choiceBox1
            // 
            this.choiceBox1.BackColor = System.Drawing.Color.Transparent;
            this.choiceBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("choiceBox1.BackgroundImage")));
            this.choiceBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.choiceBox1.Choice = null;
            this.choiceBox1.Location = new System.Drawing.Point(283, 123);
            this.choiceBox1.Name = "choiceBox1";
            this.choiceBox1.Size = new System.Drawing.Size(548, 153);
            this.choiceBox1.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 603);
            this.Controls.Add(this.choiceBox1);
            this.Controls.Add(this.playerInventoryControl1);
            this.Controls.Add(this.itemDescriptionControl1);
            this.Controls.Add(this.lootPageControl1);
            this.Controls.Add(this.fastAccessControl1);
            this.Controls.Add(this.inventoryControl1);
            this.Controls.Add(this.journalControl1);
            this.Controls.Add(this.activeQuestControl1);
            this.Controls.Add(this.skillPanel1);
            this.Controls.Add(this.scaleMP);
            this.Controls.Add(this.scaleHP);
            this.Controls.Add(this.playerMenu1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoyalPlayGame";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private VisualPart.UserControls.PlayerMenu playerMenu1;
        private VisualPart.UserControls.Scale scaleHP;
        private VisualPart.UserControls.Scale scaleMP;
        private VisualPart.UserControls.SkillPanel skillPanel1;
        private VisualPart.UserControls.ActiveQuestControl activeQuestControl1;
        private VisualPart.UserControls.JournalControl journalControl1;
        private VisualPart.UserControls.InventoryControl inventoryControl1;
        private VisualPart.UserControls.FastAccessControl fastAccessControl1;
        private VisualPart.UserControls.LootPageControl lootPageControl1;
        private VisualPart.UserControls.ItemDescriptionControl itemDescriptionControl1;
        private VisualPart.UserControls.PlayerInventoryControl playerInventoryControl1;
        private VisualPart.UserControls.ChoiceBox choiceBox1;
    }
}

