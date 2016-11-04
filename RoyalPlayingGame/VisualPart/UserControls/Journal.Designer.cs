namespace VisualPart.UserControls
{
    partial class Journal
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Quests = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.labelStageDescription = new System.Windows.Forms.Label();
            this.labelStageObjective = new System.Windows.Forms.Label();
            this.labelStageName = new System.Windows.Forms.Label();
            this.labelQuestDescription = new System.Windows.Forms.Label();
            this.labelQuestName = new System.Windows.Forms.Label();
            this.JournalNotes = new System.Windows.Forms.TabPage();
            this.listBoxQuests = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.Quests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.Quests);
            this.tabControl1.Controls.Add(this.JournalNotes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // Quests
            // 
            this.Quests.Controls.Add(this.splitContainer1);
            this.Quests.Location = new System.Drawing.Point(4, 4);
            this.Quests.Name = "Quests";
            this.Quests.Padding = new System.Windows.Forms.Padding(3);
            this.Quests.Size = new System.Drawing.Size(631, 394);
            this.Quests.TabIndex = 0;
            this.Quests.Text = "Quests";
            this.Quests.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(625, 388);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBoxQuests);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.vScrollBar1);
            this.splitContainer2.Panel2.Controls.Add(this.labelStageDescription);
            this.splitContainer2.Panel2.Controls.Add(this.labelStageObjective);
            this.splitContainer2.Panel2.Controls.Add(this.labelStageName);
            this.splitContainer2.Panel2.Controls.Add(this.labelQuestDescription);
            this.splitContainer2.Panel2.Controls.Add(this.labelQuestName);
            this.splitContainer2.Size = new System.Drawing.Size(289, 388);
            this.splitContainer2.SplitterDistance = 162;
            this.splitContainer2.TabIndex = 0;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(272, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 222);
            this.vScrollBar1.TabIndex = 5;
            // 
            // labelStageDescription
            // 
            this.labelStageDescription.AutoSize = true;
            this.labelStageDescription.Location = new System.Drawing.Point(16, 155);
            this.labelStageDescription.Name = "labelStageDescription";
            this.labelStageDescription.Size = new System.Drawing.Size(88, 13);
            this.labelStageDescription.TabIndex = 4;
            this.labelStageDescription.Text = "StageDescription";
            // 
            // labelStageObjective
            // 
            this.labelStageObjective.AutoSize = true;
            this.labelStageObjective.Location = new System.Drawing.Point(26, 124);
            this.labelStageObjective.Name = "labelStageObjective";
            this.labelStageObjective.Size = new System.Drawing.Size(80, 13);
            this.labelStageObjective.TabIndex = 3;
            this.labelStageObjective.Text = "StageObjective";
            // 
            // labelStageName
            // 
            this.labelStageName.AutoSize = true;
            this.labelStageName.Location = new System.Drawing.Point(16, 102);
            this.labelStageName.Name = "labelStageName";
            this.labelStageName.Size = new System.Drawing.Size(63, 13);
            this.labelStageName.TabIndex = 2;
            this.labelStageName.Text = "StageName";
            // 
            // labelQuestDescription
            // 
            this.labelQuestDescription.AutoSize = true;
            this.labelQuestDescription.Location = new System.Drawing.Point(26, 33);
            this.labelQuestDescription.Name = "labelQuestDescription";
            this.labelQuestDescription.Size = new System.Drawing.Size(88, 13);
            this.labelQuestDescription.TabIndex = 1;
            this.labelQuestDescription.Text = "QuestDescription";
            // 
            // labelQuestName
            // 
            this.labelQuestName.AutoSize = true;
            this.labelQuestName.Location = new System.Drawing.Point(16, 11);
            this.labelQuestName.Name = "labelQuestName";
            this.labelQuestName.Size = new System.Drawing.Size(63, 13);
            this.labelQuestName.TabIndex = 0;
            this.labelQuestName.Text = "QuestName";
            // 
            // JournalNotes
            // 
            this.JournalNotes.Location = new System.Drawing.Point(4, 4);
            this.JournalNotes.Name = "JournalNotes";
            this.JournalNotes.Padding = new System.Windows.Forms.Padding(3);
            this.JournalNotes.Size = new System.Drawing.Size(631, 394);
            this.JournalNotes.TabIndex = 1;
            this.JournalNotes.Text = "Notes";
            this.JournalNotes.UseVisualStyleBackColor = true;
            // 
            // listBoxQuests
            // 
            this.listBoxQuests.FormattingEnabled = true;
            this.listBoxQuests.Location = new System.Drawing.Point(19, 13);
            this.listBoxQuests.Name = "listBoxQuests";
            this.listBoxQuests.Size = new System.Drawing.Size(255, 134);
            this.listBoxQuests.TabIndex = 0;
            // 
            // Journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Journal";
            this.Size = new System.Drawing.Size(639, 420);
            this.tabControl1.ResumeLayout(false);
            this.Quests.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Quests;
        private System.Windows.Forms.TabPage JournalNotes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelQuestName;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label labelStageDescription;
        private System.Windows.Forms.Label labelStageObjective;
        private System.Windows.Forms.Label labelStageName;
        private System.Windows.Forms.Label labelQuestDescription;
        private System.Windows.Forms.ListBox listBoxQuests;
    }
}
