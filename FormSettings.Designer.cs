namespace RPlayer
{
    partial class FormSettings
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
      this.label_settings = new System.Windows.Forms.Label();
      this.label_settingsClose = new System.Windows.Forms.Label();
      this.panel_topBar = new System.Windows.Forms.Panel();
      this.label_topBarLine = new System.Windows.Forms.Label();
      this.label_leftLine = new System.Windows.Forms.Label();
      this.label_regular = new System.Windows.Forms.Label();
      this.label_subtitle = new System.Windows.Forms.Label();
      this.label_AV = new System.Windows.Forms.Label();
      this.panel_general = new System.Windows.Forms.Panel();
      this.comboBox_uiLang = new System.Windows.Forms.ComboBox();
      this.label_uiLang = new System.Windows.Forms.Label();
      this.panel_subtitle = new System.Windows.Forms.Panel();
      this.label_fontType = new System.Windows.Forms.Label();
      this.panel_av = new System.Windows.Forms.Panel();
      this.label_volumeAmp = new System.Windows.Forms.Label();
      this.label_plist = new System.Windows.Forms.Label();
      this.panel_plist = new System.Windows.Forms.Panel();
      this.checkBox_addPlayingFolderToPlist = new System.Windows.Forms.CheckBox();
      this.checkBox_updatePlistAfterLaunch = new System.Windows.Forms.CheckBox();
      this.checkBox_deleteFileDirectly = new System.Windows.Forms.CheckBox();
      this.panel_topBar.SuspendLayout();
      this.panel_general.SuspendLayout();
      this.panel_subtitle.SuspendLayout();
      this.panel_av.SuspendLayout();
      this.panel_plist.SuspendLayout();
      this.SuspendLayout();
      // 
      // label_settings
      // 
      this.label_settings.AutoSize = true;
      this.label_settings.BackColor = System.Drawing.Color.Transparent;
      this.label_settings.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_settings.ForeColor = System.Drawing.Color.White;
      this.label_settings.Location = new System.Drawing.Point(6, 13);
      this.label_settings.Name = "label_settings";
      this.label_settings.Size = new System.Drawing.Size(63, 14);
      this.label_settings.TabIndex = 0;
      this.label_settings.Text = "Settings";
      // 
      // label_settingsClose
      // 
      this.label_settingsClose.BackColor = System.Drawing.Color.Transparent;
      this.label_settingsClose.Location = new System.Drawing.Point(495, 14);
      this.label_settingsClose.Name = "label_settingsClose";
      this.label_settingsClose.Size = new System.Drawing.Size(13, 13);
      this.label_settingsClose.TabIndex = 1;
      this.label_settingsClose.Click += new System.EventHandler(this.label_settingsClose_Click);
      this.label_settingsClose.MouseEnter += new System.EventHandler(this.label_settingsClose_MouseEnter);
      this.label_settingsClose.MouseLeave += new System.EventHandler(this.label_settingsClose_MouseLeave);
      // 
      // panel_topBar
      // 
      this.panel_topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
      this.panel_topBar.Controls.Add(this.label_settings);
      this.panel_topBar.Controls.Add(this.label_settingsClose);
      this.panel_topBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_topBar.Location = new System.Drawing.Point(0, 0);
      this.panel_topBar.Name = "panel_topBar";
      this.panel_topBar.Size = new System.Drawing.Size(525, 41);
      this.panel_topBar.TabIndex = 3;
      this.panel_topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_topBar_MouseDown);
      this.panel_topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_topBar_MouseMove);
      this.panel_topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_topBar_MouseUp);
      // 
      // label_topBarLine
      // 
      this.label_topBarLine.BackColor = System.Drawing.Color.Silver;
      this.label_topBarLine.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_topBarLine.Location = new System.Drawing.Point(0, 41);
      this.label_topBarLine.Name = "label_topBarLine";
      this.label_topBarLine.Size = new System.Drawing.Size(525, 1);
      this.label_topBarLine.TabIndex = 4;
      // 
      // label_leftLine
      // 
      this.label_leftLine.BackColor = System.Drawing.Color.Silver;
      this.label_leftLine.Location = new System.Drawing.Point(98, 42);
      this.label_leftLine.Name = "label_leftLine";
      this.label_leftLine.Size = new System.Drawing.Size(1, 496);
      this.label_leftLine.TabIndex = 9;
      // 
      // label_regular
      // 
      this.label_regular.BackColor = System.Drawing.Color.Transparent;
      this.label_regular.ForeColor = System.Drawing.Color.White;
      this.label_regular.Location = new System.Drawing.Point(0, 44);
      this.label_regular.Name = "label_regular";
      this.label_regular.Size = new System.Drawing.Size(98, 30);
      this.label_regular.TabIndex = 11;
      this.label_regular.Text = "General";
      this.label_regular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_regular.Click += new System.EventHandler(this.label_regular_Click);
      this.label_regular.MouseEnter += new System.EventHandler(this.label_regular_MouseEnter);
      this.label_regular.MouseLeave += new System.EventHandler(this.label_regular_MouseLeave);
      // 
      // label_subtitle
      // 
      this.label_subtitle.BackColor = System.Drawing.Color.Transparent;
      this.label_subtitle.ForeColor = System.Drawing.Color.White;
      this.label_subtitle.Location = new System.Drawing.Point(0, 74);
      this.label_subtitle.Name = "label_subtitle";
      this.label_subtitle.Size = new System.Drawing.Size(98, 30);
      this.label_subtitle.TabIndex = 12;
      this.label_subtitle.Text = "Subtitle";
      this.label_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_subtitle.Click += new System.EventHandler(this.label_subtitle_Click);
      this.label_subtitle.MouseEnter += new System.EventHandler(this.label_subtitle_MouseEnter);
      this.label_subtitle.MouseLeave += new System.EventHandler(this.label_subtitle_MouseLeave);
      // 
      // label_AV
      // 
      this.label_AV.BackColor = System.Drawing.Color.Transparent;
      this.label_AV.ForeColor = System.Drawing.Color.White;
      this.label_AV.Location = new System.Drawing.Point(0, 104);
      this.label_AV.Name = "label_AV";
      this.label_AV.Size = new System.Drawing.Size(98, 30);
      this.label_AV.TabIndex = 13;
      this.label_AV.Text = "AudioVideo";
      this.label_AV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_AV.Click += new System.EventHandler(this.label_AV_Click);
      this.label_AV.MouseEnter += new System.EventHandler(this.label_AV_MouseEnter);
      this.label_AV.MouseLeave += new System.EventHandler(this.label_AV_MouseLeave);
      // 
      // panel_general
      // 
      this.panel_general.Controls.Add(this.comboBox_uiLang);
      this.panel_general.Controls.Add(this.label_uiLang);
      this.panel_general.Location = new System.Drawing.Point(101, 43);
      this.panel_general.Name = "panel_general";
      this.panel_general.Size = new System.Drawing.Size(422, 495);
      this.panel_general.TabIndex = 15;
      // 
      // comboBox_uiLang
      // 
      this.comboBox_uiLang.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.comboBox_uiLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox_uiLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox_uiLang.ForeColor = System.Drawing.Color.White;
      this.comboBox_uiLang.FormattingEnabled = true;
      this.comboBox_uiLang.Location = new System.Drawing.Point(107, 7);
      this.comboBox_uiLang.Name = "comboBox_uiLang";
      this.comboBox_uiLang.Size = new System.Drawing.Size(130, 20);
      this.comboBox_uiLang.TabIndex = 4;
      // 
      // label_uiLang
      // 
      this.label_uiLang.AutoSize = true;
      this.label_uiLang.BackColor = System.Drawing.Color.Transparent;
      this.label_uiLang.ForeColor = System.Drawing.Color.White;
      this.label_uiLang.Location = new System.Drawing.Point(24, 10);
      this.label_uiLang.Name = "label_uiLang";
      this.label_uiLang.Size = new System.Drawing.Size(71, 12);
      this.label_uiLang.TabIndex = 3;
      this.label_uiLang.Text = "UI Language";
      // 
      // panel_subtitle
      // 
      this.panel_subtitle.Controls.Add(this.label_fontType);
      this.panel_subtitle.Location = new System.Drawing.Point(101, 43);
      this.panel_subtitle.Name = "panel_subtitle";
      this.panel_subtitle.Size = new System.Drawing.Size(422, 495);
      this.panel_subtitle.TabIndex = 7;
      // 
      // label_fontType
      // 
      this.label_fontType.AutoSize = true;
      this.label_fontType.BackColor = System.Drawing.Color.Transparent;
      this.label_fontType.ForeColor = System.Drawing.Color.White;
      this.label_fontType.Location = new System.Drawing.Point(24, 19);
      this.label_fontType.Name = "label_fontType";
      this.label_fontType.Size = new System.Drawing.Size(29, 12);
      this.label_fontType.TabIndex = 1;
      this.label_fontType.Text = "字体";
      // 
      // panel_av
      // 
      this.panel_av.Controls.Add(this.label_volumeAmp);
      this.panel_av.Location = new System.Drawing.Point(101, 43);
      this.panel_av.Name = "panel_av";
      this.panel_av.Size = new System.Drawing.Size(422, 495);
      this.panel_av.TabIndex = 2;
      // 
      // label_volumeAmp
      // 
      this.label_volumeAmp.AutoSize = true;
      this.label_volumeAmp.BackColor = System.Drawing.Color.Transparent;
      this.label_volumeAmp.ForeColor = System.Drawing.Color.White;
      this.label_volumeAmp.Location = new System.Drawing.Point(24, 19);
      this.label_volumeAmp.Name = "label_volumeAmp";
      this.label_volumeAmp.Size = new System.Drawing.Size(53, 12);
      this.label_volumeAmp.TabIndex = 1;
      this.label_volumeAmp.Text = "音量放大";
      // 
      // label_plist
      // 
      this.label_plist.BackColor = System.Drawing.Color.Transparent;
      this.label_plist.ForeColor = System.Drawing.Color.White;
      this.label_plist.Location = new System.Drawing.Point(0, 136);
      this.label_plist.Name = "label_plist";
      this.label_plist.Size = new System.Drawing.Size(98, 30);
      this.label_plist.TabIndex = 13;
      this.label_plist.Text = "Playlist";
      this.label_plist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_plist.Click += new System.EventHandler(this.label_plist_Click);
      this.label_plist.MouseEnter += new System.EventHandler(this.label_plist_MouseEnter);
      this.label_plist.MouseLeave += new System.EventHandler(this.label_plist_MouseLeave);
      // 
      // panel_plist
      // 
      this.panel_plist.Controls.Add(this.checkBox_addPlayingFolderToPlist);
      this.panel_plist.Controls.Add(this.checkBox_updatePlistAfterLaunch);
      this.panel_plist.Controls.Add(this.checkBox_deleteFileDirectly);
      this.panel_plist.Location = new System.Drawing.Point(101, 43);
      this.panel_plist.Name = "panel_plist";
      this.panel_plist.Size = new System.Drawing.Size(422, 495);
      this.panel_plist.TabIndex = 7;
      // 
      // checkBox_addPlayingFolderToPlist
      // 
      this.checkBox_addPlayingFolderToPlist.AutoSize = true;
      this.checkBox_addPlayingFolderToPlist.Checked = true;
      this.checkBox_addPlayingFolderToPlist.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox_addPlayingFolderToPlist.ForeColor = System.Drawing.Color.White;
      this.checkBox_addPlayingFolderToPlist.Location = new System.Drawing.Point(14, 95);
      this.checkBox_addPlayingFolderToPlist.Name = "checkBox_addPlayingFolderToPlist";
      this.checkBox_addPlayingFolderToPlist.Size = new System.Drawing.Size(234, 16);
      this.checkBox_addPlayingFolderToPlist.TabIndex = 8;
      this.checkBox_addPlayingFolderToPlist.Text = "Auto add playing folder to playlist";
      this.checkBox_addPlayingFolderToPlist.UseVisualStyleBackColor = true;
      this.checkBox_addPlayingFolderToPlist.CheckedChanged += new System.EventHandler(this.checkBox_addPlayingFolderToPlist_CheckedChanged);
      // 
      // checkBox_updatePlistAfterLaunch
      // 
      this.checkBox_updatePlistAfterLaunch.AutoSize = true;
      this.checkBox_updatePlistAfterLaunch.Checked = true;
      this.checkBox_updatePlistAfterLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox_updatePlistAfterLaunch.ForeColor = System.Drawing.Color.White;
      this.checkBox_updatePlistAfterLaunch.Location = new System.Drawing.Point(14, 61);
      this.checkBox_updatePlistAfterLaunch.Name = "checkBox_updatePlistAfterLaunch";
      this.checkBox_updatePlistAfterLaunch.Size = new System.Drawing.Size(264, 16);
      this.checkBox_updatePlistAfterLaunch.TabIndex = 9;
      this.checkBox_updatePlistAfterLaunch.Text = "Auto update playlist after player launch";
      this.checkBox_updatePlistAfterLaunch.UseVisualStyleBackColor = true;
      this.checkBox_updatePlistAfterLaunch.CheckedChanged += new System.EventHandler(this.checkBox_updatePlistAfterLaunch_CheckedChanged);
      // 
      // checkBox_deleteFileDirectly
      // 
      this.checkBox_deleteFileDirectly.AutoSize = true;
      this.checkBox_deleteFileDirectly.Checked = true;
      this.checkBox_deleteFileDirectly.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox_deleteFileDirectly.ForeColor = System.Drawing.Color.White;
      this.checkBox_deleteFileDirectly.Location = new System.Drawing.Point(14, 25);
      this.checkBox_deleteFileDirectly.Name = "checkBox_deleteFileDirectly";
      this.checkBox_deleteFileDirectly.Size = new System.Drawing.Size(264, 16);
      this.checkBox_deleteFileDirectly.TabIndex = 7;
      this.checkBox_deleteFileDirectly.Text = "just delete playlist file without asking";
      this.checkBox_deleteFileDirectly.UseVisualStyleBackColor = true;
      this.checkBox_deleteFileDirectly.CheckedChanged += new System.EventHandler(this.checkBox_deleteFileDirectly_CheckedChanged);
      // 
      // FormSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(525, 539);
      this.Controls.Add(this.panel_plist);
      this.Controls.Add(this.panel_general);
      this.Controls.Add(this.panel_av);
      this.Controls.Add(this.panel_subtitle);
      this.Controls.Add(this.label_plist);
      this.Controls.Add(this.label_AV);
      this.Controls.Add(this.label_subtitle);
      this.Controls.Add(this.label_regular);
      this.Controls.Add(this.label_leftLine);
      this.Controls.Add(this.label_topBarLine);
      this.Controls.Add(this.panel_topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormSettings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.panel_topBar.ResumeLayout(false);
      this.panel_topBar.PerformLayout();
      this.panel_general.ResumeLayout(false);
      this.panel_general.PerformLayout();
      this.panel_subtitle.ResumeLayout(false);
      this.panel_subtitle.PerformLayout();
      this.panel_av.ResumeLayout(false);
      this.panel_av.PerformLayout();
      this.panel_plist.ResumeLayout(false);
      this.panel_plist.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_settings;
        private System.Windows.Forms.Label label_settingsClose;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.Label label_topBarLine;
        private System.Windows.Forms.Label label_leftLine;
        private System.Windows.Forms.Label label_regular;
        private System.Windows.Forms.Label label_subtitle;
        private System.Windows.Forms.Label label_AV;
        private System.Windows.Forms.Panel panel_general;
        private System.Windows.Forms.ComboBox comboBox_uiLang;
        private System.Windows.Forms.Label label_uiLang;
        private System.Windows.Forms.Panel panel_subtitle;
        private System.Windows.Forms.Label label_fontType;
        private System.Windows.Forms.Panel panel_av;
        private System.Windows.Forms.Label label_volumeAmp;
        private System.Windows.Forms.Label label_plist;
        private System.Windows.Forms.Panel panel_plist;
        private System.Windows.Forms.CheckBox checkBox_deleteFileDirectly;
        private System.Windows.Forms.CheckBox checkBox_addPlayingFolderToPlist;
        private System.Windows.Forms.CheckBox checkBox_updatePlistAfterLaunch;
    }
}