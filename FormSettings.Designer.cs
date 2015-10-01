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
      this.label_bottomBarLine = new System.Windows.Forms.Label();
      this.button_ok = new System.Windows.Forms.Button();
      this.button_cancel = new System.Windows.Forms.Button();
      this.label_leftLine = new System.Windows.Forms.Label();
      this.label_regular = new System.Windows.Forms.Label();
      this.label_subtitle = new System.Windows.Forms.Label();
      this.label_AV = new System.Windows.Forms.Label();
      this.panel_topBar.SuspendLayout();
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
      this.label_settings.Size = new System.Drawing.Size(35, 14);
      this.label_settings.TabIndex = 0;
      this.label_settings.Text = "设置";
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
      // label_bottomBarLine
      // 
      this.label_bottomBarLine.BackColor = System.Drawing.Color.Silver;
      this.label_bottomBarLine.Location = new System.Drawing.Point(0, 511);
      this.label_bottomBarLine.Name = "label_bottomBarLine";
      this.label_bottomBarLine.Size = new System.Drawing.Size(525, 1);
      this.label_bottomBarLine.TabIndex = 5;
      // 
      // button_ok
      // 
      this.button_ok.BackColor = System.Drawing.Color.DimGray;
      this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_ok.ForeColor = System.Drawing.Color.White;
      this.button_ok.Location = new System.Drawing.Point(333, 527);
      this.button_ok.Name = "button_ok";
      this.button_ok.Size = new System.Drawing.Size(75, 23);
      this.button_ok.TabIndex = 7;
      this.button_ok.Text = "确认";
      this.button_ok.UseVisualStyleBackColor = false;
      this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
      // 
      // button_cancel
      // 
      this.button_cancel.BackColor = System.Drawing.Color.DimGray;
      this.button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_cancel.ForeColor = System.Drawing.Color.White;
      this.button_cancel.Location = new System.Drawing.Point(433, 527);
      this.button_cancel.Name = "button_cancel";
      this.button_cancel.Size = new System.Drawing.Size(75, 23);
      this.button_cancel.TabIndex = 8;
      this.button_cancel.Text = "取消";
      this.button_cancel.UseVisualStyleBackColor = false;
      this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
      // 
      // label_leftLine
      // 
      this.label_leftLine.BackColor = System.Drawing.Color.Silver;
      this.label_leftLine.Location = new System.Drawing.Point(98, 42);
      this.label_leftLine.Name = "label_leftLine";
      this.label_leftLine.Size = new System.Drawing.Size(1, 469);
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
      this.label_regular.Text = "常规";
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
      this.label_subtitle.Text = "字幕";
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
      this.label_AV.Text = "音视频";
      this.label_AV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_AV.Click += new System.EventHandler(this.label_AV_Click);
      this.label_AV.MouseEnter += new System.EventHandler(this.label_AV_MouseEnter);
      this.label_AV.MouseLeave += new System.EventHandler(this.label_AV_MouseLeave);
      // 
      // FormSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(525, 562);
      this.Controls.Add(this.label_AV);
      this.Controls.Add(this.label_subtitle);
      this.Controls.Add(this.label_regular);
      this.Controls.Add(this.label_leftLine);
      this.Controls.Add(this.button_cancel);
      this.Controls.Add(this.button_ok);
      this.Controls.Add(this.label_bottomBarLine);
      this.Controls.Add(this.label_topBarLine);
      this.Controls.Add(this.panel_topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormSettings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.panel_topBar.ResumeLayout(false);
      this.panel_topBar.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_settings;
        private System.Windows.Forms.Label label_settingsClose;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.Label label_topBarLine;
        private System.Windows.Forms.Label label_bottomBarLine;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_leftLine;
        private System.Windows.Forms.Label label_regular;
        private System.Windows.Forms.Label label_subtitle;
        private System.Windows.Forms.Label label_AV;
    }
}