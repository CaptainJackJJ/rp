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
            this.label_Play = new System.Windows.Forms.Label();
            this.label_Stop = new System.Windows.Forms.Label();
            this.label_FF = new System.Windows.Forms.Label();
            this.label_FB = new System.Windows.Forms.Label();
            this.label_Next = new System.Windows.Forms.Label();
            this.label_Pre = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.label_Close = new System.Windows.Forms.Label();
            this.label_Max = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TopEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LeftEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RightEdge)).BeginInit();
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
            // label_Stop
            // 
            this.label_Stop.BackColor = System.Drawing.Color.Transparent;
            this.label_Stop.Location = new System.Drawing.Point(397, 519);
            this.label_Stop.Name = "label_Stop";
            this.label_Stop.Size = new System.Drawing.Size(25, 25);
            this.label_Stop.TabIndex = 20;
            this.label_Stop.MouseEnter += new System.EventHandler(this.label_Stop_MouseEnter);
            this.label_Stop.MouseLeave += new System.EventHandler(this.label_Stop_MouseLeave);
            // 
            // label_FF
            // 
            this.label_FF.BackColor = System.Drawing.Color.Transparent;
            this.label_FF.Location = new System.Drawing.Point(452, 519);
            this.label_FF.Name = "label_FF";
            this.label_FF.Size = new System.Drawing.Size(25, 25);
            this.label_FF.TabIndex = 21;
            this.label_FF.MouseEnter += new System.EventHandler(this.label_FF_MouseEnter);
            this.label_FF.MouseLeave += new System.EventHandler(this.label_FF_MouseLeave);
            // 
            // label_FB
            // 
            this.label_FB.BackColor = System.Drawing.Color.Transparent;
            this.label_FB.Location = new System.Drawing.Point(452, 519);
            this.label_FB.Name = "label_FB";
            this.label_FB.Size = new System.Drawing.Size(25, 25);
            this.label_FB.TabIndex = 22;
            this.label_FB.MouseEnter += new System.EventHandler(this.label_FB_MouseEnter);
            this.label_FB.MouseLeave += new System.EventHandler(this.label_FB_MouseLeave);
            // 
            // label_Next
            // 
            this.label_Next.BackColor = System.Drawing.Color.Transparent;
            this.label_Next.Location = new System.Drawing.Point(532, 519);
            this.label_Next.Name = "label_Next";
            this.label_Next.Size = new System.Drawing.Size(25, 25);
            this.label_Next.TabIndex = 23;
            this.label_Next.MouseEnter += new System.EventHandler(this.label_Next_MouseEnter);
            this.label_Next.MouseLeave += new System.EventHandler(this.label_Next_MouseLeave);
            // 
            // label_Pre
            // 
            this.label_Pre.BackColor = System.Drawing.Color.Transparent;
            this.label_Pre.Location = new System.Drawing.Point(357, 519);
            this.label_Pre.Name = "label_Pre";
            this.label_Pre.Size = new System.Drawing.Size(25, 25);
            this.label_Pre.TabIndex = 24;
            this.label_Pre.MouseEnter += new System.EventHandler(this.label_Pre_MouseEnter);
            this.label_Pre.MouseLeave += new System.EventHandler(this.label_Pre_MouseLeave);
            // 
            // label_Min
            // 
            this.label_Min.BackColor = System.Drawing.Color.Transparent;
            this.label_Min.Location = new System.Drawing.Point(836, 13);
            this.label_Min.Name = "label_Min";
            this.label_Min.Size = new System.Drawing.Size(13, 13);
            this.label_Min.TabIndex = 25;
            this.label_Min.Click += new System.EventHandler(this.label_Min_Click);
            this.label_Min.MouseEnter += new System.EventHandler(this.label_Min_MouseEnter);
            this.label_Min.MouseLeave += new System.EventHandler(this.label_Min_MouseLeave);
            // 
            // label_Close
            // 
            this.label_Close.BackColor = System.Drawing.Color.Transparent;
            this.label_Close.Location = new System.Drawing.Point(882, 13);
            this.label_Close.Name = "label_Close";
            this.label_Close.Size = new System.Drawing.Size(13, 13);
            this.label_Close.TabIndex = 26;
            this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
            this.label_Close.MouseEnter += new System.EventHandler(this.label_Close_MouseEnter);
            this.label_Close.MouseLeave += new System.EventHandler(this.label_Close_MouseLeave);
            // 
            // label_Max
            // 
            this.label_Max.BackColor = System.Drawing.Color.Transparent;
            this.label_Max.Location = new System.Drawing.Point(859, 13);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(13, 13);
            this.label_Max.TabIndex = 27;
            this.label_Max.Click += new System.EventHandler(this.label_Max_Click);
            this.label_Max.MouseEnter += new System.EventHandler(this.label_Max_MouseEnter);
            this.label_Max.MouseLeave += new System.EventHandler(this.label_Max_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 562);
            this.Controls.Add(this.label_Max);
            this.Controls.Add(this.label_Close);
            this.Controls.Add(this.label_Min);
            this.Controls.Add(this.label_Pre);
            this.Controls.Add(this.label_Next);
            this.Controls.Add(this.label_FB);
            this.Controls.Add(this.label_FF);
            this.Controls.Add(this.label_Stop);
            this.Controls.Add(this.label_Play);
            this.Controls.Add(this.pictureBox_LeftEdge);
            this.Controls.Add(this.pictureBox_RightEdge);
            this.Controls.Add(this.pictureBox_TopEdge);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_TopEdge;
        private System.Windows.Forms.PictureBox pictureBox_LeftEdge;
        private System.Windows.Forms.PictureBox pictureBox_BottomEdge;
        private System.Windows.Forms.PictureBox pictureBox_RightEdge;
        private System.Windows.Forms.Label label_Play;
        private System.Windows.Forms.Label label_Stop;
        private System.Windows.Forms.Label label_FF;
        private System.Windows.Forms.Label label_FB;
        private System.Windows.Forms.Label label_Next;
        private System.Windows.Forms.Label label_Pre;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_Max;
    }
}

