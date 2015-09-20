namespace RPlayer
{
    partial class FormSettingAv
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
            this.label_volumeAmp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_volumeAmp
            // 
            this.label_volumeAmp.AutoSize = true;
            this.label_volumeAmp.BackColor = System.Drawing.Color.Transparent;
            this.label_volumeAmp.ForeColor = System.Drawing.Color.White;
            this.label_volumeAmp.Location = new System.Drawing.Point(29, 22);
            this.label_volumeAmp.Name = "label_volumeAmp";
            this.label_volumeAmp.Size = new System.Drawing.Size(53, 12);
            this.label_volumeAmp.TabIndex = 0;
            this.label_volumeAmp.Text = "音量放大";
            // 
            // FormAv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(425, 467);
            this.Controls.Add(this.label_volumeAmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_volumeAmp;
    }
}