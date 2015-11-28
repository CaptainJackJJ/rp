namespace RPlayer
{
  partial class FormVolumeDisplay
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
      this.components = new System.ComponentModel.Container();
      this.label_volume = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // label_volume
      // 
      this.label_volume.AutoSize = true;
      this.label_volume.BackColor = System.Drawing.Color.Transparent;
      this.label_volume.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_volume.Location = new System.Drawing.Point(9, 7);
      this.label_volume.Name = "label_volume";
      this.label_volume.Size = new System.Drawing.Size(54, 21);
      this.label_volume.TabIndex = 0;
      this.label_volume.Text = "100%";
      this.label_volume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // FormVolumeDisplay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(61, 35);
      this.Controls.Add(this.label_volume);
      this.ForeColor = System.Drawing.Color.Transparent;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormVolumeDisplay";
      this.Opacity = 0.5D;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_volume;
    private System.Windows.Forms.Timer timer1;
  }
}