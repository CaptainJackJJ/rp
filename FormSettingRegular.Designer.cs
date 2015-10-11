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
      this.checkBox_updatePlistAfterLaunch = new System.Windows.Forms.CheckBox();
      this.checkBox_addPlayingFolderToPlist = new System.Windows.Forms.CheckBox();
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
      // checkBox_updatePlistAfterLaunch
      // 
      this.checkBox_updatePlistAfterLaunch.AutoSize = true;
      this.checkBox_updatePlistAfterLaunch.Checked = true;
      this.checkBox_updatePlistAfterLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox_updatePlistAfterLaunch.ForeColor = System.Drawing.Color.White;
      this.checkBox_updatePlistAfterLaunch.Location = new System.Drawing.Point(32, 64);
      this.checkBox_updatePlistAfterLaunch.Name = "checkBox_updatePlistAfterLaunch";
      this.checkBox_updatePlistAfterLaunch.Size = new System.Drawing.Size(264, 16);
      this.checkBox_updatePlistAfterLaunch.TabIndex = 2;
      this.checkBox_updatePlistAfterLaunch.Text = "Auto update playlist after player launch";
      this.checkBox_updatePlistAfterLaunch.UseVisualStyleBackColor = true;
      this.checkBox_updatePlistAfterLaunch.CheckedChanged += new System.EventHandler(this.checkBox_updatePlistAfterLaunch_CheckedChanged);
      // 
      // checkBox_addPlayingFolderToPlist
      // 
      this.checkBox_addPlayingFolderToPlist.AutoSize = true;
      this.checkBox_addPlayingFolderToPlist.Checked = true;
      this.checkBox_addPlayingFolderToPlist.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox_addPlayingFolderToPlist.ForeColor = System.Drawing.Color.White;
      this.checkBox_addPlayingFolderToPlist.Location = new System.Drawing.Point(32, 98);
      this.checkBox_addPlayingFolderToPlist.Name = "checkBox_addPlayingFolderToPlist";
      this.checkBox_addPlayingFolderToPlist.Size = new System.Drawing.Size(234, 16);
      this.checkBox_addPlayingFolderToPlist.TabIndex = 2;
      this.checkBox_addPlayingFolderToPlist.Text = "Auto add playing folder to playlist";
      this.checkBox_addPlayingFolderToPlist.UseVisualStyleBackColor = true;
      this.checkBox_addPlayingFolderToPlist.CheckedChanged += new System.EventHandler(this.checkBox_addPlayingFolderToPlist_CheckedChanged);
      // 
      // FormSettingRegular
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(425, 467);
      this.Controls.Add(this.checkBox_addPlayingFolderToPlist);
      this.Controls.Add(this.checkBox_updatePlistAfterLaunch);
      this.Controls.Add(this.comboBox_uiLang);
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
        private System.Windows.Forms.CheckBox checkBox_updatePlistAfterLaunch;
        private System.Windows.Forms.CheckBox checkBox_addPlayingFolderToPlist;
    }
}