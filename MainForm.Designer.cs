namespace RPlayer
{
    partial class MainForm
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
            this.pictureBox_TopEdge = new System.Windows.Forms.PictureBox();
            this.pictureBox_LeftEdge = new System.Windows.Forms.PictureBox();
            this.pictureBox_BottomEdge = new System.Windows.Forms.PictureBox();
            this.pictureBox_RightEdge = new System.Windows.Forms.PictureBox();
            this.pictureBox_Max = new System.Windows.Forms.PictureBox();
            this.pictureBox_Min = new System.Windows.Forms.PictureBox();
            this.pictureBox_Close = new System.Windows.Forms.PictureBox();
            this.label_Play = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TopEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LeftEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RightEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_TopEdge
            // 
            this.pictureBox_TopEdge.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_TopEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pictureBox_TopEdge.Location = new System.Drawing.Point(1, 1);
            this.pictureBox_TopEdge.Name = "pictureBox_TopEdge";
            this.pictureBox_TopEdge.Size = new System.Drawing.Size(913, 1);
            this.pictureBox_TopEdge.TabIndex = 1;
            this.pictureBox_TopEdge.TabStop = false;
            this.pictureBox_TopEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_TopEdge_MouseDown);
            this.pictureBox_TopEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_TopEdge_MouseMove);
            this.pictureBox_TopEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_TopEdge_MouseUp);
            // 
            // pictureBox_LeftEdge
            // 
            this.pictureBox_LeftEdge.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_LeftEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBox_LeftEdge.Location = new System.Drawing.Point(1, 2);
            this.pictureBox_LeftEdge.Name = "pictureBox_LeftEdge";
            this.pictureBox_LeftEdge.Size = new System.Drawing.Size(1, 596);
            this.pictureBox_LeftEdge.TabIndex = 2;
            this.pictureBox_LeftEdge.TabStop = false;
            this.pictureBox_LeftEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_LeftEdge_MouseDown);
            this.pictureBox_LeftEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_LeftEdge_MouseMove);
            this.pictureBox_LeftEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_LeftEdge_MouseUp);
            // 
            // pictureBox_BottomEdge
            // 
            this.pictureBox_BottomEdge.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_BottomEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pictureBox_BottomEdge.Location = new System.Drawing.Point(1, 598);
            this.pictureBox_BottomEdge.Name = "pictureBox_BottomEdge";
            this.pictureBox_BottomEdge.Size = new System.Drawing.Size(913, 1);
            this.pictureBox_BottomEdge.TabIndex = 3;
            this.pictureBox_BottomEdge.TabStop = false;
            this.pictureBox_BottomEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_BottomEdge_MouseDown);
            this.pictureBox_BottomEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_BottomEdge_MouseMove);
            this.pictureBox_BottomEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_BottomEdge_MouseUp);
            // 
            // pictureBox_RightEdge
            // 
            this.pictureBox_RightEdge.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_RightEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBox_RightEdge.Location = new System.Drawing.Point(913, 2);
            this.pictureBox_RightEdge.Name = "pictureBox_RightEdge";
            this.pictureBox_RightEdge.Size = new System.Drawing.Size(1, 560);
            this.pictureBox_RightEdge.TabIndex = 4;
            this.pictureBox_RightEdge.TabStop = false;
            this.pictureBox_RightEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_RightEdge_MouseDown);
            this.pictureBox_RightEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_RightEdge_MouseMove);
            this.pictureBox_RightEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_RightEdge_MouseUp);
            // 
            // pictureBox_Max
            // 
            this.pictureBox_Max.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Max.Location = new System.Drawing.Point(859, 13);
            this.pictureBox_Max.Name = "pictureBox_Max";
            this.pictureBox_Max.Size = new System.Drawing.Size(13, 13);
            this.pictureBox_Max.TabIndex = 17;
            this.pictureBox_Max.TabStop = false;
            this.pictureBox_Max.Click += new System.EventHandler(this.pictureBox_Max_Click);
            this.pictureBox_Max.MouseEnter += new System.EventHandler(this.pictureBox_Max_MouseEnter);
            this.pictureBox_Max.MouseLeave += new System.EventHandler(this.pictureBox_Max_MouseLeave);
            // 
            // pictureBox_Min
            // 
            this.pictureBox_Min.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Min.Location = new System.Drawing.Point(836, 13);
            this.pictureBox_Min.Name = "pictureBox_Min";
            this.pictureBox_Min.Size = new System.Drawing.Size(13, 13);
            this.pictureBox_Min.TabIndex = 18;
            this.pictureBox_Min.TabStop = false;
            this.pictureBox_Min.Click += new System.EventHandler(this.pictureBox_Min_Click);
            this.pictureBox_Min.MouseEnter += new System.EventHandler(this.pictureBox_Min_MouseEnter);
            this.pictureBox_Min.MouseLeave += new System.EventHandler(this.pictureBox_Min_MouseLeave);
            // 
            // pictureBox_Close
            // 
            this.pictureBox_Close.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Close.Location = new System.Drawing.Point(882, 13);
            this.pictureBox_Close.Name = "pictureBox_Close";
            this.pictureBox_Close.Size = new System.Drawing.Size(13, 13);
            this.pictureBox_Close.TabIndex = 17;
            this.pictureBox_Close.TabStop = false;
            this.pictureBox_Close.Click += new System.EventHandler(this.pictureBox_Close_Click);
            this.pictureBox_Close.MouseEnter += new System.EventHandler(this.pictureBox_Close_MouseEnter);
            this.pictureBox_Close.MouseLeave += new System.EventHandler(this.pictureBox_Close_MouseLeave);
            // 
            // label_Play
            // 
            this.label_Play.BackColor = System.Drawing.Color.Transparent;
            this.label_Play.Location = new System.Drawing.Point(437, 513);
            this.label_Play.Name = "label_Play";
            this.label_Play.Size = new System.Drawing.Size(40, 40);
            this.label_Play.TabIndex = 19;
            this.label_Play.MouseEnter += new System.EventHandler(this.label_Play_MouseEnter);
            this.label_Play.MouseLeave += new System.EventHandler(this.label_Play_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 562);
            this.Controls.Add(this.label_Play);
            this.Controls.Add(this.pictureBox_Close);
            this.Controls.Add(this.pictureBox_LeftEdge);
            this.Controls.Add(this.pictureBox_RightEdge);
            this.Controls.Add(this.pictureBox_TopEdge);
            this.Controls.Add(this.pictureBox_Min);
            this.Controls.Add(this.pictureBox_Max);
            this.Controls.Add(this.pictureBox_BottomEdge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TopEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LeftEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RightEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_TopEdge;
        private System.Windows.Forms.PictureBox pictureBox_LeftEdge;
        private System.Windows.Forms.PictureBox pictureBox_BottomEdge;
        private System.Windows.Forms.PictureBox pictureBox_RightEdge;
        private System.Windows.Forms.PictureBox pictureBox_Max;
        private System.Windows.Forms.PictureBox pictureBox_Min;
        private System.Windows.Forms.PictureBox pictureBox_Close;
        private System.Windows.Forms.Label label_Play;
    }
}

