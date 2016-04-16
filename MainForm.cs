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
using Microsoft.Win32;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security.AccessControl;



namespace RPlayer
{
  public partial class MainForm : Form
  {

    #region properties
    MovieLibHandler m_movieLibHandler;
    private readonly int m_nWebBroY = 70;
    private bool m_bHasArgus = false;
    private Mutex m_mutexOneInstance;
    public bool m_bNeedShared = false;
    private int m_nTimes = -1;
    public bool m_bShowLoading = false;
    private bool m_bFirstTimer = true;
    public WebBrowserHandler m_webBrowserHandler;
    //public InfoLocalXmlHandler m_infoLocalXmlHandler;
    public InfoSectionUI m_infoSectionTorrentUI;
    static public string m_strDownloadedFolderUrl;

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

    private int m_nMinMainFormWidth = 500;
    private int m_nMinMainFormHeight = 275;
    private const int m_nEdgeMargin = 1;
    private const int m_nTopBarButtonsMargin = 20;
    private const int m_nTopBarButtonsWidth = 13;
    private const int m_nRenderToTopBarMargin = 12;
    private const int m_nRenderToBottomBarMargin = 23;
    private const int m_nResizeableAreaSize = 10;

    private const int m_nPlayButtonWidth = 40;
    private const int m_nBottomButtonsWidth = 25;
    private const int m_nBottomBtnsToPlayBtnYMargin = (int)((m_nPlayButtonWidth - m_nBottomButtonsWidth) * 0.5);

    public bool m_bDesktop;
    bool m_isMaxBeforeDesktop = false;

    public FormBottomBar m_formBottomBar;
    private FormTopBar m_formTopBar;
    private FormSettings m_formSettings;
    private FormSpeedDisplay m_formSpeedDisplay;
    private FormPlaylist m_formPlaylist;
    private FormVolumeDisplay m_formVolumeDisplay;

    private RpCallback m_rpCallback;

    private double m_nFileDuration;
    private PlaylistFolder m_curPlistFolder;
    private PlaylistFile m_curPlistFile;
    public string m_strCurPlayingUrl;
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
    private bool m_bPlayerInited = false;
    private string m_strPlayUrlAfterInit = "";

    private readonly string m_strCompanyName = "PirateRabbit";
    private readonly string m_strAppName = "RabbitPlayer";
    private readonly string m_strAppVersionRegistryName = "AppVersion";
    private readonly string m_strRPUpdaterExeName = "RPUpdater.exe";
    private readonly string m_strRPUpdaterName = "RPUpdater";
    public string m_strAppVersion;

    static public string m_tempPath;
    public string m_CoreTempPath;
    private Thread m_threadDoSomething;

    public Point m_lastMousePosInPlayWndAndDesktop = Point.Empty;
    public bool m_bCursorShowing = true;

    // Resize and move event are fired in InitializeComponent on some pc(my sister's pc)
    // , and crash caused because some component is not inited.
    // So add this flag to let Resize and Move method do nothing before constructed.
    private bool m_bConstructed = false;

    private AppUpdater m_updaterApp;
    //private InfoUpdater m_updaterInfo;

    readonly int m_nMovieLibPaddingX = 7;
    readonly int m_nMovieLibPaddingY = 48;
 
    #endregion

    public MainForm(string[] args)
    {
      m_nMinMainFormWidth = Archive.mainFormWidthDefault;
      m_nMinMainFormHeight = Archive.mainFormHeightDefault;

      if (args.Length > 0)
        m_bHasArgus = true;

      m_tempPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + m_strAppName;
      Directory.CreateDirectory(m_tempPath);
      m_CoreTempPath = m_tempPath + "\\CoreTemp";
      Directory.CreateDirectory(m_CoreTempPath);
      m_strDownloadedFolderUrl = m_tempPath + "\\" + GlobalConstants.Common.strDownloadedFolderName;
      Directory.CreateDirectory(m_strDownloadedFolderUrl);     

      //------------- only run one instance
      bool createdNew = true;
      m_mutexOneInstance = new Mutex(true, "RPlayer", out createdNew);

      if (!createdNew)
      {
        if (m_bHasArgus)
        {
          if (!AppShare.SetGetNewUrl(m_tempPath, true, ref args[0]))
          {
            MessageBox.Show("Can not find AppShare xml");
          }
        }
        this.Close();
      }

      // ************* only run one instance

      if (!Archive.Load(m_tempPath))
      {
        MessageBox.Show("Can not find settings xml");
        return;
      }

      m_strAppVersion = GetAppVersion();
      if (m_strAppVersion == "")
      {
        MessageBox.Show("Can not get app version");
        return;
      }

      InitializeComponent();

      label_playWnd.Visible = false;
      
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
      label_Play.Image = Image.FromFile(Application.StartupPath + @"\pic\play.png");
      label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");
      label_playlist.Image = Image.FromFile(Application.StartupPath + @"\pic\playlist.png");
      label_back.Image = Image.FromFile(Application.StartupPath + @"\pic\back.png");
      label_forward.Image = Image.FromFile(Application.StartupPath + @"\pic\forward.png");
      if (!m_bHasArgus)
      {
        this.BackColor = GlobalConstants.Common.colorMainFormBG;
      }
      else
      {
        button_openFile.Hide();
        label_Play.Hide();
        label_playWnd.Visible = true;
        this.BackColor = Color.FromArgb(255, 0, 0, 0);
      }
     
      UiLang.SetLang(Archive.lang);

      m_formBottomBar = new FormBottomBar(this);
      m_formTopBar = new FormTopBar(this);
      m_formSettings = new FormSettings(this);
      m_formSpeedDisplay = new FormSpeedDisplay(this);
      m_formVolumeDisplay = new FormVolumeDisplay(this);
      m_formPlaylist = new FormPlaylist(this);
      this.AddOwnedForm(m_formBottomBar);
      this.AddOwnedForm(m_formTopBar);
      this.AddOwnedForm(m_formSettings);
      this.AddOwnedForm(m_formSpeedDisplay);
      this.AddOwnedForm(m_formPlaylist);
      this.AddOwnedForm(m_formVolumeDisplay);

      InitContextMenuStrip();

      SetUiLange();

      Cursor.Show();
      m_bCursorShowing = true;

      //m_infoLocalXmlHandler = new InfoLocalXmlHandler();
      //m_infoLocalXmlHandler.Load(m_tempPath + "\\" + GlobalConstants.Common.strInfoXmlLocalName);
      //m_infoSectionTorrentUI = new InfoSectionUI(this, m_infoLocalXmlHandler);

      if (m_bHasArgus)
      {
        //m_infoSectionTorrentUI.ShowSection(false);
        StartPlay(args[0],-1);
      }

      m_bConstructed = true;
      this.OnResize(EventArgs.Empty);

      ConfigUiByArchive();
      UpdateFormPlistTransform();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      m_threadDoSomething = new Thread(ThreadDoSomething);
      m_threadDoSomething.Start();

      m_updaterApp = new AppUpdater(this);
      m_updaterApp.ThreadStart();

      //m_updaterInfo = new InfoUpdater(this,false,m_infoLocalXmlHandler);
      //m_updaterInfo.ThreadStart();

      int movieLibWidth = this.Width - m_nMovieLibPaddingX * 2;
      int movieLibHeight = this.Height - m_nMovieLibPaddingY * 2 - 12;

      m_webBrowserHandler = new WebBrowserHandler(this, new Point(m_nMovieLibPaddingX, m_nWebBroY), 
        new Size(movieLibWidth, movieLibHeight-22));
      button_localPlay.BackColor = GlobalConstants.Common.colorSelectedNavBtn;

      label_playWnd.Location = new Point(2, label_Close.Size.Height * 3);

      timer1.Enabled = true;

      if (m_bHasArgus)
        SwitchPlayingForm(true);

      m_movieLibHandler = new MovieLibHandler(this, new Point(m_nMovieLibPaddingX, m_nMovieLibPaddingY),
        new Size(this.Width - m_nMovieLibPaddingX * 2, this.Height - m_nMovieLibPaddingY * 2 -12));

      m_movieLibHandler.ShowPlistFolder();

      if(Archive.mainFormLocX < 0)
        Archive.mainFormLocX = 0;
      if (Archive.mainFormLocY < 0)
        Archive.mainFormLocY = 0;
      this.Location = new Point(Archive.mainFormLocX, Archive.mainFormLocY);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      m_movieLibHandler.Dispose();

      if (m_threadDoSomething != null && m_threadDoSomething.IsAlive)
      {
        m_threadDoSomething.Abort(); // To avoid crash when user close app after lauch immediately
        m_threadDoSomething = null;
      }

      m_updaterApp.ThreadStop();
      //m_updaterInfo.ThreadStop();
      //if (m_infoSectionTorrentUI.m_formInfoMore != null)
      //  m_infoSectionTorrentUI.m_formInfoMore.Close();

      if (Core.IsPlaying())
        StopPlay();
      Core.UninitPlayer();
      Core.UnLoadLib();

      if (m_bDesktop)
        SwitchDesktopMode(false, false);

      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;

      if (!m_bDesktop)
      {
        Archive.mainFormWidth = this.Width;
        Archive.mainFormHeight = this.Height;
      }

      Archive.Save();
    }


