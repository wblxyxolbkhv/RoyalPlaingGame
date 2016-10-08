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
            this.playerMenu1 = new VisualPart.UserControls.PlayerMenu();
            this.scale1 = new VisualPart.UserControls.Scale();
            this.scale2 = new VisualPart.UserControls.Scale();
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
            // playerMenu1
            // 
            this.playerMenu1.Location = new System.Drawing.Point(958, 113);
            this.playerMenu1.Name = "playerMenu1";
            this.playerMenu1.Size = new System.Drawing.Size(596, 359);
            this.playerMenu1.TabIndex = 1;
            this.playerMenu1.Visible = false;
            // 
            // scale1
            // 
            this.scale1.BackColor = System.Drawing.Color.Black;
            this.scale1.CurrentValue = 100;
            this.scale1.Location = new System.Drawing.Point(13, 13);
            this.scale1.MaxValue = 100;
            this.scale1.Name = "scale1";
            this.scale1.ScaleColor = System.Drawing.Color.Red;
            this.scale1.Size = new System.Drawing.Size(136, 19);
            this.scale1.TabIndex = 2;
            // 
            // scale2
            // 
            this.scale2.BackColor = System.Drawing.Color.Black;
            this.scale2.CurrentValue = 100;
            this.scale2.Location = new System.Drawing.Point(12, 38);
            this.scale2.MaxValue = 100;
            this.scale2.Name = "scale2";
            this.scale2.ScaleColor = System.Drawing.Color.Blue;
            this.scale2.Size = new System.Drawing.Size(136, 19);
            this.scale2.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 603);
            this.Controls.Add(this.scale2);
            this.Controls.Add(this.scale1);
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
        private VisualPart.UserControls.Scale scale1;
        private VisualPart.UserControls.Scale scale2;
    }
}

