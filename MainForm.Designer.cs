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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.label_Play = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_LeftEdge = new System.Windows.Forms.Label();
      this.label_TopEdge = new System.Windows.Forms.Label();
      this.label_RightEdge = new System.Windows.Forms.Label();
      this.label_BottomEdge = new System.Windows.Forms.Label();
      this.label_settings = new System.Windows.Forms.Label();
      this.label_playWnd = new System.Windows.Forms.Label();
      this.label_playlist = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label_logo = new System.Windows.Forms.Label();
      this.label_share = new System.Windows.Forms.Label();
      this.button_openFile = new System.Windows.Forms.Button();
      this.label_InfoUpdateNotice = new System.Windows.Forms.Label();
      this.label_help = new System.Windows.Forms.Label();
      this.label_Max = new System.Windows.Forms.Label();
      this.button_onlineRes = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label_Play
      // 
      this.label_Play.BackColor = System.Drawing.Color.Transparent;
      this.label_Play.Location = new System.Drawing.Point(472, 667);
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
      // label_LeftEdge
      // 
      this.label_LeftEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_LeftEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
      this.label_LeftEdge.Location = new System.Drawing.Point(1, 2);
      this.label_LeftEdge.Name = "label_LeftEdge";
      this.label_LeftEdge.Size = new System.Drawing.Size(1, 765);
      this.label_LeftEdge.TabIndex = 28;
      this.label_LeftEdge.Visible = false;
      // 
      // label_TopEdge
      // 
      this.label_TopEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_TopEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
      this.label_TopEdge.Location = new System.Drawing.Point(1, 1);
      this.label_TopEdge.Name = "label_TopEdge";
      this.label_TopEdge.Size = new System.Drawing.Size(1022, 1);
      this.label_TopEdge.TabIndex = 29;
      this.label_TopEdge.Visible = false;
      // 
      // label_RightEdge
      // 
      this.label_RightEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_RightEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
      this.label_RightEdge.Location = new System.Drawing.Point(1022, 2);
      this.label_RightEdge.Name = "label_RightEdge";
      this.label_RightEdge.Size = new System.Drawing.Size(1, 766);
      this.label_RightEdge.TabIndex = 30;
      this.label_RightEdge.Visible = false;
      // 
      // label_BottomEdge
      // 
      this.label_BottomEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_BottomEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
      this.label_BottomEdge.Location = new System.Drawing.Point(1, 766);
      this.label_BottomEdge.Name = "label_BottomEdge";
      this.label_BottomEdge.Size = new System.Drawing.Size(1022, 1);
      this.label_BottomEdge.TabIndex = 31;
      this.label_BottomEdge.Visible = false;
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
      this.label_playWnd.Location = new System.Drawing.Point(2, 46);
      this.label_playWnd.Name = "label_playWnd";
      this.label_playWnd.Size = new System.Drawing.Size(1020, 586);
      this.label_playWnd.TabIndex = 39;
      this.label_playWnd.Visible = false;
      this.label_playWnd.Click += new System.EventHandler(this.label_playWnd_Click);
      this.label_playWnd.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
      this.label_playWnd.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
      this.label_playWnd.DoubleClick += new System.EventHandler(this.label_playWnd_DoubleClick);
      this.label_playWnd.MouseEnter += new System.EventHandler(this.label_playWnd_MouseEnter);
      this.label_playWnd.MouseLeave += new System.EventHandler(this.label_playWnd_MouseLeave);
      this.label_playWnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_playWnd_MouseMove);
      // 
      // label_playlist
      // 
      this.label_playlist.BackColor = System.Drawing.Color.Transparent;
      this.label_playlist.Location = new System.Drawing.Point(878, 519);
      this.label_playlist.Name = "label_playlist";
      this.label_playlist.Size = new System.Drawing.Size(25, 25);
      this.label_playlist.TabIndex = 36;
      this.label_playlist.Visible = false;
      this.label_playlist.Click += new System.EventHandler(this.label_playlist_Click);
      this.label_playlist.MouseEnter += new System.EventHandler(this.label_playlist_MouseEnter);
      this.label_playlist.MouseLeave += new System.EventHandler(this.label_playlist_MouseLeave);
      // 
      // timer1
      // 
      this.timer1.Interval = 200;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label_logo
      // 
      this.label_logo.AutoSize = true;
      this.label_logo.BackColor = System.Drawing.Color.Transparent;
      this.label_logo.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_logo.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_logo.ForeColor = System.Drawing.Color.White;
      this.label_logo.Location = new System.Drawing.Point(10, 6);
      this.label_logo.Name = "label_logo";
      this.label_logo.Size = new System.Drawing.Size(0, 24);
      this.label_logo.TabIndex = 45;
      this.label_logo.Click += new System.EventHandler(this.label_logo_Click);
      this.label_logo.MouseEnter += new System.EventHandler(this.label_logo_MouseEnter);
      this.label_logo.MouseLeave += new System.EventHandler(this.label_logo_MouseLeave);
      // 
      // label_share
      // 
      this.label_share.AutoSize = true;
      this.label_share.BackColor = System.Drawing.Color.Transparent;
      this.label_share.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_share.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_share.ForeColor = System.Drawing.Color.White;
      this.label_share.Location = new System.Drawing.Point(897, 683);
      this.label_share.Name = "label_share";
      this.label_share.Size = new System.Drawing.Size(31, 12);
      this.label_share.TabIndex = 45;
      this.label_share.Text = "分享";
      this.label_share.Click += new System.EventHandler(this.label_share_Click);
      this.label_share.MouseEnter += new System.EventHandler(this.label_share_MouseEnter);
      this.label_share.MouseLeave += new System.EventHandler(this.label_share_MouseLeave);
      // 
      // button_openFile
      // 
      this.button_openFile.AutoSize = true;
      this.button_openFile.BackColor = System.Drawing.Color.Transparent;
      this.button_openFile.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.button_openFile.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
      this.button_openFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
      this.button_openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_openFile.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_openFile.ForeColor = System.Drawing.Color.White;
      this.button_openFile.Location = new System.Drawing.Point(10, 671);
      this.button_openFile.Name = "button_openFile";
      this.button_openFile.Size = new System.Drawing.Size(112, 38);
      this.button_openFile.TabIndex = 46;
      this.button_openFile.Text = "打开文件";
      this.button_openFile.UseVisualStyleBackColor = false;
      this.button_openFile.Click += new System.EventHandler(this.button_openFile_Click);
      // 
      // label_InfoUpdateNotice
      // 
      this.label_InfoUpdateNotice.AutoSize = true;
      this.label_InfoUpdateNotice.BackColor = System.Drawing.Color.Transparent;
      this.label_InfoUpdateNotice.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_InfoUpdateNotice.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_InfoUpdateNotice.ForeColor = System.Drawing.Color.White;
      this.label_InfoUpdateNotice.Location = new System.Drawing.Point(407, 13);
      this.label_InfoUpdateNotice.Name = "label_InfoUpdateNotice";
      this.label_InfoUpdateNotice.Size = new System.Drawing.Size(0, 12);
      this.label_InfoUpdateNotice.TabIndex = 45;
      // 
      // label_help
      // 
      this.label_help.AutoSize = true;
      this.label_help.BackColor = System.Drawing.Color.Transparent;
      this.label_help.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_help.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_help.ForeColor = System.Drawing.Color.White;
      this.label_help.Location = new System.Drawing.Point(941, 683);
      this.label_help.Name = "label_help";
      this.label_help.Size = new System.Drawing.Size(31, 12);
      this.label_help.TabIndex = 45;
      this.label_help.Text = "求助";
      this.label_help.Click += new System.EventHandler(this.label_help_Click);
      this.label_help.MouseEnter += new System.EventHandler(this.label_help_MouseEnter);
      this.label_help.MouseLeave += new System.EventHandler(this.label_help_MouseLeave);
      // 
      // label_Max
      // 
      this.label_Max.BackColor = System.Drawing.Color.Transparent;
      this.label_Max.Location = new System.Drawing.Point(0, 0);
      this.label_Max.Name = "label_Max";
      this.label_Max.Size = new System.Drawing.Size(13, 13);
      this.label_Max.TabIndex = 51;
      this.label_Max.Click += new System.EventHandler(this.label_Max_Click);
      this.label_Max.MouseEnter += new System.EventHandler(this.label_Max_MouseEnter);
      this.label_Max.MouseLeave += new System.EventHandler(this.label_Max_MouseLeave);
      // 
      // button_onlineRes
      // 
      this.button_onlineRes.BackColor = System.Drawing.Color.DarkSalmon;
      this.button_onlineRes.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
      this.button_onlineRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
      this.button_onlineRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_onlineRes.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_onlineRes.ForeColor = System.Drawing.Color.White;
      this.button_onlineRes.Location = new System.Drawing.Point(785, 5);
      this.button_onlineRes.Name = "button_onlineRes";
      this.button_onlineRes.Size = new System.Drawing.Size(112, 38);
      this.button_onlineRes.TabIndex = 52;
      this.button_onlineRes.Text = "在线资源";
      this.button_onlineRes.UseVisualStyleBackColor = false;
      this.button_onlineRes.Click += new System.EventHandler(this.button_onlineRes_Click);
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.ClientSize = new System.Drawing.Size(1024, 720);
      this.Controls.Add(this.button_onlineRes);
      this.Controls.Add(this.button_openFile);
      this.Controls.Add(this.label_playWnd);
      this.Controls.Add(this.label_help);
      this.Controls.Add(this.label_share);
      this.Controls.Add(this.label_InfoUpdateNotice);
      this.Controls.Add(this.label_logo);
      this.Controls.Add(this.label_playlist);
      this.Controls.Add(this.label_BottomEdge);
      this.Controls.Add(this.label_RightEdge);
      this.Controls.Add(this.label_TopEdge);
      this.Controls.Add(this.label_LeftEdge);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.Controls.Add(this.label_Max);
      this.Controls.Add(this.label_Play);
      this.Controls.Add(this.label_settings);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "海盗兔影音";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
      this.Move += new System.EventHandler(this.MainForm_Move);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Play;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_LeftEdge;
        private System.Windows.Forms.Label label_TopEdge;
        private System.Windows.Forms.Label label_RightEdge;
        private System.Windows.Forms.Label label_BottomEdge;
        private System.Windows.Forms.Label label_settings;
        private System.Windows.Forms.Label label_playWnd;
        private System.Windows.Forms.Label label_playlist;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_logo;
        private System.Windows.Forms.Label label_share;
        private System.Windows.Forms.Button button_openFile;
        private System.Windows.Forms.Label label_InfoUpdateNotice;
        private System.Windows.Forms.Label label_help;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.Button button_onlineRes;
    }
}