    delegate void InfoUpdateNoticeDel(string strNotice);
    public void InfoUpdateNotice(string strNotice)
    {
      if (this.InvokeRequired)
      {
        InfoUpdateNoticeDel del = new InfoUpdateNoticeDel(InfoUpdateNotice);
        this.Invoke(del,strNotice);
      }
      else
      {
        label_InfoUpdateNotice.Text = strNotice;
        if (strNotice == "")
        {
          //m_infoSectionTorrentUI.FreshItems();
          FormNotice f = new FormNotice("电影资源已更新完毕");
          f.ShowDialog();
        }
      }
    }

    // Load lib is slow, so put it in a thread to let form show fast.
    private void ThreadDoSomething()
    {
      m_rpCallback = new RpCallback(this);
      try
      {
        Core.LoadLib(Application.StartupPath, m_tempPath + "\\",m_CoreTempPath + "\\", m_rpCallback);
      }
      catch(System.AccessViolationException)
      {
        return; // To avoid crash when user close app after lauch immediately
      }
      Core.WriteLog(Core.ELogType.notice, "****************** App version: " + m_strAppVersion);
      
      Init(true);

      string strRPUpdaterPath = Application.StartupPath + "\\" + m_strRPUpdaterExeName;
      if (File.Exists(strRPUpdaterPath))
      {
        // Launch RPUpdater.        
        bool bRPUpdaterIsRunning = false;
        System.Diagnostics.Process[] GetPArry = System.Diagnostics.Process.GetProcesses();
        foreach (System.Diagnostics.Process testProcess in GetPArry)
        {
          string ProcessName = testProcess.ProcessName;
          if (ProcessName.CompareTo(m_strRPUpdaterName) == 0)
          {
            bRPUpdaterIsRunning = true;
            break;
          }
        }

        if (!bRPUpdaterIsRunning)
        {
          System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
          startInfo.FileName = strRPUpdaterPath;
          System.Diagnostics.Process.Start(startInfo);
        }
      }
    }

    delegate void InitDelegate(bool bInvoke);
    private void Init(bool bInvoke)
    {      
      if (bInvoke)
      {
        InitDelegate del = new InitDelegate(Init);
        this.Invoke(del, false);
      }
      else
      {
        Core.InitPlayer((int)label_playWnd.Handle, label_playWnd.ClientSize.Width, label_playWnd.ClientSize.Height);
        m_bPlayerInited = true;

        ConfigRpcoreByArchive();

        m_formPlaylist.ConfigByArchive();

        Core.GetMediaInfo("D:\\test\\demo.mp4", "D:\\test\\demo1.jpg", 10,208);

        if (m_strPlayUrlAfterInit != "")
          StartPlay(m_strPlayUrlAfterInit,-1);
      }
    }

    private string GetAppVersion()
    {
      RegistryKey key = Registry.CurrentUser.OpenSubKey("Software");
      if(key != null)
      {
        key = key.OpenSubKey(m_strCompanyName);
        if(key != null)
        {
          key = key.OpenSubKey(m_strAppName);
          if (key != null)
          {            
            return key.GetValue(m_strAppVersionRegistryName) as string;
          }
        }
      }
      return "";
    }

        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(long wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);


