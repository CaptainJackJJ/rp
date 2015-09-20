using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPlayer
{
    public partial class MainForm : Form
    {
        private bool m_bMainFormMouseDown = false;
        private bool m_bMainFormMouseDownNoEdge = false;
        private Point m_MainFormMouseDownPos;

        private bool m_bTopEdge_MouseDown = false;
        private bool m_bLeftEdge_MouseDown = false;
        private bool m_bBottomEdge_MouseDown = false;
        private bool m_bRightEdge_MouseDown = false;

        private bool m_bLeftTopCornerMouseDown = false;
        private bool m_bLeftBottomCornerMouseDown = false;
        private bool m_bRightBottomCornerMouseDown = false;
        private bool m_bRightTopCornerMouseDown = false;

        private const int m_nMinSize = 50;
        private const int m_nEdgeMargin = 1;
        private const int m_nTopBarButtonsMargin = 20;
        private const int m_nTopBarButtonswidth = 13;
        private const int m_nRenderToTopBarMargin = 12;
        private const int m_nRenderToBottomBarMargin = 23;
        private const int m_nCornerSize = 10;
        private const int m_nPlayButtonSize = 40;
        private const int m_nBottomButtonsSize = 25;
        private const int m_nBottomButtonsMargin = 15;
        private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonSize - m_nBottomButtonsSize) * 0.5);
        private const int m_nPlayProcessToPlayBtnYMargin = 5;
        private const int m_nPlayProcessXMargin = 100;
       

        private const int m_nStopBtnXMarginToPlay = -(m_nBottomButtonsMargin * 3 + m_nBottomButtonsSize * 3);
        private const int m_nFBBtnXMarginToPlay = -(m_nBottomButtonsMargin + m_nBottomButtonsSize);
        private const int m_nPreBtnXMarginToPlay = -(m_nBottomButtonsMargin * 2 + m_nBottomButtonsSize * 2);
        private const int m_nFFBtnXMarginToPlay = m_nPlayButtonSize + m_nBottomButtonsMargin;
        private const int m_nNextBtnXMarginToPlay = m_nPlayButtonSize + m_nBottomButtonsMargin * 2 + m_nBottomButtonsSize;

        private bool m_bMaxed = false;
        private bool m_bInCorner = false;

        public MainForm()
        {
            InitializeComponent();
            try
            {                
                label_Close.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\close.png");
                label_Max.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\max.png");
                label_Min.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\min.png");
                label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
                label_Stop.Image = Image.FromFile(Application.StartupPath + @"\pic\stop.png");
                label_FF.Image = Image.FromFile(Application.StartupPath + @"\pic\FF.png");
                label_FB.Image = Image.FromFile(Application.StartupPath + @"\pic\FB.png");
                label_Next.Image = Image.FromFile(Application.StartupPath + @"\pic\Next.png");
                label_Pre.Image = Image.FromFile(Application.StartupPath + @"\pic\pre.png");
                label_fullScreen.Image = Image.FromFile(Application.StartupPath + @"\pic\FullScreen.png");
                label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
                label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");

                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\MainForm.jpg");
            }
            catch
            {
                this.BackColor = Color.Gainsboro;
                label_Play.Text = "play";
                label_Stop.Text = "stop";
                label_FF.Text = "ff";
                label_FB.Text = "fb";
                label_Next.Text = "next";
                label_fullScreen.Text = "full";
                label_settings.Text = "settings";
                label_Volume.Text = "volume";
                label_Close.Text = "close";
                label_Max.Text = "max";
                label_Min.Text = "min";
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            label_Close.Location =
                new Point(this.Size.Width - m_nTopBarButtonsMargin - m_nTopBarButtonswidth,
                    label_Close.Location.Y);
            label_Max.Location =
                new Point(this.Size.Width - m_nTopBarButtonsMargin * 2 - m_nTopBarButtonswidth * 2,
                    label_Max.Location.Y);
            label_Min.Location =
               new Point(this.Size.Width - m_nTopBarButtonsMargin * 3 - m_nTopBarButtonswidth * 3,
                    label_Min.Location.Y);
            label_settings.Location =
               new Point(this.Size.Width - m_nTopBarButtonsMargin * 4 - m_nTopBarButtonswidth * 4,
                    label_settings.Location.Y);

            label_Play.Location =
               new Point(((int)(this.Size.Width * 0.5) - (int)(label_Play.Size.Width * 0.5)),
                    this.Size.Height - 50);
            int nBottomButtonsY = label_Play.Location.Y + m_nBottomBtnsToPlayBtnYMargin;
            label_Stop.Location =
               new Point((label_Play.Location.X + m_nStopBtnXMarginToPlay),
                    nBottomButtonsY);
            label_FF.Location =
               new Point((label_Play.Location.X + m_nFFBtnXMarginToPlay),
                    nBottomButtonsY);
            label_FB.Location =
               new Point((label_Play.Location.X + m_nFBBtnXMarginToPlay),
                    nBottomButtonsY);
            label_Next.Location =
               new Point((label_Play.Location.X + m_nNextBtnXMarginToPlay),
                    nBottomButtonsY);
            label_Pre.Location =
               new Point((label_Play.Location.X + m_nPreBtnXMarginToPlay),
                    nBottomButtonsY);
            label_fullScreen.Location =
              new Point(this.Width - 10 - m_nBottomButtonsSize, nBottomButtonsY);
            colorSlider_volume.Location =
              new Point(label_fullScreen.Location.X - 10 - colorSlider_volume.Width, nBottomButtonsY + 7);
            label_Volume.Location =
              new Point(colorSlider_volume.Location.X - label_Volume.Width, nBottomButtonsY);

            int nPlayProcessY = label_Play.Location.Y - m_nPlayProcessToPlayBtnYMargin - colorSlider_playProcess.Height;
            colorSlider_playProcess.Location = new Point(m_nPlayProcessXMargin, nPlayProcessY);

            if (m_bMainFormMouseDown || m_bTopEdge_MouseDown || m_bLeftEdge_MouseDown 
                || m_bBottomEdge_MouseDown || m_bRightEdge_MouseDown)
            {
                label_TopEdge.Visible = label_LeftEdge.Visible 
                    = label_BottomEdge.Visible = label_RightEdge.Visible = false;
            }
            else
            {
                UpdateEdge();
            }

            colorSlider_playProcess.Size
                = new Size(this.Width - (m_nPlayProcessXMargin * 2), colorSlider_playProcess.Height);

            label_timeCurrent.Location =
                new Point(m_nPlayProcessXMargin - label_timeCurrent.Width, nPlayProcessY - 4);
            label_timeLast.Location =
                new Point(m_nPlayProcessXMargin + colorSlider_playProcess.Width, nPlayProcessY - 4);
        }      

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= this.Size.Width - m_nCornerSize && e.Location.Y >= this.Size.Height - m_nCornerSize)
                m_bRightBottomCornerMouseDown = true;
            else if (e.Location.X < m_nCornerSize && e.Location.Y < m_nCornerSize)
                m_bLeftTopCornerMouseDown = true;
            else if (e.Location.X < m_nCornerSize && e.Location.Y >= this.Size.Height - m_nCornerSize)
                m_bLeftBottomCornerMouseDown = true;
            else if (e.Location.X >= this.Size.Width - m_nCornerSize && e.Location.Y < m_nCornerSize)
                m_bRightTopCornerMouseDown = true;
            else
                m_bMainFormMouseDownNoEdge = true;
            m_MainFormMouseDownPos = e.Location;
            m_bMainFormMouseDown = true;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bMainFormMouseDownNoEdge)
            {
                int xDiff = e.X - m_MainFormMouseDownPos.X;
                int yDiff = e.Y - m_MainFormMouseDownPos.Y;
                this.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
            }
            else if (m_bRightBottomCornerMouseDown)
            {
                Control control = (Control)sender;
                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
                int yDiff = MouseScreenPoint.Y - (this.Location.Y + this.Size.Height);
                if (this.Size.Width + xDiff > m_nMinSize &&
                    this.Size.Height + yDiff > m_nMinSize)
                {
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
                }
            }
            else if (m_bLeftTopCornerMouseDown)
            {
                Control control = (Control)sender;
                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = this.Location.X - MouseScreenPoint.X;
                int yDiff = this.Location.Y - MouseScreenPoint.Y;
                if (this.Size.Width + xDiff > m_nMinSize &&
                    this.Size.Height + yDiff > m_nMinSize)
                {
                    this.Location = new Point(MouseScreenPoint.X, MouseScreenPoint.Y);
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
                }
            }
            else if (m_bLeftBottomCornerMouseDown)
            {
                Control control = (Control)sender;
                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = this.Location.X - MouseScreenPoint.X;
                int yDiff = MouseScreenPoint.Y - (this.Location.Y + this.Size.Height);
                if (this.Size.Width + xDiff > m_nMinSize &&
                    this.Size.Height + yDiff > m_nMinSize)
                {
                    this.Location = new Point(MouseScreenPoint.X, this.Location.Y);
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
                }
            }
            else if (m_bRightTopCornerMouseDown)
            {
                Control control = (Control)sender;
                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
                int yDiff = this.Location.Y - MouseScreenPoint.Y;
                if (this.Size.Width + xDiff > m_nMinSize &&
                    this.Size.Height + yDiff > m_nMinSize)
                {
                    this.Location = new Point(this.Location.X, MouseScreenPoint.Y);
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
                }
            }

            if ((e.Location.X >= this.Size.Width - m_nCornerSize && e.Location.Y >= this.Size.Height - m_nCornerSize)
                ||
                (e.Location.X < m_nCornerSize && e.Location.Y < m_nCornerSize)
                )
            {
                Cursor = Cursors.SizeNWSE;
                m_bInCorner = true;
            }
            else if ((e.Location.X < m_nCornerSize && e.Location.Y >= this.Size.Height - m_nCornerSize)
                ||
                (e.Location.X >= this.Size.Width - m_nCornerSize && e.Location.Y < m_nCornerSize)
                )
            {
                Cursor = Cursors.SizeNESW;
                m_bInCorner = true;
            }
            else if (m_bInCorner)
            {
                Cursor = Cursors.Arrow;
                m_bInCorner = false;
            }
        }

        private void UpdateEdge()
        {
            label_TopEdge.Visible = label_LeftEdge.Visible 
                = label_BottomEdge.Visible = label_RightEdge.Visible = true;

            label_TopEdge.Size
                = new Size(this.Size.Width - m_nEdgeMargin * 2,
                    label_TopEdge.Size.Height);
            label_LeftEdge.Size
                = new Size(label_LeftEdge.Width,
                    this.Size.Height - m_nEdgeMargin * 2 - label_TopEdge.Size.Height * 2);
            label_BottomEdge.Size
                = new Size(this.Size.Width - m_nEdgeMargin * 2,
                    label_BottomEdge.Size.Height);
            label_RightEdge.Size
                = new Size(label_RightEdge.Width,
                    this.Size.Height - m_nEdgeMargin * 2 - label_TopEdge.Size.Height * 2);

            label_BottomEdge.Location
                = new Point(label_BottomEdge.Location.X,
                    this.Size.Height - m_nEdgeMargin - label_BottomEdge.Size.Height);
            label_RightEdge.Location
                = new Point(this.Size.Width - m_nEdgeMargin - label_RightEdge.Size.Width,
                    label_RightEdge.Location.Y);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            m_bMainFormMouseDown = false;
            if (!label_TopEdge.Visible)
                UpdateEdge();

            m_bMainFormMouseDownNoEdge = m_bRightBottomCornerMouseDown
                = m_bLeftTopCornerMouseDown = m_bLeftBottomCornerMouseDown = m_bRightTopCornerMouseDown = false;
        }

        private void label_Play_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\playFocus.png");
            }catch { }
        }

        private void label_Play_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
            }
            catch { }
        }

        private void label_Stop_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Stop.Image = Image.FromFile(Application.StartupPath + @"\pic\stopFocus.png");
            }
            catch { }
        }

        private void label_Stop_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Stop.Image = Image.FromFile(Application.StartupPath + @"\pic\stop.png");
            }
            catch { }
        }

        private void label_FF_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_FF.Image = Image.FromFile(Application.StartupPath + @"\pic\FFFocus.png");
            }
            catch { }
        }

        private void label_FF_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_FF.Image = Image.FromFile(Application.StartupPath + @"\pic\FF.png");
            }
            catch { }
        }

        private void label_FB_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_FB.Image = Image.FromFile(Application.StartupPath + @"\pic\FBFocus.png");
            }
            catch { }
        }

        private void label_FB_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_FB.Image = Image.FromFile(Application.StartupPath + @"\pic\FB.png");
            }
            catch { }
        }

        private void label_Next_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Next.Image = Image.FromFile(Application.StartupPath + @"\pic\NextFocus.png");
            }
            catch { }
        }

        private void label_Next_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Next.Image = Image.FromFile(Application.StartupPath + @"\pic\Next.png");
            }
            catch { }
        }

        private void label_Pre_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Pre.Image = Image.FromFile(Application.StartupPath + @"\pic\preFocus.png");
            }
            catch { }
        }

        private void label_Pre_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Pre.Image = Image.FromFile(Application.StartupPath + @"\pic\pre.png");
            }
            catch { }
        }

        private void label_Min_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Min.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
            }
            catch { }
        }

        private void label_Min_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Min.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\min.png");
            }
            catch { }
        }

        private void label_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_Close_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Close.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
            }
            catch { }
        }

        private void label_Close_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Close.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\close.png");
            }
            catch { }
        }

        private void label_Max_Click(object sender, EventArgs e)
        {
            if (m_bMaxed)
            {
                this.WindowState = FormWindowState.Normal;
                m_bMaxed = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                m_bMaxed = true;
            }
        }

        private void label_Max_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_Max.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\maxFocus.png");
            }
            catch { }
        }

        private void label_Max_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_Max.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\max.png");
            }
            catch { }
        }

        private void label_LeftEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bLeftEdge_MouseDown = true;
        }

        private void label_LeftEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bLeftEdge_MouseDown)
            {
                Control control = (Control)sender;

                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = this.Location.X - MouseScreenPoint.X;
                if (this.Size.Width + xDiff > m_nMinSize)
                {
                    this.Location = new Point(MouseScreenPoint.X, this.Location.Y);
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
                }
            }
        }

        private void label_LeftEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bLeftEdge_MouseDown = false;
            if (!label_TopEdge.Visible)
                UpdateEdge();
        }

        private void label_TopEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bTopEdge_MouseDown = true;
        }

        private void label_TopEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bTopEdge_MouseDown)
            {
                Control control = (Control)sender;
                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int yDiff = this.Location.Y - MouseScreenPoint.Y;
                if (this.Size.Height + yDiff > m_nMinSize)
                {
                    this.Location = new Point(this.Location.X, MouseScreenPoint.Y);
                    this.Size = new Size(this.Size.Width, this.Size.Height + yDiff);
                }
            }
        }

        private void label_TopEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bTopEdge_MouseDown = false;
            if (!label_TopEdge.Visible)
                UpdateEdge();
        }

        private void label_RightEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bRightEdge_MouseDown = true;
        }

        private void label_RightEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bRightEdge_MouseDown)
            {
                Control control = (Control)sender;

                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
                if (this.Size.Width + xDiff > m_nMinSize)
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
            }
        }

        private void label_RightEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bRightEdge_MouseDown = false;
            if (!label_TopEdge.Visible)
                UpdateEdge();
        }

        private void label_BottomEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bBottomEdge_MouseDown = true;
        }

        private void label_BottomEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bBottomEdge_MouseDown)
            {
                Control control = (Control)sender;

                Point MouseScrrenPoint = control.PointToScreen(new Point(e.X, e.Y));
                this.Size = new Size(this.Size.Width, MouseScrrenPoint.Y - this.Location.Y);
            }
        }

        private void label_BottomEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bBottomEdge_MouseDown = false;
            if (!label_TopEdge.Visible)
                UpdateEdge();
        }

        private void colorSlider_playProcess_MouseEnter(object sender, EventArgs e)
        {
            colorSlider_playProcess.ThumbInnerColor = Color.White;
            colorSlider_playProcess.ThumbOuterColor = Color.White;
        }

        private void colorSlider_playProcess_MouseLeave(object sender, EventArgs e)
        {
            colorSlider_playProcess.ThumbInnerColor = Color.Transparent;
            colorSlider_playProcess.ThumbOuterColor = Color.Transparent;
        }

        private void label_fullScreen_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_fullScreen.Image = Image.FromFile(Application.StartupPath + @"\pic\FullScreenFocus.png");
            }
            catch { }
        }

        private void label_fullScreen_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_fullScreen.Image = Image.FromFile(Application.StartupPath + @"\pic\FullScreen.png");
            }
            catch { }
        }

        private void label_Volume_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (m_bMute)              
                    label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMuteFocus.png");
                else
                    label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeFocus.png");
            }
            catch { }
        }

        private void label_Volume_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (m_bMute)
                    label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMute.png");
                else
                    label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
            }
            catch { }
        }

        private bool m_bMute = false;

        private void label_Volume_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_bMute)
                {
                    m_bMute = false;
                    label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeFocus.png");
                }
                else
                {
                    m_bMute = true;
                    label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMuteFocus.png");
                }
            }
            catch { }
        }

        private void label_settings_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settingsFocus.png");
            }
            catch { }
        }

        private void label_settings_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");
            }
            catch { }
        }
    }
}
