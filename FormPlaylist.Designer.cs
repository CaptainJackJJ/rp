namespace RPlayer
{
  partial class FormPlaylist
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
      this.label_TopEdge = new System.Windows.Forms.Label();
      this.label_LeftEdge = new System.Windows.Forms.Label();
      this.label_BottomEdge = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_TopEdge
      // 
      this.label_TopEdge.BackColor = System.Drawing.Color.Gray;
      this.label_TopEdge.Cursor = System.Windows.Forms.Cursors.Default;
      this.label_TopEdge.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_TopEdge.Location = new System.Drawing.Point(0, 0);
      this.label_TopEdge.Name = "label_TopEdge";
      this.label_TopEdge.Size = new System.Drawing.Size(284, 1);
      this.label_TopEdge.TabIndex = 30;
      // 
      // label_LeftEdge
      // 
      this.label_LeftEdge.BackColor = System.Drawing.Color.Gray;
      this.label_LeftEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
      this.label_LeftEdge.Dock = System.Windows.Forms.DockStyle.Left;
      this.label_LeftEdge.Location = new System.Drawing.Point(0, 1);
      this.label_LeftEdge.Name = "label_LeftEdge";
      this.label_LeftEdge.Size = new System.Drawing.Size(1, 453);
      this.label_LeftEdge.TabIndex = 31;
      // 
      // label_BottomEdge
      // 
      this.label_BottomEdge.BackColor = System.Drawing.Color.Gray;
      this.label_BottomEdge.Cursor = System.Windows.Forms.Cursors.Default;
      this.label_BottomEdge.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.label_BottomEdge.Location = new System.Drawing.Point(1, 453);
      this.label_BottomEdge.Name = "label_BottomEdge";
      this.label_BottomEdge.Size = new System.Drawing.Size(283, 1);
      this.label_BottomEdge.TabIndex = 32;
      // 
      // FormPlaylist
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(284, 454);
      this.Controls.Add(this.label_BottomEdge);
      this.Controls.Add(this.label_LeftEdge);
      this.Controls.Add(this.label_TopEdge);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPlaylist";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormPlaylist";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label_TopEdge;
    private System.Windows.Forms.Label label_LeftEdge;
    private System.Windows.Forms.Label label_BottomEdge;
  }
}