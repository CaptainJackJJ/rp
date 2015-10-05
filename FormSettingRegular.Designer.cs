namespace RPlayer
{
    partial class FormSettingRegular
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
      this.label_uiLang = new System.Windows.Forms.Label();
      this.comboBox_uiLang = new System.Windows.Forms.ComboBox();
      this.label_repeatPlayback = new System.Windows.Forms.Label();
      this.comboBox_repeatPlayback = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // label_uiLang
      // 
      this.label_uiLang.AutoSize = true;
      this.label_uiLang.BackColor = System.Drawing.Color.Transparent;
      this.label_uiLang.ForeColor = System.Drawing.Color.White;
      this.label_uiLang.Location = new System.Drawing.Point(30, 20);
      this.label_uiLang.Name = "label_uiLang";
      this.label_uiLang.Size = new System.Drawing.Size(71, 12);
      this.label_uiLang.TabIndex = 0;
      this.label_uiLang.Text = "UI Language";
      // 
      // comboBox_uiLang
      // 
      this.comboBox_uiLang.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.comboBox_uiLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox_uiLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox_uiLang.ForeColor = System.Drawing.Color.White;
      this.comboBox_uiLang.FormattingEnabled = true;
      this.comboBox_uiLang.Location = new System.Drawing.Point(113, 17);
      this.comboBox_uiLang.Name = "comboBox_uiLang";
      this.comboBox_uiLang.Size = new System.Drawing.Size(130, 20);
      this.comboBox_uiLang.TabIndex = 1;
      // 
      // label_repeatPlayback
      // 
      this.label_repeatPlayback.AutoSize = true;
      this.label_repeatPlayback.BackColor = System.Drawing.Color.Transparent;
      this.label_repeatPlayback.ForeColor = System.Drawing.Color.White;
      this.label_repeatPlayback.Location = new System.Drawing.Point(30, 60);
      this.label_repeatPlayback.Name = "label_repeatPlayback";
      this.label_repeatPlayback.Size = new System.Drawing.Size(89, 12);
      this.label_repeatPlayback.TabIndex = 0;
      this.label_repeatPlayback.Text = "RepeatPlayback";
      // 
      // comboBox_repeatPlayback
      // 
      this.comboBox_repeatPlayback.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.comboBox_repeatPlayback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox_repeatPlayback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox_repeatPlayback.ForeColor = System.Drawing.Color.White;
      this.comboBox_repeatPlayback.FormattingEnabled = true;
      this.comboBox_repeatPlayback.Location = new System.Drawing.Point(134, 57);
      this.comboBox_repeatPlayback.Name = "comboBox_repeatPlayback";
      this.comboBox_repeatPlayback.Size = new System.Drawing.Size(130, 20);
      this.comboBox_repeatPlayback.TabIndex = 1;
      // 
      // FormSettingRegular
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(425, 467);
      this.Controls.Add(this.comboBox_repeatPlayback);
      this.Controls.Add(this.comboBox_uiLang);
      this.Controls.Add(this.label_repeatPlayback);
      this.Controls.Add(this.label_uiLang);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormSettingRegular";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_uiLang;
        private System.Windows.Forms.ComboBox comboBox_uiLang;
        private System.Windows.Forms.Label label_repeatPlayback;
        private System.Windows.Forms.ComboBox comboBox_repeatPlayback;
    }
}