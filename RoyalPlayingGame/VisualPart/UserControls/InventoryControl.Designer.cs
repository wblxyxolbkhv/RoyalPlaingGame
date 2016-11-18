namespace VisualPart.UserControls
{
    partial class InventoryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlInventory = new System.Windows.Forms.TabControl();
            this.tabPageAll = new System.Windows.Forms.TabPage();
            this.tabPageWeapon = new System.Windows.Forms.TabPage();
            this.tabPageArmor = new System.Windows.Forms.TabPage();
            this.tabPagePotions = new System.Windows.Forms.TabPage();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxCharacter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlInventory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(654, 357);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControlInventory
            // 
            this.tabControlInventory.Controls.Add(this.tabPageAll);
            this.tabControlInventory.Controls.Add(this.tabPageWeapon);
            this.tabControlInventory.Controls.Add(this.tabPageArmor);
            this.tabControlInventory.Controls.Add(this.tabPagePotions);
            this.tabControlInventory.Controls.Add(this.tabPageOther);
            this.tabControlInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInventory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControlInventory.Location = new System.Drawing.Point(0, 0);
            this.tabControlInventory.Name = "tabControlInventory";
            this.tabControlInventory.SelectedIndex = 0;
            this.tabControlInventory.Size = new System.Drawing.Size(307, 357);
            this.tabControlInventory.TabIndex = 1;
            // 
            // tabPageAll
            // 
            this.tabPageAll.BackColor = System.Drawing.Color.Transparent;
            this.tabPageAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPageAll.BackgroundImage")));
            this.tabPageAll.ImageKey = "(отсутствует)";
            this.tabPageAll.Location = new System.Drawing.Point(4, 22);
            this.tabPageAll.Name = "tabPageAll";
            this.tabPageAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAll.Size = new System.Drawing.Size(299, 331);
            this.tabPageAll.TabIndex = 0;
            this.tabPageAll.Text = "All";
            // 
            // tabPageWeapon
            // 
            this.tabPageWeapon.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeapon.Name = "tabPageWeapon";
            this.tabPageWeapon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeapon.Size = new System.Drawing.Size(299, 331);
            this.tabPageWeapon.TabIndex = 1;
            this.tabPageWeapon.Text = "Weapon";
            this.tabPageWeapon.UseVisualStyleBackColor = true;
            // 
            // tabPageArmor
            // 
            this.tabPageArmor.Location = new System.Drawing.Point(4, 22);
            this.tabPageArmor.Name = "tabPageArmor";
            this.tabPageArmor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArmor.Size = new System.Drawing.Size(299, 331);
            this.tabPageArmor.TabIndex = 2;
            this.tabPageArmor.Text = "Armor";
            this.tabPageArmor.UseVisualStyleBackColor = true;
            // 
            // tabPagePotions
            // 
            this.tabPagePotions.Location = new System.Drawing.Point(4, 22);
            this.tabPagePotions.Name = "tabPagePotions";
            this.tabPagePotions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePotions.Size = new System.Drawing.Size(299, 331);
            this.tabPagePotions.TabIndex = 3;
            this.tabPagePotions.Text = "Potions";
            this.tabPagePotions.UseVisualStyleBackColor = true;
            // 
            // tabPageOther
            // 
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(299, 331);
            this.tabPageOther.TabIndex = 4;
            this.tabPageOther.Text = "Other";
            this.tabPageOther.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxCharacter);
            this.splitContainer2.Size = new System.Drawing.Size(343, 357);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureBoxCharacter
            // 
            this.pictureBoxCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCharacter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCharacter.Name = "pictureBoxCharacter";
            this.pictureBoxCharacter.Size = new System.Drawing.Size(246, 357);
            this.pictureBoxCharacter.TabIndex = 0;
            this.pictureBoxCharacter.TabStop = false;
            // 
            // InventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "InventoryControl";
            this.Size = new System.Drawing.Size(654, 357);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlInventory.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlInventory;
        private System.Windows.Forms.TabPage tabPageAll;
        private System.Windows.Forms.TabPage tabPageWeapon;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBoxCharacter;
        private System.Windows.Forms.TabPage tabPageArmor;
        private System.Windows.Forms.TabPage tabPagePotions;
        private System.Windows.Forms.TabPage tabPageOther;
    }
}
