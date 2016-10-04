namespace VisualPart.UserControls
{
    partial class PlayerMenu
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
            this.scale1 = new VisualPart.UserControls.Scale();
            this.scale2 = new VisualPart.UserControls.Scale();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStrength = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelIntellegence = new System.Windows.Forms.Label();
            this.labelAgility = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scale1
            // 
            this.scale1.BackColor = System.Drawing.Color.Black;
            this.scale1.CurrentValue = 100;
            this.scale1.Location = new System.Drawing.Point(41, 41);
            this.scale1.MaxValue = 100;
            this.scale1.Name = "scale1";
            this.scale1.ScaleColor = System.Drawing.Color.Red;
            this.scale1.Size = new System.Drawing.Size(136, 19);
            this.scale1.TabIndex = 0;
            // 
            // scale2
            // 
            this.scale2.BackColor = System.Drawing.Color.Black;
            this.scale2.CurrentValue = 100;
            this.scale2.Location = new System.Drawing.Point(41, 66);
            this.scale2.MaxValue = 100;
            this.scale2.Name = "scale2";
            this.scale2.ScaleColor = System.Drawing.Color.Red;
            this.scale2.Size = new System.Drawing.Size(136, 19);
            this.scale2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(48, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Характеристики";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(38, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сила";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(38, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ловкость";
            // 
            // labelStrength
            // 
            this.labelStrength.AutoSize = true;
            this.labelStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStrength.Location = new System.Drawing.Point(164, 112);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(0, 17);
            this.labelStrength.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(38, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Интеллект";
            // 
            // labelIntellegence
            // 
            this.labelIntellegence.AutoSize = true;
            this.labelIntellegence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIntellegence.Location = new System.Drawing.Point(164, 157);
            this.labelIntellegence.Name = "labelIntellegence";
            this.labelIntellegence.Size = new System.Drawing.Size(0, 17);
            this.labelIntellegence.TabIndex = 7;
            // 
            // labelAgility
            // 
            this.labelAgility.AutoSize = true;
            this.labelAgility.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAgility.Location = new System.Drawing.Point(164, 129);
            this.labelAgility.Name = "labelAgility";
            this.labelAgility.Size = new System.Drawing.Size(0, 17);
            this.labelAgility.TabIndex = 8;
            // 
            // PlayerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelAgility);
            this.Controls.Add(this.labelIntellegence);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStrength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scale2);
            this.Controls.Add(this.scale1);
            this.Name = "PlayerMenu";
            this.Size = new System.Drawing.Size(596, 359);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scale scale1;
        private Scale scale2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStrength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelIntellegence;
        private System.Windows.Forms.Label labelAgility;
    }
}
