namespace RPlayer
{
  partial class FormChangeLog
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
      this.label_changeLog = new System.Windows.Forms.Label();
      this.label_settingsClose = new System.Windows.Forms.Label();
      this.panel_topBar = new System.Windows.Forms.Panel();
      this.label_topBarLine = new System.Windows.Forms.Label();
      this.textBox_thanks = new System.Windows.Forms.TextBox();
      this.textBox_changeLog = new System.Windows.Forms.TextBox();
      this.label_tree = new System.Windows.Forms.Label();
      this.panel_topBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // label_changeLog
      // 
      this.label_changeLog.AutoSize = true;
      this.label_changeLog.BackColor = System.Drawing.Color.Transparent;
      this.label_changeLog.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_changeLog.ForeColor = System.Drawing.Color.White;
      this.label_changeLog.Location = new System.Drawing.Point(6, 11);
      this.label_changeLog.Name = "label_changeLog";
      this.label_changeLog.Size = new System.Drawing.Size(119, 19);
      this.label_changeLog.TabIndex = 0;
      this.label_changeLog.Text = "Change Log";
      // 
      // label_settingsClose
      // 
      this.label_settingsClose.BackColor = System.Drawing.Color.Transparent;
      this.label_settingsClose.Location = new System.Drawing.Point(469, 17);
      this.label_settingsClose.Name = "label_settingsClose";
      this.label_settingsClose.Size = new System.Drawing.Size(13, 13);
      this.label_settingsClose.TabIndex = 1;
      this.label_settingsClose.Click += new System.EventHandler(this.label_settingsClose_Click);
      this.label_settingsClose.MouseEnter += new System.EventHandler(this.label_settingsClose_MouseEnter);
      this.label_settingsClose.MouseLeave += new System.EventHandler(this.label_settingsClose_MouseLeave);
      // 
      // panel_topBar
      // 
      this.panel_topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
      this.panel_topBar.Controls.Add(this.label_changeLog);
      this.panel_topBar.Controls.Add(this.label_settingsClose);
      this.panel_topBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_topBar.Location = new System.Drawing.Point(0, 0);
      this.panel_topBar.Name = "panel_topBar";
      this.panel_topBar.Size = new System.Drawing.Size(503, 41);
      this.panel_topBar.TabIndex = 3;
      this.panel_topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_topBar_MouseDown);
      this.panel_topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_topBar_MouseMove);
      this.panel_topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_topBar_MouseUp);
      // 
      // label_topBarLine
      // 
      this.label_topBarLine.BackColor = System.Drawing.Color.Silver;
      this.label_topBarLine.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_topBarLine.Location = new System.Drawing.Point(0, 41);
      this.label_topBarLine.Name = "label_topBarLine";
      this.label_topBarLine.Size = new System.Drawing.Size(503, 1);
      this.label_topBarLine.TabIndex = 4;
      // 
      // textBox_thanks
      // 
      this.textBox_thanks.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.textBox_thanks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_thanks.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_thanks.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.textBox_thanks.ForeColor = System.Drawing.Color.White;
      this.textBox_thanks.Location = new System.Drawing.Point(214, 62);
      this.textBox_thanks.Multiline = true;
      this.textBox_thanks.Name = "textBox_thanks";
      this.textBox_thanks.ReadOnly = true;
      this.textBox_thanks.Size = new System.Drawing.Size(289, 109);
      this.textBox_thanks.TabIndex = 44;
      this.textBox_thanks.TabStop = false;
      this.textBox_thanks.Text = "Thank you for accompanying RabbitPlayer grows up.\r\n\r\nI am working hard to fix bug" +
    " and add new feature to bring you better media player.\r\nI will never stop.";
      // 
      // textBox_changeLog
      // 
      this.textBox_changeLog.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.textBox_changeLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textBox_changeLog.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.textBox_changeLog.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.textBox_changeLog.ForeColor = System.Drawing.Color.White;
      this.textBox_changeLog.Location = new System.Drawing.Point(9, 191);
      this.textBox_changeLog.Multiline = true;
      this.textBox_changeLog.Name = "textBox_changeLog";
      this.textBox_changeLog.ReadOnly = true;
      this.textBox_changeLog.Size = new System.Drawing.Size(494, 336);
      this.textBox_changeLog.TabIndex = 44;
      this.textBox_changeLog.TabStop = false;
      this.textBox_changeLog.Text = "1.1.5 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
    "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\r\n\r\n1.1.2 yyyyyyyyyyyyyyyyyyyyyyyyyyy" +
    "yyyyyyyyyyyyyyyyyyyyyyy";
      // 
      // label_tree
      // 
      this.label_tree.BackColor = System.Drawing.Color.Transparent;
      this.label_tree.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.label_tree.ForeColor = System.Drawing.Color.White;
      this.label_tree.Image = global::RPlayer.Properties.Resources.tree;
      this.label_tree.Location = new System.Drawing.Point(2, 42);
      this.label_tree.Name = "label_tree";
      this.label_tree.Size = new System.Drawing.Size(200, 133);
      this.label_tree.TabIndex = 0;
      // 
      // FormChangeLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(503, 539);
      this.Controls.Add(this.label_tree);
      this.Controls.Add(this.textBox_changeLog);
      this.Controls.Add(this.textBox_thanks);
      this.Controls.Add(this.label_topBarLine);
      this.Controls.Add(this.panel_topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormChangeLog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Shown += new System.EventHandler(this.FormChangeLog_Shown);
      this.panel_topBar.ResumeLayout(false);
      this.panel_topBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_changeLog;
        private System.Windows.Forms.Label label_settingsClose;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.Label label_topBarLine;
        private System.Windows.Forms.TextBox textBox_thanks;
        private System.Windows.Forms.TextBox textBox_changeLog;
        private System.Windows.Forms.Label label_tree;
    }
}