using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpCoreWrapper;

namespace RPlayer
{
  public partial class FormBottomBar : Form
  {
    private const int m_nPlayButtonSize = 40;
    private const int m_nBottomButtonsSize = 25;
    private const int m_nBottomButtonsMargin = 15;
    private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonSize - m_nBottomButtonsSize) * 0.5);
    private const int m_nPlayProcessToPlayBtnYMargin = 5;
    private const int m_nPlayProcessXMargin = 90;


    private const int m_nStopBtnXMarginToPlay = -(m_nBottomButtonsMargin * 3 + m_nBottomButtonsSize * 3);
    private const int m_nFBBtnXMarginToPlay = -(m_nBottomButtonsMargin + m_nBottomButtonsSize);
    private const int m_nPreBtnXMarginToPlay = -(m_nBottomButtonsMargin * 2 + m_nBottomButtonsSize * 2);
    private const int m_nFFBtnXMarginToPlay = m_nPlayButtonSize + m_nBottomButtonsMargin;
    private const int m_nNextBtnXMarginToPlay = m_nPlayButtonSize + m_nBottomButtonsMargin * 2 + m_nBottomButtonsSize;

    private bool m_bDesktop;
    private bool m_bMute = false;

    public FormBottomBar()
    {
      InitializeComponent();

      try
      {
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
        label_Stop.Image = Image.FromFile(Application.StartupPath + @"\pic\stop.png");
        label_FF.Image = Image.FromFile(Application.StartupPath + @"\pic\FF.png");
        label_FB.Image = Image.FromFile(Application.StartupPath + @"\pic\FB.png");
        label_Next.Image = Image.FromFile(Application.StartupPath + @"\pic\Next.png");
        label_Pre.Image = Image.FromFile(Application.StartupPath + @"\pic\pre.png");
        label_desktop.Image = Image.FromFile(Application.StartupPath + @"\pic\desktop.png");
        label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
      }
      catch
      {
        this.BackColor = Color.Gainsboro;
        label_Play.Text = "play";
        label_Stop.Text = "stop";
        label_FF.Text = "ff";
        label_FB.Text = "fb";
        label_Next.Text = "next";
        label_desktop.Text = "desktop";
      }
    }

    private void FormBottomBar_Resize(object sender, EventArgs e)
    {
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
      label_desktop.Location =
        new Point(this.Width - m_nBottomButtonsSize, nBottomButtonsY);
      colorSlider_volume.Location =
        new Point(label_desktop.Location.X - 10 - colorSlider_volume.Width, nBottomButtonsY + 7);
      label_Volume.Location =
        new Point(colorSlider_volume.Location.X - label_Volume.Width, nBottomButtonsY);

      int nPlayProcessY = label_Play.Location.Y - m_nPlayProcessToPlayBtnYMargin - colorSlider_playProcess.Height;

      label_timeCurrent.Location =
    new Point(m_nPlayProcessXMargin - label_timeCurrent.Width, nPlayProcessY - 4);
      label_timeLast.Location =
          new Point(m_nPlayProcessXMargin + colorSlider_playProcess.Width, nPlayProcessY - 4);

      colorSlider_playProcess.Size
    = new Size(this.Width - (m_nPlayProcessXMargin * 2), colorSlider_playProcess.Height);
    }

    private void label_Play_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\playFocus.png");
      }
      catch { }
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

    private void label_desktop_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_desktop.Image = Image.FromFile(Application.StartupPath + @"\pic\desktopFocus.png");
      }
      catch { }
    }

    private void label_desktop_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_desktop.Image = Image.FromFile(Application.StartupPath + @"\pic\desktop.png");
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

    private void label_FB_Click(object sender, EventArgs e)
    {

    }

    private void label_Play_Click(object sender, EventArgs e)
    {
      RpCore.Play("F:\\av\\FileSource\\AVATAR.Title1.mp4", 0);
    }

    private void label_desktop_Click(object sender, EventArgs e)
    {
      //if (m_bDesktop)
      //{
      //  m_bDesktop = false;
      //  this.WindowState = FormWindowState.Normal;
      //  label_playWnd.Location = new Point(0, label_Close.Size.Height * 3);
      //}
      //else
      //{
      //  m_bDesktop = true;
      //  this.WindowState = FormWindowState.Maximized;
      //  label_playWnd.Location = this.Location;
      //  label_playWnd.Size = this.Size;
      //}
    }
  }
}
