using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;
using CoreWrapper;

namespace RPlayer
{
  class MovieLibHandler
  {
    #region fields
    readonly Color m_ContextBackColor = Color.SlateGray;
    string m_strThumbDir;
    readonly int m_nThumbWidth = 204;
    PlaylistFolder m_curFolder;
    PlaylistFile m_curFile;
    ListViewNF listViewNF;
    FormBigThumb m_formBigThumb;

    ContextMenuStrip m_contextMenuStrip_plist;
    ToolStripMenuItem m_toolStripMenuItem_showPlistQuickLook;

    enum ePlistShowState {folder,file,quickLook}
    ePlistShowState m_ePlistShowState = ePlistShowState.folder;

    private Thread m_threadRefreshPlistFolder;
    private Thread m_threadRefreshThumbs;
    private Thread m_threadRefreshPlistFiles;
    private Thread m_threadRefreshPlistQuickLook;
    MainForm m_formMain;
    Label labelAdd;
    Label labelDes;
    readonly Color m_ColorBg = Color.FromArgb(255, 252, 252, 252);
    #endregion

    public MovieLibHandler(MainForm formOwner,Point posStart,Size size)
    {
      m_formMain = formOwner;
      m_strThumbDir = MainForm.m_tempPath + "\\Thumb";
      Directory.CreateDirectory(m_strThumbDir);

      m_formBigThumb = new FormBigThumb();

      InitializeComponent(posStart,size);

    }

    void InitializeComponent(Point posStart, Size size)
    {
      m_formMain.SuspendLayout();

      listViewNF = new ListViewNF();
      listViewNF.Location = posStart;
      listViewNF.Size = size;
      listViewNF.Font = new System.Drawing.Font("simsun", 9f);
      listViewNF.BorderStyle = BorderStyle.None;
      listViewNF.BackColor = m_ColorBg;

      listViewNF.DoubleClick += listView_localLib_DoubleClick;
      listViewNF.MouseDown += listViewNF_MouseDown;
      listViewNF.MouseMove += listViewNF_MouseMove;
      listViewNF.ItemMouseHover += listViewNF_ItemMouseHover;
      listViewNF.MouseLeave += listViewNF_MouseLeave;

      ImageList imageListLarge = new ImageList();
      imageListLarge.ImageSize = new Size(m_nThumbWidth, (int)(m_nThumbWidth / 1.77));
      imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
      listViewNF.LargeImageList = imageListLarge;

      m_contextMenuStrip_plist = new ContextMenuStrip();
      m_contextMenuStrip_plist.BackColor = m_ContextBackColor;
      m_contextMenuStrip_plist.ForeColor = Color.White;
      m_contextMenuStrip_plist.Renderer = new CustomToolStripProfessionalRendererPlist();
      listViewNF.ContextMenuStrip = m_contextMenuStrip_plist;

      m_formMain.Controls.Add(listViewNF);
      m_formMain.ResumeLayout();
    }

    public void Focus()
    {
      listViewNF.Focus();
    }

    public void Dispose()
    {
      if (m_threadRefreshPlistFolder != null)
        m_threadRefreshPlistFolder.Abort();
      if (m_threadRefreshThumbs != null)
        m_threadRefreshThumbs.Abort();
      if (m_threadRefreshPlistFiles != null)
        m_threadRefreshPlistFiles.Abort();
      if (m_threadRefreshPlistQuickLook != null)
        m_threadRefreshPlistQuickLook.Abort();
    }

    public void ShowLibUi(bool IsShow)
    {
      listViewNF.Visible = IsShow;
      if (labelAdd != null)
        labelAdd.Visible = IsShow;
      if (labelDes != null)
        labelDes.Visible = IsShow;
    }

    void listViewNF_MouseLeave(object sender, EventArgs e)
    {
      if (m_ePlistShowState == ePlistShowState.quickLook)
      {
        m_formBigThumb.Hide();
      }
    }

