namespace RPlayer
{
    partial class MainForm
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
      this.label_Play = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_Max = new System.Windows.Forms.Label();
      this.label_LeftEdge = new System.Windows.Forms.Label();
      this.label_TopEdge = new System.Windows.Forms.Label();
      this.label_RightEdge = new System.Windows.Forms.Label();
      this.label_BottomEdge = new System.Windows.Forms.Label();
      this.label_settings = new System.Windows.Forms.Label();
      this.label_playWnd = new System.Windows.Forms.Label();
      this.label_Volume = new System.Windows.Forms.Label();
      this.colorSlider_volume = new MB.Controls.ColorSlider();
      this.label_playlist = new System.Windows.Forms.Label();
      this.label_openFile = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // label_Play
      // 
      this.label_Play.BackColor = System.Drawing.Color.Transparent;
      this.label_Play.Location = new System.Drawing.Point(437, 513);
      this.label_Play.Name = "label_Play";
      this.label_Play.Size = new System.Drawing.Size(40, 40);
      this.label_Play.TabIndex = 19;
      this.label_Play.Click += new System.EventHandler(this.label_Play_Click);
      this.label_Play.MouseEnter += new System.EventHandler(this.label_Play_MouseEnter);
      this.label_Play.MouseLeave += new System.EventHandler(this.label_Play_MouseLeave);
      // 
      // label_Min
      // 
      this.label_Min.BackColor = System.Drawing.Color.Transparent;
      this.label_Min.Location = new System.Drawing.Point(836, 13);
      this.label_Min.Name = "label_Min";
      this.label_Min.Size = new System.Drawing.Size(13, 13);
      this.label_Min.TabIndex = 25;
      this.label_Min.Click += new System.EventHandler(this.label_Min_Click);
      this.label_Min.MouseEnter += new System.EventHandler(this.label_Min_MouseEnter);
      this.label_Min.MouseLeave += new System.EventHandler(this.label_Min_MouseLeave);
      // 
      // label_Close
      // 
      this.label_Close.BackColor = System.Drawing.Color.Transparent;
      this.label_Close.Location = new System.Drawing.Point(882, 13);
      this.label_Close.Name = "label_Close";
      this.label_Close.Size = new System.Drawing.Size(13, 13);
      this.label_Close.TabIndex = 26;
      this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
      this.label_Close.MouseEnter += new System.EventHandler(this.label_Close_MouseEnter);
      this.label_Close.MouseLeave += new System.EventHandler(this.label_Close_MouseLeave);
      // 
      // label_Max
      // 
      this.label_Max.BackColor = System.Drawing.Color.Transparent;
      this.label_Max.Location = new System.Drawing.Point(859, 13);
      this.label_Max.Name = "label_Max";
      this.label_Max.Size = new System.Drawing.Size(13, 13);
      this.label_Max.TabIndex = 27;
      this.label_Max.Click += new System.EventHandler(this.label_Max_Click);
      this.label_Max.MouseEnter += new System.EventHandler(this.label_Max_MouseEnter);
      this.label_Max.MouseLeave += new System.EventHandler(this.label_Max_MouseLeave);
      // 
      // label_LeftEdge
      // 
      this.label_LeftEdge.BackColor = System.Drawing.Color.Gray;
      this.label_LeftEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
      this.label_LeftEdge.Location = new System.Drawing.Point(1, 2);
      this.label_LeftEdge.Name = "label_LeftEdge";
      this.label_LeftEdge.Size = new System.Drawing.Size(1, 596);
      this.label_LeftEdge.TabIndex = 28;
      this.label_LeftEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_LeftEdge_MouseDown);
      this.label_LeftEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_LeftEdge_MouseMove);
      this.label_LeftEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_LeftEdge_MouseUp);
      // 
      // label_TopEdge
      // 
      this.label_TopEdge.BackColor = System.Drawing.Color.Gray;
      this.label_TopEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
      this.label_TopEdge.Location = new System.Drawing.Point(1, 1);
      this.label_TopEdge.Name = "label_TopEdge";
      this.label_TopEdge.Size = new System.Drawing.Size(913, 1);
      this.label_TopEdge.TabIndex = 29;
      this.label_TopEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_TopEdge_MouseDown);
      this.label_TopEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_TopEdge_MouseMove);
      this.label_TopEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_TopEdge_MouseUp);
      // 
      // label_RightEdge
      // 
      this.label_RightEdge.BackColor = System.Drawing.Color.Gray;
      this.label_RightEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
      this.label_RightEdge.Location = new System.Drawing.Point(913, 2);
      this.label_RightEdge.Name = "label_RightEdge";
      this.label_RightEdge.Size = new System.Drawing.Size(1, 560);
      this.label_RightEdge.TabIndex = 30;
      this.label_RightEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_RightEdge_MouseDown);
      this.label_RightEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_RightEdge_MouseMove);
      this.label_RightEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_RightEdge_MouseUp);
      // 
      // label_BottomEdge
      // 
      this.label_BottomEdge.BackColor = System.Drawing.Color.Gray;
      this.label_BottomEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
      this.label_BottomEdge.Location = new System.Drawing.Point(1, 598);
      this.label_BottomEdge.Name = "label_BottomEdge";
      this.label_BottomEdge.Size = new System.Drawing.Size(913, 1);
      this.label_BottomEdge.TabIndex = 31;
      this.label_BottomEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_BottomEdge_MouseDown);
      this.label_BottomEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_BottomEdge_MouseMove);
      this.label_BottomEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_BottomEdge_MouseUp);
      // 
      // label_settings
      // 
      this.label_settings.BackColor = System.Drawing.Color.Transparent;
      this.label_settings.Location = new System.Drawing.Point(783, 13);
      this.label_settings.Name = "label_settings";
      this.label_settings.Size = new System.Drawing.Size(13, 13);
      this.label_settings.TabIndex = 38;
      this.label_settings.Click += new System.EventHandler(this.label_settings_Click);
      this.label_settings.MouseEnter += new System.EventHandler(this.label_settings_MouseEnter);
      this.label_settings.MouseLeave += new System.EventHandler(this.label_settings_MouseLeave);
      // 
      // label_playWnd
      // 
      this.label_playWnd.AllowDrop = true;
      this.label_playWnd.BackColor = System.Drawing.Color.Transparent;
      this.label_playWnd.Location = new System.Drawing.Point(2, 39);
      this.label_playWnd.Name = "label_playWnd";
      this.label_playWnd.Size = new System.Drawing.Size(911, 454);
      this.label_playWnd.TabIndex = 39;
      this.label_playWnd.Click += new System.EventHandler(this.label_playWnd_Click);
      this.label_playWnd.DragDrop += new System.Windows.Forms.DragEventHandler(this.label_playWnd_DragDrop);
      this.label_playWnd.DragEnter += new System.Windows.Forms.DragEventHandler(this.label_playWnd_DragEnter);
      this.label_playWnd.DoubleClick += new System.EventHandler(this.label_playWnd_DoubleClick);
      this.label_playWnd.MouseEnter += new System.EventHandler(this.label_playWnd_MouseEnter);
      this.label_playWnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_playWnd_MouseMove);
      // 
      // label_Volume
      // 
      this.label_Volume.BackColor = System.Drawing.Color.Transparent;
      this.label_Volume.Location = new System.Drawing.Point(703, 519);
      this.label_Volume.Name = "label_Volume";
      this.label_Volume.Size = new System.Drawing.Size(25, 25);
      this.label_Volume.TabIndex = 36;
      this.label_Volume.Click += new System.EventHandler(this.label_Volume_Click);
      this.label_Volume.MouseEnter += new System.EventHandler(this.label_Volume_MouseEnter);
      this.label_Volume.MouseLeave += new System.EventHandler(this.label_Volume_MouseLeave);
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
      this.colorSlider_volume.Location = new System.Drawing.Point(728, 526);
      this.colorSlider_volume.MouseEffects = false;
      this.colorSlider_volume.MouseWheelBarPartitions = 100;
      this.colorSlider_volume.MouseWheelRespond = true;
      this.colorSlider_volume.Name = "colorSlider_volume";
      this.colorSlider_volume.Size = new System.Drawing.Size(100, 10);
      this.colorSlider_volume.SmallChange = ((uint)(1u));
      this.colorSlider_volume.TabIndex = 37;
      this.colorSlider_volume.ThumbInnerColor = System.Drawing.Color.White;
      this.colorSlider_volume.ThumbPenColor = System.Drawing.Color.Transparent;
      this.colorSlider_volume.ThumbRoundRectSize = new System.Drawing.Size(9, 9);
      this.colorSlider_volume.ThumbSize = 10;
      this.colorSlider_volume.Value = 100;
      this.colorSlider_volume.ValueChanged += new System.EventHandler(this.colorSlider_volume_ValueChanged);
      // 
      // label_playlist
      // 
      this.label_playlist.BackColor = System.Drawing.Color.Transparent;
      this.label_playlist.Location = new System.Drawing.Point(878, 519);
      this.label_playlist.Name = "label_playlist";
      this.label_playlist.Size = new System.Drawing.Size(25, 25);
      this.label_playlist.TabIndex = 36;
      this.label_playlist.Click += new System.EventHandler(this.label_playlist_Click);
      this.label_playlist.MouseEnter += new System.EventHandler(this.label_playlist_MouseEnter);
      this.label_playlist.MouseLeave += new System.EventHandler(this.label_playlist_MouseLeave);
      // 
      // label_openFile
      // 
      this.label_openFile.BackColor = System.Drawing.Color.Transparent;
      this.label_openFile.Cursor = System.Windows.Forms.Cursors.Hand;
      this.label_openFile.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_openFile.ForeColor = System.Drawing.Color.White;
      this.label_openFile.Location = new System.Drawing.Point(408, 266);
      this.label_openFile.Name = "label_openFile";
      this.label_openFile.Size = new System.Drawing.Size(100, 100);
      this.label_openFile.TabIndex = 40;
      this.label_openFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label_openFile.Click += new System.EventHandler(this.label_openFile_Click);
      this.label_openFile.MouseEnter += new System.EventHandler(this.label_openFile_MouseEnter);
      this.label_openFile.MouseLeave += new System.EventHandler(this.label_openFile_MouseLeave);
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(915, 562);
      this.Controls.Add(this.label_openFile);
      this.Controls.Add(this.label_playWnd);
      this.Controls.Add(this.label_settings);
      this.Controls.Add(this.colorSlider_volume);
      this.Controls.Add(this.label_playlist);
      this.Controls.Add(this.label_Volume);
      this.Controls.Add(this.label_BottomEdge);
      this.Controls.Add(this.label_RightEdge);
      this.Controls.Add(this.label_TopEdge);
      this.Controls.Add(this.label_LeftEdge);
      this.Controls.Add(this.label_Max);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.Controls.Add(this.label_Play);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
      this.Move += new System.EventHandler(this.MainForm_Move);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Play;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.Label label_LeftEdge;
        private System.Windows.Forms.Label label_TopEdge;
        private System.Windows.Forms.Label label_RightEdge;
        private System.Windows.Forms.Label label_BottomEdge;
        private System.Windows.Forms.Label label_settings;
        private System.Windows.Forms.Label label_playWnd;
        private System.Windows.Forms.Label label_Volume;
        private MB.Controls.ColorSlider colorSlider_volume;
        private System.Windows.Forms.Label label_playlist;
        private System.Windows.Forms.Label label_openFile;
        private System.Windows.Forms.Timer timer1;
    }
}

