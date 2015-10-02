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
    private bool m_bTopBarAreaMouseDown = false;
    private Point m_TopBarAreaMouseDownPos;

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
    private const int m_nTopBarButtonsWidth = 13;
    private const int m_nRenderToTopBarMargin = 12;
    private const int m_nRenderToBottomBarMargin = 23;
    private const int m_nCornerSize = 10;

    private const int m_nPlayButtonSize = 40;
    private const int m_nBottomButtonsSize = 25;
    private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonSize - m_nBottomButtonsSize) * 0.5);

    public bool m_bMute = false;
    private bool m_bMaxed = false;
    private bool m_bInCorner = false;
    public bool m_bDesktop;

    public FormBottomBar m_formBottomBar;
    private FormTopBar m_formTopBar;
    private FormSettings m_formSettings;
    private FormSpeedDisplay m_formSpeedDisplay;

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
      m_formTopBar = new FormTopBar(this);
      m_formSettings = new FormSettings(this);
      m_formSpeedDisplay = new FormSpeedDisplay();
      this.AddOwnedForm(m_formBottomBar);
      this.AddOwnedForm(m_formTopBar);
      this.AddOwnedForm(m_formSettings);
      this.AddOwnedForm(m_formSpeedDisplay);
    }

    public void SetFormSpeedDisplayString(string str)
    {
      m_formSpeedDisplay.SetString(str);
    }

    public void ShowFormSpeedDisplay()
    {
      m_formSpeedDisplay.Show();
    }

    public void HideFormSpeedDisplay()
    {
      m_formSpeedDisplay.Hide();
    }

    public void TriggerVolumeOnMouseWheel(MouseEventArgs e)
    {
      if (RpCore.IsPlaying())
        m_formBottomBar.TriggerVolumeOnMouseWheel(e);
      else
        colorSlider_volume.TriggerOnMouseWheel(e);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      TriggerVolumeOnMouseWheel(e);
    }

    public void UpDownVolume(bool bUp)
    {
      if (RpCore.IsPlaying())
      {
        m_formBottomBar.UpDownVolume(bUp);
      }
      else
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
    }

    // return false means this method do not handle that key.
    public bool HandleCmdKey(Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Space:
          m_formBottomBar.Pause();
          break;
        case Keys.Escape:
          if (m_bDesktop)
            SwitchDesktopMode();
          break;
        case Keys.Up:
          UpDownVolume(true);
          break;
        case Keys.Down:
          UpDownVolume(false);
          break;
        default:
          return false;
      }
      return true;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (HandleCmdKey(keyData))
        return true;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      ChangeSubFormsLocAndSize();
      label_Close.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin - m_nTopBarButtonsWidth,
              label_Close.Location.Y);
      label_Max.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin * 2 - m_nTopBarButtonsWidth * 2,
              label_Max.Location.Y);
      label_Min.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 3 - m_nTopBarButtonsWidth * 3,
              label_Min.Location.Y);
      label_settings.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 4 - m_nTopBarButtonsWidth * 4,
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
      else if (e.Location.Y < label_playWnd.Location.Y)
        m_bTopBarAreaMouseDown = true;
      m_TopBarAreaMouseDownPos = e.Location;
      m_bMainFormMouseDown = true;
    }

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
      m_bMainFormMouseDown = false;
      if (!label_TopEdge.Visible)
        UpdateEdge();

      m_bTopBarAreaMouseDown = m_bRightBottomCornerMouseDown
          = m_bLeftTopCornerMouseDown = m_bLeftBottomCornerMouseDown = m_bRightTopCornerMouseDown = false;
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_bTopBarAreaMouseDown)
      {
        int xDiff = e.X - m_TopBarAreaMouseDownPos.X;
        int yDiff = e.Y - m_TopBarAreaMouseDownPos.Y;
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
      ChangeSubFormsLocAndSize();
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

    public void ClickClose()
    {
      if (RpCore.IsPlaying())
        StopPlay();
      RpCore.UninitPlayer();
      RpCore.UnLoadLib();
      this.Close();
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      ClickClose();
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

    public void ClickMax()
    {
      if(m_bDesktop)
      {
        SwitchDesktopMode();
      }
      else
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
    }

    private void label_Max_Click(object sender, EventArgs e)
    {
      ClickMax();
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
      ShowFormSettings(FormSettings.enumSettingFormType.regular);
    }

    public void ShowFormSettings(FormSettings.enumSettingFormType settingType)
    {
      m_formSettings.ShowForm(settingType);
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
        SwitchFormMode(true);
        StartPlay(openFileDialog1.FileName, 0);
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
        m_formTopBar.Opacity = 1;
        m_formTopBar.Show();
      }
      else
      {
        m_bDesktop = true;
        if (this.WindowState == FormWindowState.Maximized)
          ChangeSubFormsLocAndSize(); // Manually call it, because main form will not resize, it was max.
        this.WindowState = FormWindowState.Maximized;
        label_playWnd.Location = this.Location;
        label_playWnd.Size = this.Size;
        m_formBottomBar.Hide();
        m_formTopBar.Hide();
      }
    }

    private void label_playWnd_Click(object sender, EventArgs e)
    {
      if (m_bDesktop)
      {
        m_formTopBar.Hide();
        m_formBottomBar.Hide();
        this.BringToFront();
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
        m_formTopBar.Hide();
        m_formBottomBar.Hide();
        this.BringToFront();
      }
    }

    private void label_playWnd_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_bDesktop)
      {
        if (e.Location.Y >= label_playWnd.Height - m_formBottomBar.Height 
          || e.Location.Y <= m_formTopBar.Height)
        {
          m_formBottomBar.Opacity = 0.4;
          m_formBottomBar.Show();
          m_formTopBar.Opacity = 0.4;
          m_formTopBar.Show();
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
        StopPlay();
        StartPlay(FileList[0], 0);
      }
      else
      {
        SwitchFormMode(true);
        StartPlay(FileList[0], 0);
      }
    }

    private void ChangeSubFormsLocAndSize()
    {
      int nMarginBarToEdge;
      if (m_bDesktop)
        nMarginBarToEdge = 0;
      else
        nMarginBarToEdge = 2;

      m_formBottomBar.Location
        = new Point(this.Location.X + m_nCornerSize, this.Location.Y + this.Height - m_formBottomBar.Height - nMarginBarToEdge);

      m_formBottomBar.Size
        = new Size(this.Width - m_nCornerSize * 2, m_formBottomBar.Height);

      m_formTopBar.Location
        = new Point(this.Location.X + m_nCornerSize, this.Location.Y + nMarginBarToEdge);

      m_formTopBar.Size
        = new Size(this.Width - m_nCornerSize * 2, m_formTopBar.Height);

      m_formSpeedDisplay.Location
        = new Point(this.Location.X + (this.Width - m_formSpeedDisplay.Width) / 2, this.Location.Y + label_playWnd.Location.Y);

    }

    public void SwitchFormMode(bool bPlayingMode)
    {
      if (bPlayingMode)
      {
        label_Play.Hide();
        label_Volume.Hide();
        colorSlider_volume.Hide();

        m_formTopBar.Show();
        m_formBottomBar.Show();
      }
      else
      {
        m_formTopBar.Hide();
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

    private void StartPlay(string url, double nStartTime)
    {
      RpCore.Play(url, nStartTime);
      m_formBottomBar.StartThreadUpdate();
    }

    public void StopPlay()
    {
      m_formBottomBar.EndThreadUpdate();
      RpCore.Stop();
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