    void listViewNF_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
    {
      if (m_ePlistShowState == ePlistShowState.quickLook)
      {
        if (e.Item.Index == 0)
          return;

        string thumbName = e.Item.Tag as string;
        int thumbPercent = Convert.ToInt32(thumbName.Substring(thumbName.LastIndexOf("-") + 1));
        string thumbUrl = GetThumbUrl(thumbName + "big");
        if (!File.Exists(thumbUrl))
        {
          try
          {
            Core.GetMediaInfo(m_curFile.url, thumbUrl, thumbPercent, m_formBigThumb.Width);
          }
          catch (Exception ex)
          {
            Core.WriteLog(Core.ELogType.error, "ThreadRefreshPlistQuickLook: " + ex.ToString());
            return;
          }
        }

        int xOffset = 30;
        int yOffset = 20;
        if (Control.MousePosition.Y > Screen.PrimaryScreen.Bounds.Height / 2)
          yOffset = -(m_formBigThumb.Height + yOffset);
        if (Control.MousePosition.X > Screen.PrimaryScreen.Bounds.Width / 2)
          xOffset = -(m_formBigThumb.Width + xOffset);

        m_formBigThumb.Location = new Point(Control.MousePosition.X + xOffset, Control.MousePosition.Y + yOffset);
        m_formBigThumb.ShowForm(thumbUrl);
      }
    }

    void listViewNF_MouseMove(object sender, MouseEventArgs e)
    {
      ListViewItem item = listViewNF.GetItemAt(e.X, e.Y);
      if (item == null)
      {
        if (m_ePlistShowState == ePlistShowState.quickLook)
        {
          m_formBigThumb.Hide();
        }
      }
    }

    void listViewNF_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        m_contextMenuStrip_plist.Items.Clear();
        ListViewItem item = listViewNF.GetItemAt(e.X, e.Y);

