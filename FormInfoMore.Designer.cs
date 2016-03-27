namespace RPlayer
{
  partial class FormInfoMore
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
      this.label_Close = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.label_InfoUpdateNotice = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_Close
      // 
      this.label_Close.BackColor = System.Drawing.Color.Transparent;
      this.label_Close.Location = new System.Drawing.Point(886, 9);
      this.label_Close.Name = "label_Close";
      this.label_Close.Size = new System.Drawing.Size(13, 13);
      this.label_Close.TabIndex = 28;
      this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
      this.label_Close.MouseEnter += new System.EventHandler(this.label_Close_MouseEnter);
      this.label_Close.MouseLeave += new System.EventHandler(this.label_Close_MouseLeave);
      // 
      // label_Min
      // 
      this.label_Min.BackColor = System.Drawing.Color.Transparent;
      this.label_Min.Location = new System.Drawing.Point(858, 9);
      this.label_Min.Name = "label_Min";
      this.label_Min.Size = new System.Drawing.Size(13, 13);
      this.label_Min.TabIndex = 27;
      this.label_Min.Click += new System.EventHandler(this.label_Min_Click);
      this.label_Min.MouseEnter += new System.EventHandler(this.label_Min_MouseEnter);
      this.label_Min.MouseLeave += new System.EventHandler(this.label_Min_MouseLeave);
      // 
      // label_InfoUpdateNotice
      // 
      this.label_InfoUpdateNotice.AutoSize = true;
      this.label_InfoUpdateNotice.BackColor = System.Drawing.Color.Transparent;
      this.label_InfoUpdateNotice.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_InfoUpdateNotice.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_InfoUpdateNotice.ForeColor = System.Drawing.Color.White;
      this.label_InfoUpdateNotice.Location = new System.Drawing.Point(12, 10);
      this.label_InfoUpdateNotice.Name = "label_InfoUpdateNotice";
      this.label_InfoUpdateNotice.Size = new System.Drawing.Size(0, 12);
      this.label_InfoUpdateNotice.TabIndex = 46;
      // 
      // FormInfoMore
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(75)))), ((int)(((byte)(92)))));
      this.ClientSize = new System.Drawing.Size(911, 720);
      this.Controls.Add(this.label_InfoUpdateNotice);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormInfoMore";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormInfoMore";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInfoMore_FormClosing);
      this.Shown += new System.EventHandler(this.FormInfoMore_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_Close;
    private System.Windows.Forms.Label label_Min;
    private System.Windows.Forms.Label label_InfoUpdateNotice;
  }
}