    public void AssociateExtension()
    {
      try
      {
        const string strProgId = "RabbitPlayer";

        RegistryKey key;
        RegistryKey subKey;
        // Associate all extension
        //string strExtension = ".m4v|.3g2|.3gp|.nsv|.tp|.ts|.ty|.strm|.pls|.rm|.rmvb|.m3u|.m3u8|.ifo|.mov|.qt|.divx|.xvid|.bivx|.vob|.nrg|.pva|.wmv|.asf|.asx|.ogm|.m2v|.avi|.mpg|.mpeg|.mp4|.mkv|.mk3d|.avc|.vp3|.svq3|.nuv|.viv|.dv|.fli|.flv|.wpl|.vdr|.dvr-ms|.xsp|.mts|.m2t|.m2ts|.evo|.ogv|.sdp|.avs|.rec|.pxml|.vc1|.h264|.rcv|.rss|.mpls|.webm|.bdmv|.wtv";
        string strExtension = ".mp4|.mkv|.avi|.wmv|.rm|.rmvb|.td";
        string[] extArray = strExtension.Split('|');
        foreach (string ext in extArray)
        {
          // Delete user choice so my assicote can take effect.
          key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + ext, true);
          if (key != null)
          {
            if (key.OpenSubKey("UserChoice", false) != null)
            {
              RegistrySecurity rs = key.GetAccessControl();
              string currentUserStr = Environment.UserDomainName + "\\" + Environment.UserName;
              rs.AddAccessRule(new RegistryAccessRule(currentUserStr, RegistryRights.Delete, AccessControlType.Allow));
              key.SetAccessControl(rs);

              key.DeleteSubKey("UserChoice");
            }
          }

          // Associate ext to my progId
          key = Registry.ClassesRoot.OpenSubKey(ext, true);
          if (key == null)
            key = Registry.ClassesRoot.CreateSubKey(ext);
          string defaultId = key.GetValue("") as string;
          if (defaultId == strProgId)
            continue;
          key.SetValue("", strProgId);
        }

        // Set up progId
        string name = strProgId;
        string value = "RPlayer media";
        key = Registry.ClassesRoot.OpenSubKey(name, true);
        if (key == null)
          key = Registry.ClassesRoot.CreateSubKey(name);
        if (key.GetValue("") as string != value)
          key.SetValue("", value);

        name = "DefaultIcon";
        value = Application.ExecutablePath;
        subKey = key.OpenSubKey(name, true);
        if (subKey == null)
          subKey = key.CreateSubKey(name);
        if (subKey.GetValue("") as string != value)
          subKey.SetValue("", value);

        name = @"Shell\Open\Command";
        value = Application.ExecutablePath + " \"%1\"";
        subKey = key.OpenSubKey(name, true);
        if (subKey == null)
          subKey = key.CreateSubKey(name);
        if (subKey.GetValue("") as string != value)
          subKey.SetValue("", value);

        SHChangeNotify(0x08000000, 0, IntPtr.Zero, IntPtr.Zero);
      }
      catch (System.Security.SecurityException ex)
      {
        MessageBox.Show("此操作需要管理员权限！步骤如下：关闭本软件->右键点击本软件图标->选择以管理员身份运行->点击软件右上角的设置图标->点击设置为系统默认播放器！");
      }
      catch (Exception ex)
      {
        MessageBox.Show(UiLang.msgSetAsDefaultFailed + "   error info is :" + ex.ToString());
      }
    }

    public void ConfigAllByArchive()
    {
      ConfigByArchive();
      m_formBottomBar.ConfigByAchive();
      m_formPlaylist.ConfigByArchive();
      m_formSettings.ConfigByArchive();
    }

    private void ConfigByArchive()
    {
      ConfigUiByArchive();
      ConfigRpcoreByArchive();
    }

    private void ConfigUiByArchive()
    {
      if (m_bDesktop)
        SwitchDesktopMode(false, false);

      this.Size = new Size(Archive.mainFormWidth, Archive.mainFormHeight);

      if (Archive.plistShowingInNoneDesktop)
      {
        //m_formPlaylist.Show();
        ChangePlayWndSizeInNonDesktop();
      }
      else
        m_formPlaylist.Hide();
    }

    private void ConfigRpcoreByArchive()
    {
      Core.SetMute(Archive.mute);
      Core.SetOverAssOrig(Archive.overAssOrig);
      Core.SetSubtitleBold(Archive.bold);
      Core.SetSubtitleBorderColor(Archive.fontBorderColor);
      Core.SetSubtitleColor(Archive.fontColor);
      Core.SetSubtitleItalic(Archive.italic);
      Core.SetSubtitlePos(Archive.fontPos);
      Core.SetSubtitleSize(Archive.fontSize);
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
      label_logo.Text = UiLang.rabbitPlayer;

      //label_help.Location =
      //  new Point(label_settings.Location.X - label_help.Width - m_nTopBarButtonsMargin / 2,
      //      label_playlist.Location.Y);
      //label_share.Text = UiLang.labelShare;
      //label_share.Location =
      //  new Point(label_help.Location.X - label_share.Width - m_nTopBarButtonsMargin / 2,
      //      label_playlist.Location.Y);
      //button_openFile.Text = UiLang.buttonOpenFile;
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

      Core.CatchSnapshot(saveUrl);
    }

