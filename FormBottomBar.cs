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

    public bool m_bMute = false;
    private MainForm m_mainForm;
    Thread m_threadUpdate;
    private volatile bool m_stopThreadUpdate = false;
    private double m_nTotalTime = 0;
    private bool m_bPaused = false;
    private Object m_TimeMoniter = new Object();
    public bool m_bProcessBarMouseUp = true;
    public bool m_bSeekDone = true;
    private bool m_bDragSeeking = false;
    private float m_fSpeed = 1f;

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

    public void UpDownVolume(bool bUp)
    {
      if (bUp)
      {
        if (colorSlider_volume.Value < colorSlider_volume.Maximum)
          colorSlider_volume.Value++;
      }
      else
      {
        if (colorSlider_volume.Value > colorSlider_volume.Minimum)
          colorSlider_volume.Value--;
      }
    }

    public void TriggerVolumeOnMouseWheel(MouseEventArgs e)
    {
      colorSlider_volume.TriggerOnMouseWheel(e);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      colorSlider_volume.TriggerOnMouseWheel(e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (m_mainForm.HandleCmdKey(keyData))
        return true;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public void StartThreadUpdate()
    {
      try
      {
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pause.png");
        m_bMute = m_mainForm.m_bMute;
        if (m_bMute)
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMute.png");
        else
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
      }
      catch
      {
        label_Play.Text = "pause";
        if (m_mainForm.m_bMute)
          label_Volume.Text = "mute";
        else
          label_Volume.Text = "volume";
      }
      colorSlider_volume.Value = m_mainForm.GetVolume();

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

    private void PauseTimeUpdate()
    {
      Monitor.Enter(m_TimeMoniter);
    }

    delegate void ResumeTimeUpdateDelegate(bool bInvoke);
    public void ResumeTimeUpdate(bool bInvoke)
    {
      if (bInvoke)
      {
        ResumeTimeUpdateDelegate del = new ResumeTimeUpdateDelegate(ResumeTimeUpdate);
        colorSlider_playProcess.Invoke(del, false);
      }
      else
      {
        while (true)
        {
          try
          {
            Monitor.Exit(m_TimeMoniter);
          }
          catch (SynchronizationLockException)
          { break; }
        }
      }
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

    delegate void AskReleaseLockDelegate(ColorSlider ctrl);
    public void AskReleaseLockFromThread(ColorSlider ctrl)
    {
      if (ctrl.InvokeRequired)
      {
        AskReleaseLockDelegate del = new AskReleaseLockDelegate(AskReleaseLockFromThread);
        ctrl.Invoke(del, ctrl);
      }
      else
      {
        while (true)
        {
          try
          {
            Monitor.Exit(m_TimeMoniter);
          }
          catch (SynchronizationLockException)
          { break; }
        }
      }
    }

    private void DoThreadUpdate()
    {
      while (!m_stopThreadUpdate)
      {
        bool bOwnLock = false;
        try
        {
          bOwnLock = Monitor.TryEnter(m_TimeMoniter, 1000 * 10);
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
        }
        finally
        {
          if (bOwnLock)
            Monitor.Exit(m_TimeMoniter);
          else
            AskReleaseLockFromThread(colorSlider_playProcess);
        }

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

    public void Pause()
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

    private void label_Play_Click(object sender, EventArgs e)
    {
      Pause();
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
      m_mainForm.StopPlay();
      m_mainForm.SwitchFormMode(false);
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

    public void ChangeSpeed(bool bForward)
    {
      int nSpeed = (int)(m_fSpeed * 1000);
      if(bForward)
      {
        if(nSpeed >= 1000)
        {
          m_fSpeed *= 2;
        }
        else
        {
          m_fSpeed /= 2;
        }
      }
      else
      {
        if (nSpeed > 1000)
        {
          m_fSpeed /= 2;
        }
        else if (nSpeed == 1000)
        {
          m_fSpeed *= -2;
        }
        else
        {
          m_fSpeed *= 2;
        }
      }
      nSpeed = (int)(m_fSpeed * 1000);
      if (nSpeed == -1000)
        m_fSpeed = 1;
      RpCore.ToFFRW(m_fSpeed);
    }

    private void label_FF_Click(object sender, EventArgs e)
    {
      ChangeSpeed(true);
    }
    private void label_FB_Click(object sender, EventArgs e)
    {
      ChangeSpeed(false);
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

    private void colorSlider_playProcess_MouseDown(object sender, MouseEventArgs e)
    {
      PauseTimeUpdate();
      double time = colorSlider_playProcess.Maximum * ((double)e.X / (double)colorSlider_playProcess.Width);
      colorSlider_playProcess.Value = (int)time;

      TimeSpan t = TimeSpan.FromSeconds(time);
      string strText = string.Format("{0:D2} : {1:D2} : {2:D2}",
                      t.Hours,
                      t.Minutes,
                      t.Seconds);
      label_timeCurrent.Text = strText;

      t = TimeSpan.FromSeconds(m_nTotalTime - time);
      strText = string.Format("- {0:D2} : {1:D2} : {2:D2}",
                      t.Hours,
                      t.Minutes,
                      t.Seconds);
      label_timeLast.Text = strText;

      m_bSeekDone = false;
      RpCore.Seek(time, false);
      m_bProcessBarMouseUp = false;
    }

    private void colorSlider_playProcess_MouseUp(object sender, MouseEventArgs e)
    {
      if (m_bDragSeeking) // Make sure last seek get performed when drag seek done
      {
        m_bDragSeeking = false;
        while (!m_bSeekDone)
        {
          Thread.Sleep(10);
        }
        m_bProcessBarMouseUp = true;
        RpCore.Seek(colorSlider_playProcess.Value, false);
      }
      else
      {
        if (m_bSeekDone)
          ResumeTimeUpdate(false);
        m_bProcessBarMouseUp = true;
      }
    }

    private void colorSlider_playProcess_ValueChanged(object sender, EventArgs e)
    {
      if (!m_bProcessBarMouseUp && m_bSeekDone)// drag seek
      {
        m_bDragSeeking = true;
        m_bSeekDone = false;
        RpCore.Seek(colorSlider_playProcess.Value, false);
      }
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
      RpCore.SetMute(m_bMute);
    }

    private void colorSlider_volume_ValueChanged(object sender, EventArgs e)
    {
      RpCore.SetVolume((float)(colorSlider_volume.Value * 0.01));
    }

    public int GetVolume()
    {
      return colorSlider_volume.Value;
    }

  }
}
