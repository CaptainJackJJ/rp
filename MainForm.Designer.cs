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
            this.label_Play = new System.Windows.Forms.Label();
            this.label_Stop = new System.Windows.Forms.Label();
            this.label_FF = new System.Windows.Forms.Label();
            this.label_FB = new System.Windows.Forms.Label();
            this.label_Next = new System.Windows.Forms.Label();
            this.label_Pre = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.label_Close = new System.Windows.Forms.Label();
            this.label_Max = new System.Windows.Forms.Label();
            this.label_LeftEdge = new System.Windows.Forms.Label();
            this.label_TopEdge = new System.Windows.Forms.Label();
            this.label_RightEdge = new System.Windows.Forms.Label();
            this.label_BottomEdge = new System.Windows.Forms.Label();
            this.colorSlider_playProcess = new MB.Controls.ColorSlider();
            this.SuspendLayout();
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
            // label_LeftEdge
            // 
            this.label_LeftEdge.BackColor = System.Drawing.Color.Gray;
            this.label_LeftEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.label_LeftEdge.Location = new System.Drawing.Point(1, 2);
            this.label_LeftEdge.Name = "label_LeftEdge";
            this.label_LeftEdge.Size = new System.Drawing.Size(1, 596);
            this.label_LeftEdge.TabIndex = 28;
            this.label_LeftEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_LeftEdge_MouseDown);
            this.label_LeftEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_LeftEdge_MouseMove);
            this.label_LeftEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_LeftEdge_MouseUp);
            // 
            // label_TopEdge
            // 
            this.label_TopEdge.BackColor = System.Drawing.Color.Gray;
            this.label_TopEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.label_TopEdge.Location = new System.Drawing.Point(1, 1);
            this.label_TopEdge.Name = "label_TopEdge";
            this.label_TopEdge.Size = new System.Drawing.Size(913, 1);
            this.label_TopEdge.TabIndex = 29;
            this.label_TopEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_TopEdge_MouseDown);
            this.label_TopEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_TopEdge_MouseMove);
            this.label_TopEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_TopEdge_MouseUp);
            // 
            // label_RightEdge
            // 
            this.label_RightEdge.BackColor = System.Drawing.Color.Gray;
            this.label_RightEdge.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.label_RightEdge.Location = new System.Drawing.Point(913, 2);
            this.label_RightEdge.Name = "label_RightEdge";
            this.label_RightEdge.Size = new System.Drawing.Size(1, 560);
            this.label_RightEdge.TabIndex = 30;
            this.label_RightEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_RightEdge_MouseDown);
            this.label_RightEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_RightEdge_MouseMove);
            this.label_RightEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_RightEdge_MouseUp);
            // 
            // label_BottomEdge
            // 
            this.label_BottomEdge.BackColor = System.Drawing.Color.Gray;
            this.label_BottomEdge.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.label_BottomEdge.Location = new System.Drawing.Point(1, 598);
            this.label_BottomEdge.Name = "label_BottomEdge";
            this.label_BottomEdge.Size = new System.Drawing.Size(913, 1);
            this.label_BottomEdge.TabIndex = 31;
            this.label_BottomEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_BottomEdge_MouseDown);
            this.label_BottomEdge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_BottomEdge_MouseMove);
            this.label_BottomEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_BottomEdge_MouseUp);
            // 
            // colorSlider_playProcess
            // 
            this.colorSlider_playProcess.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider_playProcess.BarInnerColor = System.Drawing.Color.Gray;
            this.colorSlider_playProcess.BarOuterColor = System.Drawing.Color.Transparent;
            this.colorSlider_playProcess.BarPenColor = System.Drawing.Color.Transparent;
            this.colorSlider_playProcess.BorderRoundRectSize = new System.Drawing.Size(1, 1);
            this.colorSlider_playProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSlider_playProcess.DrawFocusRectangle = false;
            this.colorSlider_playProcess.ElapsedInnerColor = System.Drawing.Color.RoyalBlue;
            this.colorSlider_playProcess.ElapsedOuterColor = System.Drawing.Color.MidnightBlue;
            this.colorSlider_playProcess.LargeChange = ((uint)(5u));
            this.colorSlider_playProcess.Location = new System.Drawing.Point(80, 497);
            this.colorSlider_playProcess.MouseEffects = false;
            this.colorSlider_playProcess.MouseWheelBarPartitions = 100;
            this.colorSlider_playProcess.Name = "colorSlider_playProcess";
            this.colorSlider_playProcess.Size = new System.Drawing.Size(755, 10);
            this.colorSlider_playProcess.SmallChange = ((uint)(1u));
            this.colorSlider_playProcess.TabIndex = 32;
            this.colorSlider_playProcess.ThumbInnerColor = System.Drawing.Color.Transparent;
            this.colorSlider_playProcess.ThumbOuterColor = System.Drawing.Color.Transparent;
            this.colorSlider_playProcess.ThumbPenColor = System.Drawing.Color.Transparent;
            this.colorSlider_playProcess.ThumbRoundRectSize = new System.Drawing.Size(9, 9);
            this.colorSlider_playProcess.ThumbSize = 9;
            this.colorSlider_playProcess.MouseEnter += new System.EventHandler(this.colorSlider_playProcess_MouseEnter);
            this.colorSlider_playProcess.MouseLeave += new System.EventHandler(this.colorSlider_playProcess_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 562);
            this.Controls.Add(this.colorSlider_playProcess);
            this.Controls.Add(this.label_BottomEdge);
            this.Controls.Add(this.label_RightEdge);
            this.Controls.Add(this.label_TopEdge);
            this.Controls.Add(this.label_LeftEdge);
            this.Controls.Add(this.label_Max);
            this.Controls.Add(this.label_Close);
            this.Controls.Add(this.label_Min);
            this.Controls.Add(this.label_Pre);
            this.Controls.Add(this.label_Next);
            this.Controls.Add(this.label_FB);
            this.Controls.Add(this.label_FF);
            this.Controls.Add(this.label_Stop);
            this.Controls.Add(this.label_Play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Play;
        private System.Windows.Forms.Label label_Stop;
        private System.Windows.Forms.Label label_FF;
        private System.Windows.Forms.Label label_FB;
        private System.Windows.Forms.Label label_Next;
        private System.Windows.Forms.Label label_Pre;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.Label label_LeftEdge;
        private System.Windows.Forms.Label label_TopEdge;
        private System.Windows.Forms.Label label_RightEdge;
        private System.Windows.Forms.Label label_BottomEdge;
        private MB.Controls.ColorSlider colorSlider_playProcess;
    }
}

