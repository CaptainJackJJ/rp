namespace RPlayer
{
  partial class FormNotice
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
      this.label_notice = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button_ok
      // 
      this.button_ok.BackColor = System.Drawing.Color.SlateGray;
      this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_ok.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_ok.ForeColor = System.Drawing.Color.White;
      this.button_ok.Location = new System.Drawing.Point(54, 49);
      this.button_ok.Name = "button_ok";
      this.button_ok.Size = new System.Drawing.Size(75, 23);
      this.button_ok.TabIndex = 47;
      this.button_ok.Text = "知道了";
      this.button_ok.UseVisualStyleBackColor = false;
      this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
      // 
      // label_notice
      // 
      this.label_notice.AutoSize = true;
      this.label_notice.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_notice.ForeColor = System.Drawing.Color.Snow;
      this.label_notice.Location = new System.Drawing.Point(27, 21);
      this.label_notice.Name = "label_notice";
      this.label_notice.Size = new System.Drawing.Size(133, 14);
      this.label_notice.TabIndex = 48;
      this.label_notice.Text = "电影资源已更新完毕";
      // 
      // FormNotice
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SlateGray;
      this.ClientSize = new System.Drawing.Size(189, 80);
      this.Controls.Add(this.label_notice);
      this.Controls.Add(this.button_ok);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormNotice";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_ok;
    private System.Windows.Forms.Label label_notice;

  }
}

