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
      this.textBox_description = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // button_notAllow
      // 
      this.button_notAllow.BackColor = System.Drawing.Color.SlateGray;
      this.button_notAllow.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_notAllow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_notAllow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_notAllow.ForeColor = System.Drawing.Color.White;
      this.button_notAllow.Location = new System.Drawing.Point(179, 116);
      this.button_notAllow.Name = "button_notAllow";
      this.button_notAllow.Size = new System.Drawing.Size(75, 23);
      this.button_notAllow.TabIndex = 41;
      this.button_notAllow.Text = "Later";
      this.button_notAllow.UseVisualStyleBackColor = false;
      this.button_notAllow.Click += new System.EventHandler(this.button_notAllow_Click);
      // 
      // button_allow
      // 
      this.button_allow.BackColor = System.Drawing.Color.SlateGray;
      this.button_allow.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_allow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_allow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_allow.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.button_allow.ForeColor = System.Drawing.Color.White;
      this.button_allow.Location = new System.Drawing.Point(49, 116);
      this.button_allow.Name = "button_allow";
      this.button_allow.Size = new System.Drawing.Size(75, 23);
      this.button_allow.TabIndex = 40;
      this.button_allow.Text = "Yes";
      this.button_allow.UseVisualStyleBackColor = false;
      this.button_allow.Click += new System.EventHandler(this.button_allow_Click);
      // 
      // textBox_description
      // 
      this.textBox_description.BackColor = System.Drawing.Color.SlateGray;
      this.textBox_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox_description.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_description.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.textBox_description.ForeColor = System.Drawing.Color.White;
      this.textBox_description.Location = new System.Drawing.Point(16, 21);
      this.textBox_description.Multiline = true;
      this.textBox_description.Name = "textBox_description";
      this.textBox_description.ReadOnly = true;
      this.textBox_description.Size = new System.Drawing.Size(291, 90);
      this.textBox_description.TabIndex = 41;
      this.textBox_description.TabStop = false;
      this.textBox_description.Text = "Do you want to set RabbitPlayer as default media player.\r\n\r\nSome SecuritySoftware" +
    " may ask your permisson agian.";
      // 
      // FormRegisterAsk
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SlateGray;
      this.ClientSize = new System.Drawing.Size(309, 155);
      this.Controls.Add(this.textBox_description);
      this.Controls.Add(this.button_notAllow);
      this.Controls.Add(this.button_allow);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormRegisterAsk";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_notAllow;
    private System.Windows.Forms.Button button_allow;
    private System.Windows.Forms.TextBox textBox_description;

  }
}

