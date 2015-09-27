using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using RpCoreWrapper;
using MB.Controls;

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

    private bool m_bMute = false;
    private MainForm m_mainForm;
    Thread m_threadUpdate;
    private volatile bool m_stopThreadUpdate = false;
    private double m_nTotalTime = 0;
    private bool m_bPaused = false;

    public FormBottomBar(MainForm mainForm)
    {
      InitializeComponent();
      this.ShowInTaskbar = false;
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
      m_mainForm = mainForm;      
    }

    public void StartThreadUpdate()
    {
      try
      {
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pause.png");
      }
      catch
      {
        label_Play.Text = "pause";
      }

      m_nTotalTime = (int)RpCore.GetTotalTime();
      colorSlider_playProcess.Maximum = (int)m_nTotalTime;
      TimeSpan t = TimeSpan.FromSeconds(m_nTotalTime);
      label_timeLast.Text = string.Format("-{0:D2} : {1:D2} : {2:D2}",
                      t.Hours,
                      t.Minutes,
                      t.Seconds);

      m_stopThreadUpdate = false;
      m_threadUpdate = new Thread(DoThreadUpdate);
      m_threadUpdate.Start();
      while (!m_threadUpdate.IsAlive) ;
    }

    public void EndThreadUpdate()
    {
      m_stopThreadUpdate = true;
      m_threadUpdate.Join();
      colorSlider_playProcess.Value = 0;
      label_timeCurrent.Text = "00 : 00 : 00";
      label_timeLast.Text = "-00 : 00 : 00";
    }

    public void PauseThreadUpdate()
    {
      m_threadUpdate.Suspend();
    }

    public void ResumeThreadUpdate()
    {
      m_threadUpdate.Resume();
    }

    delegate void ChangeTextDelegate(Control ctrl, string text);
    public static void ChangeTextFromThread(Control ctrl, string text)
    {
      if (ctrl.InvokeRequired)
      {
        ChangeTextDelegate del = new ChangeTextDelegate(ChangeTextFromThread);
        ctrl.Invoke(del, ctrl, text);
      }
      else
        ctrl.Text = text;
    }

    delegate void ChangeValueDelegate(ColorSlider ctrl, int value);
    public static void ChangeValueFromThread(ColorSlider ctrl, int value)
    {
      if (ctrl.InvokeRequired)
      {
        ChangeValueDelegate del = new ChangeValueDelegate(ChangeValueFromThread);
        ctrl.Invoke(del, ctrl, value);
      }
      else
      {
        ctrl.Value = value;
      }
    }

    private void DoThreadUpdate()
    {
      while (!m_stopThreadUpdate)
      {
        double nCurTime = RpCore.GetCurTime();
        ChangeValueFromThread(colorSlider_playProcess, (int)nCurTime);

        TimeSpan t = TimeSpan.FromSeconds(nCurTime);
        string strText = string.Format("{0:D2} : {1:D2} : {2:D2}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);
        ChangeTextFromThread(label_timeCurrent, strText);

        t = TimeSpan.FromSeconds(m_nTotalTime - nCurTime);
        strText = string.Format("- {0:D2} : {1:D2} : {2:D2}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);
        ChangeTextFromThread(label_timeLast, strText);

        Thread.Sleep(1000);
      }
    }

    private void FormBottomBar_Resize(object sender, EventArgs e)
    {
      // Every control's location is based on label_Play.
      label_Play.Location =
   new Point(((int)(this.Size.Width * 0.5) - (int)(label_Play.Size.Width * 0.5)),
        this.Size.Height - 50 + 2);
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

      colorSlider_playProcess.Size
          = new Size(this.Width - (m_nPlayProcessXMargin * 2), colorSlider_playProcess.Height);
      colorSlider_playProcess.Location =
          new Point(m_nPlayProcessXMargin, nPlayProcessY);
      label_timeCurrent.Location =
          new Point(m_nPlayProcessXMargin - label_timeCurrent.Width, nPlayProcessY - 4);
      label_timeLast.Location =
          new Point(m_nPlayProcessXMargin + colorSlider_playProcess.Width, nPlayProcessY - 4);

    }

    private void label_Play_Click(object sender, EventArgs e)
    {
      RpCore.Pause();
      if (m_bPaused)
      {
        m_bPaused = false;
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pause.png");
        }
        catch
        {
          label_Play.Text = "play";
        }
      }
      else
      {
        m_bPaused = true;
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
        }
        catch
        {
          label_Play.Text = "pause";
        }
      }
    }

    private void label_Play_MouseEnter(object sender, EventArgs e)
    {
      if (m_bPaused)
      {
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\playFocus.png");
        }
        catch
        {
          label_Play.Text = "playFocus";
        }
      }
      else
      {
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pauseFocus.png");
        }
        catch
        {
          label_Play.Text = "pauseFocus";
        }
      }
    }

    private void label_Play_MouseLeave(object sender, EventArgs e)
    {
      if (m_bPaused)
      {
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
        }
        catch
        {
          label_Play.Text = "play";
        }
      }
      else
      {
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pause.png");
        }
        catch
        {
          label_Play.Text = "pause";
        }
      }
    }

    private void label_Stop_Click(object sender, EventArgs e)
    {
      m_mainForm.StopPlay(true);
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

    private void label_FB_Click(object sender, EventArgs e)
    {

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

    private void colorSlider_playProcess_Click(object sender, EventArgs e)
    {
      PauseThreadUpdate();
      RpCore.Seek(colorSlider_playProcess.Value, false);
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

    private void label_desktop_Click(object sender, EventArgs e)
    {
      m_mainForm.SwitchDesktopMode();
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
  }
}
