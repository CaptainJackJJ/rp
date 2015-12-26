namespace RPlayer
{
  partial class FormFeedback
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
      this.label_guide = new System.Windows.Forms.Label();
      this.label_Close = new System.Windows.Forms.Label();
      this.label_weChatGroupShow = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label_guide
      // 
      this.label_guide.AutoSize = true;
      this.label_guide.BackColor = System.Drawing.Color.Transparent;
      this.label_guide.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_guide.ForeColor = System.Drawing.Color.White;
      this.label_guide.Location = new System.Drawing.Point(12, 9);
      this.label_guide.Name = "label_guide";
      this.label_guide.Size = new System.Drawing.Size(217, 14);
      this.label_guide.TabIndex = 38;
      this.label_guide.Text = "Scan WeChat to feedback please";
      // 
      // label_Close
      // 
      this.label_Close.BackColor = System.Drawing.Color.Transparent;
      this.label_Close.Location = new System.Drawing.Point(248, 11);
      this.label_Close.Name = "label_Close";
      this.label_Close.Size = new System.Drawing.Size(13, 13);
      this.label_Close.TabIndex = 39;
      this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
      this.label_Close.MouseEnter += new System.EventHandler(this.label_Close_MouseEnter);
      this.label_Close.MouseLeave += new System.EventHandler(this.label_Close_MouseLeave);
      // 
      // label_weChatGroupShow
      // 
      this.label_weChatGroupShow.BackColor = System.Drawing.Color.Transparent;
      this.label_weChatGroupShow.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_weChatGroupShow.ForeColor = System.Drawing.Color.White;
      this.label_weChatGroupShow.Image = global::RPlayer.Properties.Resources.未标题_1;
      this.label_weChatGroupShow.Location = new System.Drawing.Point(12, 36);
      this.label_weChatGroupShow.Name = "label_weChatGroupShow";
      this.label_weChatGroupShow.Size = new System.Drawing.Size(250, 309);
      this.label_weChatGroupShow.TabIndex = 40;
      // 
      // FormFeedback
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SlateGray;
      this.ClientSize = new System.Drawing.Size(275, 357);
      this.Controls.Add(this.label_weChatGroupShow);
      this.Controls.Add(this.label_Close);
      this.Controls.Add(this.label_guide);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormFeedback";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Shown += new System.EventHandler(this.FormFeedback_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_guide;
    private System.Windows.Forms.Label label_Close;
    private System.Windows.Forms.Label label_weChatGroupShow;
  }
}

