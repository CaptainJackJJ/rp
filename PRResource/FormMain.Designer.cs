namespace PRResource
{
  partial class FormMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.button_subtitle = new System.Windows.Forms.Button();
      this.panel_neck = new System.Windows.Forms.Panel();
      this.label_loading = new System.Windows.Forms.Label();
      this.label_back = new System.Windows.Forms.Label();
      this.label_forward = new System.Windows.Forms.Label();
      this.button_dlOversea = new System.Windows.Forms.Button();
      this.button_dlChina2 = new System.Windows.Forms.Button();
      this.button_dlChina1 = new System.Windows.Forms.Button();
      this.button_onlineVideo = new System.Windows.Forms.Button();
      this.label_Max = new System.Windows.Forms.Label();
      this.label_Min = new System.Windows.Forms.Label();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_LeftEdge = new System.Windows.Forms.Label();
      this.label_TopEdge = new System.Windows.Forms.Label();
      this.label_RightEdge = new System.Windows.Forms.Label();
      this.label_BottomEdge = new System.Windows.Forms.Label();
      this.label_logo = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.panel_neck.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_subtitle
      // 
      this.button_subtitle.BackColor = System.Drawing.Color.MediumPurple;
      this.button_subtitle.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
      this.button_subtitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkViolet;
      this.button_subtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_subtitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_subtitle.ForeColor = System.Drawing.Color.White;
      this.button_subtitle.Location = new System.Drawing.Point(628, 1);
      this.button_subtitle.Name = "button_subtitle";
      this.button_subtitle.Size = new System.Drawing.Size(115, 40);
      this.button_subtitle.TabIndex = 52;
      this.button_subtitle.Text = "字幕下载";
      this.button_subtitle.UseVisualStyleBackColor = false;
      this.button_subtitle.Click += new System.EventHandler(this.button_subtitle_Click);
      // 
      // panel_neck
      // 
      this.panel_neck.BackColor = System.Drawing.Color.MintCream;
      this.panel_neck.Controls.Add(this.label_loading);
      this.panel_neck.Controls.Add(this.label_back);
      this.panel_neck.Controls.Add(this.label_forward);
      this.panel_neck.Location = new System.Drawing.Point(7, 47);
      this.panel_neck.Name = "panel_neck";
      this.panel_neck.Size = new System.Drawing.Size(1010, 23);
      this.panel_neck.TabIndex = 56;
      this.panel_neck.Resize += new System.EventHandler(this.panel_neck_Resize);
      // 
      // label_loading
      // 
      this.label_loading.BackColor = System.Drawing.Color.Transparent;
      this.label_loading.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_loading.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_loading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.label_loading.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label_loading.Location = new System.Drawing.Point(483, 0);
      this.label_loading.Name = "label_loading";
      this.label_loading.Size = new System.Drawing.Size(62, 25);
      this.label_loading.TabIndex = 45;
      this.label_loading.Text = "加载中...";
      this.label_loading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label_back
      // 
      this.label_back.BackColor = System.Drawing.Color.Transparent;
      this.label_back.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_back.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_back.ForeColor = System.Drawing.Color.DimGray;
      this.label_back.Location = new System.Drawing.Point(435, 0);
      this.label_back.Name = "label_back";
      this.label_back.Size = new System.Drawing.Size(23, 23);
      this.label_back.TabIndex = 45;
      this.label_back.Click += new System.EventHandler(this.label_back_Click);
      this.label_back.MouseEnter += new System.EventHandler(this.label_back_MouseEnter);
      this.label_back.MouseLeave += new System.EventHandler(this.label_back_MouseLeave);
      // 
      // label_forward
      // 
      this.label_forward.BackColor = System.Drawing.Color.Transparent;
      this.label_forward.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_forward.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_forward.ForeColor = System.Drawing.Color.DimGray;
      this.label_forward.Location = new System.Drawing.Point(556, 0);
      this.label_forward.Name = "label_forward";
      this.label_forward.Size = new System.Drawing.Size(23, 23);
      this.label_forward.TabIndex = 45;
      this.label_forward.Click += new System.EventHandler(this.label_forward_Click);
      this.label_forward.MouseEnter += new System.EventHandler(this.label_forward_MouseEnter);
      this.label_forward.MouseLeave += new System.EventHandler(this.label_forward_MouseLeave);
      // 
      // button_dlOversea
      // 
      this.button_dlOversea.BackColor = System.Drawing.Color.MediumPurple;
      this.button_dlOversea.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
      this.button_dlOversea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkViolet;
      this.button_dlOversea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_dlOversea.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_dlOversea.ForeColor = System.Drawing.Color.White;
      this.button_dlOversea.Location = new System.Drawing.Point(513, 1);
      this.button_dlOversea.Name = "button_dlOversea";
      this.button_dlOversea.Size = new System.Drawing.Size(115, 40);
      this.button_dlOversea.TabIndex = 53;
      this.button_dlOversea.Text = "国外下载";
      this.button_dlOversea.UseVisualStyleBackColor = false;
      this.button_dlOversea.Click += new System.EventHandler(this.button_dlOversea_Click);
      // 
      // button_dlChina2
      // 
      this.button_dlChina2.BackColor = System.Drawing.Color.MediumPurple;
      this.button_dlChina2.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
      this.button_dlChina2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkViolet;
      this.button_dlChina2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_dlChina2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_dlChina2.ForeColor = System.Drawing.Color.White;
      this.button_dlChina2.Location = new System.Drawing.Point(398, 1);
      this.button_dlChina2.Name = "button_dlChina2";
      this.button_dlChina2.Size = new System.Drawing.Size(115, 40);
      this.button_dlChina2.TabIndex = 54;
      this.button_dlChina2.Text = "国内下载2";
      this.button_dlChina2.UseVisualStyleBackColor = false;
      this.button_dlChina2.Click += new System.EventHandler(this.button_dlChina2_Click);
      // 
      // button_dlChina1
      // 
      this.button_dlChina1.BackColor = System.Drawing.Color.MediumPurple;
      this.button_dlChina1.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
      this.button_dlChina1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkViolet;
      this.button_dlChina1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_dlChina1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_dlChina1.ForeColor = System.Drawing.Color.White;
      this.button_dlChina1.Location = new System.Drawing.Point(283, 1);
      this.button_dlChina1.Name = "button_dlChina1";
      this.button_dlChina1.Size = new System.Drawing.Size(115, 40);
      this.button_dlChina1.TabIndex = 55;
      this.button_dlChina1.Text = "国内下载1";
      this.button_dlChina1.UseVisualStyleBackColor = false;
      this.button_dlChina1.Click += new System.EventHandler(this.button_dlChina1_Click);
      // 
      // button_onlineVideo
      // 
      this.button_onlineVideo.BackColor = System.Drawing.Color.MediumPurple;
      this.button_onlineVideo.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
      this.button_onlineVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkViolet;
      this.button_onlineVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_onlineVideo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
      this.button_onlineVideo.ForeColor = System.Drawing.Color.White;
      this.button_onlineVideo.Location = new System.Drawing.Point(743, 1);
      this.button_onlineVideo.Name = "button_onlineVideo";
      this.button_onlineVideo.Size = new System.Drawing.Size(115, 40);
      this.button_onlineVideo.TabIndex = 51;
      this.button_onlineVideo.Text = "在线观看";
      this.button_onlineVideo.UseVisualStyleBackColor = false;
      this.button_onlineVideo.Click += new System.EventHandler(this.button_onlineVideo_Click);
      // 
      // label_Max
      // 
      this.label_Max.BackColor = System.Drawing.Color.Transparent;
      this.label_Max.Location = new System.Drawing.Point(506, 354);
      this.label_Max.Name = "label_Max";
      this.label_Max.Size = new System.Drawing.Size(13, 13);
      this.label_Max.TabIndex = 57;
      this.label_Max.Click += new System.EventHandler(this.label_Max_Click);
      this.label_Max.MouseEnter += new System.EventHandler(this.label_Max_MouseEnter);
      this.label_Max.MouseLeave += new System.EventHandler(this.label_Max_MouseLeave);
      // 
      // label_Min
      // 
      this.label_Min.BackColor = System.Drawing.Color.Transparent;
      this.label_Min.Location = new System.Drawing.Point(514, 362);
      this.label_Min.Name = "label_Min";
      this.label_Min.Size = new System.Drawing.Size(13, 13);
      this.label_Min.TabIndex = 58;
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
      this.label_Close.TabIndex = 59;
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
      this.label_LeftEdge.TabIndex = 60;
      this.label_LeftEdge.Visible = false;
      // 
      // label_TopEdge
      // 
      this.label_TopEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_TopEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
      this.label_TopEdge.Location = new System.Drawing.Point(1, 1);
      this.label_TopEdge.Name = "label_TopEdge";
      this.label_TopEdge.Size = new System.Drawing.Size(1022, 1);
      this.label_TopEdge.TabIndex = 61;
      this.label_TopEdge.Visible = false;
      // 
      // label_RightEdge
      // 
      this.label_RightEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_RightEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
      this.label_RightEdge.Location = new System.Drawing.Point(1022, 2);
      this.label_RightEdge.Name = "label_RightEdge";
      this.label_RightEdge.Size = new System.Drawing.Size(1, 766);
      this.label_RightEdge.TabIndex = 62;
      this.label_RightEdge.Visible = false;
      // 
      // label_BottomEdge
      // 
      this.label_BottomEdge.BackColor = System.Drawing.Color.RoyalBlue;
      this.label_BottomEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
      this.label_BottomEdge.Location = new System.Drawing.Point(1, 766);
      this.label_BottomEdge.Name = "label_BottomEdge";
      this.label_BottomEdge.Size = new System.Drawing.Size(1022, 1);
      this.label_BottomEdge.TabIndex = 63;
      this.label_BottomEdge.Visible = false;
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
      this.label_logo.Size = new System.Drawing.Size(135, 24);
      this.label_logo.TabIndex = 64;
      this.label_logo.Text = "海盗兔资源";
      // 
      // timer1
      // 
      this.timer1.Interval = 200;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // FormMain
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.ClientSize = new System.Drawing.Size(1024, 720);
      this.Controls.Add(this.label_logo);
      this.Controls.Add(this.label_BottomEdge);
      this.Controls.Add(this.label_RightEdge);
      this.Controls.Add(this.label_TopEdge);
      this.Controls.Add(this.label_LeftEdge);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_Min);
      this.Controls.Add(this.label_Max);
      this.Controls.Add(this.button_subtitle);
      this.Controls.Add(this.panel_neck);
      this.Controls.Add(this.button_dlOversea);
      this.Controls.Add(this.button_dlChina2);
      this.Controls.Add(this.button_dlChina1);
      this.Controls.Add(this.button_onlineVideo);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "海盗兔资源";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
      this.Move += new System.EventHandler(this.FormMain_Move);
      this.Resize += new System.EventHandler(this.FormMain_Resize);
      this.panel_neck.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_subtitle;
    private System.Windows.Forms.Panel panel_neck;
    private System.Windows.Forms.Label label_loading;
    private System.Windows.Forms.Label label_back;
    private System.Windows.Forms.Label label_forward;
    private System.Windows.Forms.Button button_dlOversea;
    private System.Windows.Forms.Button button_dlChina2;
    private System.Windows.Forms.Button button_dlChina1;
    private System.Windows.Forms.Button button_onlineVideo;
    private System.Windows.Forms.Label label_Max;
    private System.Windows.Forms.Label label_Min;
    private System.Windows.Forms.Label label_Close;
    private System.Windows.Forms.Label label_LeftEdge;
    private System.Windows.Forms.Label label_TopEdge;
    private System.Windows.Forms.Label label_RightEdge;
    private System.Windows.Forms.Label label_BottomEdge;
    private System.Windows.Forms.Label label_logo;
    private System.Windows.Forms.Timer timer1;


  }
}

