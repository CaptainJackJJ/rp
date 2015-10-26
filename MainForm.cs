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
using Microsoft.Win32;

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

    private const int m_nPlayButtonWidth = 40;
    private const int m_nBottomButtonsWidth = 25;
    private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonWidth - m_nBottomButtonsWidth) * 0.5);

    private bool m_bMaxed = false;
    private bool m_bInCorner = false;
    public bool m_bDesktop;

    public FormBottomBar m_formBottomBar;
    private FormTopBar m_formTopBar;
    private FormSettings m_formSettings;
    private FormSpeedDisplay m_formSpeedDisplay;
    private FormPlaylist m_formPlaylist;

    private RpCallback m_rpCallback;

    private double m_nFileDuration;
    private PlaylistFolder m_curPlistFolder;
    private PlaylistFile m_curPlistFile;
    private string m_strCurPlayingUrl;
    private bool m_bIsPlaying = false;

    private ContextMenuStrip m_contextMenuStrip_playWnd;
    private ToolStripMenuItem m_toolStripMenuItem_subtitles;
    private ToolStripMenuItem m_toolStripMenuItem_audios;
    private ToolStripMenuItem m_toolStripMenuItem_chapters;
    private ToolStripMenuItem m_toolStripMenuItem_snapshot;
    private ToolStripMenuItem m_toolStripMenuItem_playerSettings;
    private ToolStripMenuItem m_toolStripMenuItem_mediaInfo; 
    private int m_nSubtitleAddItemIndex;
    private int m_nSubtitleHideItemIndex;
    private int m_nSubtitleSeperatorItemIndex;
    private bool m_bSubtitleVisible = true;

    private bool m_bStopPlayCalled = true;
    private bool m_bPlayingForm = false;

    public MainForm(string[] args)
    {
      if (!Archive.Load(Application.StartupPath))
      {
        MessageBox.Show("Can not find settings xml");
        return;
      }
      InitializeComponent();

      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
        label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
        label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");
        label_playlist.Image = Image.FromFile(Application.StartupPath + @"\pic\playlist.png");
      }
      catch
      {
        this.BackColor = Color.Gainsboro;
        label_Play.Text = "play";
        label_settings.Text = "settings";        
        label_Close.Text = "close";
        label_Max.Text = "max";
        label_Min.Text = "min";
        label_playlist.Text = "Plist";
      }
      m_rpCallback = new RpCallback(this);
      RpCore.LoadLib(Application.StartupPath, Application.StartupPath + "\\", m_rpCallback);
      RpCore.InitPlayer((int)label_playWnd.Handle, label_playWnd.ClientSize.Width, label_playWnd.ClientSize.Height);

      UiLang.SetLang(Archive.lang);

      m_formBottomBar = new FormBottomBar(this);
      m_formTopBar = new FormTopBar(this);
      m_formSettings = new FormSettings(this);
      m_formSpeedDisplay = new FormSpeedDisplay();
      m_formPlaylist = new FormPlaylist(this);
      this.AddOwnedForm(m_formBottomBar);
      this.AddOwnedForm(m_formTopBar);
      this.AddOwnedForm(m_formSettings);
      this.AddOwnedForm(m_formSpeedDisplay);
      this.AddOwnedForm(m_formPlaylist);

      InitContextMenuStrip();

      ConfigByArchive();
      SetUiLange();

      if (args.Length > 0)
      {
        StartPlay(args[0]);
      }

      AssociateExtension();
    }

    private void AssociateExtension()
    {
      // Associate extension
      string ext = ".mp4";
      string progId = "RabbitPlayer";
      RegistryKey key = Registry.ClassesRoot.OpenSubKey(ext, true);
      if (key == null)
      {
        key = Registry.ClassesRoot.CreateSubKey(ext);
      }
      string defaultId = key.GetValue("") as string;
      if (defaultId == progId)
        return;
      key.SetValue("", progId);

      // Set up progId
      key = Registry.ClassesRoot.OpenSubKey(progId, false);
      if (key != null)
        return;
      key = Registry.ClassesRoot.CreateSubKey(progId);
      key.SetValue("", "RabbitPlayer is the greatest mediaplayer");
      key.CreateSubKey("DefaultIcon").SetValue("", Application.ExecutablePath);
      key.CreateSubKey(@"Shell\Open\Command").SetValue("", Application.ExecutablePath + " \"%1\"");
    }

    private void ConfigByArchive()
    {
      this.Location = new Point(Archive.mainFormLocX, Archive.mainFormLocY);
      this.Size = new Size(Archive.mainFormWidth, Archive.mainFormHeight);

      colorSlider_volume.Value = Archive.volume;
      try
      {
        RpCore.SetMute(Archive.mute);
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
      if (Archive.plistShowingInNoneDesktop)
      {
        m_formPlaylist.Show();
        ChangePlayWndSizeInNonDesktop();
      }

      RpCore.SetOverAssOrig(Archive.overAssOrig);
      RpCore.SetSubtitleBold(Archive.bold);
      RpCore.SetSubtitleBorderColor(Archive.fontBorderColor);
      RpCore.SetSubtitleColor(Archive.fontColor);
      RpCore.SetSubtitleItalic(Archive.italic);
      RpCore.SetSubtitlePos(Archive.fontPos);
      RpCore.SetSubtitleSize(Archive.fontSize);
    }

    public void SetAllUiLange()
    {
      SetUiLange();
      m_formBottomBar.SetAllUiLange();
      m_formTopBar.SetAllUiLange();
      m_formSettings.SetAllUiLange();
      m_formPlaylist.SetAllUiLange();
    }

    private void SetUiLange()
    {
      label_openFile.Text = UiLang.labelOpenFile;
      m_toolStripMenuItem_subtitles.Text = UiLang.contextMenuSubtitles;
      m_toolStripMenuItem_audios.Text = UiLang.contextMenuAudios;
      m_toolStripMenuItem_chapters.Text = UiLang.contextMenuChapters;
      m_toolStripMenuItem_snapshot.Text = UiLang.contextMenuSnapshot;
      m_toolStripMenuItem_playerSettings.Text = UiLang.contextMenuPlayerSettings;
      m_toolStripMenuItem_mediaInfo.Text = UiLang.labelMediainfo;
      ToolStripMenuItem item;
      if (m_nSubtitleAddItemIndex != -1)
      {
        item = m_toolStripMenuItem_subtitles.DropDownItems[m_nSubtitleAddItemIndex] as ToolStripMenuItem;
        item.Text = UiLang.contextMenuAddSubtitle;
      }
      if (m_nSubtitleHideItemIndex != -1)
      {
        item = m_toolStripMenuItem_subtitles.DropDownItems[m_nSubtitleHideItemIndex] as ToolStripMenuItem;
        item.Text = UiLang.contextMenuAddSubtitle;
      }

      int count = m_toolStripMenuItem_chapters.DropDownItems.Count;
      int number;
      for (int i = 0; i < count; i++)
      {
        item = m_toolStripMenuItem_chapters.DropDownItems[i] as ToolStripMenuItem;
        number = i + 1;
        item.Text = UiLang.contextMenuChapter + number.ToString();
      }
    }

    private void InitContextMenuStrip()
    {
      m_contextMenuStrip_playWnd = new ContextMenuStrip();
      m_contextMenuStrip_playWnd.BackColor = Archive.colorContextMenu;
      m_contextMenuStrip_playWnd.ForeColor = Color.White;
      m_contextMenuStrip_playWnd.Renderer = new CustomToolStripProfessionalRenderer();

      m_toolStripMenuItem_subtitles = new ToolStripMenuItem();
      m_contextMenuStrip_playWnd.Items.Add(m_toolStripMenuItem_subtitles);    
      m_toolStripMenuItem_subtitles.MouseEnter += toolStripMenuItem_subtitles_MouseEnter;

      m_nSubtitleAddItemIndex = -1;
      m_nSubtitleHideItemIndex = -1;
      m_nSubtitleSeperatorItemIndex = -1;

      m_toolStripMenuItem_audios = new ToolStripMenuItem();
      m_contextMenuStrip_playWnd.Items.Add(m_toolStripMenuItem_audios);
      m_toolStripMenuItem_audios.MouseEnter += toolStripMenuItem_audios_MouseEnter;

      m_toolStripMenuItem_chapters = new ToolStripMenuItem(); 
      m_contextMenuStrip_playWnd.Items.Add(m_toolStripMenuItem_chapters);
      m_toolStripMenuItem_chapters.MouseEnter += toolStripMenuItem_chapters_MouseEnter;

      m_toolStripMenuItem_snapshot = new ToolStripMenuItem();
      m_contextMenuStrip_playWnd.Items.Add(m_toolStripMenuItem_snapshot);
      m_toolStripMenuItem_snapshot.Click += toolStripMenuItem_snapshot_Click;

      m_toolStripMenuItem_playerSettings = new ToolStripMenuItem();
      m_contextMenuStrip_playWnd.Items.Add(m_toolStripMenuItem_playerSettings);
      m_toolStripMenuItem_playerSettings.Click += toolStripMenuItem_PlayerSettings_MouseClick;

      m_toolStripMenuItem_mediaInfo = new ToolStripMenuItem();
      m_contextMenuStrip_playWnd.Items.Add(m_toolStripMenuItem_mediaInfo);
      m_toolStripMenuItem_mediaInfo.Click += toolStripMenuItem_mediaInfo_MouseClick;
    }

    private void toolStripMenuItem_mediaInfo_MouseClick(object sender, EventArgs e)
    {
      FormMediaInfo info = new FormMediaInfo(m_strCurPlayingUrl);
      info.ShowDialog();
    }

    private void toolStripMenuItem_PlayerSettings_MouseClick(object sender, EventArgs e)
    {
      ShowFormSettings(FormSettings.enumSettingFormType.regular);
    }

    private void toolStripMenuItem_snapshot_Click(object sender, EventArgs e)
    {
      string saveUrl = Archive.snapSavePath + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
        + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
        DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg";

      RpCore.CatchSnapshot(saveUrl);
    }

    // To mark selected items
    private void toolStripMenuItem_audios_MouseEnter(object sender, EventArgs e)
    {
      if (m_toolStripMenuItem_audios.DropDownItems.Count > 0)
      {
        int index = RpCore.GetCurrentAudio();
        if (index < 0)
          return;

        foreach (ToolStripMenuItem item in m_toolStripMenuItem_audios.DropDownItems)
        {
          if (index == (int)item.Tag)
            item.Checked = true;
          else
            item.Checked = false;
        }
      }
    }

    // To mark selected items
    private void toolStripMenuItem_subtitles_MouseEnter(object sender, EventArgs e)
    {
      int count = m_toolStripMenuItem_subtitles.DropDownItems.Count;
      if (count > 0)
      {
        int index = RpCore.GetCurrentSubtitle();

        ToolStripMenuItem subtitleItem = (ToolStripMenuItem)m_toolStripMenuItem_subtitles.DropDownItems[m_nSubtitleHideItemIndex];
        if (RpCore.GetSubtitleVisible())
          subtitleItem.Checked = false;
        else
          subtitleItem.Checked = true;

        for (int i = m_nSubtitleSeperatorItemIndex + 1; i < count; i++ )
        {
          subtitleItem = (ToolStripMenuItem)m_toolStripMenuItem_subtitles.DropDownItems[i];
          if (subtitleItem.Tag != null)
          {
            if (index == (int)subtitleItem.Tag)
              subtitleItem.Checked = true;
            else
              subtitleItem.Checked = false;
          }
        }
      }
    }

    private void toolStripMenuItem_chapters_MouseEnter(object sender, EventArgs e)
    {
      if (m_toolStripMenuItem_chapters.DropDownItems.Count > 0)
      {
        int number = RpCore.GetCurrentChapter();

        foreach (ToolStripMenuItem item in m_toolStripMenuItem_chapters.DropDownItems)
        {
          if (number == (int)item.Tag)
            item.Checked = true;
          else
            item.Checked = false;
        }
      }
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
          SwitchDesktopMode(false,false);
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

      const int nLeftBottomBtnsMargin = 10;
      int nPlaylistBtnX = this.Width - nLeftBottomBtnsMargin - m_nBottomButtonsWidth;
      int nVolumeSliderX 
        = this.Width - nLeftBottomBtnsMargin * 3 - m_nBottomButtonsWidth * 2 - colorSlider_volume.Width;
      label_playlist.Location = new Point(nPlaylistBtnX, nBottomButtonsY);
      colorSlider_volume.Location = new Point(nVolumeSliderX,nBottomButtonsY + 7);
      label_Volume.Location = new Point(colorSlider_volume.Location.X - label_Volume.Width, nBottomButtonsY);

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

      ChangePlayWndSizeInNonDesktop();

      ChangeSubFormsLocAndSize();
    }

    public void ChangePlayWndSizeInNonDesktop()
    {
      if (!m_bDesktop)
      {
        int width = this.Width - 4;
        int height = m_formBottomBar.Location.Y - this.Location.Y - label_Close.Size.Height * 3;
        if (Archive.plistShowingInNoneDesktop)
          width -= (m_formPlaylist.Width + 5);
        label_playWnd.Size = new Size(width, height);
        RpCore.PlayWndResized(label_playWnd.Size.Width, label_playWnd.Size.Height);

        label_openFile.Location =
          new Point(label_playWnd.Location.X + (int)(label_playWnd.Width * 0.5 - label_openFile.Width * 0.5),
            label_playWnd.Location.Y + (int)(label_playWnd.Height * 0.5 - label_openFile.Height * 0.5));
      }
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

      Archive.mainFormLocX = this.Location.X;
      Archive.mainFormLocY = this.Location.Y;
      Archive.mainFormWidth = this.Width;
      Archive.mainFormHeight = this.Height;

      Archive.Save();
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
        SwitchDesktopMode(false,false);
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

    public void ShowHidePlayListFormInNoneDesktop()
    {
      if (Archive.plistShowingInNoneDesktop)
      {
        m_formPlaylist.Hide();
        Archive.plistShowingInNoneDesktop = false;
      }
      else
      {
        m_formPlaylist.Show();
        Archive.plistShowingInNoneDesktop = true;
      }
      ChangePlayWndSizeInNonDesktop();
    }

    private void label_playlist_Click(object sender, EventArgs e)
    {
      ShowHidePlayListFormInNoneDesktop();      
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
      if(Archive.histroy.Count > 0)
      {
        HistroyItem item = Archive.histroy[Archive.histroy.Count - 1];
        StartPlay(item.url);
      }
      else
      {
        OpenFileDlg();
      }
    }

    private void OpenFileDlg()
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      openFileDialog1.Filter = "All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 1;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        StartPlay(openFileDialog1.FileName);
      }
    }

    public void SwitchDesktopMode(bool bAuto, bool bDesktop)
    {
      if (bAuto)
      {
        if (m_bDesktop)
          m_bDesktop = false;
        else
          m_bDesktop = true;
      }
      else
      {
        if (m_bDesktop == bDesktop)
          return;
        m_bDesktop = bDesktop;
      }
      if (m_bDesktop)
      {
        m_bDesktop = true;
        if (this.WindowState == FormWindowState.Maximized)
          ChangeSubFormsLocAndSize(); // Manually call it, because main form will not resize, it was max.
        this.WindowState = FormWindowState.Maximized;
        label_playWnd.Location = this.Location;
        label_playWnd.Size = this.Size;
        RpCore.PlayWndResized(label_playWnd.Size.Width, label_playWnd.Size.Height);
        m_formBottomBar.Hide();
        m_formBottomBar.ShowHidePlaylistLabel(false);
        m_formTopBar.Hide();
        m_formPlaylist.Hide();
      }
      else
      {
        m_bDesktop = false;
        label_playWnd.Location = new Point(2, label_Close.Size.Height * 3);
        this.WindowState = FormWindowState.Normal;
        m_formBottomBar.Opacity = 1;
        if (m_bPlayingForm)
          m_formBottomBar.Show();
        m_formBottomBar.ShowHidePlaylistLabel(true);
        m_formTopBar.Opacity = 1;
        if (m_bPlayingForm)
          m_formTopBar.Show();
        if (Archive.plistShowingInNoneDesktop)
        {
          m_formPlaylist.Show();
        }
      }
    }

    private void label_playWnd_Click(object sender, EventArgs e)
    {
      if (m_bDesktop)
      {
        m_formTopBar.Hide();
        m_formBottomBar.Hide();
        m_formPlaylist.Hide();
        this.BringToFront();
      }
    }

    private void label_playWnd_DoubleClick(object sender, EventArgs e)
    {
      if(RpCore.IsPlaying())
        SwitchDesktopMode(true,false);
    }

    private void label_playWnd_MouseEnter(object sender, EventArgs e)
    {
      if (m_bDesktop)
      {
        m_formTopBar.Hide();
        m_formBottomBar.Hide();
        m_formPlaylist.Hide();
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
        else if (e.Location.X >= label_playWnd.Width - m_formPlaylist.Width)
        {
          m_formPlaylist.Show();
        }
      }
    }

    private void label_playWnd_DragEnter(object sender, DragEventArgs e)
    {
      string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      if(File.Exists(FileList[0]))
        e.Effect = DragDropEffects.Link;
    }

    private void label_playWnd_DragDrop(object sender, DragEventArgs e)
    {
      string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      if (RpCore.IsPlaying())
      {
        StopPlay();
        StartPlay(FileList[0]);
      }
      else
      {
        StartPlay(FileList[0]);
      }
    }

    private void label_openFile_Click(object sender, EventArgs e)
    {
      OpenFileDlg();
    }

    private void label_openFile_MouseEnter(object sender, EventArgs e)
    {
      label_openFile.ForeColor = Color.DodgerBlue;
    }

    private void label_openFile_MouseLeave(object sender, EventArgs e)
    {
      label_openFile.ForeColor = Color.White;
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
      
      m_formPlaylist.Location
       = new Point(this.Location.X + this.Width - m_formPlaylist.Width - nMarginBarToEdge, 
         this.Location.Y + label_playWnd.Location.Y + 1);
      m_formPlaylist.Size
        = new Size(m_formPlaylist.Width, m_formBottomBar.Location.Y - this.Location.Y - label_Close.Size.Height * 3);
    }

    public void SwitchPlayingForm(bool bPlaying)
    {
      if(bPlaying == m_bPlayingForm)
        return;
      m_bPlayingForm = bPlaying;
      if (m_bPlayingForm)
      {
        label_openFile.Hide();
        label_Play.Hide();
        label_Volume.Hide();
        colorSlider_volume.Hide();

        m_formTopBar.Show();
        m_formBottomBar.Show();

        label_playWnd.ContextMenuStrip = m_contextMenuStrip_playWnd;
      }
      else
      {
        m_formTopBar.Hide();
        m_formBottomBar.Hide();

        try
        {
          if (Archive.mute)
            label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\VolumeMute.png");
          else
            label_Volume.Image = Image.FromFile(Application.StartupPath + @"\pic\Volume.png");
        }
        catch { }

        label_openFile.Show();
        label_Play.Show();
        label_Volume.Show();
        colorSlider_volume.Show();
        SwitchDesktopMode(false,false);

        label_playWnd.ContextMenuStrip = null;
      }
    }

    public bool PlayPreNext(bool bPre)
    {
      StopPlay();

      if (m_curPlistFolder != null && m_curPlistFile != null)
      {
        int index = m_curPlistFolder.playlistFiles.IndexOf(m_curPlistFile);
        if(index != -1 )
        {
          if (bPre)
            index--;
          else
            index++;
          if(index < m_curPlistFolder.playlistFiles.Count && index > -1)
          {
            return StartPlay(m_curPlistFolder.playlistFiles[index].url);
          }
          // If no pre or next item and in repeat all mode
          if(Archive.repeatPlayback == Archive.enumRepeatPlayback.all) 
          {
            int nPlayIndex = 0;
            if (bPre)
              nPlayIndex = m_curPlistFolder.playlistFiles.Count - 1;
            else
              nPlayIndex = 0;
            return StartPlay(m_curPlistFolder.playlistFiles[nPlayIndex].url);
          }
        }
      }

      SwitchPlayingForm(false);
      return false;
    }

    private void SubtitleItemClick(object sender, EventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      RpCore.SwitchSubtitle((int)item.Tag);
    }

    private void AudioItemClick(object sender, EventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      RpCore.SwitchAudio((int)item.Tag);
    }

    private void ChapterItemClick(object sender, EventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      RpCore.SwitchChapter((int)item.Tag);
    }

    private void AddSubtitleItemClick(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      openFileDialog1.Filter = "All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 1;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        int index = RpCore.AddSubtitle(openFileDialog1.FileName);
        if (index >= 0)
        {
          RpCore.SwitchSubtitle(index);

          ToolStripMenuItem item = new ToolStripMenuItem();
          Uri uri = new Uri(openFileDialog1.FileName);
          item.Text = System.IO.Path.GetFileName(uri.LocalPath);
          item.Tag = index;
          item.Click += SubtitleItemClick;
          item.BackColor = Archive.colorContextMenu;
          item.ForeColor = Color.White;
          m_toolStripMenuItem_subtitles.DropDownItems.Add(item);
        }
      }
    }

    private void HideSubtitleItemClick(object sender, EventArgs e)
    {
      if (m_bSubtitleVisible)
        m_bSubtitleVisible = false;
      else
        m_bSubtitleVisible = true;
      RpCore.SetSubtitleVisible(m_bSubtitleVisible);
    }

    private void ClearContextMenuDynamically()
    {
      m_toolStripMenuItem_subtitles.DropDownItems.Clear();
      m_toolStripMenuItem_audios.DropDownItems.Clear();
      m_toolStripMenuItem_chapters.DropDownItems.Clear();
      m_nSubtitleAddItemIndex = -1;
      m_nSubtitleHideItemIndex = -1;
      m_nSubtitleSeperatorItemIndex = -1;
    }

    private void FillContextMenuDynamically()
    {
      // subtitles
      ToolStripMenuItem item = new ToolStripMenuItem();
      item.Text = UiLang.contextMenuAddSubtitle;
      item.Click += AddSubtitleItemClick;
      item.BackColor = Archive.colorContextMenu;
      item.ForeColor = Color.White;
      m_nSubtitleAddItemIndex = m_toolStripMenuItem_subtitles.DropDownItems.Add(item);

      item = new ToolStripMenuItem();
      item.Text = UiLang.contextMenuHideSubtitle;
      item.Click += HideSubtitleItemClick;
      item.BackColor = Archive.colorContextMenu;
      item.ForeColor = Color.White;
      m_nSubtitleHideItemIndex = m_toolStripMenuItem_subtitles.DropDownItems.Add(item);

      ToolStripSeparator separator = new ToolStripSeparator();
      separator.ForeColor = Color.Red;
      separator.Height = 1;
      m_nSubtitleSeperatorItemIndex = m_toolStripMenuItem_subtitles.DropDownItems.Add(separator);      

      int amount = RpCore.GetSubtitleCount();
      for(int i = 0; i < amount;i++)
      {
        item = new ToolStripMenuItem();
        SubtitleStreamInfo info = RpCore.GetSubtitleStreamInfo(i);
        if (info.bExternalSub)
        {
          Uri uri = new Uri(info.filename);
          item.Text = System.IO.Path.GetFileName(uri.LocalPath);
        }
        else
          item.Text = info.language;
        item.Tag = i;
        item.Click += SubtitleItemClick;
        item.BackColor = Archive.colorContextMenu;
        item.ForeColor = Color.White;
        m_toolStripMenuItem_subtitles.DropDownItems.Add(item);
      }
      
      // audios
      amount = RpCore.GetAudioCount();
      for (int i = 0; i < amount; i++)
      {
        item = new ToolStripMenuItem();
        AudioStreamInfo info = RpCore.GetAudioStreamInfo(i);
        item.Text = info.language + " " + info.name;
        item.Tag = i;
        item.Click += AudioItemClick;
        item.BackColor = Archive.colorContextMenu;
        item.ForeColor = Color.White;
        m_toolStripMenuItem_audios.DropDownItems.Add(item);
      }

      // chapters
      amount = RpCore.GetChapterCount();
      for (int i = 1; i < amount+1; i++)
      {
        item = new ToolStripMenuItem();
        item.Text = UiLang.contextMenuChapter + i.ToString();
        item.Tag = i;
        item.Click += ChapterItemClick;
        item.BackColor = Archive.colorContextMenu;
        item.ForeColor = Color.White;
        m_toolStripMenuItem_chapters.DropDownItems.Add(item);
      }
    }

    public bool StartPlay(string url)
    {
      SwitchPlayingForm(true);

      if (RpCore.IsPlaying())
        StopPlay();

      m_bStopPlayCalled = false;

      if (!File.Exists(url))
      {
        MessageBox.Show(UiLang.pathNotFound + url);
        SwitchPlayingForm(false);
        return false;
      }
      
      double nStartTime = 0;
      int nPreSeletedAudioIndex = -1;
      int nPreSeletedSubtitleIndex = -1;
      bool bPreSeletedSubtitleVisible = true;
      for (int i = Archive.histroy.Count - 1; i >= 0; i--)
      {
        HistroyItem item = Archive.histroy[i];
        if (item.url == url)
        { 
          nStartTime = item.timeWatched;
          nPreSeletedAudioIndex = item.audioIndex;
          nPreSeletedSubtitleIndex = item.subtitleIndex;
          bPreSeletedSubtitleVisible = item.subtitleVisible;
          break;
        }
      }

      if (!RpCore.Play(url, nStartTime,nPreSeletedAudioIndex,nPreSeletedSubtitleIndex))
      {
        SwitchPlayingForm(false);
        return false;
      }

      m_bIsPlaying = true;

      if(RpCore.GetSubtitleVisible() != bPreSeletedSubtitleVisible)
      {
        RpCore.SetSubtitleVisible(bPreSeletedSubtitleVisible);
      }

      m_strCurPlayingUrl = url;
      m_formBottomBar.StartPlay();

      m_nFileDuration = RpCore.GetTotalTime();

      Uri uri = new Uri(url);
      string strCurrentFileName = System.IO.Path.GetFileName(uri.LocalPath);
      string strCurrentFolder = System.IO.Path.GetDirectoryName(uri.LocalPath);

      m_formTopBar.setFileName(strCurrentFileName);

      if (Archive.autoAddFolderToPlist)
      {
        m_curPlistFolder = m_formPlaylist.AddOrUpdatePlaylist(url, true);

        foreach (PlaylistFile file in m_curPlistFolder.playlistFiles)
        {
          if (file.url == url)
          {
            m_curPlistFile = file;
            break;
          }
        }
      }
      else
      {
        m_formPlaylist.GetPlistFolderAndFile(url, out m_curPlistFile, out m_curPlistFolder);
      }

      FillContextMenuDynamically();
      this.Activate(); // This will bring player to front.
      return true;
    }

    public void StopPlay()
    {   
      if (m_bStopPlayCalled)
        return;

      int index = -1;
      HistroyItem item = new HistroyItem();
      for (int i = Archive.histroy.Count - 1; i >= 0; i--)
      {
        item = Archive.histroy[i];
        if (item.url == m_strCurPlayingUrl)
        {
          index = i;
          break;
        }
      }
      double curPlayingTime;
      if (!RpCore.IsPlaying()) // play ended not be stoped from ui.
        curPlayingTime = 0;
      else
      {
        curPlayingTime = RpCore.GetCurTime();
        if (m_nFileDuration - curPlayingTime < 60) // Just left 1 minute, so still is finished playback
          curPlayingTime = 0;
      }
      
      if (index == -1) // url is not in histroy
      {
        HistroyItem newItem = new HistroyItem();
        newItem.url = m_strCurPlayingUrl;
        newItem.timeWatched = curPlayingTime;
        newItem.duration = m_nFileDuration;
        newItem.audioIndex = RpCore.GetCurrentAudio();
        newItem.subtitleIndex = RpCore.GetCurrentSubtitle();
        newItem.subtitleVisible = RpCore.GetSubtitleVisible();
        Archive.histroy.Add(newItem);
      }
      else
      {
        item.timeWatched = curPlayingTime;
        item.audioIndex = RpCore.GetCurrentAudio();
        item.subtitleIndex = RpCore.GetCurrentSubtitle();
        item.subtitleVisible = RpCore.GetSubtitleVisible();
        if (index != Archive.histroy.Count - 1) // url is in histroy, but not the last one
        {
          Archive.histroy.Remove(item);
          Archive.histroy.Add(item);
        }
      }

      if (m_curPlistFile != null)
      {
        PlaylistFile.enumPlayState playState;
        if (curPlayingTime == 0)
        {
          playState = PlaylistFile.enumPlayState.finished;
          m_curPlistFile.timeWatched = 0;
        }
        else
        {
          playState = PlaylistFile.enumPlayState.played;
          m_curPlistFile.timeWatched = curPlayingTime;
        }
        if (playState != m_curPlistFile.playState && m_curPlistFolder != null)
        {
          m_curPlistFile.playState = playState;
          m_formPlaylist.UpdatePlayListView(false, m_curPlistFolder.url);
        }
      }

      m_bStopPlayCalled = true;
      m_formBottomBar.StopPlay();
      RpCore.Stop();
      m_bIsPlaying = false;
      ClearContextMenuDynamically();

      colorSlider_volume.Value = Archive.volume;

      m_formPlaylist.UpdateListViewHistroy();
    }

    public void deletePlayingPlistFolder(PlaylistFolder file)
    {
      if (file != m_curPlistFolder)
        return;
      m_curPlistFile = null;
      m_curPlistFolder = null;
    }

    // return true means file is playing file and is deleted
    public bool deletePlayingPlistFile(PlaylistFile file)
    {
      if(file == m_curPlistFile)
      {
        if (RpCore.IsPlaying())
        {
          StopPlay();
          SwitchPlayingForm(false);
        }
        m_curPlistFolder.playlistFiles.Remove(file);
        m_curPlistFile = null;
        return true;
      }
      return false;
    }

    private void colorSlider_volume_ValueChanged(object sender, EventArgs e)
    {
      Archive.volume = colorSlider_volume.Value;
      RpCore.SetVolume((float)(Archive.volume * 0.01));
    }

    delegate void ResponseOnEndedStoppedDelegate(bool bInvoke);
    public void ResponseOnEndedStopped(bool bInvoke)
    {      
      if (m_bStopPlayCalled)// ui stop button clicked
        return;

      if (!m_bIsPlaying)
      {
        MessageBox.Show(UiLang.msgCannotPlay);
        return;
      }

      if (bInvoke)
      {
        ResponseOnEndedStoppedDelegate del = new ResponseOnEndedStoppedDelegate(ResponseOnEndedStopped);
        this.BeginInvoke(del, false);
      }
      else
      {
        StopPlay();
        switch (Archive.repeatPlayback)
        {
          case Archive.enumRepeatPlayback.none:
            SwitchPlayingForm(false);
            break;
          case Archive.enumRepeatPlayback.one:
            StartPlay(m_strCurPlayingUrl);
            break;
          case Archive.enumRepeatPlayback.all:
             PlayPreNext(false);    
            break;
        }
      }
    }
  }

  public class RpCallback : IRpCallback
  {
    private MainForm m_mainForm;
    public RpCallback(MainForm mainForm) { m_mainForm = mainForm; }
    public override void OnEnded() 
    {
      m_mainForm.ResponseOnEndedStopped(true);
    }
    public override void OnStopped()
    {
      m_mainForm.ResponseOnEndedStopped(true);
    }
    public override void OnSeekStarted() { }
    public override void OnSeekFailed()
    {
      if (!m_mainForm.m_formBottomBar.m_bSeekDone)
      {
        if (m_mainForm.m_formBottomBar.m_bProcessBarMouseUp)
          m_mainForm.m_formBottomBar.EnableUpdateTimer(true);
        m_mainForm.m_formBottomBar.m_bSeekDone = true;
      }
    }
    public override void OnSeekEnded()
    {
      if (!m_mainForm.m_formBottomBar.m_bSeekDone)
      {
        if (m_mainForm.m_formBottomBar.m_bProcessBarMouseUp)
          m_mainForm.m_formBottomBar.EnableUpdateTimer(true);
        m_mainForm.m_formBottomBar.m_bSeekDone = true;
      }
    }
    public override void OnHwDecodeFailed() { }
    public override void OnDecodeModeNotify(bool Hw) { }
  }

  public class CustomToolStripProfessionalRenderer : ToolStripProfessionalRenderer
  {
    public CustomToolStripProfessionalRenderer() : base(new CustomProfessionalColorTable()) { }
  }

  public class CustomProfessionalColorTable : ProfessionalColorTable
  {
    private Color m_color = Color.FromArgb(255, 70, 70, 70);
    private Color m_backColor = Color.FromArgb(255, 25, 25, 25);
    public override Color MenuItemSelected
    {
      get { return m_color; }
    }
    public override Color MenuItemBorder
    {
      get { return m_color; }
    }
    public override Color MenuBorder
    {
      get { return m_color; }
    }
    public override Color ToolStripDropDownBackground
    {
      get { return m_backColor; }
    }
    public override Color ButtonSelectedBorder
    {
      get { return m_color; }
    }
    public override Color CheckBackground
    {
      get { return m_color; }
    }
    public override Color CheckSelectedBackground
    {
      get { return m_color; }
    }
    public override Color ImageMarginGradientBegin
    {
      get { return m_backColor; }
    }
    public override Color ImageMarginGradientMiddle
    {
      get { return m_backColor; }
    }
    public override Color ImageMarginGradientEnd
    {
      get { return m_backColor; }
    }
    public override Color SeparatorDark
    {
      get { return m_color; }
    }
  }
}
