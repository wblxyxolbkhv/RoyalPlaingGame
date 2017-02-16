namespace VisualPart.UserControls
{
    partial class PlayerInventoryControl
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
            this.itemMenuControl1 = new VisualPart.UserControls.ItemMenuControl();
            this.SuspendLayout();
            // 
            // itemMenuControl1
            // 
            this.itemMenuControl1.Location = new System.Drawing.Point(80, 78);
            this.itemMenuControl1.Name = "itemMenuControl1";
            this.itemMenuControl1.Size = new System.Drawing.Size(106, 90);
            this.itemMenuControl1.TabIndex = 0;
            // 
            // PlayerInventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemMenuControl1);
            this.Name = "PlayerInventoryControl";
            this.Size = new System.Drawing.Size(275, 234);
            this.ResumeLayout(false);

        }

        #endregion

        private ItemMenuControl itemMenuControl1;
    }
}
