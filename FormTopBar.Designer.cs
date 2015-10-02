namespace RPlayer
{
  partial class FormTopBar
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
      this.label_Max = new System.Windows.Forms.Label();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.label_fileName = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_settings
      // 
      this.label_settings.BackColor = System.Drawing.Color.Transparent;
      this.label_settings.Location = new System.Drawing.Point(790, 11);
      this.label_settings.Name = "label_settings";
      this.label_settings.Size = new System.Drawing.Size(13, 13);
      this.label_settings.TabIndex = 42;
      this.label_settings.Click += new System.EventHandler(this.label_settings_Click);
      this.label_settings.MouseEnter += new System.EventHandler(this.label_settings_MouseEnter);
      this.label_settings.MouseLeave += new System.EventHandler(this.label_settings_MouseLeave);
      // 
      // label_Max
      // 
      this.label_Max.BackColor = System.Drawing.Color.Transparent;
      this.label_Max.Location = new System.Drawing.Point(866, 11);
      this.label_Max.Name = "label_Max";
      this.label_Max.Size = new System.Drawing.Size(13, 13);
      this.label_Max.TabIndex = 41;
      this.label_Max.Click += new System.EventHandler(this.label_Max_Click);
      this.label_Max.MouseEnter += new System.EventHandler(this.label_Max_MouseEnter);
      this.label_Max.MouseLeave += new System.EventHandler(this.label_Max_MouseLeave);
      // 
      // label_Close
      // 
      this.label_Close.BackColor = System.Drawing.Color.Transparent;
      this.label_Close.Location = new System.Drawing.Point(889, 11);
      this.label_Close.Name = "label_Close";
      this.label_Close.Size = new System.Drawing.Size(13, 13);
      this.label_Close.TabIndex = 40;
      this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
      this.label_Close.MouseEnter += new System.EventHandler(this.label_Close_MouseEnter);
      this.label_Close.MouseLeave += new System.EventHandler(this.label_Close_MouseLeave);
      // 
      // label_Min
      // 
      this.label_Min.BackColor = System.Drawing.Color.Transparent;
      this.label_Min.Location = new System.Drawing.Point(843, 11);
      this.label_Min.Name = "label_Min";
      this.label_Min.Size = new System.Drawing.Size(13, 13);
      this.label_Min.TabIndex = 39;
      this.label_Min.Click += new System.EventHandler(this.label_Min_Click);
      this.label_Min.MouseEnter += new System.EventHandler(this.label_Min_MouseEnter);
      this.label_Min.MouseLeave += new System.EventHandler(this.label_Min_MouseLeave);
      // 
      // label_fileName
      // 
      this.label_fileName.BackColor = System.Drawing.Color.Transparent;
      this.label_fileName.ForeColor = System.Drawing.Color.White;
      this.label_fileName.Location = new System.Drawing.Point(130, 7);
      this.label_fileName.Name = "label_fileName";
      this.label_fileName.Size = new System.Drawing.Size(650, 23);
      this.label_fileName.TabIndex = 43;
      this.label_fileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_fileName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseDown);
      this.label_fileName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseMove);
      this.label_fileName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseUp);
      // 
      // FormTopBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(915, 37);
      this.Controls.Add(this.label_fileName);
      this.Controls.Add(this.label_settings);
      this.Controls.Add(this.label_Max);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormTopBar";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseUp);
      this.Resize += new System.EventHandler(this.FormTopBar_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label_settings;
    private System.Windows.Forms.Label label_Max;
    private System.Windows.Forms.Label label_Close;
    private System.Windows.Forms.Label label_Min;
    private System.Windows.Forms.Label label_fileName;
  }
}