namespace RPlayer
{
  partial class FormPlistFileDeleteConfirm
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
      this.textBox_deleteWarning = new System.Windows.Forms.TextBox();
      this.button_no = new System.Windows.Forms.Button();
      this.button_yse = new System.Windows.Forms.Button();
      this.checkBox_deleteDirectly = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // textBox_deleteWarning
      // 
      this.textBox_deleteWarning.BackColor = System.Drawing.Color.DimGray;
      this.textBox_deleteWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox_deleteWarning.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_deleteWarning.ForeColor = System.Drawing.Color.White;
      this.textBox_deleteWarning.Location = new System.Drawing.Point(11, 11);
      this.textBox_deleteWarning.Multiline = true;
      this.textBox_deleteWarning.Name = "textBox_deleteWarning";
      this.textBox_deleteWarning.ReadOnly = true;
      this.textBox_deleteWarning.Size = new System.Drawing.Size(332, 70);
      this.textBox_deleteWarning.TabIndex = 36;
      this.textBox_deleteWarning.TabStop = false;
      this.textBox_deleteWarning.Text = "\r\nWarning: This will also delete the source file.\r\n(delete playlist folder does n" +
    "ot delete source folder)\r\n\r\nAre you still want to delete it?";
      // 
      // button_no
      // 
      this.button_no.BackColor = System.Drawing.Color.DimGray;
      this.button_no.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_no.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_no.ForeColor = System.Drawing.Color.White;
      this.button_no.Location = new System.Drawing.Point(167, 108);
      this.button_no.Name = "button_no";
      this.button_no.Size = new System.Drawing.Size(75, 23);
      this.button_no.TabIndex = 38;
      this.button_no.Text = "No";
      this.button_no.UseVisualStyleBackColor = false;
      this.button_no.Click += new System.EventHandler(this.button_no_Click);
      // 
      // button_yse
      // 
      this.button_yse.BackColor = System.Drawing.Color.DimGray;
      this.button_yse.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_yse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_yse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_yse.ForeColor = System.Drawing.Color.White;
      this.button_yse.Location = new System.Drawing.Point(80, 108);
      this.button_yse.Name = "button_yse";
      this.button_yse.Size = new System.Drawing.Size(75, 23);
      this.button_yse.TabIndex = 37;
      this.button_yse.Text = "Yes";
      this.button_yse.UseVisualStyleBackColor = false;
      this.button_yse.Click += new System.EventHandler(this.button_yse_Click);
      // 
      // checkBox_deleteDirectly
      // 
      this.checkBox_deleteDirectly.AutoSize = true;
      this.checkBox_deleteDirectly.ForeColor = System.Drawing.Color.White;
      this.checkBox_deleteDirectly.Location = new System.Drawing.Point(69, 86);
      this.checkBox_deleteDirectly.Name = "checkBox_deleteDirectly";
      this.checkBox_deleteDirectly.Size = new System.Drawing.Size(198, 16);
      this.checkBox_deleteDirectly.TabIndex = 39;
      this.checkBox_deleteDirectly.Text = "Just delete it without asking";
      this.checkBox_deleteDirectly.UseVisualStyleBackColor = true;
      this.checkBox_deleteDirectly.CheckedChanged += new System.EventHandler(this.checkBox_deleteDirectly_CheckedChanged);
      // 
      // FormPlistFileDeleteConfirm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.DimGray;
      this.ClientSize = new System.Drawing.Size(347, 149);
      this.Controls.Add(this.checkBox_deleteDirectly);
      this.Controls.Add(this.button_no);
      this.Controls.Add(this.button_yse);
      this.Controls.Add(this.textBox_deleteWarning);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPlistFileDeleteConfirm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox_deleteWarning;
    private System.Windows.Forms.Button button_no;
    private System.Windows.Forms.Button button_yse;
    private System.Windows.Forms.CheckBox checkBox_deleteDirectly;

  }
}