namespace RPlayer
{
  partial class FormNoticeUseQuickPlay
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNoticeUseQuickPlay));
      this.richTextBox_changeLog = new System.Windows.Forms.RichTextBox();
      this.button_ok = new System.Windows.Forms.Button();
      this.label_FF = new System.Windows.Forms.Label();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.richTextBox2 = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // richTextBox_changeLog
      // 
      this.richTextBox_changeLog.BackColor = System.Drawing.Color.SlateGray;
      this.richTextBox_changeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_changeLog.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox_changeLog.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_changeLog.ForeColor = System.Drawing.Color.White;
      this.richTextBox_changeLog.Location = new System.Drawing.Point(17, 12);
      this.richTextBox_changeLog.Name = "richTextBox_changeLog";
      this.richTextBox_changeLog.ReadOnly = true;
      this.richTextBox_changeLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox_changeLog.Size = new System.Drawing.Size(52, 34);
      this.richTextBox_changeLog.TabIndex = 48;
      this.richTextBox_changeLog.Text = "点击";
      // 
      // button_ok
      // 
      this.button_ok.AutoSize = true;
      this.button_ok.BackColor = System.Drawing.Color.Transparent;
      this.button_ok.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
      this.button_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
      this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_ok.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_ok.ForeColor = System.Drawing.Color.White;
      this.button_ok.Location = new System.Drawing.Point(84, 97);
      this.button_ok.Name = "button_ok";
      this.button_ok.Size = new System.Drawing.Size(112, 38);
      this.button_ok.TabIndex = 49;
      this.button_ok.Text = "知道了";
      this.button_ok.UseVisualStyleBackColor = false;
      this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
      // 
      // label_FF
      // 
      this.label_FF.BackColor = System.Drawing.Color.Transparent;
      this.label_FF.Image = ((System.Drawing.Image)(resources.GetObject("label_FF.Image")));
      this.label_FF.Location = new System.Drawing.Point(68, 12);
      this.label_FF.Name = "label_FF";
      this.label_FF.Size = new System.Drawing.Size(25, 25);
      this.label_FF.TabIndex = 50;
      // 
      // richTextBox1
      // 
      this.richTextBox1.BackColor = System.Drawing.Color.SlateGray;
      this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox1.ForeColor = System.Drawing.Color.White;
      this.richTextBox1.Location = new System.Drawing.Point(105, 12);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox1.Size = new System.Drawing.Size(174, 34);
      this.richTextBox1.TabIndex = 51;
      this.richTextBox1.Text = "按钮可以变速播放";
      // 
      // richTextBox2
      // 
      this.richTextBox2.BackColor = System.Drawing.Color.SlateGray;
      this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox2.ForeColor = System.Drawing.Color.White;
      this.richTextBox2.Location = new System.Drawing.Point(16, 49);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.ReadOnly = true;
      this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox2.Size = new System.Drawing.Size(251, 34);
      this.richTextBox2.TabIndex = 51;
      this.richTextBox2.Text = "并且同时还可以保持语调不变";
      // 
      // FormNoticeUseQuickPlay
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.SlateGray;
      this.ClientSize = new System.Drawing.Size(279, 147);
      this.Controls.Add(this.richTextBox2);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.label_FF);
      this.Controls.Add(this.button_ok);
      this.Controls.Add(this.richTextBox_changeLog);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormNoticeUseQuickPlay";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "提示";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox_changeLog;
    private System.Windows.Forms.Button button_ok;
    private System.Windows.Forms.Label label_FF;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.RichTextBox richTextBox2;

  }
}

