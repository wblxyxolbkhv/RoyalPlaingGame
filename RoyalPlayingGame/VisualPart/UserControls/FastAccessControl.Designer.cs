namespace VisualPart.UserControls
{
    partial class FastAccessControl
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
            this.buttonJournal = new System.Windows.Forms.Button();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonJournal
            // 
            this.buttonJournal.Location = new System.Drawing.Point(0, 0);
            this.buttonJournal.Name = "buttonJournal";
            this.buttonJournal.Size = new System.Drawing.Size(50, 50);
            this.buttonJournal.TabIndex = 0;
            this.buttonJournal.Text = "Journal (J)";
            this.buttonJournal.UseVisualStyleBackColor = true;
            this.buttonJournal.Click += new System.EventHandler(this.buttonJournal_Click);
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(52, 0);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(50, 50);
            this.buttonInventory.TabIndex = 1;
            this.buttonInventory.Text = "Inventory (I)";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(104, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FastAccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonInventory);
            this.Controls.Add(this.buttonJournal);
            this.Name = "FastAccessControl";
            this.Size = new System.Drawing.Size(215, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonJournal;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Button button3;
    }
}
