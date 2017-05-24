namespace VisualPart.UserControls
{
    partial class InventoryInterface
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryInterface));
            this.interfaceControl1 = new VisualPart.UserControls.InterfaceControl();
            this.tabControl1 = new VisualPart.UserControls.TabControl();
            this.SuspendLayout();
            // 
            // interfaceControl1
            // 
            this.interfaceControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("interfaceControl1.BackgroundImage")));
            this.interfaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceControl1.Location = new System.Drawing.Point(0, 0);
            this.interfaceControl1.MinimumSize = new System.Drawing.Size(100, 100);
            this.interfaceControl1.Name = "interfaceControl1";
            this.interfaceControl1.Size = new System.Drawing.Size(563, 370);
            this.interfaceControl1.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabControl1.BackgroundImage")));
            this.tabControl1.Location = new System.Drawing.Point(31, 30);
            this.tabControl1.MinimumSize = new System.Drawing.Size(268, 169);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(502, 309);
            this.tabControl1.TabIndex = 14;
            // 
            // InventoryInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.interfaceControl1);
            this.Name = "InventoryInterface";
            this.Size = new System.Drawing.Size(563, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private InterfaceControl interfaceControl1;
        private TabControl tabControl1;
    }
}
