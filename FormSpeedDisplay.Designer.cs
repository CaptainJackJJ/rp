namespace RPlayer
{
  partial class FormSpeedDisplay
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
      this.label_speed = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_speed
      // 
      this.label_speed.AutoSize = true;
      this.label_speed.BackColor = System.Drawing.Color.Transparent;
      this.label_speed.Location = new System.Drawing.Point(9, 8);
      this.label_speed.Name = "label_speed";
      this.label_speed.Size = new System.Drawing.Size(71, 12);
      this.label_speed.TabIndex = 0;
      this.label_speed.Text = "Speed: X-16";
      this.label_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // FormSpeedDisplay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(84, 28);
      this.Controls.Add(this.label_speed);
      this.ForeColor = System.Drawing.Color.Transparent;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormSpeedDisplay";
      this.Opacity = 0.5D;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_speed;
  }
}