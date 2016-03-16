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
      this.components = new System.ComponentModel.Container();
      this.label_settings = new System.Windows.Forms.Label();
      this.label_Max = new System.Windows.Forms.Label();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.label_fileName = new System.Windows.Forms.Label();
      this.label_curTime = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label_logo = new System.Windows.Forms.Label();
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
      this.label_fileName.ForeColor = System.Drawing.Color.Gainsboro;
      this.label_fileName.Location = new System.Drawing.Point(225, 7);
      this.label_fileName.Name = "label_fileName";
      this.label_fileName.Size = new System.Drawing.Size(465, 23);
      this.label_fileName.TabIndex = 43;
      this.label_fileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_fileName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseDown);
      this.label_fileName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseMove);
      this.label_fileName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseUp);
      // 
      // label_curTime
      // 
      this.label_curTime.BackColor = System.Drawing.Color.Transparent;
      this.label_curTime.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_curTime.ForeColor = System.Drawing.Color.White;
      this.label_curTime.Location = new System.Drawing.Point(695, 7);
      this.label_curTime.Name = "label_curTime";
      this.label_curTime.Size = new System.Drawing.Size(72, 23);
      this.label_curTime.TabIndex = 43;
      this.label_curTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_curTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseDown);
      this.label_curTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseMove);
      this.label_curTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseUp);
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label_logo
      // 
      this.label_logo.AutoSize = true;
      this.label_logo.BackColor = System.Drawing.Color.Transparent;
      this.label_logo.Cursor = System.Windows.Forms.Cursors.Hand;
      this.label_logo.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_logo.ForeColor = System.Drawing.Color.White;
      this.label_logo.Location = new System.Drawing.Point(4, 6);
      this.label_logo.Name = "label_logo";
      this.label_logo.Size = new System.Drawing.Size(166, 24);
      this.label_logo.TabIndex = 44;
      this.label_logo.Text = "RabbitPlayer";
      this.label_logo.Click += new System.EventHandler(this.label_logo_Click);
      this.label_logo.MouseEnter += new System.EventHandler(this.label_logo_MouseEnter);
      this.label_logo.MouseLeave += new System.EventHandler(this.label_logo_MouseLeave);
      // 
      // FormTopBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(915, 37);
      this.Controls.Add(this.label_logo);
      this.Controls.Add(this.label_curTime);
      this.Controls.Add(this.label_fileName);
      this.Controls.Add(this.label_settings);
      this.Controls.Add(this.label_Max);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormTopBar";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Load += new System.EventHandler(this.FormTopBar_Load);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTopBar_MouseUp);
      this.Resize += new System.EventHandler(this.FormTopBar_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_settings;
    private System.Windows.Forms.Label label_Max;
    private System.Windows.Forms.Label label_Close;
    private System.Windows.Forms.Label label_Min;
    private System.Windows.Forms.Label label_fileName;
    private System.Windows.Forms.Label label_curTime;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label_logo;
  }
}