using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoreWrapper;
using System.IO;

namespace RPlayer
{
    public partial class FormHelp : Form
    {
      private bool m_bTopBarMouseDown = false;
      private Point m_TopBarMouseDownPos;

      public FormHelp()
      {
        InitializeComponent();
        using (StreamReader sr = new StreamReader("help.txt"))
        {
          richTextBox_changeLog.Text = sr.ReadToEnd();
        }
        label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      }


      private void label_settingsClose_Click(object sender, EventArgs e)
      {
        this.Close();
      }

      private void label_settingsClose_MouseEnter(object sender, EventArgs e)
      {
        try
        {
          label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
        }
        catch { }
      }

      private void label_settingsClose_MouseLeave(object sender, EventArgs e)
      {
        try
        {
          label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
        }
        catch { }
      }

      private void panel_topBar_MouseDown(object sender, MouseEventArgs e)
      {
        m_bTopBarMouseDown = true;
        m_TopBarMouseDownPos = e.Location;
      }

      private void panel_topBar_MouseMove(object sender, MouseEventArgs e)
      {
        if (m_bTopBarMouseDown)
        {
          int xDiff = e.X - m_TopBarMouseDownPos.X;
          int yDiff = e.Y - m_TopBarMouseDownPos.Y;
          this.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
        }
      }

      private void panel_topBar_MouseUp(object sender, MouseEventArgs e)
      {
        m_bTopBarMouseDown = false;
      }
    }
}
