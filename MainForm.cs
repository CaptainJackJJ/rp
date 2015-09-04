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

        public MainForm()
        {
            InitializeComponent();
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
    }
}
