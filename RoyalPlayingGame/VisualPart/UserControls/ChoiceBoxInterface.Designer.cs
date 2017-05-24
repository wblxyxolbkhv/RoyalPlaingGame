namespace VisualPart.UserControls
{
    partial class ChoiceBoxInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceBoxInterface));
            this.interfaceControl1 = new VisualPart.UserControls.InterfaceControl();
            this.advancedLabel1 = new VisualPart.UserControls.AdvancedLabel();
            this.advancedLabel2 = new VisualPart.UserControls.AdvancedLabel();
            this.advancedLabel3 = new VisualPart.UserControls.AdvancedLabel();
            this.SuspendLayout();
            // 
            // interfaceControl1
            // 
            this.interfaceControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("interfaceControl1.BackgroundImage")));
            this.interfaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceControl1.Location = new System.Drawing.Point(0, 0);
            this.interfaceControl1.MinimumSize = new System.Drawing.Size(100, 100);
            this.interfaceControl1.Name = "interfaceControl1";
            this.interfaceControl1.Size = new System.Drawing.Size(466, 132);
            this.interfaceControl1.TabIndex = 0;
            // 
            // advancedLabel1
            // 
            this.advancedLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.advancedLabel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("advancedLabel1.BackgroundImage")));
            this.advancedLabel1.LabelText = "label1";
            this.advancedLabel1.Location = new System.Drawing.Point(28, 25);
            this.advancedLabel1.Name = "advancedLabel1";
            this.advancedLabel1.Size = new System.Drawing.Size(410, 29);
            this.advancedLabel1.TabIndex = 1;
            // 
            // advancedLabel2
            // 
            this.advancedLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedLabel2.BackColor = System.Drawing.Color.Transparent;
            this.advancedLabel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("advancedLabel2.BackgroundImage")));
            this.advancedLabel2.LabelText = "label1";
            this.advancedLabel2.Location = new System.Drawing.Point(28, 54);
            this.advancedLabel2.Name = "advancedLabel2";
            this.advancedLabel2.Size = new System.Drawing.Size(410, 29);
            this.advancedLabel2.TabIndex = 2;
            // 
            // advancedLabel3
            // 
            this.advancedLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedLabel3.BackColor = System.Drawing.Color.Transparent;
            this.advancedLabel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("advancedLabel3.BackgroundImage")));
            this.advancedLabel3.LabelText = "label1";
            this.advancedLabel3.Location = new System.Drawing.Point(28, 83);
            this.advancedLabel3.Name = "advancedLabel3";
            this.advancedLabel3.Size = new System.Drawing.Size(410, 29);
            this.advancedLabel3.TabIndex = 3;
            // 
            // ChoiceBoxInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advancedLabel3);
            this.Controls.Add(this.advancedLabel2);
            this.Controls.Add(this.advancedLabel1);
            this.Controls.Add(this.interfaceControl1);
            this.Name = "ChoiceBoxInterface";
            this.Size = new System.Drawing.Size(466, 132);
            this.ResumeLayout(false);

        }

        #endregion

        private InterfaceControl interfaceControl1;
        private AdvancedLabel advancedLabel1;
        private AdvancedLabel advancedLabel2;
        private AdvancedLabel advancedLabel3;
    }
}