    // To mark selected items
    private void toolStripMenuItem_audios_MouseEnter(object sender, EventArgs e)
    {
      if (m_toolStripMenuItem_audios.DropDownItems.Count > 0)
      {
        int index = Core.GetCurrentAudio();
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
        int index = Core.GetCurrentSubtitle();

        ToolStripMenuItem subtitleItem = (ToolStripMenuItem)m_toolStripMenuItem_subtitles.DropDownItems[m_nSubtitleHideItemIndex];
        if (Core.GetSubtitleVisible())
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
        int number = Core.GetCurrentChapter();

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
      try
      {        
        m_formSpeedDisplay.SetString(str);
      }
      catch
      {
        Core.WriteLog(Core.ELogType.error, "Speed form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
    }

    public void ShowFormSpeedDisplay()
    {
      try
      {       
        m_formSpeedDisplay.Show();
        m_formSpeedDisplay.Size = new Size(84, 28);
      }
      catch
      {
        Core.WriteLog(Core.ELogType.error, "Speed form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
    }

    public void HideFormSpeedDisplay()
    {
      try
      { 
        m_formSpeedDisplay.Hide();
      }
      catch
      {
        Core.WriteLog(Core.ELogType.error, "Speed form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
    }

    public void TriggerVolumeOnMouseWheel(MouseEventArgs e)
    {
      if (Core.IsPlaying())
        m_formBottomBar.TriggerVolumeOnMouseWheel(e);
      else
      {
        if (button_localPlay.BackColor == GlobalConstants.Common.colorSelectedNavBtn)
          m_movieLibHandler.Focus();
        else
          m_webBrowserHandler.Focus();
      }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      TriggerVolumeOnMouseWheel(e);
    }

    public void UpDownVolume(bool bUp)
    {
      if (Core.IsPlaying())
      {
        m_formBottomBar.UpDownVolume(bUp);
      }
    }

    // return false means this method do not handle that key.
    public bool HandleCmdKey(Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Space:
          if (m_formBottomBar.IsSameSpeed(m_formBottomBar.Speed,1.0f))
            m_formBottomBar.SetSpeed(0);
          else
            m_formBottomBar.SetSpeed(1);
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
      if (!m_bConstructed)
        return;
      label_Close.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin - m_nTopBarButtonsWidth,
              label_Close.Location.Y);
      label_Max.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin * 2 - m_nTopBarButtonsWidth * 2,
              label_Min.Location.Y);
      label_Min.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 3 - m_nTopBarButtonsWidth * 3,
              label_Min.Location.Y);
      label_settings.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 4 - m_nTopBarButtonsWidth * 4,
              label_settings.Location.Y);
      //label_help.Location =
      //  new Point(label_settings.Location.X - label_help.Width - m_nTopBarButtonsMargin / 2,
      //      label_settings.Location.Y);
      //label_share.Location =
      //   new Point(label_help.Location.X - label_share.Width - m_nTopBarButtonsMargin / 2,
      //         label_settings.Location.Y);

      button_openFile.Location =
        new Point(10, this.Size.Height - 50);

      label_Play.Location =
         new Point(((int)(this.Size.Width * 0.5) - (int)(label_Play.Size.Width * 0.5)),
              this.Size.Height - 50);
      int nBottomButtonsY = label_Play.Location.Y + m_nBottomBtnsToPlayBtnYMargin;

      const int nLeftBottomBtnsMargin = 10;
      int nPlaylistBtnX = this.Width - nLeftBottomBtnsMargin - m_nBottomButtonsWidth;
      label_playlist.Location = new Point(nPlaylistBtnX, nBottomButtonsY);
      int nHelpBtnX = this.Width - nLeftBottomBtnsMargin * 2 - m_nBottomButtonsWidth * 2;
      label_help.Location = new Point(nHelpBtnX, nBottomButtonsY + 7);
      int nShareBtnX = this.Width - nLeftBottomBtnsMargin * 3 - m_nBottomButtonsWidth * 3;
      label_share.Location = new Point(nShareBtnX, nBottomButtonsY + 7);

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

      int movieLibWidth = this.Width - m_nMovieLibPaddingX * 2;
      int movieLibHeight = this.Height - m_nMovieLibPaddingY * 2 -12;
      if (m_movieLibHandler != null)
        m_movieLibHandler.CtlSize = new Size(movieLibWidth, movieLibHeight);

      if (m_webBrowserHandler != null)
        m_webBrowserHandler.CtlSize = new Size(movieLibWidth, movieLibHeight - 22);

      panel_neck.Size = new Size(this.Width - panel_neck.Location.X * 2, panel_neck.Height);

      ChangeNavBtnPos();

      ChangeSubFormsLocAndSize();

      ChangePlayWndSizeInNonDesktop();
    }

    void ChangeNavBtnPos()
    {
      int btnY = button_dlOversea.Location.Y;
      int btnWidth = button_dlOversea.Width;
      int posOverseaX = this.Width / 2;
      button_dlOversea.Location = new Point(posOverseaX, btnY);
      button_subtitle.Location = new Point(posOverseaX + btnWidth, btnY);
      button_onlineVideo.Location = new Point(posOverseaX + btnWidth * 2, btnY);
      button_dlChina2.Location = new Point(posOverseaX - btnWidth, btnY);
      button_dlChina1.Location = new Point(posOverseaX - btnWidth * 2, btnY);
      button_localPlay.Location = new Point(posOverseaX - btnWidth * 3, btnY);
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
        m_bRightBottomCornerMouseDown = true;
      else if (e.Location.X < m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
        m_bLeftTopCornerMouseDown = true;
      else if (e.Location.X < m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
        m_bLeftBottomCornerMouseDown = true;
      else if (e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
        m_bRightTopCornerMouseDown = true;
      else if (e.Location.X < m_nResizeableAreaSize)
        m_bLeftEdge_MouseDown = true;
      else if (e.Location.Y < m_nResizeableAreaSize)
        m_bTopEdge_MouseDown = true;
      else if (e.Location.X >= this.Size.Width - m_nResizeableAreaSize)
        m_bRightEdge_MouseDown = true;
      else if (e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
        m_bBottomEdge_MouseDown = true;
      else 
        m_bTopBarAreaMouseDown = true;
    
      m_TopBarAreaMouseDownPos = e.Location;
      m_bMainFormMouseDown = true;
    }

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
      m_bMainFormMouseDown = false;
      if (!label_TopEdge.Visible)
        UpdateEdge();

      m_bTopBarAreaMouseDown = m_bRightBottomCornerMouseDown = m_bLeftTopCornerMouseDown 
        = m_bLeftBottomCornerMouseDown = m_bRightTopCornerMouseDown = m_bLeftEdge_MouseDown
        = m_bTopEdge_MouseDown = m_bRightEdge_MouseDown = m_bBottomEdge_MouseDown = false;
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_bTopBarAreaMouseDown)
      {
        int xDiff = e.X - m_TopBarAreaMouseDownPos.X;
        int yDiff = e.Y - m_TopBarAreaMouseDownPos.Y;
        this.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
      }
      else
      {
        ShowResizebaleCursor(e);
        ResizeFrom(sender, e);        
      }
    }

    private void ResizeFrom(object sender, MouseEventArgs e)
    {
      if (m_bRightBottomCornerMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
        int yDiff = MouseScreenPoint.Y - (this.Location.Y + this.Size.Height);

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
      }
      else if (m_bLeftTopCornerMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = this.Location.X - MouseScreenPoint.X;
        int yDiff = this.Location.Y - MouseScreenPoint.Y;

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
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

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
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

        if (this.Size.Width + xDiff < m_nMinMainFormWidth)
          xDiff = 0;
        if (this.Size.Height + yDiff < m_nMinMainFormHeight)
          yDiff = 0;
        if (xDiff != 0 || yDiff != 0)
        {
          if (yDiff != 0)
            this.Location = new Point(this.Location.X, MouseScreenPoint.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height + yDiff);
        }
      }
      else if (m_bLeftEdge_MouseDown)
      {
        Control control = (Control)sender;

        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = this.Location.X - MouseScreenPoint.X;
        if (this.Size.Width + xDiff > m_nMinMainFormWidth)
        {
          this.Location = new Point(MouseScreenPoint.X, this.Location.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
        }
      }
      else if (m_bTopEdge_MouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int yDiff = this.Location.Y - MouseScreenPoint.Y;
        if (this.Size.Height + yDiff > m_nMinMainFormHeight)
        {
          this.Location = new Point(this.Location.X, MouseScreenPoint.Y);
          this.Size = new Size(this.Size.Width, this.Size.Height + yDiff);
        }
      }
      else if (m_bRightEdge_MouseDown)
      {
        Control control = (Control)sender;

        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = MouseScreenPoint.X - (this.Location.X + this.Size.Width);
        if (this.Size.Width + xDiff > m_nMinMainFormWidth)
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
      }
      else if (m_bBottomEdge_MouseDown)
      {
        Control control = (Control)sender;

        Point MouseScrrenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int newHeight = MouseScrrenPoint.Y - this.Location.Y;
        if (newHeight > m_nMinMainFormHeight)
          this.Size = new Size(this.Size.Width, newHeight);
      }
    }

    private void MainForm_Move(object sender, EventArgs e)
    {
      if (!m_bConstructed)
        return;
      ChangeSubFormsLocAndSize();
      if (!m_bDesktop)
      {
        Archive.mainFormLocX = this.Location.X;
        Archive.mainFormLocY = this.Location.Y;
      }
    }

    private void label_Min_MouseEnter(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
    }

    private void label_Min_MouseLeave(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
    }

    private void label_Min_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void label_Max_Click(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;
      else
        this.WindowState = FormWindowState.Maximized;
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

    private void label_Close_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
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
      try
      {
        if (Archive.plistShowingInNoneDesktop)
        {
          m_formPlaylist.Hide();
          Archive.plistShowingInNoneDesktop = false;
        }
        else
        {
          //m_formPlaylist.Show();
          Archive.plistShowingInNoneDesktop = true;
        }
        ChangePlayWndSizeInNonDesktop();
      }
      catch
      {
        Core.WriteLog(Core.ELogType.error, "Speed form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
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
      try
      {
        m_formSettings.ShowForm(settingType);
      }
      catch(Exception e)
      {
        Core.WriteLog(Core.ELogType.error, "settings form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
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
        StartPlay(item.url,-1);
      }
      else
      {
        OpenFileDlg();
      }
    }

    private void OpenFileDlg()
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      if(AppShare.SetGetIsFirst(m_tempPath, false,AppShare.m_strNodeNameIsFirstOpenFile))
      {
        openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        AppShare.SetGetIsFirst(m_tempPath, true,AppShare.m_strNodeNameIsFirstOpenFile);
      }

      openFileDialog1.Filter = "All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 1;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        StartPlay(openFileDialog1.FileName,-1);
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
        m_isMaxBeforeDesktop = this.WindowState == FormWindowState.Maximized ? true : false;
        this.WindowState = FormWindowState.Maximized;
        label_playWnd.Location = this.Location;
        label_playWnd.Size = this.Size;
        Core.PlayWndResized(label_playWnd.Size.Width, label_playWnd.Size.Height);
        m_formBottomBar.Hide();
        m_formBottomBar.ShowHidePlaylistLabel(false);
        m_formTopBar.ShowCurrentTime(true);
        m_formTopBar.Hide();
        m_formPlaylist.Hide();
        m_formTopBar.Location = new Point(0, 0);
        m_formTopBar.Size = new Size(this.Width, m_formTopBar.Height);
        m_formBottomBar.Location = new Point(0, m_formBottomBar.Location.Y);
        m_formBottomBar.Size = new Size(this.Width, m_formBottomBar.Height);

        m_lastMousePosInPlayWndAndDesktop = Control.MousePosition;
      }
      else
      {
        m_bDesktop = false;
        if (!m_isMaxBeforeDesktop)
          this.WindowState = FormWindowState.Normal;
        this.OnResize(EventArgs.Empty);
        label_playWnd.Location = new Point(2, label_Close.Size.Height * 3);
        ChangePlayWndSizeInNonDesktop();
        m_formBottomBar.Opacity = 1;
        if (m_bPlayingForm)
          m_formBottomBar.Show();
        m_formBottomBar.ShowHidePlaylistLabel(true);
        m_formTopBar.Opacity = 1;
        if (m_bPlayingForm)
          m_formTopBar.Show();
        m_formTopBar.ShowCurrentTime(false);
        if (Archive.plistShowingInNoneDesktop)
        {
          //m_formPlaylist.Show();
        }

        m_lastMousePosInPlayWndAndDesktop = Point.Empty;
        if (!m_bCursorShowing)
        {
          Cursor.Show();
          m_bCursorShowing = true;
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
      if(Core.IsPlaying())
        SwitchDesktopMode(true,false);
    }

    private void label_playWnd_MouseEnter(object sender, EventArgs e)
    {
      label_playWnd.Cursor = Cursors.Arrow;
      if (m_bDesktop)
      {
        this.BringToFront();
        m_formTopBar.Hide();
        m_formBottomBar.Hide();
        m_formPlaylist.Hide();
        m_lastMousePosInPlayWndAndDesktop = Control.MousePosition;
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
          //m_formPlaylist.Show();
        }
      }
    }

    private void label_playWnd_MouseLeave(object sender, EventArgs e)
    {
      if (m_bDesktop)
      {
        m_lastMousePosInPlayWndAndDesktop = Point.Empty;
        if (!m_bCursorShowing)
        {
          Cursor.Show();
          m_bCursorShowing = true;
        }
      }
    }

    private void FileDragEnter(object sender, DragEventArgs e)
    {
      string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      if(File.Exists(FileList[0]))
        e.Effect = DragDropEffects.Link;
    }

    private void FileDragDrop(object sender, DragEventArgs e)
    {
      string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      if (Core.IsPlaying())
      {
        StopPlay();
        StartPlay(FileList[0],-1);
      }
      else
      {
        StartPlay(FileList[0],-1);
      }
    }

    private void button_openFile_Click(object sender, EventArgs e)
    {
      OpenFileDlg();
    }

    private void label_logo_Click(object sender, EventArgs e)
    {
      FormChangeLog f = new FormChangeLog();
      f.Show();
    }

    private void label_logo_MouseEnter(object sender, EventArgs e)
    {
      label_logo.ForeColor = Color.DodgerBlue;
    }

    private void label_logo_MouseLeave(object sender, EventArgs e)
    {
      label_logo.ForeColor = Color.White;
    }

    private void label_share_Click(object sender, EventArgs e)
    {
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strOfficalWebsite);
    }

    private void label_share_MouseEnter(object sender, EventArgs e)
    {
      label_share.ForeColor = Color.DodgerBlue;
    }

    private void label_share_MouseLeave(object sender, EventArgs e)
    {
      label_share.ForeColor = Color.White;
    }

    public void ChangePlayWndSizeInNonDesktop()
    {
      if (!m_bDesktop)
      {
        int playWndWidth = this.Width - 4;
        int playWndHeight = m_formBottomBar.Location.Y - this.Location.Y - label_Close.Size.Height * 3;
        if (Archive.plistShowingInNoneDesktop)
          playWndWidth -= (m_formPlaylist.Width + 5);
        label_playWnd.Size = new Size(playWndWidth, playWndHeight);
        Core.PlayWndResized(playWndWidth, playWndHeight);
      }
    }

    private void ShowResizebaleCursor(MouseEventArgs e)
    {
      if ((e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
      ||
      (e.Location.X < m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
      )
      {
        Cursor = Cursors.SizeNWSE;
      }
      else if ((e.Location.X < m_nResizeableAreaSize && e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
          ||
          (e.Location.X >= this.Size.Width - m_nResizeableAreaSize && e.Location.Y < m_nResizeableAreaSize)
          )
      {
        Cursor = Cursors.SizeNESW;
      }
      else if (e.Location.X < m_nResizeableAreaSize
        || e.Location.X >= this.Size.Width - m_nResizeableAreaSize)
      {
        Cursor = Cursors.SizeWE;
      }
      else if (e.Location.Y < m_nResizeableAreaSize ||
        e.Location.Y >= this.Size.Height - m_nResizeableAreaSize)
      {
        Cursor = Cursors.SizeNS;
      }
      else
      {
        Cursor = Cursors.Arrow;
      }
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

    private void ChangeSubFormsLocAndSize()
    {
      try
      {
        int nMarginBarToEdge;
        if (m_bDesktop)
          nMarginBarToEdge = 0;
        else
          nMarginBarToEdge = 2;

        m_formBottomBar.Location
          = new Point(this.Location.X + m_nResizeableAreaSize, this.Location.Y + this.Height - m_formBottomBar.Height - nMarginBarToEdge);

        m_formBottomBar.Size
          = new Size(this.Width - m_nResizeableAreaSize * 2, m_formBottomBar.Height);

        m_formTopBar.Location
          = new Point(this.Location.X + m_nResizeableAreaSize, this.Location.Y + nMarginBarToEdge);

        m_formTopBar.Size
          = new Size(this.Width - m_nResizeableAreaSize * 2, m_formTopBar.Height);

        m_formSpeedDisplay.Location
          = new Point(this.Location.X + (this.Width - m_formSpeedDisplay.Width) / 2, this.Location.Y + label_playWnd.Location.Y);

        m_formVolumeDisplay.Location
          = new Point(this.Location.X + 20, m_formTopBar.Location.Y + m_formTopBar.Height);

        UpdateFormPlistTransform();
      }
      catch
      {
        Core.WriteLog(Core.ELogType.error, "sub forms is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }
   }

    private void UpdateFormPlistTransform()
    {
      int nMarginBarToEdge;
      if (m_bDesktop)
        nMarginBarToEdge = 0;
      else
        nMarginBarToEdge = 2;

      int y,h;
      if (m_bPlayingForm)
      {
        y = this.Location.Y + label_Close.Size.Height * 3 + 1;
        h = m_formBottomBar.Location.Y - this.Location.Y - label_Close.Size.Height * 3 - 1;
      }
      else
      {
        y = this.Location.Y + m_nWebBroY;
        h = 590;
      }

      m_formPlaylist.Location
       = new Point(this.Location.X + this.Width - m_formPlaylist.Width - nMarginBarToEdge,
         y);

      m_formPlaylist.Size
        = new Size(m_formPlaylist.Width, h);
    }

    private void ShowBroswerUIs(bool bBrowsering)
    {
      panel_neck.Visible = bBrowsering;
      m_webBrowserHandler.Show(bBrowsering);
      m_movieLibHandler.ShowLibUi(!bBrowsering);
    }

    private void ShowPlayingUIs(bool bPlaying)
    {
      UpdateFormPlistTransform();

      Color colorEdge = Color.RoyalBlue;
      if(bPlaying)
      {
        colorEdge = Color.Gray;
      }
      label_TopEdge.BackColor = label_BottomEdge.BackColor = label_RightEdge.BackColor
          = label_LeftEdge.BackColor = colorEdge;

      button_dlChina1.Visible = !bPlaying;
      button_dlChina2.Visible = !bPlaying;
      button_localPlay.Visible = !bPlaying;
      button_onlineVideo.Visible = !bPlaying;
      button_dlOversea.Visible = !bPlaying;
      button_subtitle.Visible = !bPlaying;

      if(bPlaying)
      {
        m_webBrowserHandler.Show(!bPlaying);
        panel_neck.Visible = !bPlaying;
        m_movieLibHandler.ShowLibUi(!bPlaying);
      }
      else
      {
        if (button_localPlay.BackColor == GlobalConstants.Common.colorSelectedNavBtn)
          m_movieLibHandler.ShowLibUi(!bPlaying);
        else
        {
          m_webBrowserHandler.Show(!bPlaying);
          panel_neck.Visible = !bPlaying;
        }
      }

      label_playWnd.Visible = bPlaying;
      label_logo.Visible = !bPlaying;
      try
      {
        m_formTopBar.Visible = bPlaying;
        m_formBottomBar.Visible = bPlaying;
      }
      catch
      {
        Core.WriteLog(Core.ELogType.error, "top bottom form is closed by antivirus");
        MessageBox.Show(UiLang.msgWndClosedBySfApp);
      }

      button_openFile.Visible = !bPlaying;
      label_Play.Visible = !bPlaying;      
    }

    public void SwitchPlayingForm(bool bPlaying)
    {
      if(bPlaying == m_bPlayingForm)
        return;
      m_bPlayingForm = bPlaying;
      if (m_bPlayingForm)
      {        
        m_webBrowserHandler.Stop();

        this.BackColor = Color.FromArgb(255, 0, 0, 0);
        //if (this.WindowState == FormWindowState.Maximized)
        //  this.WindowState = FormWindowState.Normal;
        //m_infoSectionTorrentUI.ShowSection(false);

        label_playWnd.Location = new Point(2, label_Close.Size.Height * 3);       
        label_playWnd.ContextMenuStrip = m_contextMenuStrip_playWnd;
        ShowPlayingUIs(true);

        if (AppShare.SetGetIsFirst(MainForm.m_tempPath, false, AppShare.m_strNodeNameIsFirstPlay))
        {
          FormNoticeUseQuickPlay f = new FormNoticeUseQuickPlay();
          f.ShowDialog(this);
          AppShare.SetGetIsFirst(MainForm.m_tempPath, true, AppShare.m_strNodeNameIsFirstPlay);
        }
      }
      else
      {
        //m_infoSectionTorrentUI.ShowSection(true);
       
        this.BackColor = GlobalConstants.Common.colorMainFormBG;
        
        SwitchDesktopMode(false,false);

        label_playWnd.ContextMenuStrip = null;

        if(button_localPlay.BackColor != GlobalConstants.Common.colorSelectedNavBtn)
          m_webBrowserHandler.Navigate(true, "");

        ShowPlayingUIs(false);
      }

      this.Activate(); // This will bring player to front.
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
            return StartPlay(m_curPlistFolder.playlistFiles[index].url,-1);
          }
          // If no pre or next item and in repeat all mode
          if(Archive.repeatPlayback == Archive.enumRepeatPlayback.all) 
          {
            int nPlayIndex = 0;
            if (bPre)
              nPlayIndex = m_curPlistFolder.playlistFiles.Count - 1;
            else
              nPlayIndex = 0;
            return StartPlay(m_curPlistFolder.playlistFiles[nPlayIndex].url,-1);
          }
        }
      }

      SwitchPlayingForm(false);
      return false;
    }

    private void SubtitleItemClick(object sender, EventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      Core.SwitchSubtitle((int)item.Tag);
    }

    private void AudioItemClick(object sender, EventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      Core.SwitchAudio((int)item.Tag);
    }

    private void ChapterItemClick(object sender, EventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      Core.SwitchChapter((int)item.Tag);
    }

    private void AddSubtitleItemClick(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      openFileDialog1.Filter = "All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 1;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        int index = Core.AddSubtitle(openFileDialog1.FileName);
        if (index >= 0)
        {
          Core.SwitchSubtitle(index);

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
      Core.SetSubtitleVisible(m_bSubtitleVisible);
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

    private void ConvertToChinese(ref string str)
    {
      switch (str)
      {
        case "Chinese":
          {
            str = "中文";
            break;
          }
        case "English":
          {
            str = "英语";
            break;
          }
        case "Japanese":
          {
            str = "日语";
            break;
          }
        case "Franch":
          {
            str = "法语";
            break;
          }
        case "German":
          {
            str = "德语";
            break;
          }
        case "Korean":
          {
            str = "韩语";
            break;
          }
        case "Russian":
          {
            str = "俄语";
            break;
          }
      }
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

      int amount = Core.GetSubtitleCount();
      for(int i = 0; i < amount;i++)
      {
        item = new ToolStripMenuItem();
        SubtitleStreamInfo info = Core.GetSubtitleStreamInfo(i);
        if (info.bExternalSub)
        {
          Uri uri = new Uri(info.filename);
          item.Text = System.IO.Path.GetFileName(uri.LocalPath);
        }
        else
        {
          string strLan = info.language;
          if (Archive.lang == "中文")
          {
            ConvertToChinese(ref strLan);
          }
          item.Text = strLan;
        }
        item.Tag = i;
        item.Click += SubtitleItemClick;
        item.BackColor = Archive.colorContextMenu;
        item.ForeColor = Color.White;
        m_toolStripMenuItem_subtitles.DropDownItems.Add(item);
      }
      
      // audios
      amount = Core.GetAudioCount();
      for (int i = 0; i < amount; i++)
      {
        item = new ToolStripMenuItem();
        AudioStreamInfo info = Core.GetAudioStreamInfo(i);
        string strLan = info.language;
        if (Archive.lang == "中文")
        {
          ConvertToChinese(ref strLan);
        }
        item.Text = strLan + " " + info.name;
        item.Tag = i;
        item.Click += AudioItemClick;
        item.BackColor = Archive.colorContextMenu;
        item.ForeColor = Color.White;
        m_toolStripMenuItem_audios.DropDownItems.Add(item);
      }

      // chapters
      amount = Core.GetChapterCount();
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

    public bool StartPlay(string url, double nStartTime)
    {
      url = url.Replace("\\\\", "smb://");
      if(!m_bPlayerInited)
      {
        m_strPlayUrlAfterInit = url; // To let method init to play it.
        return true;
      }
      m_strPlayUrlAfterInit = "";

      SwitchPlayingForm(true);

      if (Core.IsPlaying())
        StopPlay();

      m_bStopPlayCalled = false;

      if (!File.Exists(url))
      {
        MessageBox.Show(UiLang.pathNotFound + url);
        SwitchPlayingForm(false);
        return false;
      }
      
      int nPreSeletedAudioIndex = -1;
      int nPreSeletedSubtitleIndex = -1;
      bool bPreSeletedSubtitleVisible = true;
      for (int i = Archive.histroy.Count - 1; i >= 0; i--)
      {
        HistroyItem item = Archive.histroy[i];
        if (item.url == url)
        {
          if (nStartTime == -1)
            nStartTime = item.timeWatched;
          nPreSeletedAudioIndex = item.audioIndex;
          nPreSeletedSubtitleIndex = item.subtitleIndex;
          bPreSeletedSubtitleVisible = item.subtitleVisible;
          break;
        }
      }

      if (!Core.Play(url, nStartTime,nPreSeletedAudioIndex,nPreSeletedSubtitleIndex))
      {
        SwitchPlayingForm(false);
        return false;
      }
      m_bIsPlaying = true;

      if(Core.GetSubtitleVisible() != bPreSeletedSubtitleVisible)
      {
        Core.SetSubtitleVisible(bPreSeletedSubtitleVisible);
      }

      m_strCurPlayingUrl = url;
      m_formBottomBar.StartPlay();

      m_nFileDuration = Core.GetTotalTime();

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

      if (m_curPlistFolder != null && m_curPlistFile != null)
        m_formPlaylist.MarkPlayingPlist(m_curPlistFolder, m_curPlistFile);

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
      if (!Core.IsPlaying()) // play ended not be stoped from ui.
        curPlayingTime = 0;
      else
      {
        curPlayingTime = Core.GetCurTime();
        if (m_nFileDuration - curPlayingTime < 120) // Just left 2 minute, so still is finished playback
          curPlayingTime = 0;
      }
      
      if (index == -1) // url is not in histroy
      {
        HistroyItem newItem = new HistroyItem();
        newItem.url = m_strCurPlayingUrl;
        newItem.timeWatched = curPlayingTime;
        newItem.duration = m_nFileDuration;
        newItem.audioIndex = Core.GetCurrentAudio();
        newItem.subtitleIndex = Core.GetCurrentSubtitle();
        newItem.subtitleVisible = Core.GetSubtitleVisible();
        Archive.histroy.Add(newItem);
      }
      else
      {
        item.timeWatched = curPlayingTime;
        item.audioIndex = Core.GetCurrentAudio();
        item.subtitleIndex = Core.GetCurrentSubtitle();
        item.subtitleVisible = Core.GetSubtitleVisible();
        if (index != Archive.histroy.Count - 1) // url is in histroy, but not the last one
        {
          Archive.histroy.Remove(item);
          Archive.histroy.Add(item);
        }
      }

      if (m_curPlistFile != null)
      {
        if (curPlayingTime == 0)
        {
          m_curPlistFile.playState = PlaylistFile.enumPlayState.finished;
          m_curPlistFile.timeWatched = 0;
        }
        else
        {
          m_curPlistFile.playState = PlaylistFile.enumPlayState.played;
          m_curPlistFile.timeWatched = curPlayingTime;
        }

        m_formPlaylist.UpdatePlayListView(false, m_curPlistFolder.url);
      }

      m_bStopPlayCalled = true;
      m_formBottomBar.StopPlay();
      Core.Stop();
      m_bIsPlaying = false;
      ClearContextMenuDynamically();

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
        if (Core.IsPlaying())
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

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (m_bFirstTimer)
      {
        m_bFirstTimer = false;

        if (AppShare.SetGetFirstTimeRun(m_tempPath, false)) // first time run
        {
          FormRegisterAsk f = new FormRegisterAsk(this);
          f.Show();
          AppShare.SetGetFirstTimeRun(m_tempPath, true); // set first time run to NO
        }

        UInt64 nLanuchTimes = 1;
        AppShare.SetGetLaunchTimes(m_tempPath, false, ref nLanuchTimes);        
        if (nLanuchTimes > 5)
        {
          bool bShared = AppShare.SetGetShared(m_tempPath, false);
          if (!bShared)
            m_bNeedShared = true;
        }
        UInt64 times = nLanuchTimes + 1;
        AppShare.SetGetLaunchTimes(m_tempPath, true, ref times);
      }

      if (m_bShowLoading)
      {
        ++m_nTimes;
        switch (m_nTimes)
        {
          case -1:
            label_loading.Text = "加载中";
            break;
          case 0:
            label_loading.Text = "加载中.";
            break;
          case 1:
            label_loading.Text = "加载中..";
            break;
          case 2:
            label_loading.Text = "加载中...";
            m_nTimes = -2;
            break;
        }
      }
      else
      {
        label_loading.Text = "";
        m_nTimes = -1;
      }

      if (!m_bConstructed)
        return;
      string url = "";
      if (!AppShare.SetGetNewUrl(m_tempPath, false, ref url))
      {
        MessageBox.Show("Can not find AppShare xml");
      }
      if(url != "")
      {
        if (m_bIsPlaying)
          StopPlay();
        StartPlay(url,-1);
      }
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
            StartPlay(m_strCurPlayingUrl,-1);
            break;
          case Archive.enumRepeatPlayback.all:
             PlayPreNext(false);    
            break;
        }
      }
    }

    private void button_dlChina1_Click(object sender, EventArgs e)
    {
      m_updaterApp.UpdateWebUrl();
      ChangeNavButtonColor(GlobalConstants.Common.strChinaDl1);
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strChinaDl1);
    }

    private void button_onlineVideo_Click(object sender, EventArgs e)
    {
      m_updaterApp.UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strChinaOnline);
      ChangeNavButtonColor(GlobalConstants.Common.strChinaOnline);
    }

    private void button_dlOversea_Click(object sender, EventArgs e)
    {
      m_updaterApp.UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strOverseaDl);
      ChangeNavButtonColor(GlobalConstants.Common.strOverseaDl);
    }

    private void button_subtitle_Click(object sender, EventArgs e)
    {
      m_updaterApp.UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strSubtitle);
      ChangeNavButtonColor(GlobalConstants.Common.strSubtitle);
    }

    private void ResetNavButtonColor()
    {
      button_dlChina1.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_dlChina2.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_localPlay.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_onlineVideo.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_dlOversea.BackColor = GlobalConstants.Common.colorMainBtnBG;
      button_subtitle.BackColor = GlobalConstants.Common.colorMainBtnBG;
    }

    public void ChangeNavButtonColor(string strWebsite)
    {
      bool bShowBrowserUIs = true;
      if (strWebsite == GlobalConstants.Common.strChinaDl1)
      {
        ResetNavButtonColor();
        button_dlChina1.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if (strWebsite == GlobalConstants.Common.strChinaDl2)
      {
        ResetNavButtonColor();
        button_dlChina2.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if (strWebsite == GlobalConstants.Common.strLocalPlay)
      {
        ResetNavButtonColor();
        button_localPlay.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
        bShowBrowserUIs = false;
      }
      else if (strWebsite == GlobalConstants.Common.strOverseaDl
              || strWebsite == GlobalConstants.Common.strOverseaDl + "/index8.php")
      {
        ResetNavButtonColor();
        button_dlOversea.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      else if(strWebsite == GlobalConstants.Common.strSubtitle)
      {
        ResetNavButtonColor();
        button_subtitle.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }      
      else if (strWebsite == GlobalConstants.Common.strChinaOnline)
      {
        ResetNavButtonColor();
        button_onlineVideo.BackColor = GlobalConstants.Common.colorSelectedNavBtn;
      }
      ShowBroswerUIs(bShowBrowserUIs);
    }

    private void label_back_Click(object sender, EventArgs e)
    {
      m_webBrowserHandler.Back();
    }

    private void label_forward_Click(object sender, EventArgs e)
    {
      m_webBrowserHandler.Forward();
    }

    private void label_back_MouseEnter(object sender, EventArgs e)
    {
      label_back.Image = Image.FromFile(Application.StartupPath + @"\pic\backFocus.png");
      
    }

    private void label_back_MouseLeave(object sender, EventArgs e)
    {
      label_back.Image = Image.FromFile(Application.StartupPath + @"\pic\back.png");
    }

    private void label_forward_MouseEnter(object sender, EventArgs e)
    {
      label_forward.Image = Image.FromFile(Application.StartupPath + @"\pic\forwardFocus.png");
    }

    private void label_forward_MouseLeave(object sender, EventArgs e)
    {
      label_forward.Image = Image.FromFile(Application.StartupPath + @"\pic\forward.png");
    }

    private void button_dlChina2_Click(object sender, EventArgs e)
    {
      m_updaterApp.UpdateWebUrl();
      m_webBrowserHandler.Navigate(false, GlobalConstants.Common.strChinaDl2);
      ChangeNavButtonColor(GlobalConstants.Common.strChinaDl2);
    }

    private void button_localPlay_Click(object sender, EventArgs e)
    {
      m_webBrowserHandler.Stop();
      ChangeNavButtonColor(GlobalConstants.Common.strLocalPlay);
    }

    private void label_help_MouseLeave(object sender, EventArgs e)
    {
      label_help.ForeColor = Color.White;
    }

    private void label_help_Click(object sender, EventArgs e)
    {
      FormHelp f = new FormHelp();
      f.Show();
    }

    private void label_help_MouseEnter(object sender, EventArgs e)
    {
      label_help.ForeColor = Color.DodgerBlue;
    }

    private void panel_neck_Resize(object sender, EventArgs e)
    {
      int loadingX = panel_neck.Width / 2 - label_loading.Width / 2 + 8;
      int loadingY = label_loading.Location.Y;
      label_loading.Location = new Point(loadingX, loadingY);
      label_back.Location = new Point(loadingX - 48, loadingY);
      label_forward.Location = new Point(loadingX + 73, loadingY);
    }

  }

  public class RpCallback : ICoreCallback
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
