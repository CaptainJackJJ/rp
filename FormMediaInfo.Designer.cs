namespace RPlayer
{
  partial class FormMediaInfo
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMediaInfo));
      this.label_mediaInfo = new System.Windows.Forms.Label();
      this.label_settingsClose = new System.Windows.Forms.Label();
      this.panel_topBar = new System.Windows.Forms.Panel();
      this.label_topBarLine = new System.Windows.Forms.Label();
      this.textBox_url = new System.Windows.Forms.TextBox();
      this.label_url = new System.Windows.Forms.Label();
      this.label_creationTime = new System.Windows.Forms.Label();
      this.label_fileSize = new System.Windows.Forms.Label();
      this.label_creationTimeShow = new System.Windows.Forms.Label();
      this.label_fileSizeShow = new System.Windows.Forms.Label();
      this.label_durationShow = new System.Windows.Forms.Label();
      this.label_duration = new System.Windows.Forms.Label();
      this.textBox_infoDetail = new System.Windows.Forms.TextBox();
      this.panel_topBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // label_mediaInfo
      // 
      this.label_mediaInfo.AutoSize = true;
      this.label_mediaInfo.BackColor = System.Drawing.Color.Transparent;
      this.label_mediaInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_mediaInfo.ForeColor = System.Drawing.Color.White;
      this.label_mediaInfo.Location = new System.Drawing.Point(6, 13);
      this.label_mediaInfo.Name = "label_mediaInfo";
      this.label_mediaInfo.Size = new System.Drawing.Size(70, 14);
      this.label_mediaInfo.TabIndex = 0;
      this.label_mediaInfo.Text = "MediaInfo";
      // 
      // label_settingsClose
      // 
      this.label_settingsClose.BackColor = System.Drawing.Color.Transparent;
      this.label_settingsClose.Location = new System.Drawing.Point(392, 14);
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
      this.panel_topBar.Controls.Add(this.label_mediaInfo);
      this.panel_topBar.Controls.Add(this.label_settingsClose);
      this.panel_topBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_topBar.Location = new System.Drawing.Point(0, 0);
      this.panel_topBar.Name = "panel_topBar";
      this.panel_topBar.Size = new System.Drawing.Size(426, 41);
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
      this.label_topBarLine.Size = new System.Drawing.Size(426, 1);
      this.label_topBarLine.TabIndex = 4;
      // 
      // textBox_url
      // 
      this.textBox_url.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.textBox_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_url.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_url.ForeColor = System.Drawing.Color.White;
      this.textBox_url.Location = new System.Drawing.Point(14, 68);
      this.textBox_url.Multiline = true;
      this.textBox_url.Name = "textBox_url";
      this.textBox_url.ReadOnly = true;
      this.textBox_url.Size = new System.Drawing.Size(400, 24);
      this.textBox_url.TabIndex = 44;
      this.textBox_url.TabStop = false;
      this.textBox_url.Text = "D:\\迅雷下载\\Modern.Family.S03E01.HDTV.XviD-75Mb-Arnarcool.mp4";
      // 
      // label_url
      // 
      this.label_url.AutoSize = true;
      this.label_url.BackColor = System.Drawing.Color.Transparent;
      this.label_url.ForeColor = System.Drawing.Color.White;
      this.label_url.Location = new System.Drawing.Point(12, 53);
      this.label_url.Name = "label_url";
      this.label_url.Size = new System.Drawing.Size(29, 12);
      this.label_url.TabIndex = 37;
      this.label_url.Text = "Url:";
      // 
      // label_creationTime
      // 
      this.label_creationTime.AutoSize = true;
      this.label_creationTime.BackColor = System.Drawing.Color.Transparent;
      this.label_creationTime.ForeColor = System.Drawing.Color.White;
      this.label_creationTime.Location = new System.Drawing.Point(12, 130);
      this.label_creationTime.Name = "label_creationTime";
      this.label_creationTime.Size = new System.Drawing.Size(83, 12);
      this.label_creationTime.TabIndex = 38;
      this.label_creationTime.Text = "CreationTime:";
      // 
      // label_fileSize
      // 
      this.label_fileSize.AutoSize = true;
      this.label_fileSize.BackColor = System.Drawing.Color.Transparent;
      this.label_fileSize.ForeColor = System.Drawing.Color.White;
      this.label_fileSize.Location = new System.Drawing.Point(239, 101);
      this.label_fileSize.Name = "label_fileSize";
      this.label_fileSize.Size = new System.Drawing.Size(65, 12);
      this.label_fileSize.TabIndex = 39;
      this.label_fileSize.Text = "File Size:";
      // 
      // label_creationTimeShow
      // 
      this.label_creationTimeShow.AutoSize = true;
      this.label_creationTimeShow.BackColor = System.Drawing.Color.Transparent;
      this.label_creationTimeShow.ForeColor = System.Drawing.Color.White;
      this.label_creationTimeShow.Location = new System.Drawing.Point(101, 130);
      this.label_creationTimeShow.Name = "label_creationTimeShow";
      this.label_creationTimeShow.Size = new System.Drawing.Size(113, 12);
      this.label_creationTimeShow.TabIndex = 40;
      this.label_creationTimeShow.Text = "1987/2/19 00:00:00";
      // 
      // label_fileSizeShow
      // 
      this.label_fileSizeShow.AutoSize = true;
      this.label_fileSizeShow.BackColor = System.Drawing.Color.Transparent;
      this.label_fileSizeShow.ForeColor = System.Drawing.Color.White;
      this.label_fileSizeShow.Location = new System.Drawing.Point(310, 101);
      this.label_fileSizeShow.Name = "label_fileSizeShow";
      this.label_fileSizeShow.Size = new System.Drawing.Size(29, 12);
      this.label_fileSizeShow.TabIndex = 41;
      this.label_fileSizeShow.Text = "37MB";
      // 
      // label_durationShow
      // 
      this.label_durationShow.AutoSize = true;
      this.label_durationShow.BackColor = System.Drawing.Color.Transparent;
      this.label_durationShow.ForeColor = System.Drawing.Color.White;
      this.label_durationShow.Location = new System.Drawing.Point(101, 101);
      this.label_durationShow.Name = "label_durationShow";
      this.label_durationShow.Size = new System.Drawing.Size(77, 12);
      this.label_durationShow.TabIndex = 41;
      this.label_durationShow.Text = "01 : 00 : 00";
      // 
      // label_duration
      // 
      this.label_duration.AutoSize = true;
      this.label_duration.BackColor = System.Drawing.Color.Transparent;
      this.label_duration.ForeColor = System.Drawing.Color.White;
      this.label_duration.Location = new System.Drawing.Point(12, 101);
      this.label_duration.Name = "label_duration";
      this.label_duration.Size = new System.Drawing.Size(59, 12);
      this.label_duration.TabIndex = 39;
      this.label_duration.Text = "Duration:";
      // 
      // textBox_infoDetail
      // 
      this.textBox_infoDetail.BackColor = System.Drawing.Color.DimGray;
      this.textBox_infoDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_infoDetail.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_infoDetail.ForeColor = System.Drawing.Color.White;
      this.textBox_infoDetail.Location = new System.Drawing.Point(12, 160);
      this.textBox_infoDetail.Multiline = true;
      this.textBox_infoDetail.Name = "textBox_infoDetail";
      this.textBox_infoDetail.ReadOnly = true;
      this.textBox_infoDetail.Size = new System.Drawing.Size(402, 367);
      this.textBox_infoDetail.TabIndex = 44;
      this.textBox_infoDetail.TabStop = false;
      this.textBox_infoDetail.Text = "infoDetail";
      // 
      // FormMediaInfo
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(426, 539);
      this.Controls.Add(this.textBox_infoDetail);
      this.Controls.Add(this.textBox_url);
      this.Controls.Add(this.label_url);
      this.Controls.Add(this.label_creationTime);
      this.Controls.Add(this.label_duration);
      this.Controls.Add(this.label_fileSize);
      this.Controls.Add(this.label_durationShow);
      this.Controls.Add(this.label_creationTimeShow);
      this.Controls.Add(this.label_fileSizeShow);
      this.Controls.Add(this.label_topBarLine);
      this.Controls.Add(this.panel_topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormMediaInfo";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "媒体信息";
      this.panel_topBar.ResumeLayout(false);
      this.panel_topBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_mediaInfo;
        private System.Windows.Forms.Label label_settingsClose;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.Label label_topBarLine;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Label label_url;
        private System.Windows.Forms.Label label_creationTime;
        private System.Windows.Forms.Label label_fileSize;
        private System.Windows.Forms.Label label_creationTimeShow;
        private System.Windows.Forms.Label label_fileSizeShow;
        private System.Windows.Forms.Label label_durationShow;
        private System.Windows.Forms.Label label_duration;
        private System.Windows.Forms.TextBox textBox_infoDetail;
    }
}