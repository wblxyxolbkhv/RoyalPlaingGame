namespace StartUpProject
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
            this.activeQuestControl1 = new VisualPart.UserControls.ActiveQuestControl();
            this.choiceBox1 = new VisualPart.UserControls.ChoiceBox();
            this.skillPanel1 = new VisualPart.UserControls.SkillPanel();
            this.scaleMP = new VisualPart.UserControls.Scale();
            this.scaleHP = new VisualPart.UserControls.Scale();
            this.playerMenu1 = new VisualPart.UserControls.PlayerMenu();
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
            // activeQuestControl1
            // 
            this.activeQuestControl1.ActiveQuest = null;
            this.activeQuestControl1.BackColor = System.Drawing.Color.Transparent;
            this.activeQuestControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.activeQuestControl1.Location = new System.Drawing.Point(410, 13);
            this.activeQuestControl1.Name = "activeQuestControl1";
            this.activeQuestControl1.Size = new System.Drawing.Size(244, 73);
            this.activeQuestControl1.TabIndex = 6;
            // 
            // choiceBox1
            // 
            this.choiceBox1.BackColor = System.Drawing.Color.Transparent;
            this.choiceBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("choiceBox1.BackgroundImage")));
            this.choiceBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.choiceBox1.Choice = null;
            this.choiceBox1.Location = new System.Drawing.Point(283, 79);
            this.choiceBox1.Name = "choiceBox1";
            this.choiceBox1.Size = new System.Drawing.Size(547, 163);
            this.choiceBox1.TabIndex = 5;
            this.choiceBox1.Visible = false;
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
            this.scaleMP.Location = new System.Drawing.Point(12, 38);
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
            this.scaleHP.Location = new System.Drawing.Point(13, 13);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 603);
            this.Controls.Add(this.activeQuestControl1);
            this.Controls.Add(this.choiceBox1);
            this.Controls.Add(this.skillPanel1);
            this.Controls.Add(this.scaleMP);
            this.Controls.Add(this.scaleHP);
            this.Controls.Add(this.playerMenu1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "RoyalPlayGame";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private VisualPart.UserControls.PlayerMenu playerMenu1;
        private VisualPart.UserControls.Scale scaleHP;
        private VisualPart.UserControls.Scale scaleMP;
        private VisualPart.UserControls.SkillPanel skillPanel1;
        private VisualPart.UserControls.ChoiceBox choiceBox1;
        private VisualPart.UserControls.ActiveQuestControl activeQuestControl1;
    }
}

