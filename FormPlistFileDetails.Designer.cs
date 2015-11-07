namespace RPlayer
{
  partial class FormPlistFileDetails
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
      this.label_timeWatched = new System.Windows.Forms.Label();
      this.label_duration = new System.Windows.Forms.Label();
      this.label_timeWatchedShow = new System.Windows.Forms.Label();
      this.label_durationShow = new System.Windows.Forms.Label();
      this.label_url = new System.Windows.Forms.Label();
      this.textBox_url = new System.Windows.Forms.TextBox();
      this.label_creationTimeShow = new System.Windows.Forms.Label();
      this.label_creationTime = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_timeWatched
      // 
      this.label_timeWatched.AutoSize = true;
      this.label_timeWatched.BackColor = System.Drawing.Color.Transparent;
      this.label_timeWatched.ForeColor = System.Drawing.Color.White;
      this.label_timeWatched.Location = new System.Drawing.Point(12, 9);
      this.label_timeWatched.Name = "label_timeWatched";
      this.label_timeWatched.Size = new System.Drawing.Size(83, 12);
      this.label_timeWatched.TabIndex = 35;
      this.label_timeWatched.Text = "Time Watched:";
      // 
      // label_duration
      // 
      this.label_duration.AutoSize = true;
      this.label_duration.BackColor = System.Drawing.Color.Transparent;
      this.label_duration.ForeColor = System.Drawing.Color.White;
      this.label_duration.Location = new System.Drawing.Point(12, 30);
      this.label_duration.Name = "label_duration";
      this.label_duration.Size = new System.Drawing.Size(59, 12);
      this.label_duration.TabIndex = 35;
      this.label_duration.Text = "Duration:";
      // 
      // label_timeWatchedShow
      // 
      this.label_timeWatchedShow.AutoSize = true;
      this.label_timeWatchedShow.BackColor = System.Drawing.Color.Transparent;
      this.label_timeWatchedShow.ForeColor = System.Drawing.Color.Azure;
      this.label_timeWatchedShow.Location = new System.Drawing.Point(101, 9);
      this.label_timeWatchedShow.Name = "label_timeWatchedShow";
      this.label_timeWatchedShow.Size = new System.Drawing.Size(77, 12);
      this.label_timeWatchedShow.TabIndex = 35;
      this.label_timeWatchedShow.Text = "00 : 00 : 50";
      // 
      // label_durationShow
      // 
      this.label_durationShow.AutoSize = true;
      this.label_durationShow.BackColor = System.Drawing.Color.Transparent;
      this.label_durationShow.ForeColor = System.Drawing.Color.Azure;
      this.label_durationShow.Location = new System.Drawing.Point(101, 30);
      this.label_durationShow.Name = "label_durationShow";
      this.label_durationShow.Size = new System.Drawing.Size(77, 12);
      this.label_durationShow.TabIndex = 35;
      this.label_durationShow.Text = "01 : 00 : 00";
      // 
      // label_url
      // 
      this.label_url.AutoSize = true;
      this.label_url.BackColor = System.Drawing.Color.Transparent;
      this.label_url.ForeColor = System.Drawing.Color.White;
      this.label_url.Location = new System.Drawing.Point(12, 80);
      this.label_url.Name = "label_url";
      this.label_url.Size = new System.Drawing.Size(29, 12);
      this.label_url.TabIndex = 35;
      this.label_url.Text = "Url:";
      // 
      // textBox_url
      // 
      this.textBox_url.BackColor = System.Drawing.Color.DimGray;
      this.textBox_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_url.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_url.ForeColor = System.Drawing.Color.White;
      this.textBox_url.Location = new System.Drawing.Point(14, 95);
      this.textBox_url.Multiline = true;
      this.textBox_url.Name = "textBox_url";
      this.textBox_url.ReadOnly = true;
      this.textBox_url.Size = new System.Drawing.Size(200, 49);
      this.textBox_url.TabIndex = 36;
      this.textBox_url.TabStop = false;
      this.textBox_url.Text = "D:\\迅雷下载\\Modern.Family.S03E01.HDTV.XviD-75Mb-Arnarcool.mp4";
      // 
      // label_creationTimeShow
      // 
      this.label_creationTimeShow.AutoSize = true;
      this.label_creationTimeShow.BackColor = System.Drawing.Color.Transparent;
      this.label_creationTimeShow.ForeColor = System.Drawing.Color.Azure;
      this.label_creationTimeShow.Location = new System.Drawing.Point(101, 54);
      this.label_creationTimeShow.Name = "label_creationTimeShow";
      this.label_creationTimeShow.Size = new System.Drawing.Size(113, 12);
      this.label_creationTimeShow.TabIndex = 35;
      this.label_creationTimeShow.Text = "1987/2/19 00:00:00";
      // 
      // label_creationTime
      // 
      this.label_creationTime.AutoSize = true;
      this.label_creationTime.BackColor = System.Drawing.Color.Transparent;
      this.label_creationTime.ForeColor = System.Drawing.Color.White;
      this.label_creationTime.Location = new System.Drawing.Point(12, 54);
      this.label_creationTime.Name = "label_creationTime";
      this.label_creationTime.Size = new System.Drawing.Size(83, 12);
      this.label_creationTime.TabIndex = 35;
      this.label_creationTime.Text = "CreationTime:";
      // 
      // FormPlistFileDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DimGray;
      this.ClientSize = new System.Drawing.Size(230, 151);
      this.Controls.Add(this.textBox_url);
      this.Controls.Add(this.label_url);
      this.Controls.Add(this.label_creationTime);
      this.Controls.Add(this.label_duration);
      this.Controls.Add(this.label_creationTimeShow);
      this.Controls.Add(this.label_durationShow);
      this.Controls.Add(this.label_timeWatchedShow);
      this.Controls.Add(this.label_timeWatched);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPlistFileDetails";
      this.Opacity = 0.85D;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.MouseLeave += new System.EventHandler(this.FormPlistFileDetails_MouseLeave);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_timeWatched;
    private System.Windows.Forms.Label label_duration;
    private System.Windows.Forms.Label label_timeWatchedShow;
    private System.Windows.Forms.Label label_durationShow;
    private System.Windows.Forms.Label label_url;
    private System.Windows.Forms.TextBox textBox_url;
    private System.Windows.Forms.Label label_creationTimeShow;
    private System.Windows.Forms.Label label_creationTime;
  }
}