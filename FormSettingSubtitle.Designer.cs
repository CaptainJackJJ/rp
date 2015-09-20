namespace RPlayer
{
    partial class FormSettingSubtitle
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
            this.label_fontType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_fontType
            // 
            this.label_fontType.AutoSize = true;
            this.label_fontType.BackColor = System.Drawing.Color.Transparent;
            this.label_fontType.ForeColor = System.Drawing.Color.White;
            this.label_fontType.Location = new System.Drawing.Point(28, 21);
            this.label_fontType.Name = "label_fontType";
            this.label_fontType.Size = new System.Drawing.Size(29, 12);
            this.label_fontType.TabIndex = 0;
            this.label_fontType.Text = "字体";
            // 
            // FormSubtitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(425, 467);
            this.Controls.Add(this.label_fontType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSubtitle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_fontType;
    }
}