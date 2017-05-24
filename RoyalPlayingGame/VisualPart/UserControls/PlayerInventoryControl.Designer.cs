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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInventoryControl));
            this.interfaceControl1 = new VisualPart.UserControls.InterfaceControl();
            this.itemDescriptionControl1 = new VisualPart.UserControls.ItemDescriptionControl();
            this.itemMenuControl1 = new VisualPart.UserControls.ItemMenuControl();
            this.SuspendLayout();
            // 
            // interfaceControl1
            // 
            this.interfaceControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("interfaceControl1.BackgroundImage")));
            this.interfaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceControl1.Location = new System.Drawing.Point(0, 0);
            this.interfaceControl1.MinimumSize = new System.Drawing.Size(100, 100);
            this.interfaceControl1.Name = "interfaceControl1";
            this.interfaceControl1.Size = new System.Drawing.Size(415, 425);
            this.interfaceControl1.TabIndex = 2;
            // 
            // itemDescriptionControl1
            // 
            this.itemDescriptionControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemDescriptionControl1.Item = null;
            this.itemDescriptionControl1.Location = new System.Drawing.Point(252, 105);
            this.itemDescriptionControl1.Name = "itemDescriptionControl1";
            this.itemDescriptionControl1.Size = new System.Drawing.Size(121, 54);
            this.itemDescriptionControl1.TabIndex = 4;
            this.itemDescriptionControl1.Visible = false;
            // 
            // itemMenuControl1
            // 
            this.itemMenuControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemMenuControl1.Location = new System.Drawing.Point(226, 179);
            this.itemMenuControl1.Name = "itemMenuControl1";
            this.itemMenuControl1.Size = new System.Drawing.Size(106, 90);
            this.itemMenuControl1.TabIndex = 3;
            // 
            // PlayerInventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemDescriptionControl1);
            this.Controls.Add(this.itemMenuControl1);
            this.Controls.Add(this.interfaceControl1);
            this.Name = "PlayerInventoryControl";
            this.Size = new System.Drawing.Size(415, 425);
            this.ResumeLayout(false);

        }

        #endregion

        private InterfaceControl interfaceControl1;
        private ItemDescriptionControl itemDescriptionControl1;
        private ItemMenuControl itemMenuControl1;
    }
}
