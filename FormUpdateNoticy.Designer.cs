namespace RPlayer
{
  partial class FormUpdateNoticy
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
      this.button_ok = new System.Windows.Forms.Button();
      this.richTextBox_notice = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // button_ok
      // 
      this.button_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.button_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
      this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_ok.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_ok.ForeColor = System.Drawing.Color.White;
      this.button_ok.Location = new System.Drawing.Point(83, 73);
      this.button_ok.Name = "button_ok";
      this.button_ok.Size = new System.Drawing.Size(95, 23);
      this.button_ok.TabIndex = 40;
      this.button_ok.Text = "Ok";
      this.button_ok.UseVisualStyleBackColor = false;
      this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
      // 
      // richTextBox_notice
      // 
      this.richTextBox_notice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.richTextBox_notice.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_notice.Cursor = System.Windows.Forms.Cursors.Default;
      this.richTextBox_notice.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_notice.ForeColor = System.Drawing.SystemColors.Info;
      this.richTextBox_notice.Location = new System.Drawing.Point(13, 12);
      this.richTextBox_notice.Name = "richTextBox_notice";
      this.richTextBox_notice.ReadOnly = true;
      this.richTextBox_notice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox_notice.Size = new System.Drawing.Size(260, 58);
      this.richTextBox_notice.TabIndex = 42;
      this.richTextBox_notice.Text = "感谢您使用兔子影音。软件已更新至最新版V1.1.12，几秒钟后将会自动重启。";
      // 
      // FormUpdateNoticy
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.ClientSize = new System.Drawing.Size(285, 107);
      this.Controls.Add(this.richTextBox_notice);
      this.Controls.Add(this.button_ok);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormUpdateNoticy";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button_ok;
    private System.Windows.Forms.RichTextBox richTextBox_notice;

  }
}

