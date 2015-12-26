using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpCoreWrapper;
using System.IO;

namespace RPlayer
{
    public partial class FormChangeLog : Form
    {
      private bool m_bTopBarMouseDown = false;
      private Point m_TopBarMouseDownPos;

      public FormChangeLog()
      {
        InitializeComponent();
      }

      private void FormChangeLog_Shown(object sender, EventArgs e)
      {
        try
        {
          label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
        }
        catch
        {
          label_settingsClose.Text = "close";
        }

        if (Archive.lang == "中文")
        {
          label_changeLog.Text = "版本历史";

          richTextBox_thanks.Text =
@"
谢谢您陪伴着兔子影音成长。

我会更加努力的修复bug、添加新功能，带给您更好的播放器。";
        }

        try
        {
          if (Archive.lang == "中文")
          {
            using (StreamReader sr = new StreamReader("changeLogCh.txt"))
            {
              richTextBox_changeLog.Text = sr.ReadToEnd();
            }
          }
          else
          {
            using (StreamReader sr = new StreamReader("changeLogEng.txt"))
            {
              richTextBox_changeLog.Text = sr.ReadToEnd();
            }
          }

        }
        catch
        {
          MessageBox.Show("change log file is missing");
        }
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
