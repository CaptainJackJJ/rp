namespace PRResource
{
  partial class FormDownload
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownload));
      this.label_progress = new System.Windows.Forms.Label();
      this.textBoxFileName = new System.Windows.Forms.TextBox();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_progress
      // 
      this.label_progress.AutoSize = true;
      this.label_progress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.label_progress.Location = new System.Drawing.Point(153, 12);
      this.label_progress.Name = "label_progress";
      this.label_progress.Size = new System.Drawing.Size(59, 12);
      this.label_progress.TabIndex = 52;
      this.label_progress.Text = "已下载 1%";
      // 
      // textBoxFileName
      // 
      this.textBoxFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
      this.textBoxFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBoxFileName.ForeColor = System.Drawing.Color.WhiteSmoke;
      this.textBoxFileName.Location = new System.Drawing.Point(7, 35);
      this.textBoxFileName.Name = "textBoxFileName";
      this.textBoxFileName.ReadOnly = true;
      this.textBoxFileName.Size = new System.Drawing.Size(354, 14);
      this.textBoxFileName.TabIndex = 53;
      this.textBoxFileName.Text = "叶问3【720p.BluRay-4.37GB】【国粤中字】.torrent";
      this.textBoxFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label_Close
      // 
      this.label_Close.BackColor = System.Drawing.Color.Transparent;
      this.label_Close.Location = new System.Drawing.Point(344, 9);
      this.label_Close.Name = "label_Close";
      this.label_Close.Size = new System.Drawing.Size(13, 13);
      this.label_Close.TabIndex = 55;
      this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
      this.label_Close.MouseEnter += new System.EventHandler(this.label_Close_MouseEnter);
      this.label_Close.MouseLeave += new System.EventHandler(this.label_Close_MouseLeave);
      // 
      // label_Min
      // 
      this.label_Min.BackColor = System.Drawing.Color.Transparent;
      this.label_Min.Location = new System.Drawing.Point(319, 9);
      this.label_Min.Name = "label_Min";
      this.label_Min.Size = new System.Drawing.Size(13, 13);
      this.label_Min.TabIndex = 54;
      this.label_Min.Click += new System.EventHandler(this.label_Min_Click);
      this.label_Min.MouseEnter += new System.EventHandler(this.label_Min_MouseEnter);
      this.label_Min.MouseLeave += new System.EventHandler(this.label_Min_MouseLeave);
      // 
      // FormDownload
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
      this.ClientSize = new System.Drawing.Size(369, 60);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.Controls.Add(this.label_progress);
      this.Controls.Add(this.textBoxFileName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormDownload";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Load += new System.EventHandler(this.FormDownload_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_progress;
    private System.Windows.Forms.TextBox textBoxFileName;
    private System.Windows.Forms.Label label_Close;
    private System.Windows.Forms.Label label_Min;
  }
}