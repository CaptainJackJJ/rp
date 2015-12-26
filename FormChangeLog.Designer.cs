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
      this.label_tree = new System.Windows.Forms.Label();
      this.richTextBox_changeLog = new System.Windows.Forms.RichTextBox();
      this.richTextBox_thanks = new System.Windows.Forms.RichTextBox();
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
      // richTextBox_changeLog
      // 
      this.richTextBox_changeLog.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.richTextBox_changeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_changeLog.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox_changeLog.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_changeLog.ForeColor = System.Drawing.Color.White;
      this.richTextBox_changeLog.Location = new System.Drawing.Point(9, 191);
      this.richTextBox_changeLog.Name = "richTextBox_changeLog";
      this.richTextBox_changeLog.ReadOnly = true;
      this.richTextBox_changeLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.richTextBox_changeLog.Size = new System.Drawing.Size(494, 336);
      this.richTextBox_changeLog.TabIndex = 45;
      this.richTextBox_changeLog.Text = "";
      // 
      // richTextBox_thanks
      // 
      this.richTextBox_thanks.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.richTextBox_thanks.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox_thanks.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.richTextBox_thanks.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.richTextBox_thanks.ForeColor = System.Drawing.Color.White;
      this.richTextBox_thanks.Location = new System.Drawing.Point(208, 46);
      this.richTextBox_thanks.Name = "richTextBox_thanks";
      this.richTextBox_thanks.ReadOnly = true;
      this.richTextBox_thanks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      this.richTextBox_thanks.Size = new System.Drawing.Size(295, 138);
      this.richTextBox_thanks.TabIndex = 45;
      this.richTextBox_thanks.Text = "Thank you for accompanying RabbitPlayer grows up.\n\nI am working hard to fix bug a" +
    "nd add new feature to bring you better media player.\nI will never stop.";
      // 
      // FormChangeLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.WindowFrame;
      this.ClientSize = new System.Drawing.Size(503, 539);
      this.Controls.Add(this.richTextBox_thanks);
      this.Controls.Add(this.richTextBox_changeLog);
      this.Controls.Add(this.label_tree);
      this.Controls.Add(this.label_topBarLine);
      this.Controls.Add(this.panel_topBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormChangeLog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Shown += new System.EventHandler(this.FormChangeLog_Shown);
      this.panel_topBar.ResumeLayout(false);
      this.panel_topBar.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_changeLog;
        private System.Windows.Forms.Label label_settingsClose;
        private System.Windows.Forms.Panel panel_topBar;
        private System.Windows.Forms.Label label_topBarLine;
        private System.Windows.Forms.Label label_tree;
        private System.Windows.Forms.RichTextBox richTextBox_changeLog;
        private System.Windows.Forms.RichTextBox richTextBox_thanks;
    }
}