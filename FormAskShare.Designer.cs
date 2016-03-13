namespace RPlayer
{
  partial class FormAskShare
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
      this.richTextBox_changeLog = new System.Windows.Forms.RichTextBox();
      this.button_share = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // richTextBox_changeLog
      // 
      this.richTextBox_changeLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.richTextBox_changeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_changeLog.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox_changeLog.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_changeLog.ForeColor = System.Drawing.Color.White;
      this.richTextBox_changeLog.Location = new System.Drawing.Point(11, 12);
      this.richTextBox_changeLog.Name = "richTextBox_changeLog";
      this.richTextBox_changeLog.ReadOnly = true;
      this.richTextBox_changeLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox_changeLog.Size = new System.Drawing.Size(345, 82);
      this.richTextBox_changeLog.TabIndex = 48;
      this.richTextBox_changeLog.Text = "亲，试用期已过，需要30元购买使用权。\n但由于兔子影音还处于推广阶段，只要\n你分享给好友，就可以免费终身使用！";
      // 
      // button_share
      // 
      this.button_share.AutoSize = true;
      this.button_share.BackColor = System.Drawing.Color.Transparent;
      this.button_share.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.button_share.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
      this.button_share.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
      this.button_share.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_share.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_share.ForeColor = System.Drawing.Color.White;
      this.button_share.Location = new System.Drawing.Point(118, 101);
      this.button_share.Name = "button_share";
      this.button_share.Size = new System.Drawing.Size(112, 38);
      this.button_share.TabIndex = 49;
      this.button_share.Text = "去分享";
      this.button_share.UseVisualStyleBackColor = false;
      this.button_share.Click += new System.EventHandler(this.button_share_Click);
      // 
      // FormAskShare
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.ClientSize = new System.Drawing.Size(355, 155);
      this.Controls.Add(this.button_share);
      this.Controls.Add(this.richTextBox_changeLog);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormAskShare";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAskShare_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox_changeLog;
    private System.Windows.Forms.Button button_share;

  }
}

