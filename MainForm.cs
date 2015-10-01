﻿using System;
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
    private const int m_nFormBottomBar = 65;

    private const int m_nPlayButtonSize = 40;
    private const int m_nBottomButtonsSize = 25;
    private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonSize - m_nBottomButtonsSize) * 0.5);

    public bool m_bMute = false;
    private bool m_bMaxed = false;
    private bool m_bInCorner = false;
    public bool m_bDesktop;

    public FormBottomBar m_formBottomBar;
    private RpCallback m_rpCallback;

    public MainForm()
    {
      InitializeComponent();
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
        label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
        label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");
      }
      catch
      {
        this.BackColor = Color.Gainsboro;
        label_Play.Text = "play";
        label_settings.Text = "settings";
        label_Volume.Text = "volume";
        label_Close.Text = "close";
        label_Max.Text = "max";
        label_Min.Text = "min";
      }
      m_rpCallback = new RpCallback(this);
      RpCore.LoadLib(Application.StartupPath, Application.StartupPath + "\\", m_rpCallback);
      RpCore.InitPlayer((int)label_playWnd.Handle, label_playWnd.ClientSize.Width, label_playWnd.ClientSize.Height);

      m_formBottomBar = new FormBottomBar(this);
      this.AddOwnedForm(m_formBottomBar);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch(keyData)
      {
        case Keys.Space:
          m_formBottomBar.Pause();
          return true;
        case Keys.Escape:
          if (m_bDesktop)
            SwitchDesktopMode();
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      ChangeSubFormsLocAndSize(true, true);
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
      colorSlider_volume.Location =
        new Point(this.Width - m_nBottomButtonsSize - m_nCornerSize - 10 - colorSlider_volume.Width,
          nBottomButtonsY + 7);
      label_Volume.Location =
        new Point(colorSlider_volume.Location.X - label_Volume.Width, nBottomButtonsY);

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

      if (!m_bDesktop)
      {
        label_playWnd.Size = new Size(this.Width - 4, m_formBottomBar.Location.Y - this.Location.Y - label_Close.Size.Height * 3);
      }
      RpCore.PlayWndResized(label_playWnd.Size.Width, label_playWnd.Size.Height);
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

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
      m_bMainFormMouseDown = false;
      if (!label_TopEdge.Visible)
        UpdateEdge();

      m_bMainFormMouseDownNoEdge = m_bRightBottomCornerMouseDown
          = m_bLeftTopCornerMouseDown = m_bLeftBottomCornerMouseDown = m_bRightTopCornerMouseDown = false;
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

    private void MainForm_Move(object sender, EventArgs e)
    {
      ChangeSubFormsLocAndSize(true, false);
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

    private void label_Min_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
      }
      catch { }
    }

    private void label_Min_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
      }
      catch { }
    }

    private void label_Min_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      if (RpCore.IsPlaying())
        StopPlay(false);
      RpCore.UninitPlayer();
      RpCore.UnLoadLib();
      this.Close();
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
      }
      catch { }
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
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
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\maxFocus.png");
      }
      catch { }
    }

    private void label_Max_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
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

    private void label_settings_Click(object sender, EventArgs e)
    {
      FormSettings fs = new FormSettings(FormSettings.enumSettingFormType.regular);
      fs.Show();
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

    private void label_Play_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      openFileDialog1.Filter = "All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 1;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        StartPlay(openFileDialog1.FileName, 0, true);
      }
    }

    public void SwitchDesktopMode()
    {
      if (m_bDesktop)
      {
        m_bDesktop = false;
        this.WindowState = FormWindowState.Normal;
        label_playWnd.Location = new Point(2, label_Close.Size.Height * 3);
        m_formBottomBar.Opacity = 1;
        m_formBottomBar.Show();
      }
      else
      {
        m_bDesktop = true;
        this.WindowState = FormWindowState.Maximized;
        label_playWnd.Location = this.Location;
        label_playWnd.Size = this.Size;
        m_formBottomBar.Hide();
      }
    }

    private void label_playWnd_DoubleClick(object sender, EventArgs e)
    {
      if(RpCore.IsPlaying())
        SwitchDesktopMode();
    }

    private void label_playWnd_MouseEnter(object sender, EventArgs e)
    {
      if (m_bDesktop)
      {
        m_formBottomBar.Hide();
      }
    }

    private void label_playWnd_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_bDesktop)
      {
        if (e.Location.Y >= label_playWnd.Height - m_nFormBottomBar || e.Location.Y <= m_nFormBottomBar)
        {
          m_formBottomBar.Opacity = 0.3;
          m_formBottomBar.Show();
        }
      }
    }

    private void label_playWnd_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Link;
    }

    private void label_playWnd_DragDrop(object sender, DragEventArgs e)
    {
      string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      if (RpCore.IsPlaying())
      {
        StopPlay(false);
        StartPlay(FileList[0], 0, false);
      }
      else
      {
        StartPlay(FileList[0], 0, true);
      }
    }

    private void ChangeSubFormsLocAndSize(bool bLoc, bool bSize)
    {
      if (bLoc)
      {
        m_formBottomBar.Location
          = new Point(this.Location.X + m_nCornerSize, this.Location.Y + this.Height - m_nFormBottomBar - 3);
      }
      if (bSize)
      {
        m_formBottomBar.Size
          = new Size(this.Width - m_nCornerSize * 2, m_nFormBottomBar);
      }
    }

    private void StartPlay(string url, double nStartTime, bool bSwitchToSubForms)
    {
      if (bSwitchToSubForms)
      {
        label_Play.Hide();
        label_Volume.Hide();
        colorSlider_volume.Hide();

        ChangeSubFormsLocAndSize(true, true);
        m_formBottomBar.Show();
      }

      RpCore.Play(url, nStartTime);
      m_formBottomBar.StartThreadUpdate();
    }

    public void StopPlay(bool bSwitchToMainForm)
    {
      m_formBottomBar.EndThreadUpdate();
      RpCore.Stop();

      if (bSwitchToMainForm)
      {
        m_formBottomBar.Hide();

        m_bMute = m_formBottomBar.m_bMute;
        if (m_bMute)
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMute.png");
        else
          label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
        colorSlider_volume.Value = m_formBottomBar.GetVolume();

        label_Play.Show();
        label_Volume.Show();
        colorSlider_volume.Show();
      }
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

  public class RpCallback : IRpCallback
  {
    private MainForm m_mainForm;
    public RpCallback(MainForm mainForm) { m_mainForm = mainForm; }
    public override void OnEnded() { }
    public override void OnStopped() { }
    public override void OnSeekStarted() { }
    public override void OnSeekFailed()
    {
      if (m_mainForm.m_formBottomBar.m_bProcessBarMouseUp)
        m_mainForm.m_formBottomBar.ResumeTimeUpdate(true);
      m_mainForm.m_formBottomBar.m_bSeekDone = true;
    }
    public override void OnSeekEnded()
    {
      if (m_mainForm.m_formBottomBar.m_bProcessBarMouseUp)
        m_mainForm.m_formBottomBar.ResumeTimeUpdate(true);
      m_mainForm.m_formBottomBar.m_bSeekDone = true;
    }
    public override void OnHwDecodeFailed() { }
    public override void OnDecodeModeNotify(bool Hw) { }
  }
}
