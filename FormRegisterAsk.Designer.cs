namespace RPlayer
{
  partial class FormRegisterAsk
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
      this.button_notAllow = new System.Windows.Forms.Button();
      this.button_allow = new System.Windows.Forms.Button();
      this.richTextBox_description = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // button_notAllow
      // 
      this.button_notAllow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.button_notAllow.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.button_notAllow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
      this.button_notAllow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_notAllow.ForeColor = System.Drawing.Color.White;
      this.button_notAllow.Location = new System.Drawing.Point(178, 188);
      this.button_notAllow.Name = "button_notAllow";
      this.button_notAllow.Size = new System.Drawing.Size(75, 23);
      this.button_notAllow.TabIndex = 41;
      this.button_notAllow.Text = "Later";
      this.button_notAllow.UseVisualStyleBackColor = false;
      this.button_notAllow.Click += new System.EventHandler(this.button_notAllow_Click);
      // 
      // button_allow
      // 
      this.button_allow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.button_allow.FlatAppearance.BorderColor = System.Drawing.Color.White;
      this.button_allow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
      this.button_allow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_allow.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_allow.ForeColor = System.Drawing.Color.White;
      this.button_allow.Location = new System.Drawing.Point(48, 188);
      this.button_allow.Name = "button_allow";
      this.button_allow.Size = new System.Drawing.Size(75, 23);
      this.button_allow.TabIndex = 40;
      this.button_allow.Text = "Yes";
      this.button_allow.UseVisualStyleBackColor = false;
      this.button_allow.Click += new System.EventHandler(this.button_allow_Click);
      // 
      // richTextBox_description
      // 
      this.richTextBox_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.richTextBox_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_description.Cursor = System.Windows.Forms.Cursors.Default;
      this.richTextBox_description.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_description.ForeColor = System.Drawing.SystemColors.Info;
      this.richTextBox_description.Location = new System.Drawing.Point(13, 21);
      this.richTextBox_description.Name = "richTextBox_description";
      this.richTextBox_description.ReadOnly = true;
      this.richTextBox_description.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox_description.Size = new System.Drawing.Size(284, 158);
      this.richTextBox_description.TabIndex = 42;
      this.richTextBox_description.Text = "\n\nDo you want to set RabbitPlayer as default media player.\n\nSome SecuritySoftware" +
    " may ask your permisson agian.";
      // 
      // FormRegisterAsk
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(175)))), ((int)(((byte)(254)))));
      this.ClientSize = new System.Drawing.Size(309, 222);
      this.Controls.Add(this.richTextBox_description);
      this.Controls.Add(this.button_notAllow);
      this.Controls.Add(this.button_allow);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormRegisterAsk";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button_notAllow;
    private System.Windows.Forms.Button button_allow;
    private System.Windows.Forms.RichTextBox richTextBox_description;

  }
}

