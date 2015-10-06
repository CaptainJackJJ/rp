namespace RPlayer
{
  partial class FormBottomBar
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
      this.colorSlider_volume = new MB.Controls.ColorSlider();
      this.label_desktop = new System.Windows.Forms.Label();
      this.label_timeLast = new System.Windows.Forms.Label();
      this.label_timeCurrent = new System.Windows.Forms.Label();
      this.colorSlider_playProcess = new MB.Controls.ColorSlider();
      this.label_Volume = new System.Windows.Forms.Label();
      this.label_Pre = new System.Windows.Forms.Label();
      this.label_Next = new System.Windows.Forms.Label();
      this.label_Stop = new System.Windows.Forms.Label();
      this.label_Play = new System.Windows.Forms.Label();
      this.label_FB = new System.Windows.Forms.Label();
      this.label_FF = new System.Windows.Forms.Label();
      this.timer_updateProcessBar = new System.Windows.Forms.Timer(this.components);
      this.label_playlist = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // colorSlider_volume
      // 
      this.colorSlider_volume.BackColor = System.Drawing.Color.Transparent;
      this.colorSlider_volume.BarInnerColor = System.Drawing.Color.Gray;
      this.colorSlider_volume.BarOuterColor = System.Drawing.Color.Transparent;
      this.colorSlider_volume.BarPenColor = System.Drawing.Color.Transparent;
      this.colorSlider_volume.BorderRoundRectSize = new System.Drawing.Size(1, 1);
      this.colorSlider_volume.Cursor = System.Windows.Forms.Cursors.Hand;
      this.colorSlider_volume.DrawFocusRectangle = false;
      this.colorSlider_volume.ElapsedInnerColor = System.Drawing.Color.RoyalBlue;
      this.colorSlider_volume.ElapsedOuterColor = System.Drawing.Color.MidnightBlue;
      this.colorSlider_volume.KeyPressRespond = true;
      this.colorSlider_volume.LargeChange = ((uint)(5u));
      this.colorSlider_volume.Location = new System.Drawing.Point(739, 35);
      this.colorSlider_volume.MouseEffects = false;
      this.colorSlider_volume.MouseWheelBarPartitions = 100;
      this.colorSlider_volume.MouseWheelRespond = true;
      this.colorSlider_volume.Name = "colorSlider_volume";
      this.colorSlider_volume.Size = new System.Drawing.Size(100, 10);
      this.colorSlider_volume.SmallChange = ((uint)(1u));
      this.colorSlider_volume.TabIndex = 42;
      this.colorSlider_volume.ThumbInnerColor = System.Drawing.Color.White;
      this.colorSlider_volume.ThumbPenColor = System.Drawing.Color.Transparent;
      this.colorSlider_volume.ThumbRoundRectSize = new System.Drawing.Size(9, 9);
      this.colorSlider_volume.ThumbSize = 10;
      this.colorSlider_volume.Value = 100;
      this.colorSlider_volume.ValueChanged += new System.EventHandler(this.colorSlider_volume_ValueChanged);
      // 
      // label_desktop
      // 
      this.label_desktop.BackColor = System.Drawing.Color.Transparent;
      this.label_desktop.Location = new System.Drawing.Point(847, 37);
      this.label_desktop.Name = "label_desktop";
      this.label_desktop.Size = new System.Drawing.Size(25, 25);
      this.label_desktop.TabIndex = 41;
      this.label_desktop.Click += new System.EventHandler(this.label_desktop_Click);
      this.label_desktop.MouseEnter += new System.EventHandler(this.label_desktop_MouseEnter);
      this.label_desktop.MouseLeave += new System.EventHandler(this.label_desktop_MouseLeave);
      // 
      // label_timeLast
      // 
      this.label_timeLast.AutoSize = true;
      this.label_timeLast.BackColor = System.Drawing.Color.Transparent;
      this.label_timeLast.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_timeLast.ForeColor = System.Drawing.Color.White;
      this.label_timeLast.Location = new System.Drawing.Point(811, 3);
      this.label_timeLast.Name = "label_timeLast";
      this.label_timeLast.Size = new System.Drawing.Size(77, 17);
      this.label_timeLast.TabIndex = 40;
      this.label_timeLast.Text = "-01 : 00 : 30";
      this.label_timeLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label_timeCurrent
      // 
      this.label_timeCurrent.AutoSize = true;
      this.label_timeCurrent.BackColor = System.Drawing.Color.Transparent;
      this.label_timeCurrent.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_timeCurrent.ForeColor = System.Drawing.Color.White;
      this.label_timeCurrent.Location = new System.Drawing.Point(18, 3);
      this.label_timeCurrent.Name = "label_timeCurrent";
      this.label_timeCurrent.Size = new System.Drawing.Size(72, 17);
      this.label_timeCurrent.TabIndex = 39;
      this.label_timeCurrent.Text = "00 : 00 : 00";
      this.label_timeCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // colorSlider_playProcess
      // 
      this.colorSlider_playProcess.BackColor = System.Drawing.Color.Transparent;
      this.colorSlider_playProcess.BarInnerColor = System.Drawing.Color.Gray;
      this.colorSlider_playProcess.BarOuterColor = System.Drawing.Color.Transparent;
      this.colorSlider_playProcess.BarPenColor = System.Drawing.Color.Transparent;
      this.colorSlider_playProcess.BorderRoundRectSize = new System.Drawing.Size(1, 1);
      this.colorSlider_playProcess.Cursor = System.Windows.Forms.Cursors.Hand;
      this.colorSlider_playProcess.DrawFocusRectangle = false;
      this.colorSlider_playProcess.ElapsedInnerColor = System.Drawing.Color.RoyalBlue;
      this.colorSlider_playProcess.ElapsedOuterColor = System.Drawing.Color.MidnightBlue;
      this.colorSlider_playProcess.LargeChange = ((uint)(5u));
      this.colorSlider_playProcess.Location = new System.Drawing.Point(93, 6);
      this.colorSlider_playProcess.MouseEffects = false;
      this.colorSlider_playProcess.MouseWheelBarPartitions = 100;
      this.colorSlider_playProcess.Name = "colorSlider_playProcess";
      this.colorSlider_playProcess.Size = new System.Drawing.Size(715, 10);
      this.colorSlider_playProcess.SmallChange = ((uint)(1u));
      this.colorSlider_playProcess.TabIndex = 38;
      this.colorSlider_playProcess.ThumbInnerColor = System.Drawing.Color.Transparent;
      this.colorSlider_playProcess.ThumbOuterColor = System.Drawing.Color.Transparent;
      this.colorSlider_playProcess.ThumbPenColor = System.Drawing.Color.Transparent;
      this.colorSlider_playProcess.ThumbRoundRectSize = new System.Drawing.Size(9, 9);
      this.colorSlider_playProcess.ThumbSize = 9;
      this.colorSlider_playProcess.Value = 0;
      this.colorSlider_playProcess.ValueChanged += new System.EventHandler(this.colorSlider_playProcess_ValueChanged);
      this.colorSlider_playProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorSlider_playProcess_MouseDown);
      this.colorSlider_playProcess.MouseEnter += new System.EventHandler(this.colorSlider_playProcess_MouseEnter);
      this.colorSlider_playProcess.MouseLeave += new System.EventHandler(this.colorSlider_playProcess_MouseLeave);
      this.colorSlider_playProcess.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorSlider_playProcess_MouseUp);
      // 
      // label_Volume
      // 
      this.label_Volume.BackColor = System.Drawing.Color.Transparent;
      this.label_Volume.Location = new System.Drawing.Point(710, 28);
      this.label_Volume.Name = "label_Volume";
      this.label_Volume.Size = new System.Drawing.Size(25, 25);
      this.label_Volume.TabIndex = 47;
      this.label_Volume.Click += new System.EventHandler(this.label_Volume_Click);
      this.label_Volume.MouseEnter += new System.EventHandler(this.label_Volume_MouseEnter);
      this.label_Volume.MouseLeave += new System.EventHandler(this.label_Volume_MouseLeave);
      // 
      // label_Pre
      // 
      this.label_Pre.BackColor = System.Drawing.Color.Transparent;
      this.label_Pre.Location = new System.Drawing.Point(346, 28);
      this.label_Pre.Name = "label_Pre";
      this.label_Pre.Size = new System.Drawing.Size(25, 25);
      this.label_Pre.TabIndex = 46;
      this.label_Pre.Click += new System.EventHandler(this.label_Pre_Click);
      this.label_Pre.MouseEnter += new System.EventHandler(this.label_Pre_MouseEnter);
      this.label_Pre.MouseLeave += new System.EventHandler(this.label_Pre_MouseLeave);
      // 
      // label_Next
      // 
      this.label_Next.BackColor = System.Drawing.Color.Transparent;
      this.label_Next.Location = new System.Drawing.Point(521, 28);
      this.label_Next.Name = "label_Next";
      this.label_Next.Size = new System.Drawing.Size(25, 25);
      this.label_Next.TabIndex = 45;
      this.label_Next.Click += new System.EventHandler(this.label_Next_Click);
      this.label_Next.MouseEnter += new System.EventHandler(this.label_Next_MouseEnter);
      this.label_Next.MouseLeave += new System.EventHandler(this.label_Next_MouseLeave);
      // 
      // label_Stop
      // 
      this.label_Stop.BackColor = System.Drawing.Color.Transparent;
      this.label_Stop.Location = new System.Drawing.Point(386, 28);
      this.label_Stop.Name = "label_Stop";
      this.label_Stop.Size = new System.Drawing.Size(25, 25);
      this.label_Stop.TabIndex = 44;
      this.label_Stop.Click += new System.EventHandler(this.label_Stop_Click);
      this.label_Stop.MouseEnter += new System.EventHandler(this.label_Stop_MouseEnter);
      this.label_Stop.MouseLeave += new System.EventHandler(this.label_Stop_MouseLeave);
      // 
      // label_Play
      // 
      this.label_Play.BackColor = System.Drawing.Color.Transparent;
      this.label_Play.Location = new System.Drawing.Point(426, 22);
      this.label_Play.Name = "label_Play";
      this.label_Play.Size = new System.Drawing.Size(40, 40);
      this.label_Play.TabIndex = 43;
      this.label_Play.Click += new System.EventHandler(this.label_Play_Click);
      this.label_Play.MouseEnter += new System.EventHandler(this.label_Play_MouseEnter);
      this.label_Play.MouseLeave += new System.EventHandler(this.label_Play_MouseLeave);
      // 
      // label_FB
      // 
      this.label_FB.BackColor = System.Drawing.Color.Transparent;
      this.label_FB.Location = new System.Drawing.Point(484, 28);
      this.label_FB.Name = "label_FB";
      this.label_FB.Size = new System.Drawing.Size(25, 25);
      this.label_FB.TabIndex = 48;
      this.label_FB.Click += new System.EventHandler(this.label_FB_Click);
      this.label_FB.MouseEnter += new System.EventHandler(this.label_FB_MouseEnter);
      this.label_FB.MouseLeave += new System.EventHandler(this.label_FB_MouseLeave);
      // 
      // label_FF
      // 
      this.label_FF.BackColor = System.Drawing.Color.Transparent;
      this.label_FF.Location = new System.Drawing.Point(515, 31);
      this.label_FF.Name = "label_FF";
      this.label_FF.Size = new System.Drawing.Size(25, 25);
      this.label_FF.TabIndex = 49;
      this.label_FF.Click += new System.EventHandler(this.label_FF_Click);
      this.label_FF.MouseEnter += new System.EventHandler(this.label_FF_MouseEnter);
      this.label_FF.MouseLeave += new System.EventHandler(this.label_FF_MouseLeave);
      // 
      // timer_updateProcessBar
      // 
      this.timer_updateProcessBar.Interval = 1000;
      this.timer_updateProcessBar.Tick += new System.EventHandler(this.timer_updateProcessBar_Tick);
      // 
      // label_playlist
      // 
      this.label_playlist.BackColor = System.Drawing.Color.Transparent;
      this.label_playlist.Location = new System.Drawing.Point(883, 31);
      this.label_playlist.Name = "label_playlist";
      this.label_playlist.Size = new System.Drawing.Size(25, 25);
      this.label_playlist.TabIndex = 50;
      this.label_playlist.Click += new System.EventHandler(this.label_playlist_Click);
      this.label_playlist.MouseEnter += new System.EventHandler(this.label_playlist_MouseEnter);
      this.label_playlist.MouseLeave += new System.EventHandler(this.label_playlist_MouseLeave);
      // 
      // FormBottomBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(915, 65);
      this.Controls.Add(this.label_playlist);
      this.Controls.Add(this.label_FF);
      this.Controls.Add(this.label_FB);
      this.Controls.Add(this.label_Volume);
      this.Controls.Add(this.label_Pre);
      this.Controls.Add(this.label_Next);
      this.Controls.Add(this.label_Stop);
      this.Controls.Add(this.label_Play);
      this.Controls.Add(this.colorSlider_volume);
      this.Controls.Add(this.label_desktop);
      this.Controls.Add(this.label_timeLast);
      this.Controls.Add(this.label_timeCurrent);
      this.Controls.Add(this.colorSlider_playProcess);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormBottomBar";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Resize += new System.EventHandler(this.FormBottomBar_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MB.Controls.ColorSlider colorSlider_volume;
    private System.Windows.Forms.Label label_desktop;
    private System.Windows.Forms.Label label_timeLast;
    private System.Windows.Forms.Label label_timeCurrent;
    private MB.Controls.ColorSlider colorSlider_playProcess;
    private System.Windows.Forms.Label label_Volume;
    private System.Windows.Forms.Label label_Pre;
    private System.Windows.Forms.Label label_Next;
    private System.Windows.Forms.Label label_Stop;
    private System.Windows.Forms.Label label_Play;
    private System.Windows.Forms.Label label_FB;
    private System.Windows.Forms.Label label_FF;
    private System.Windows.Forms.Timer timer_updateProcessBar;
    private System.Windows.Forms.Label label_playlist;
  }
}