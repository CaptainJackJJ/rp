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
        private bool m_bPanelTopMouseDown = false;
        private Point m_PanelTopMouseDownPos;

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

        private bool m_bMaxed = false;

        public MainForm()
        {
            InitializeComponent();
            try
            {                
                pictureBox_Close.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\close.png");
                pictureBox_Max.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\max.png");
                pictureBox_Min.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\min.png");
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\MainForm.jpg");
            }
            catch
            {}
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            m_bPanelTopMouseDown = true;
            m_PanelTopMouseDownPos = e.Location;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if(m_bPanelTopMouseDown)
            {
                int xDiff = e.X - m_PanelTopMouseDownPos.X;
                int yDiff = e.Y - m_PanelTopMouseDownPos.Y;
                this.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            m_bPanelTopMouseDown = false;
        }

        private void pictureBox_TopEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bTopEdge_MouseDown = true;
        }

        private void pictureBox_TopEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if(m_bTopEdge_MouseDown)
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

        private void pictureBox_TopEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bTopEdge_MouseDown = false;
        }

        private void pictureBox_LeftEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bLeftEdge_MouseDown = true;
        }

        private void pictureBox_LeftEdge_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBox_LeftEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bLeftEdge_MouseDown = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            pictureBox_TopEdge.Size
                = new Size(this.Size.Width - m_nEdgeMargin * 2, 
                    pictureBox_TopEdge.Size.Height);
            pictureBox_LeftEdge.Size
                = new Size(pictureBox_LeftEdge.Width,
                    this.Size.Height - m_nEdgeMargin * 2 - pictureBox_TopEdge.Size.Height * 2);
            pictureBox_BottomEdge.Size
                = new Size(this.Size.Width - m_nEdgeMargin * 2, 
                    pictureBox_BottomEdge.Size.Height);
            pictureBox_RightEdge.Size 
                = new Size(pictureBox_RightEdge.Width,
                    this.Size.Height - m_nEdgeMargin * 2 - pictureBox_TopEdge.Size.Height * 2);
            panelTop.Size = new Size(this.Size.Width,panelTop.Size.Height);
            pictureBox_Background.Size
                = new Size(this.Size.Width,
                    this.Size.Height);

            pictureBox_BottomEdge.Location
                = new Point(pictureBox_BottomEdge.Location.X,
                    this.Size.Height - m_nEdgeMargin - pictureBox_BottomEdge.Size.Height);
            pictureBox_RightEdge.Location
                = new Point(this.Size.Width - m_nEdgeMargin - pictureBox_RightEdge.Size.Width, 
                    pictureBox_RightEdge.Location.Y);
            pictureBox_LeftBottomCorner.Location
                = new Point(pictureBox_LeftBottomCorner.Location.X,
                this.Size.Height - pictureBox_LeftBottomCorner.Size.Height);
            pictureBox_RightTopCorner.Location
                = new Point(this.Size.Width - pictureBox_RightTopCorner.Size.Width,
                    pictureBox_RightTopCorner.Location.Y);
            pictureBox_RightBottomCorner.Location
                = new Point(this.Size.Width - pictureBox_RightBottomCorner.Size.Width,
                    this.Size.Height - pictureBox_RightBottomCorner.Size.Height);

            pictureBox_Close.Location =
                new Point(this.Size.Width - m_nTopBarButtonsMargin - m_nTopBarButtonswidth,
                    pictureBox_Close.Location.Y);
            pictureBox_Max.Location =
                new Point(this.Size.Width - m_nTopBarButtonsMargin * 2 - m_nTopBarButtonswidth * 2,
                    pictureBox_Max.Location.Y);
            pictureBox_Min.Location =
               new Point(this.Size.Width - m_nTopBarButtonsMargin * 3 - m_nTopBarButtonswidth * 3,
                    pictureBox_Min.Location.Y);

            pictureBox_Background.Location =
               new Point(0,
                    0);
        }

        private void pictureBox_BottomEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bBottomEdge_MouseDown = true;
        }

        private void pictureBox_BottomEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if(m_bBottomEdge_MouseDown)
            {
                Control control = (Control)sender;

                Point MouseScrrenPoint = control.PointToScreen(new Point(e.X, e.Y));
                this.Size = new Size(this.Size.Width, MouseScrrenPoint.Y - this.Location.Y);
            }
        }

        private void pictureBox_BottomEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bBottomEdge_MouseDown = false;
        }

        private void pictureBox_RightEdge_MouseDown(object sender, MouseEventArgs e)
        {
            m_bRightEdge_MouseDown = true;
        }

        private void pictureBox_RightEdge_MouseMove(object sender, MouseEventArgs e)
        {
            if(m_bRightEdge_MouseDown)
            {
                Control control = (Control)sender;

                Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
                int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
                if (this.Size.Width + xDiff > m_nMinSize)
                    this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
            }
        }

        private void pictureBox_RightEdge_MouseUp(object sender, MouseEventArgs e)
        {
            m_bRightEdge_MouseDown = false;
        }

        private void pictureBox_RightBottomCorner_MouseDown(object sender, MouseEventArgs e)
        {
            m_bRightBottomCornerMouseDown = true;
        }

        private void pictureBox_RightBottomCorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bRightBottomCornerMouseDown)
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
        }

        private void pictureBox_RightBottomCorner_MouseUp(object sender, MouseEventArgs e)
        {
            m_bRightBottomCornerMouseDown = false;
        }

        private void pictureBox_LeftTopCorner_MouseDown(object sender, MouseEventArgs e)
        {
            m_bLeftTopCornerMouseDown = true;
        }

        private void pictureBox_LeftTopCorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bLeftTopCornerMouseDown)
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
        }

        private void pictureBox_LeftTopCorner_MouseUp(object sender, MouseEventArgs e)
        {
            m_bLeftTopCornerMouseDown = false;
        }

        private void pictureBox_LeftBottomCorner_MouseDown(object sender, MouseEventArgs e)
        {
            m_bLeftBottomCornerMouseDown = true;
        }

        private void pictureBox_LeftBottomCorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bLeftBottomCornerMouseDown)
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
        }

        private void pictureBox_LeftBottomCorner_MouseUp(object sender, MouseEventArgs e)
        {
            m_bLeftBottomCornerMouseDown = false;
        }

        private void pictureBox_RightTopCorner_MouseDown(object sender, MouseEventArgs e)
        {
            m_bRightTopCornerMouseDown = true;
        }

        private void pictureBox_RightTopCorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bRightTopCornerMouseDown)
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
        }

        private void pictureBox_RightTopCorner_MouseUp(object sender, MouseEventArgs e)
        {
            m_bRightTopCornerMouseDown = false;
        }

        private void pictureBox_Max_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Max.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\maxFocus.png");
            }catch{}
        }

        private void pictureBox_Max_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Max.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\max.png");
            }
            catch { }
        }

        private void pictureBox_Close_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Close.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
            }
            catch { }
        }

        private void pictureBox_Close_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Close.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\close.png");
            }
            catch { }
        }

        private void pictureBox_Min_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Min.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
            }
            catch { }
        }

        private void pictureBox_Min_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Min.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\min.png");
            }
            catch { }
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Max_Click(object sender, EventArgs e)
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

        private void pictureBox_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