        if (item != null)
        {
          switch (m_ePlistShowState)
          {
            case ePlistShowState.folder:
              break;
            case ePlistShowState.file:
              {
                m_curFile = item.Tag as PlaylistFile;
                m_toolStripMenuItem_showPlistQuickLook = new ToolStripMenuItem();
                m_contextMenuStrip_plist.Items.Add(m_toolStripMenuItem_showPlistQuickLook);
                m_toolStripMenuItem_showPlistQuickLook.Text = "快速预览";
                m_toolStripMenuItem_showPlistQuickLook.ForeColor = Color.White;
                m_toolStripMenuItem_showPlistQuickLook.Click += m_toolStripMenuItem_showPlistQuickLook_Click;
              }
              break;
            case ePlistShowState.quickLook:
              break;
          }
        }
        else
        {
          switch (m_ePlistShowState)
          {
            case ePlistShowState.folder:
              break;
            case ePlistShowState.file:
              break;
            case ePlistShowState.quickLook:
              break;
          }
        }
      }
    }

    void m_toolStripMenuItem_showPlistQuickLook_Click(object sender, EventArgs e)
    {
      ShowPlistQuickLook();
    }

    void AddBackItem()
    {
      string strBlackImageUrl = GetBlackImageUrl();
      listViewNF.LargeImageList.Images.Add(strBlackImageUrl, Image.FromFile(strBlackImageUrl));
      listViewNF.Items.Add("返回", strBlackImageUrl);
    }

    private void ShowPlistQuickLook()
    {
      m_ePlistShowState = ePlistShowState.quickLook;

      listViewNF.BeginUpdate();
      listViewNF.Items.Clear();
      listViewNF.LargeImageList.Images.Clear();

      AddBackItem();

      if (m_curFile == null)
        return;
      string fileName = m_curFile.fileName;

      Image img;
      for (int i = 1; i <= 100; ++i)
      {
        string thumbName;
        string thumbUrl = GetThumbUrl(fileName, i, out thumbName);
        try
        {
          img = Image.FromFile(thumbUrl);
        }
        catch
        {
          img = Image.FromFile(Application.StartupPath + @"\pic\black.jpg");
        }
        listViewNF.LargeImageList.Images.Add(thumbUrl, img);

        ListViewItem item = listViewNF.Items.Add(thumbUrl, thumbName, thumbUrl);
        item.Tag = thumbName;
      }
      listViewNF.EnsureVisible(0);
      listViewNF.EndUpdate();

      RefreshPlistQuickLook();
    }

    private void RefreshPlistQuickLook()
    {
      m_threadRefreshPlistQuickLook = new Thread(ThreadRefreshPlistQuickLook);
      m_threadRefreshPlistQuickLook.Start();
    }

    delegate void ReplacePlQuickLookThumbDel(string thumbUrl);
    private void ReplacePlQuickLookThumb(string thumbUrl)
    {
      if (listViewNF.InvokeRequired)
      {
        ReplacePlQuickLookThumbDel del = new ReplacePlQuickLookThumbDel(ReplacePlQuickLookThumb);
        listViewNF.Invoke(del, thumbUrl);
      }
      else
      {
        Image img;
        try
        {
          img = Image.FromFile(thumbUrl);
        }
        catch (Exception ex)
        {
          Core.WriteLog(Core.ELogType.error, "ReplaceThumb fail." + ex.ToString());
          return;
        }
        listViewNF.LargeImageList.Images.RemoveByKey(thumbUrl);
        listViewNF.LargeImageList.Images.Add(thumbUrl, img);
      }
    }

    string GetThumbUrl(string fileName, int thumbNum,out string thumbName)
    {
      thumbName = fileName + "-" + thumbNum.ToString();
      return GetThumbUrl(thumbName);
    }

    private void ThreadRefreshPlistQuickLook()
    {
      if (m_curFile == null)
        return;
      string fileName = m_curFile.fileName;
      string fileUrl = m_curFile.url;
      for (int i = 1; i <= 100; i += 1)
      {
        string thumbName;
        string thumbUrl = GetThumbUrl(fileName, i, out thumbName);
        if (!File.Exists(thumbUrl))
        {
          try
          {
            Core.GetMediaInfo(fileUrl, thumbUrl, i, m_nThumbWidth);
          }
          catch (Exception ex)
          {
            Core.WriteLog(Core.ELogType.error, "ThreadRefreshPlistQuickLook: " + ex.ToString());
            continue;
          }
          ReplacePlQuickLookThumb(thumbUrl);
        }
      }
    }

    string GetFolderImageUrl()
    {
      return Application.StartupPath + @"\pic\folder.png";
    }

    void ShowAddBtn()
    {
      labelAdd = new Label();
      labelAdd.AutoSize = false;
      labelAdd.Size = new Size(90, 90);
      labelAdd.BackColor = Color.Transparent;
      labelAdd.Visible = true;
      labelAdd.Image = Image.FromFile(Application.StartupPath + @"\pic\addFolder.png");
      labelAdd.Location
        = new Point(m_formMain.Width / 2 - labelAdd.Width / 2,
          m_formMain.Height / 2 - labelAdd.Height);
      labelAdd.Cursor = Cursors.Hand;
      labelAdd.Click += labelAdd_Click;
      labelAdd.MouseEnter += labelAdd_MouseEnter;
      labelAdd.MouseLeave += labelAdd_MouseLeave;

      labelDes = new Label();
      labelDes.BackColor = m_ColorBg;
      labelDes.ForeColor = GlobalConstants.Common.colorMainBG;
      labelDes.AutoSize = true;
      labelDes.Font = new Font("simsun", 10f, FontStyle.Bold);
      labelDes.Text = "添加视频文件夹到影库中!";
      labelDes.Location = new Point(labelAdd.Location.X - 40,
        labelAdd.Location.Y + labelAdd.Height + 15);

      m_formMain.Controls.Add(labelDes);
      m_formMain.Controls.Add(labelAdd);
      labelAdd.BringToFront();
      labelDes.BringToFront();
    }

    public void ShowPlistFolder()
    {
      m_curFile = null;
      m_ePlistShowState = ePlistShowState.folder;

      if (Archive.playlist.Count == 0)
      {
        ShowAddBtn();
        return;
      }

      listViewNF.BeginUpdate();
      listViewNF.Items.Clear();
      listViewNF.LargeImageList.Images.Clear();

      string strFolderImageUrl = GetFolderImageUrl();
      listViewNF.LargeImageList.Images.Add(strFolderImageUrl, Image.FromFile(strFolderImageUrl));

      foreach (PlaylistFolder folder in Archive.playlist)
      {
        if (!Directory.Exists(folder.url))
          continue;
        ListViewItem item = listViewNF.Items.Add(folder.url, folder.folderName, strFolderImageUrl);
        item.Tag = folder;
      }
      listViewNF.EndUpdate();

      if(m_curFolder != null)
      {
        ListViewItem curItem = listViewNF.Items[listViewNF.Items.IndexOfKey(m_curFolder.url)];
        curItem.Selected = true;
        listViewNF.EnsureVisible(curItem.Index);
      }

      RefreshPlistFolder();
    }

    void labelAdd_MouseLeave(object sender, EventArgs e)
    {
      labelAdd.Image = Image.FromFile(Application.StartupPath + @"\pic\addFolder.png");
    }

    void labelAdd_MouseEnter(object sender, EventArgs e)
    {
      labelAdd.Image = Image.FromFile(Application.StartupPath + @"\pic\addFolderFocus.png");
    }

    PlaylistFolder AddFolderUrl(string folderUrl)
    {
      PlaylistFolder plistFolder = new PlaylistFolder();
      plistFolder.url = folderUrl;
      DirectoryInfo dir = new DirectoryInfo(folderUrl);
      plistFolder.folderName = dir.Name;
      plistFolder.expand = true;
      plistFolder.creationTime = dir.CreationTime.ToString();
      plistFolder.playlistFiles = new List<PlaylistFile>();
      Archive.playlist.Add(plistFolder);
      return plistFolder;
    }

    void labelAdd_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog f = new FolderBrowserDialog();
      DialogResult result = f.ShowDialog();
      if (result == DialogResult.OK)
      {
        string[] drives = System.Environment.GetLogicalDrives();
        if (drives.Contains(f.SelectedPath))
        {
          MessageBox.Show("请不要直接添加系统根目录(例如C盘D盘)，请添加包含影片的文件夹！");
          return;
        }

        labelAdd.Visible = false;
        labelDes.Visible = false;
        labelAdd = labelDes = null;
        AddFolderUrl(f.SelectedPath);
        ShowPlistFolder();
      }
    }

    private void RefreshPlistFolder()
    {
      m_threadRefreshPlistFolder = new Thread(ThreadRefreshPlistFolder);
      m_threadRefreshPlistFolder.Start();
    }

    private void ThreadRefreshPlistFolder()
    {
      // delete no-exists folder
      List<PlaylistFolder> deleteFolders = new List<PlaylistFolder>();
      foreach (PlaylistFolder folder in Archive.playlist)
      {
        if (!Directory.Exists(folder.url))
        {
          deleteFolders.Add(folder);
          continue;
        }
      }

      foreach (PlaylistFolder folder in deleteFolders)
      {
        Archive.playlist.Remove(folder);
      }

      // sort by pathLen
      Archive.enumSortBy origSortBy = Archive.sortBy;
      Archive.sortBy = Archive.enumSortBy.pathLen;
      FormPlaylist.SortPlistFolder();

      // get folder url
      int folderCount = Archive.playlist.Count;
      string[] folderUrls = new string[folderCount];
      for(int i = 0; i < folderCount; ++i)
      {
        folderUrls[i] = Archive.playlist[i].url;
      }

      // sort back
      Archive.sortBy = origSortBy;
      FormPlaylist.SortPlistFolder();

      // scan sub folder
      string[] drives = System.Environment.GetLogicalDrives(); 
      List<string> subFolderList = new List<string>();
      for (int i = 0; i < folderCount; ++i)
      {
        string folderUrl = folderUrls[i];
        // Avoid reScan some folders || do not scan drive root
        if (subFolderList.Exists(e => e == folderUrl) || drives.Contains(folderUrl))
          continue;
        string[] subs;
        try
        {
          subs = Directory.GetDirectories(folderUrl, "*.*", System.IO.SearchOption.AllDirectories);
        }
        catch (Exception ex)
        {
          Core.WriteLog(Core.ELogType.error, ex.ToString());
          continue;
        }
        subFolderList.AddRange(subs);
      }

      // remove same
      foreach (PlaylistFolder folder in Archive.playlist)
      {
        if (!subFolderList.Exists(e => e == folder.url))
          continue;
        subFolderList.Remove(folder.url);
      }

      // add new
      foreach (string subFolder in subFolderList)
      {
        string[] strFilesInCurrentDirectory = FormPlaylist.GetMoives(subFolder);
        if (strFilesInCurrentDirectory.Length < 1)
          continue;

        AddPlFolder(AddFolderUrl(subFolder));
      }

      // sort new
      Archive.sortBy = origSortBy;
      FormPlaylist.SortPlistFolder();
    }

    delegate void AddPlFolderDel(PlaylistFolder folder);
    private void AddPlFolder(PlaylistFolder folder)
    {
      if (m_ePlistShowState != ePlistShowState.folder)
        return;
      if (listViewNF.InvokeRequired)
      {
        AddPlFolderDel del = new AddPlFolderDel(AddPlFolder);
        listViewNF.Invoke(del, folder);
      }
      else
      {
        ListViewItem item = listViewNF.Items.Add(folder.url, folder.folderName, GetFolderImageUrl());
        item.Tag = folder;
      }
    }

    private void listView_localLib_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
    {
      ListViewItem viewItem = e.Item;
      //MessageBox.Show(viewItem.Text);
    }

    private void listView_localLib_DoubleClick(object sender, EventArgs e)
    {
      ListView view = sender as ListView;
      ListView.SelectedListViewItemCollection viewItems = view.SelectedItems;
      if (viewItems.Count != 0)
      {
        switch(m_ePlistShowState)
        {
          case ePlistShowState.folder:
            ShowPlistFiles(viewItems[0].Tag as PlaylistFolder);
            break;
          case ePlistShowState.file:
            {
              if (viewItems[0].Index == 0)
                ShowPlistFolder();
              else
              {
                m_formMain.StartPlay((viewItems[0].Tag as PlaylistFile).url);
              }
            }
            break;
          case ePlistShowState.quickLook:
            {
              if (viewItems[0].Index == 0)
                ShowPlistFiles(m_curFolder);
            }
            break;
        }
      }
    }

    string GetBlackImageUrl()
    {
      return Application.StartupPath + @"\pic\backToFolder.png";
    }

    private void ShowPlistFiles(PlaylistFolder folder)
    {
      m_ePlistShowState = ePlistShowState.file;
      m_curFolder = folder;

      listViewNF.BeginUpdate();
      listViewNF.Items.Clear();
      listViewNF.LargeImageList.Images.Clear();

      AddBackItem();

      foreach (PlaylistFile file in folder.playlistFiles)
      {
        if (!File.Exists(file.url))
          continue;

        string thumbUrl = GetThumbUrl(file.fileName);
        Image img;
        try
        {
          img = Image.FromFile(thumbUrl);
        }
        catch
        {
          img = Image.FromFile(Application.StartupPath + @"\pic\black.jpg");
        }
        listViewNF.LargeImageList.Images.Add(thumbUrl, img);

        ListViewItem item = listViewNF.Items.Add(file.url, file.fileName, thumbUrl);
        item.Tag = file;
      }

      if (m_curFile != null)
      {
        ListViewItem curItem = listViewNF.Items[listViewNF.Items.IndexOfKey(m_curFile.url)];
        curItem.Selected = true;
        listViewNF.EnsureVisible(curItem.Index);
      }

      listViewNF.EndUpdate();

      RefreshThumbs(folder);
      RefreshPlistFiles(folder);
    }

    private void RefreshPlistFiles(PlaylistFolder folder)
    {
      m_threadRefreshPlistFiles = new Thread(ThreadRefreshPlistFiles);
      m_threadRefreshPlistFiles.Start();
    }

    private void ThreadRefreshPlistFiles()
    {
      // delete no-exists file
      List<PlaylistFile> deleteFiles = new List<PlaylistFile>();
      foreach (PlaylistFile file in m_curFolder.playlistFiles)
      {
        if (!File.Exists(file.url))
        {
          deleteFiles.Add(file);
          continue;
        }
      }

      foreach (PlaylistFile file in deleteFiles)
      {
        m_curFolder.playlistFiles.Remove(file);
      }

      // add new
      string[] strFilesInCurrentDirectory = FormPlaylist.GetMoives(m_curFolder.url);
      foreach (string fileUrl in strFilesInCurrentDirectory)
      {
        if (m_curFolder.playlistFiles.Exists(e => e.url == fileUrl))
          continue;

        PlaylistFile file = new PlaylistFile();
        file.url = fileUrl;
        Uri uri = new Uri(fileUrl);
        file.fileName = System.IO.Path.GetFileName(uri.LocalPath);
        file.timeWatched = 0;
        file.playState = PlaylistFile.enumPlayState.notPlayed;
        MediaInfo info = new MediaInfo();
        info = Core.GetMediaInfo(fileUrl, GetThumbUrl(file.fileName), 5, m_nThumbWidth);
        file.duration = info.nDuration;
        file.creationTime = File.GetCreationTime(fileUrl).ToString();
        m_curFolder.playlistFiles.Add(file);
        AddPlFile(file);
      }
      FormPlaylist.SortPlistFile(m_curFolder);
    }

    delegate void AddPlFileDel(PlaylistFile file);
    private void AddPlFile(PlaylistFile file)
    {
      if (listViewNF.InvokeRequired)
      {
        AddPlFileDel del = new AddPlFileDel(AddPlFile);
        listViewNF.Invoke(del, file);
      }
      else
      {
        string thumbUrl = GetThumbUrl(file.fileName);
        Image img;
        try
        {
          img = Image.FromFile(thumbUrl);
        }
        catch
        {
          img = Image.FromFile(Application.StartupPath + @"\pic\black.jpg");
        }
        listViewNF.LargeImageList.Images.Add(thumbUrl, img);

        ListViewItem item = listViewNF.Items.Add(file.url, file.fileName, thumbUrl);
        item.Tag = file;
      }
    }

    private void RefreshThumbs(PlaylistFolder folder)
    {
      m_threadRefreshThumbs = new Thread(ThreadRefreshThumbs);
      m_threadRefreshThumbs.Start();
    }

    private void ThreadRefreshThumbs()
    {
      foreach (PlaylistFile file in m_curFolder.playlistFiles)
      {
        string thumbUrl = GetThumbUrl(file.fileName);
        if (!File.Exists(thumbUrl))
        {
          try
          {
            Core.GetMediaInfo(file.url, thumbUrl, 5, m_nThumbWidth);
            ReplaceThumb(thumbUrl);
          }
          catch (Exception ex)
          {
            Core.WriteLog(Core.ELogType.error, "get thumb fail." + ex.ToString());
          }
        }
      }
    }

    private string GetThumbUrl(string thumbName)
    {
      return m_strThumbDir + "\\" + thumbName + ".jpg";
    }

    delegate void ReplaceThumbDel(string thumbUrl);
    private void ReplaceThumb(string thumbUrl)
    {
      if (m_ePlistShowState != ePlistShowState.file)
        return;
      if (listViewNF.InvokeRequired)
      {
        ReplaceThumbDel del = new ReplaceThumbDel(ReplaceThumb);
        listViewNF.Invoke(del, thumbUrl);
      }
      else
      {
        Image img;
        try
        {
          img = Image.FromFile(thumbUrl);
        }
        catch (Exception ex)
        {
          Core.WriteLog(Core.ELogType.error, "ReplaceThumb fail." + ex.ToString());
          return;
        }
        listViewNF.LargeImageList.Images.RemoveByKey(thumbUrl);
        listViewNF.LargeImageList.Images.Add(thumbUrl, img);
      }
    }
  }

  class ListViewNF : System.Windows.Forms.ListView
  {
    public ListViewNF()
    {
      //Activate double buffering
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

      //Enable the OnNotifyMessage event so we get a chance to filter out 
      // Windows messages before they get to the form's WndProc
      this.SetStyle(ControlStyles.EnableNotifyMessage, true);
    }

    protected override void OnNotifyMessage(Message m)
    {
      //Filter out the WM_ERASEBKGND message
      if (m.Msg != 0x14)
      {
        base.OnNotifyMessage(m);
      }
    }
  }
}
