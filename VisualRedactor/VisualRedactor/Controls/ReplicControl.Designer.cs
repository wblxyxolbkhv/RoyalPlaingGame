namespace VisualRedactor.Controls
{
    partial class ReplicControl
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
            this.groupBoxReplic = new System.Windows.Forms.GroupBox();
            this.richTextBoxReplic = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.pictureBoxPrev = new System.Windows.Forms.PictureBox();
            this.groupBoxReplic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrev)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxReplic
            // 
            this.groupBoxReplic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxReplic.Controls.Add(this.pictureBoxPrev);
            this.groupBoxReplic.Controls.Add(this.pictureBoxNext);
            this.groupBoxReplic.Controls.Add(this.label3);
            this.groupBoxReplic.Controls.Add(this.textBoxDuration);
            this.groupBoxReplic.Controls.Add(this.label2);
            this.groupBoxReplic.Controls.Add(this.textBoxNumber);
            this.groupBoxReplic.Controls.Add(this.label1);
            this.groupBoxReplic.Controls.Add(this.richTextBoxReplic);
            this.groupBoxReplic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReplic.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReplic.Name = "groupBoxReplic";
            this.groupBoxReplic.Size = new System.Drawing.Size(165, 156);
            this.groupBoxReplic.TabIndex = 0;
            this.groupBoxReplic.TabStop = false;
            // 
            // richTextBoxReplic
            // 
            this.richTextBoxReplic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxReplic.Location = new System.Drawing.Point(56, 62);
            this.richTextBoxReplic.Name = "richTextBoxReplic";
            this.richTextBoxReplic.Size = new System.Drawing.Size(99, 87);
            this.richTextBoxReplic.TabIndex = 0;
            this.richTextBoxReplic.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(56, 13);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(45, 20);
            this.textBoxNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duration";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(56, 36);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(45, 20);
            this.textBoxDuration.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Text";
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNext.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBoxNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNext.Location = new System.Drawing.Point(153, 0);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(12, 12);
            this.pictureBoxNext.TabIndex = 8;
            this.pictureBoxNext.TabStop = false;
            // 
            // pictureBoxPrev
            // 
            this.pictureBoxPrev.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBoxPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPrev.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPrev.Name = "pictureBoxPrev";
            this.pictureBoxPrev.Size = new System.Drawing.Size(12, 12);
            this.pictureBoxPrev.TabIndex = 9;
            this.pictureBoxPrev.TabStop = false;
            // 
            // ReplicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBoxReplic);
            this.Name = "ReplicControl";
            this.Size = new System.Drawing.Size(165, 156);
            this.groupBoxReplic.ResumeLayout(false);
            this.groupBoxReplic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReplic;
        private System.Windows.Forms.RichTextBox richTextBoxReplic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxPrev;
        private System.Windows.Forms.PictureBox pictureBoxNext;
    }
}
