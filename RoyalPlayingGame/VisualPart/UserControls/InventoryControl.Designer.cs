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
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(579, 357);
            this.splitContainer1.SplitterDistance = 311;
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
            this.tabControlInventory.Size = new System.Drawing.Size(311, 357);
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
            this.tabPageAll.Size = new System.Drawing.Size(300, 331);
            this.tabPageAll.TabIndex = 0;
            this.tabPageAll.Text = "All";
            // 
            // tabPageWeapon
            // 
            this.tabPageWeapon.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeapon.Name = "tabPageWeapon";
            this.tabPageWeapon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeapon.Size = new System.Drawing.Size(300, 331);
            this.tabPageWeapon.TabIndex = 1;
            this.tabPageWeapon.Text = "Weapon";
            this.tabPageWeapon.UseVisualStyleBackColor = true;
            // 
            // tabPageArmor
            // 
            this.tabPageArmor.Location = new System.Drawing.Point(4, 22);
            this.tabPageArmor.Name = "tabPageArmor";
            this.tabPageArmor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArmor.Size = new System.Drawing.Size(300, 331);
            this.tabPageArmor.TabIndex = 2;
            this.tabPageArmor.Text = "Armor";
            this.tabPageArmor.UseVisualStyleBackColor = true;
            // 
            // tabPagePotions
            // 
            this.tabPagePotions.Location = new System.Drawing.Point(4, 22);
            this.tabPagePotions.Name = "tabPagePotions";
            this.tabPagePotions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePotions.Size = new System.Drawing.Size(300, 331);
            this.tabPagePotions.TabIndex = 3;
            this.tabPagePotions.Text = "Potions";
            this.tabPagePotions.UseVisualStyleBackColor = true;
            // 
            // tabPageOther
            // 
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(303, 331);
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
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox9);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox8);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxCharacter);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox7);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox6);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox5);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox4);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(264, 357);
            this.splitContainer2.SplitterDistance = 205;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureBoxCharacter
            // 
            this.pictureBoxCharacter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxCharacter.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCharacter.Name = "pictureBoxCharacter";
            this.pictureBoxCharacter.Size = new System.Drawing.Size(205, 303);
            this.pictureBoxCharacter.TabIndex = 0;
            this.pictureBoxCharacter.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox6.Location = new System.Drawing.Point(2, 256);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(48, 48);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox5.Location = new System.Drawing.Point(2, 206);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 48);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox4.Location = new System.Drawing.Point(2, 156);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox3.Location = new System.Drawing.Point(2, 106);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox2.Location = new System.Drawing.Point(2, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(2, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox7.Location = new System.Drawing.Point(2, 306);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(48, 48);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox8.Location = new System.Drawing.Point(50, 306);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(48, 48);
            this.pictureBox8.TabIndex = 6;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox9.Location = new System.Drawing.Point(104, 306);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(48, 48);
            this.pictureBox9.TabIndex = 7;
            this.pictureBox9.TabStop = false;
            // 
            // InventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "InventoryControl";
            this.Size = new System.Drawing.Size(579, 357);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlInventory.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}
