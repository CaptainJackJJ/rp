namespace RPlayer
{
  partial class FormNoticeUseQuickLook
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNoticeUseQuickLook));
      this.richTextBox_changeLog = new System.Windows.Forms.RichTextBox();
      this.button_ok = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // richTextBox_changeLog
      // 
      this.richTextBox_changeLog.BackColor = System.Drawing.Color.DarkSalmon;
      this.richTextBox_changeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_changeLog.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox_changeLog.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_changeLog.ForeColor = System.Drawing.Color.White;
      this.richTextBox_changeLog.Location = new System.Drawing.Point(10, 39);
      this.richTextBox_changeLog.Name = "richTextBox_changeLog";
      this.richTextBox_changeLog.ReadOnly = true;
      this.richTextBox_changeLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox_changeLog.Size = new System.Drawing.Size(272, 60);
      this.richTextBox_changeLog.TabIndex = 48;
      this.richTextBox_changeLog.Text = "在影片上点击右键可以快速预览";
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
      this.button_ok.Location = new System.Drawing.Point(85, 100);
      this.button_ok.Name = "button_ok";
      this.button_ok.Size = new System.Drawing.Size(112, 38);
      this.button_ok.TabIndex = 49;
      this.button_ok.Text = "知道了";
      this.button_ok.UseVisualStyleBackColor = false;
      this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
      // 
      // FormNoticeUseQuickLook
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.DarkSalmon;
      this.ClientSize = new System.Drawing.Size(287, 159);
      this.Controls.Add(this.button_ok);
      this.Controls.Add(this.richTextBox_changeLog);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormNoticeUseQuickLook";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "提示";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox_changeLog;
    private System.Windows.Forms.Button button_ok;

  }
}

