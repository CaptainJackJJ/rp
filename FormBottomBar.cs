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
    private const int m_nPlayButtonWidth = 40;
    private const int m_nBottomButtonsWidth = 25;
    private const int m_nBottomButtonsMargin = 15;
    private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonWidth - m_nBottomButtonsWidth) * 0.5);
    private const int m_nPlayProcessToPlayBtnYMargin = 5;
    private const int m_nPlayProcessXMargin = 90;

    private const int m_nStopBtnXMarginToPlay = -(m_nBottomButtonsMargin * 3 + m_nBottomButtonsWidth * 3);
    private const int m_nFBBtnXMarginToPlay = -(m_nBottomButtonsMargin + m_nBottomButtonsWidth);
    private const int m_nPreBtnXMarginToPlay = -(m_nBottomButtonsMargin * 2 + m_nBottomButtonsWidth * 2);
    private const int m_nFFBtnXMarginToPlay = m_nPlayButtonWidth + m_nBottomButtonsMargin;
    private const int m_nNextBtnXMarginToPlay = m_nPlayButtonWidth + m_nBottomButtonsMargin * 2 + m_nBottomButtonsWidth;

    private MainForm m_mainForm;
    private double m_nTotalTime = 0;
    public bool m_bProcessBarMouseUp = true;
    public bool m_bSeekDone = true;
    private bool m_bDragSeeking = false;
    private float m_fSpeed = 1f;
    public float Speed { get { return m_fSpeed; } }
    private FormSpeedControl m_formSpeedControl;
    private bool m_bConstructed = false;

    public FormBottomBar(MainForm mainForm)
    {
      InitializeComponent();
      SetUiLange();
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
        label_playlist.Image = Image.FromFile(Application.StartupPath + @"\pic\playlist.png");
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
        label_playlist.Text = "plist";
      }
      m_mainForm = mainForm;
      m_formSpeedControl = new FormSpeedControl(this);
      this.AddOwnedForm(m_formSpeedControl);
      m_bConstructed = true;
      this.OnResize(EventArgs.Empty);
    }

    public void SetAllUiLange()
    {
      SetUiLange();
    }

    private void SetUiLange()
    {
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

    public void ConfigByAchive()
    {
      try
      {
        if (Archive.mute)
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMute.png");
        else
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
      }
      catch
      {
        if (Archive.mute)
          label_Volume.Text = "mute";
        else
          label_Volume.Text = "volume";
      }
      colorSlider_volume.Value = Archive.volume;
    }

    public void StartPlay()
    {     
      try
      {
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pause.png");
      }
      catch
      {
        label_Play.Text = "pause";
      }
      ConfigByAchive();

      m_nTotalTime = (int)RpCore.GetTotalTime();
      if (m_nTotalTime == 0)
        m_nTotalTime = 1;
      colorSlider_playProcess.Maximum = (int)m_nTotalTime;

      timer_updateProcessBar.Enabled = true;
    }

    public void StopPlay()
    {
      timer_updateProcessBar.Enabled = false;
      colorSlider_playProcess.Value = 0;
      label_timeCurrent.Text = "00 : 00 : 00";
      label_timeLast.Text = "-00 : 00 : 00";
      m_fSpeed = 1.0f;      

      m_mainForm.HideFormSpeedDisplay();
    }

    delegate void EnableUpdateTimerDelegate(bool bInvoke);
    public void EnableUpdateTimer(bool bInvoke)
    {
      if (bInvoke)
      {
        EnableUpdateTimerDelegate del = new EnableUpdateTimerDelegate(EnableUpdateTimer);
        this.Invoke(del, false);
      }
      else
      {
        timer_updateProcessBar.Enabled = true;
      }
    }

    private void timer_updateProcessBar_Tick(object sender, EventArgs e)
    {
      double nCurTime = RpCore.GetCurTime();
      if ((int)nCurTime <= colorSlider_playProcess.Maximum && (int)nCurTime >= 0)
        colorSlider_playProcess.Value = (int)nCurTime;

      // auto hide cursor
      if (m_mainForm.m_lastMousePosInPlayWndAndDesktop != Point.Empty) // mouse is in playWnd at desktop mode
      {
        if (m_mainForm.m_lastMousePosInPlayWndAndDesktop == Control.MousePosition)
        {
          if (m_mainForm.m_bCursorShowing)
          {
            Cursor.Hide();
            m_mainForm.m_bCursorShowing = false;
          }
        }
        else
        {
          if (!m_mainForm.m_bCursorShowing)
          {
            Cursor.Show();
            m_mainForm.m_bCursorShowing = true;
          }
          m_mainForm.m_lastMousePosInPlayWndAndDesktop = Control.MousePosition;
        }
      }
    }

    private void FormBottomBar_Resize(object sender, EventArgs e)
    {
      if (!m_bConstructed)
        return;
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

      const int nLeftBottomBtnsMargin = 10;
      int nPlaylistBtnX = this.Width - m_nBottomButtonsWidth;
      int nDesktopBtnX = this.Width - nLeftBottomBtnsMargin - m_nBottomButtonsWidth * 2;
      int nVolumeSliderX
        = this.Width - nLeftBottomBtnsMargin * 2 - m_nBottomButtonsWidth * 2 - colorSlider_volume.Width;
      label_playlist.Location = new Point(nPlaylistBtnX, nBottomButtonsY);
      label_desktop.Location = new Point(nDesktopBtnX, nBottomButtonsY);
      colorSlider_volume.Location = new Point(nVolumeSliderX, nBottomButtonsY + 7);
      label_Volume.Location = new Point(colorSlider_volume.Location.X - label_Volume.Width, nBottomButtonsY);

      int nPlayProcessY = label_Play.Location.Y - m_nPlayProcessToPlayBtnYMargin - colorSlider_playProcess.Height + 2;

      colorSlider_playProcess.Size
          = new Size(this.Width - (m_nPlayProcessXMargin * 2), colorSlider_playProcess.Height);
      colorSlider_playProcess.Location =
          new Point(m_nPlayProcessXMargin, nPlayProcessY);
      label_timeCurrent.Location =
          new Point(m_nPlayProcessXMargin - label_timeCurrent.Width, nPlayProcessY - 4);
      label_timeLast.Location =
          new Point(m_nPlayProcessXMargin + colorSlider_playProcess.Width, nPlayProcessY - 4);

      m_formSpeedControl.Location
          = new Point(this.Location.X + (this.Width - m_formSpeedControl.Width) / 2, this.Location.Y - m_formSpeedControl.Height);
    }

    public bool IsSameSpeed(float fSpeed1, float fSpeed2)
    {
      return Math.Abs(fSpeed1 - fSpeed2) < 0.05;
    }

    public bool IsLargerSpeed(float fSpeed1, float fSpeed2)
    {
      return fSpeed1 - fSpeed2 > 0.05; 
    }

    public bool IsSmallerSpeed(float fSpeed1, float fSpeed2)
    {
      return fSpeed1 - fSpeed2 < -0.05; 
    }

    public void SetSpeed(float fSpeed)
    {
      if (IsSameSpeed(fSpeed,m_fSpeed))
        return;

      RpCore.ToFFRW(fSpeed);

      if (IsSameSpeed(fSpeed,1.0f))
      {
        try
        {
          label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\pause.png");
        }
        catch
        {
          label_Play.Text = "play";
        }

        try
        {
          m_formSpeedControl.HideMe();
        }
        catch
        {
          RpCore.WriteLog(RpCore.ELogType.error, "Speed control form is closed by antivirus");
          MessageBox.Show(UiLang.msgWndClosedBySfApp);
        }

        m_mainForm.HideFormSpeedDisplay();   
      }
      else
      {
        if (IsSameSpeed(m_fSpeed, 1.0f))
        {
          try
          {
            label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
          }
          catch
          {
            label_Play.Text = "pause";
          }          
        }

        if (IsSameSpeed(fSpeed, 0.0f))
        {
          m_mainForm.HideFormSpeedDisplay();          
        }
        else
        {
          m_mainForm.SetFormSpeedDisplayString(UiLang.speedDisplay + fSpeed.ToString());
          m_mainForm.ShowFormSpeedDisplay();
          m_formSpeedControl.Focus();

          if (IsLargerSpeed(fSpeed, 1.0f))
            Archive.speedFF = fSpeed;
          else
            Archive.speedRW = fSpeed;
        }
      }

      m_fSpeed = fSpeed;
    }

    private void label_Play_Click(object sender, EventArgs e)
    {
      if (IsSameSpeed(m_fSpeed, 1.0f))
        SetSpeed(0);
      else
        SetSpeed(1);
    }

    private void label_Play_MouseEnter(object sender, EventArgs e)
    {
      if (IsSameSpeed(m_fSpeed,1.0f))
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
      else
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
    }

    private void label_Play_MouseLeave(object sender, EventArgs e)
    {
      if (IsSameSpeed(m_fSpeed,1.0f))
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
      else
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
    }

    private void label_Stop_Click(object sender, EventArgs e)
    {
      m_mainForm.StopPlay();
      m_mainForm.SwitchPlayingForm(false);
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

    private void label_FF_Click(object sender, EventArgs e)
    {
      try
      {
        m_formSpeedControl.ShowMe(true);
      }
      catch
      {
        RpCore.WriteLog(RpCore.ELogType.error, "Speed control form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
    }
    private void label_FB_Click(object sender, EventArgs e)
    {
      try
      {
        m_formSpeedControl.ShowMe(false);
      }
      catch
      {
        RpCore.WriteLog(RpCore.ELogType.error, "Speed control form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
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

    private void label_Next_Click(object sender, EventArgs e)
    {
      m_mainForm.PlayPreNext(false);
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

    private void label_Pre_Click(object sender, EventArgs e)
    {
      m_mainForm.PlayPreNext(true);
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
      double time = colorSlider_playProcess.Maximum * ((double)e.X / (double)colorSlider_playProcess.Width);
      colorSlider_playProcess.Value = (int)time;

      timer_updateProcessBar.Enabled = false;
      m_bSeekDone = false;
      RpCore.Seek(time, false);
      m_bProcessBarMouseUp = false;
    }

    private void colorSlider_playProcess_MouseUp(object sender, MouseEventArgs e)
    {
      if (m_bDragSeeking) // Make sure last seek get performed when drag seek done
      {
        m_bDragSeeking = false;
        m_bProcessBarMouseUp = true;
        m_bSeekDone = false;
        RpCore.Seek(colorSlider_playProcess.Value, false);
      }
      else
      {
        if (m_bSeekDone)
          timer_updateProcessBar.Enabled = true;
        m_bProcessBarMouseUp = true;
      }
    }

    private void colorSlider_playProcess_ValueChanged(object sender, EventArgs e)
    {
      double nCurTime = colorSlider_playProcess.Value;
      TimeSpan t = TimeSpan.FromSeconds(nCurTime);
      string strText = string.Format("{0:D2} : {1:D2} : {2:D2}",
                      t.Hours,
                      t.Minutes,
                      t.Seconds);
      label_timeCurrent.Text = strText;

      t = TimeSpan.FromSeconds(m_nTotalTime - nCurTime);
      strText = string.Format("-{0:D2} : {1:D2} : {2:D2}",
                      t.Hours,
                      t.Minutes,
                      t.Seconds);
      label_timeLast.Text = strText;

      if (!m_bProcessBarMouseUp && m_bSeekDone)// drag seek
      {
        m_bDragSeeking = true;
        m_bSeekDone = false;
        RpCore.Seek(nCurTime, false);
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
      m_mainForm.SwitchDesktopMode(true,true);
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

    private void label_playlist_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_playlist.Image = Image.FromFile(Application.StartupPath + @"\pic\playlistFocus.png");
      }
      catch { }
    }

    private void label_playlist_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_playlist.Image = Image.FromFile(Application.StartupPath + @"\pic\playlist.png");
      }
      catch { }
    }

    private void label_playlist_Click(object sender, EventArgs e)
    {
      m_mainForm.ShowHidePlayListFormInNoneDesktop();
    }

    public void ShowHidePlaylistLabel(bool bShow)
    {
      label_playlist.Visible = bShow;
    }

    private void label_Volume_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        if (Archive.mute)
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
        if (Archive.mute)
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
        if (Archive.mute)
        {
          Archive.mute = false;
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeFocus.png");
        }
        else
        {
          Archive.mute = true;
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMuteFocus.png");
        }
      }
      catch { }
      RpCore.SetMute(Archive.mute);
    }

    private void colorSlider_volume_ValueChanged(object sender, EventArgs e)
    {
      Archive.volume = colorSlider_volume.Value;
      RpCore.SetVolume((float)(Archive.volume * 0.01));
    }

    private void FormBottomBar_Move(object sender, EventArgs e)
    {
      if (!m_bConstructed)
        return;
      m_formSpeedControl.Location
        = new Point(this.Location.X + (this.Width - m_formSpeedControl.Width) / 2, this.Location.Y - m_formSpeedControl.Height);
    }
  }
}
