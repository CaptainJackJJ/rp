using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RpCoreWrapper;

namespace RPlayer
{
  public partial class FormPlaylist : Form
  {
    private MainForm m_mainForm;
    private bool m_bLeftEdgeMouseDown = false;
    private Point m_leftEdgeMouseDownLoc;
    private const int nEdgeMargin = 10;
    private const int m_nMinWidth = 194;
    private FormHistroyDetails m_formHistroyDetails;
    private FormPlistFileDetails m_formPlistFileDetails;
    private FormPlistFolderDetails m_formPlistFolderDetails;
    private ContextMenuStrip m_contextMenuStrip_histroy;
    private ToolStripMenuItem m_toolStripMenuItem_histroyDelete;
    private ToolStripMenuItem m_toolStripMenuItem_markHistroyAsFinished;
    private bool m_bFirstShowHistroy = true;
    private bool m_bFirstShowPlaylist = true;

    private ContextMenuStrip m_contextMenuStrip_plist;
    private ToolStripMenuItem m_toolStripMenuItem_markPlistAsFinished;
    private ToolStripMenuItem m_toolStripMenuItem_deletePlistFile;
    private ToolStripMenuItem m_toolStripMenuItem_updatePlistFolder;
    private ToolStripMenuItem m_toolStripMenuItem_deletePlistFolder;
    private Color m_ContextBackColor = Color.SlateGray;

    private Color m_colorFinished = Color.RosyBrown;
    private Color m_colorPlayed = Color.SkyBlue;
    
    public FormPlaylist(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();
      ConfigByArchive();
      SetUiLange();
      m_formHistroyDetails = new FormHistroyDetails();
      this.AddOwnedForm(m_formHistroyDetails);
      m_formPlistFileDetails = new FormPlistFileDetails();
      this.AddOwnedForm(m_formPlistFileDetails);
      m_formPlistFolderDetails = new FormPlistFolderDetails();
      this.AddOwnedForm(m_formPlistFolderDetails);
      InitContextMenuStrip();
    }

    private void InitContextMenuStrip()
    {
      m_contextMenuStrip_histroy = new ContextMenuStrip();
      m_contextMenuStrip_histroy.BackColor = m_ContextBackColor;
      m_contextMenuStrip_histroy.ForeColor = Color.White;
      m_contextMenuStrip_histroy.Renderer = new CustomToolStripProfessionalRendererPlist();
      listView_histroy.ContextMenuStrip = m_contextMenuStrip_histroy;

      m_toolStripMenuItem_markHistroyAsFinished = new ToolStripMenuItem();
      m_contextMenuStrip_histroy.Items.Add(m_toolStripMenuItem_markHistroyAsFinished);
      m_toolStripMenuItem_markHistroyAsFinished.Text = UiLang.markAsFinished;
      m_toolStripMenuItem_markHistroyAsFinished.ForeColor = Color.White;
      m_toolStripMenuItem_markHistroyAsFinished.Click += toolStripMenuItem_markHistroyAsFinished_click;

      m_toolStripMenuItem_histroyDelete = new ToolStripMenuItem();
      m_contextMenuStrip_histroy.Items.Add(m_toolStripMenuItem_histroyDelete);
      m_toolStripMenuItem_histroyDelete.Text = UiLang.delete;
      m_toolStripMenuItem_histroyDelete.ForeColor = Color.White;
      m_toolStripMenuItem_histroyDelete.Click += toolStripMenuItem_histroyDelete_click;

      m_contextMenuStrip_plist = new ContextMenuStrip();
      m_contextMenuStrip_plist.BackColor = m_ContextBackColor;
      m_contextMenuStrip_plist.ForeColor = Color.White;
      m_contextMenuStrip_plist.Renderer = new CustomToolStripProfessionalRendererPlist();
      treeView_playlist.ContextMenuStrip = m_contextMenuStrip_plist;
    }

    private void toolStripMenuItem_histroyDelete_click(object sender, EventArgs e)
    {
      int count = listView_histroy.SelectedItems.Count;
      if(count == 0)
        MessageBox.Show(UiLang.messageToSelectItem);
      else
      {
        foreach(ListViewItem item in listView_histroy.SelectedItems)
        {
          Archive.histroy.Remove(item.Tag as HistroyItem);
          listView_histroy.Items.Remove(item);
        }
      }
    }

    private void toolStripMenuItem_markHistroyAsFinished_click(object sender, EventArgs e)
    {
      int count = listView_histroy.SelectedItems.Count;
      if(count == 0)
        MessageBox.Show(UiLang.messageToSelectItem);
      else
      {
        foreach(ListViewItem item in listView_histroy.SelectedItems)
        {
          HistroyItem histroyItem = item.Tag as HistroyItem;
          histroyItem.timeWatched = 0;
          item.ForeColor = m_colorFinished;
        }
      }
    }

    private void FormPlaylist_Resize(object sender, EventArgs e)
    {
      Archive.formPlistWidth = this.Width;
      Archive.formPlistHeight = this.Height;
      int nBtnHeight = button_histroy.Height;
      int nComboBoxHeight = comboBox_repeat.Height;
      Size listViewSize = 
        new Size(this.Width - nEdgeMargin * 2, 
          this.Height - nEdgeMargin * 4 - nBtnHeight - nComboBoxHeight * 2);
      treeView_playlist.Size = listViewSize;
      listView_histroy.Size = listViewSize;
      int nRepeatY = this.Height - nEdgeMargin * 2 - nComboBoxHeight * 2;
      label_repeat.Location = new Point(label_repeat.Location.X, nRepeatY + 3);
      comboBox_repeat.Location = new Point(comboBox_repeat.Location.X, nRepeatY);
      int nSortByY = this.Height - nEdgeMargin - nComboBoxHeight;
      label_sortBy.Location = new Point(label_sortBy.Location.X, nSortByY + 3);
      comboBox_sort.Location = new Point(comboBox_sort.Location.X, nSortByY);      
    }

    public void ConfigByArchive()
    {
      this.Size = new Size(Archive.formPlistWidth, Archive.formPlistHeight);
      SwitchListView(Archive.selectedPListBtn);
    }

    // Update whole plist
    private void UpdatePlayList(bool bAutoUpdateView)
    {
      List<PlaylistFolder> deleteFolders = new List<PlaylistFolder>();
      foreach(PlaylistFolder folder in Archive.playlist)
      {
        if (!Directory.Exists(folder.url))
        {
            deleteFolders.Add(folder);
            continue;
        }
        AddOrUpdatePlaylist(folder.url, bAutoUpdateView);
      }

      foreach (PlaylistFolder folder in deleteFolders)
      {
        Archive.playlist.Remove(folder);
      }

      if (deleteFolders.Count > 0 && bAutoUpdateView)
        UpdatePlayListView(true, "");
    }

    // Url: file path or folder path
    public PlaylistFolder AddOrUpdatePlaylist(string Url,bool bAutoUpdateView)
    {
      if(File.Exists(Url))
      {
        Uri uri = new Uri(Url);
        string strCurrentFolder = System.IO.Path.GetDirectoryName(uri.LocalPath);

        foreach (PlaylistFolder folder in Archive.playlist)// Check if file is already in plist, if so, just return.
        {
          if (folder.url == strCurrentFolder)
          {
            foreach (PlaylistFile file in folder.playlistFiles)
            {
              if (file.url == Url)
              {
                return folder;
              }
            }
          }
        }

        Url = strCurrentFolder;
      }

      if (!Directory.Exists(Url))
      {
        MessageBox.Show(UiLang.pathNotFound + Url);
        return null;
      }

      string strFilters = "*.m4v|*.3g2|*.3gp|*.nsv|*.tp|*.ts|*.ty|*.strm|*.pls|*.rm|*.rmvb|*.m3u|*.m3u8|*.ifo|*.mov|*.qt|*.divx|*.xvid|*.bivx|*.vob|*.nrg|*.img|*.iso|*.pva|*.wmv|*.asf|*.asx|*.ogm|*.m2v|*.avi|*.bin|*.dat|*.mpg|*.mpeg|*.mp4|*.mkv|*.mk3d|*.avc|*.vp3|*.svq3|*.nuv|*.viv|*.dv|*.fli|*.flv|*.rar|*.001|*.wpl|*.zip|*.vdr|*.dvr-ms|*.xsp|*.mts|*.m2t|*.m2ts|*.evo|*.ogv|*.sdp|*.avs|*.rec|*.url|*.pxml|*.vc1|*.h264|*.rcv|*.rss|*.mpls|*.webm|*.bdmv|*.wtv|*.td";
      string[] strFilesInCurrentDirectory
        = strFilters.Split('|').SelectMany(filter =>
          Directory.GetFiles(Url, filter, SearchOption.TopDirectoryOnly)
          ).ToArray();

      List<string> addFiles = strFilesInCurrentDirectory.ToList();

      if(addFiles.Count == 0)
      {
        if (File.Exists(Url))//Handle some file exts that not in the ext list
        {
          addFiles.Add(Url);
        }
      }

      PlaylistFolder curPlistFolder = null;

      // Check if folder is already in plist. If so, check which files need be added or deleted
      List<PlaylistFile> deleteFiles = new List<PlaylistFile>();
      foreach (PlaylistFolder folder in Archive.playlist) 
      {
        if (folder.url != Url)
          continue;

        curPlistFolder = folder;
        foreach (PlaylistFile file in folder.playlistFiles)
        {
          int index = addFiles.IndexOf(file.url);
          if (index != -1)
          {
            addFiles.RemoveAt(index);
          }
          else
          {
            deleteFiles.Add(file);
          }
        }

        foreach (PlaylistFile file in deleteFiles)
        {
          folder.playlistFiles.Remove(file);
        }
      }

      if (addFiles.Count == 0 && deleteFiles.Count == 0 && curPlistFolder != null) // Nothing changed
        return curPlistFolder;

      if (curPlistFolder == null)
      {
        curPlistFolder = new PlaylistFolder();
        curPlistFolder.url = Url;
        DirectoryInfo dir = new DirectoryInfo(Url);
        curPlistFolder.folderName = dir.Name;
        curPlistFolder.expand = true;
        curPlistFolder.creationTime = dir.CreationTime.ToString();
        curPlistFolder.playlistFiles = new List<PlaylistFile>();
        Archive.playlist.Add(curPlistFolder);

        SortPlistFolder();

        if (bAutoUpdateView)
          UpdatePlayListView(true, "");
      }

      foreach (string fileUrl in addFiles)
      {
        PlaylistFile file = new PlaylistFile();
        file.url = fileUrl;
        Uri uri = new Uri(fileUrl);
        file.fileName = System.IO.Path.GetFileName(uri.LocalPath);
        file.timeWatched = 0;
        file.playState = PlaylistFile.enumPlayState.notPlayed;
        MediaInfo info = new MediaInfo();
        info = RpCore.GetMediaInfo(fileUrl);
        file.duration = info.nDuration;
        file.creationTime = File.GetCreationTime(fileUrl).ToString();
        curPlistFolder.playlistFiles.Add(file);
      }

      SortPlistFile(curPlistFolder);

      if (bAutoUpdateView)
        UpdatePlayListView(false, Url);

      return curPlistFolder;
    }

    private void SortPlistFolder()
    {
      Archive.playlist.Sort(delegate(PlaylistFolder folder1, PlaylistFolder folder2)
      {
        switch (Archive.sortBy)
        {
          case Archive.enumSortBy.creationTimeUp:
            return DateTime.Parse(folder1.creationTime).CompareTo(DateTime.Parse(folder2.creationTime));
          case Archive.enumSortBy.creationTimeDown:
            return DateTime.Parse(folder1.creationTime).CompareTo(DateTime.Parse(folder2.creationTime)) > 0 ? -1 : 1;
          case Archive.enumSortBy.nameUp:
            return folder1.folderName.CompareTo(folder2.folderName);
          case Archive.enumSortBy.nameDown:
            return folder1.folderName.CompareTo(folder2.folderName) > 0 ? -1 : 1;
          default:
            return 0;
        }
      });
    }

    private void SortPlistFile(PlaylistFolder folder)
    {
      folder.playlistFiles.Sort(delegate(PlaylistFile file1, PlaylistFile file2)
      {
        switch (Archive.sortBy)
        {
          case Archive.enumSortBy.creationTimeUp:
            return DateTime.Parse(file1.creationTime).CompareTo(DateTime.Parse(file2.creationTime));
          case Archive.enumSortBy.creationTimeDown:
            return DateTime.Parse(file1.creationTime).CompareTo(DateTime.Parse(file2.creationTime)) > 0 ? -1 : 1;
          case Archive.enumSortBy.nameUp:
            return file1.fileName.CompareTo(file2.fileName);
          case Archive.enumSortBy.nameDown:
            return file1.fileName.CompareTo(file2.fileName) > 0 ? -1 : 1;;
          case Archive.enumSortBy.durationUp:
            return TimeSpan.FromSeconds(file1.duration).CompareTo(TimeSpan.FromSeconds(file2.duration));
          case Archive.enumSortBy.durationDown:
            return TimeSpan.FromSeconds(file1.duration).CompareTo(TimeSpan.FromSeconds(file2.duration)) > 0 ? -1 : 1;
          default:
            return 0;
        }
      });
    }

    private void SortPlist()
    {
      foreach(PlaylistFolder folder in Archive.playlist)
      {
        SortPlistFile(folder);
      }
      SortPlistFolder();
      UpdatePlayListView(true, "");
    }

    public void GetPlistFolderAndFile(string fileUrl, out PlaylistFile Plistfile, out PlaylistFolder Plistfolder)
    {
      Plistfile = null;
      Plistfolder = null;
      foreach(PlaylistFolder folder in Archive.playlist)
      {
        foreach(PlaylistFile file in folder.playlistFiles)
        {
          if(file.url == fileUrl)
          {
            Plistfile = file;
            Plistfolder = folder;
            return;
          }
        }
      }
    }

    public void MarkPlayingPlist(PlaylistFolder plistFolder, PlaylistFile plistFile)
    {
      foreach (TreeNode nodeFolder in treeView_playlist.Nodes)
      {
        if (((PlaylistFolder)(nodeFolder.Tag) == plistFolder))
        {
          foreach (TreeNode nodeFile in nodeFolder.Nodes)
          {
            if (((PlaylistFile)(nodeFile.Tag) == plistFile))
            {
              nodeFile.ForeColor = Color.Red;
              return;
            }
          }
          return;
        }
      }
     MessageBox.Show("MarkPlayingPlist: no match plistFile");
    }

    public void UpdatePlayListView(bool bAllFloder, string folderUrl)
    {
      Cursor.Current = Cursors.WaitCursor;
      treeView_playlist.BeginUpdate();

      if (bAllFloder)
        treeView_playlist.Nodes.Clear();

      foreach(PlaylistFolder folder in Archive.playlist)
      {
        TreeNode folderNode = null;
        if (!bAllFloder)
        {
          if(folder.url != folderUrl)
            continue;
          foreach(TreeNode node in treeView_playlist.Nodes)
          {
            if (((PlaylistFolder)(node.Tag)).url == folderUrl)
            {
              folderNode = node;
              folderNode.Nodes.Clear();
              break;
            }
          }
        }

        if (folderNode == null)
        {
          folderNode = new TreeNode();
          folderNode.Text = folder.folderName;
          folderNode.Tag = folder;
          treeView_playlist.Nodes.Add(folderNode);
        }

        foreach(PlaylistFile file in folder.playlistFiles)
        {
          TreeNode fileNode = new TreeNode();
          fileNode.Text = file.fileName;
          fileNode.Tag = file;
          switch(file.playState)
          {
            case PlaylistFile.enumPlayState.finished:
              fileNode.ForeColor = m_colorFinished;
              break;
            case PlaylistFile.enumPlayState.played:
              fileNode.ForeColor = m_colorPlayed;
              break;
          }
          folderNode.Nodes.Add(fileNode);
        }

        if (folder.expand)
          folderNode.Expand();

        if (!bAllFloder)
          break;
      }

      Cursor.Current = Cursors.Arrow;
      treeView_playlist.EndUpdate();
    }

    public void  UpdateListViewHistroy()
    {
      listView_histroy.Clear();
      for (int i = Archive.histroy.Count - 1; i >= 0; i--)
      {
        HistroyItem item = Archive.histroy[i];
        ListViewItem listItem = new ListViewItem();
        Uri uri = new Uri(item.url);
        listItem.Text = System.IO.Path.GetFileName(uri.LocalPath);
        listItem.Tag = item;
        if ((int)item.timeWatched != 0)
          listItem.ForeColor = m_colorPlayed;
        else
          listItem.ForeColor = m_colorFinished;
        listView_histroy.Items.Add(listItem);
      }
    }

    private void SwitchListView(Archive.enumSelectedPListBtn selectedBtn)
    {
      switch (selectedBtn)
      {
        case Archive.enumSelectedPListBtn.playlist:
          button_histroy.BackColor = Color.SlateGray;
          button_playlist.BackColor = Color.DodgerBlue;
          listView_histroy.Hide();
          treeView_playlist.Show();
          Archive.selectedPListBtn = Archive.enumSelectedPListBtn.playlist;
          if (m_bFirstShowPlaylist)
          {
            if (Archive.updatePlistAfterLaunch)
              UpdatePlayList(false);
            UpdatePlayListView(true, "");
            m_bFirstShowPlaylist = false;
          }
          break;
        case Archive.enumSelectedPListBtn.histroy:
          button_histroy.BackColor = Color.DodgerBlue;
          button_playlist.BackColor = Color.SlateGray;
          listView_histroy.Show();
          treeView_playlist.Hide();
          Archive.selectedPListBtn = Archive.enumSelectedPListBtn.histroy;
          if (m_bFirstShowHistroy)
          {
            UpdateListViewHistroy();
            m_bFirstShowHistroy = false;
          }
          break;
      }
    }

    public void SetAllUiLange()
    {
      SetUiLange();
      m_formHistroyDetails.SetAllUiLange();
      m_formPlistFileDetails.SetAllUiLange();
      m_formPlistFolderDetails.SetAllUiLange();
    }

    private void SetUiLange()
    {
      button_histroy.Text = UiLang.btnHistory;
      button_playlist.Text = UiLang.btnPlaylist;

      label_repeat.Text = UiLang.labelRepeatPlayback;
      comboBox_repeat.Items.Clear();
      comboBox_repeat.Items.Add(UiLang.ComboBoxRepeatNone);
      comboBox_repeat.Items.Add(UiLang.ComboBoxRepeatOne);
      comboBox_repeat.Items.Add(UiLang.ComboBoxRepeatAll);
      comboBox_repeat.SelectedIndex = (int)Archive.repeatPlayback;
      comboBox_repeat.SelectedIndexChanged += comboBox_repeatPlayback_SelectedIndexChanged;

      label_sortBy.Text = UiLang.labelSortBy;
      comboBox_sort.Items.Clear();
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByCreatedTimeUp);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByCreatedTimeDown);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByFileNameUp);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByFileNameDown);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByDurationUp);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByDurationDown);
      comboBox_sort.SelectedIndex = (int)Archive.sortBy;
      comboBox_sort.SelectedIndexChanged += comboBox_comboBox_sort_SelectedIndexChanged;
    }

    private void comboBox_repeatPlayback_SelectedIndexChanged(object sender, EventArgs e)
    {
      Archive.repeatPlayback = (Archive.enumRepeatPlayback)comboBox_repeat.SelectedIndex;
    }

    private void comboBox_comboBox_sort_SelectedIndexChanged(object sender, EventArgs e)
    {
      Archive.sortBy = (Archive.enumSortBy)comboBox_sort.SelectedIndex;
    }

    private void button_playlist_Click(object sender, EventArgs e)
    {
      SwitchListView(Archive.enumSelectedPListBtn.playlist);
    }

    private void button_histroy_Click(object sender, EventArgs e)
    {
      SwitchListView(Archive.enumSelectedPListBtn.histroy);
    }

    private void FormPlaylist_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Location.X < nEdgeMargin)
      {
        m_bLeftEdgeMouseDown = true;
        m_leftEdgeMouseDownLoc = e.Location;
      }
    }

    private void FormPlaylist_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Location.X < 5)
        Cursor = Cursors.SizeWE;
      else
        Cursor = Cursors.Arrow;

      if(m_bLeftEdgeMouseDown)
      {
        Control control = (Control)sender;
        Point MouseScreenPoint = control.PointToScreen(new Point(e.X, e.Y));
        int xDiff = this.Location.X - MouseScreenPoint.X;
        if (this.Size.Width + xDiff > m_nMinWidth)
        {
          this.Location = new Point(MouseScreenPoint.X, this.Location.Y);
          this.Size = new Size(this.Size.Width + xDiff, this.Size.Height);
          m_mainForm.ChangePlayWndSizeInNonDesktop();
        }
      }
    }

    private void FormPlaylist_MouseLeave(object sender, EventArgs e)
    {
      Cursor = Cursors.Arrow;
    }

    private void FormPlaylist_MouseUp(object sender, MouseEventArgs e)
    {
      m_bLeftEdgeMouseDown = false;
    }

    private void listView_histroy_MouseMove(object sender, MouseEventArgs e)
    {
      ListView view = sender as ListView;
      ListViewItem viewItem = view.GetItemAt(e.X, e.Y);
      if (viewItem == null)
      {
        m_formHistroyDetails.Hide();
      }
    }

    private void listView_histroy_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
    {
      ListView view = sender as ListView;
      ListViewItem viewItem = e.Item;

      HistroyItem item = viewItem.Tag as HistroyItem;

      m_formHistroyDetails.Location 
        = new Point(Control.MousePosition.X + 20, Control.MousePosition.Y + 3);
      TimeSpan t = TimeSpan.FromSeconds(item.duration);
      string strDuration = string.Format("{0:D2} : {1:D2} : {2:D2}",
                    t.Hours, t.Minutes, t.Seconds);
      string strTimeWatched = UiLang.labelDetailsFinished;
      if ((int)item.timeWatched != 0)
      {
        t = TimeSpan.FromSeconds(item.timeWatched);
        strTimeWatched = string.Format("{0:D2} : {1:D2} : {2:D2}",
                      t.Hours, t.Minutes, t.Seconds);
      }
      m_formHistroyDetails.ShowForm(strTimeWatched, strDuration, item.url);
    }

    private void listView_histroy_MouseLeave(object sender, EventArgs e)
    {
      m_formHistroyDetails.Hide();
    }

    private void listView_histroy_DoubleClick(object sender, EventArgs e)
    {
      ListView view = sender as ListView;
      ListView.SelectedListViewItemCollection viewItems = view.SelectedItems;
      if(viewItems.Count != 0)
      {
        HistroyItem item = viewItems[0].Tag as HistroyItem;
        m_mainForm.StartPlay(item.url);
      }

    }

    private void treeView_playlist_AfterExpand(object sender, TreeViewEventArgs e)
    {
      ((PlaylistFolder)(e.Node.Tag)).expand = e.Node.IsExpanded;
    }

    private void treeView_playlist_AfterCollapse(object sender, TreeViewEventArgs e)
    {
      ((PlaylistFolder)(e.Node.Tag)).expand = e.Node.IsExpanded;
    }

    private void treeView_playlist_DoubleClick(object sender, EventArgs e)
    {
      TreeNode node = treeView_playlist.SelectedNode;
      if (node.Parent == null)
        return;
      PlaylistFile file = (PlaylistFile)node.Tag;
      m_mainForm.StartPlay(file.url);
    }

    private void treeView_playlist_MouseMove(object sender, MouseEventArgs e)
    {
      TreeView view = sender as TreeView;
      TreeNode node = view.GetNodeAt(e.X, e.Y);
      if (node == null)
      {
        m_formPlistFileDetails.Hide();
        m_formPlistFolderDetails.Hide();
      }
    }

    private void treeView_playlist_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
    {
      TreeNode node = e.Node;
      if(node.Parent == null) // folder node
      {
        m_formPlistFileDetails.Hide();

        PlaylistFolder folder = node.Tag as PlaylistFolder;

        m_formPlistFolderDetails.Location = new Point(Control.MousePosition.X + 20, Control.MousePosition.Y + 3);

        string strCreationTime = folder.creationTime;

        m_formPlistFolderDetails.ShowForm(strCreationTime, folder.url);
      }
      else
      {
        m_formPlistFolderDetails.Hide();

        PlaylistFile file = node.Tag as PlaylistFile;

        m_formPlistFileDetails.Location = new Point(Control.MousePosition.X + 20, Control.MousePosition.Y + 3);
        TimeSpan t = TimeSpan.FromSeconds(file.duration);
        string strDuration = string.Format("{0:D2} : {1:D2} : {2:D2}",
                      t.Hours, t.Minutes, t.Seconds);
        string strTimeWatched = UiLang.labelDetailsFinished;
        switch(file.playState)
        {
          case PlaylistFile.enumPlayState.notPlayed:
            strTimeWatched = "00 : 00 : 00";
            break;
          case PlaylistFile.enumPlayState.played:
            t = TimeSpan.FromSeconds(file.timeWatched);
            strTimeWatched = string.Format("{0:D2} : {1:D2} : {2:D2}",t.Hours, t.Minutes, t.Seconds);
            break;
        }

        string strCreationTime = file.creationTime;

        m_formPlistFileDetails.ShowForm(strTimeWatched, strDuration, strCreationTime,file.url);
      }
    }

    private void treeView_playlist_MouseLeave(object sender, EventArgs e)
    {
      m_formPlistFileDetails.Hide();
      m_formPlistFolderDetails.Hide();
    }

    private void treeView_playlist_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Link;
    }

    private void treeView_playlist_DragDrop(object sender, DragEventArgs e)
    {
      string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      if(File.Exists(FileList[0]))// If it is file
      {
        AddOrUpdatePlaylist(FileList[0],true);
        return;
      }
      // folder
      foreach(string url in FileList)
      {
        AddOrUpdatePlaylist(url,false);
      }
      UpdatePlayListView(true, "");
    }

    private void treeView_playlist_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      TreeView view = sender as TreeView;
      view.SelectedNode = e.Node;
      if (view.SelectedNode.Parent != null)// selected plist file node
      {
        m_contextMenuStrip_plist.Items.Clear();

        m_toolStripMenuItem_markPlistAsFinished = new ToolStripMenuItem();
        m_contextMenuStrip_plist.Items.Add(m_toolStripMenuItem_markPlistAsFinished);
        m_toolStripMenuItem_markPlistAsFinished.Text = UiLang.markAsFinished;
        m_toolStripMenuItem_markPlistAsFinished.ForeColor = Color.White;
        m_toolStripMenuItem_markPlistAsFinished.Click += toolStripMenuItem_markPlistAsFinished_click;

        m_toolStripMenuItem_deletePlistFile = new ToolStripMenuItem();
        m_contextMenuStrip_plist.Items.Add(m_toolStripMenuItem_deletePlistFile);
        m_toolStripMenuItem_deletePlistFile.Text = UiLang.delete;
        m_toolStripMenuItem_deletePlistFile.ForeColor = Color.White;
        m_toolStripMenuItem_deletePlistFile.Click += toolStripMenuItem_deletePlistFile_click;
      }
      else // folder node
      {
        m_contextMenuStrip_plist.Items.Clear();

        m_toolStripMenuItem_updatePlistFolder = new ToolStripMenuItem();
        m_contextMenuStrip_plist.Items.Add(m_toolStripMenuItem_updatePlistFolder);
        m_toolStripMenuItem_updatePlistFolder.Text = UiLang.update;
        m_toolStripMenuItem_updatePlistFolder.ForeColor = Color.White;
        m_toolStripMenuItem_updatePlistFolder.Click += toolStripMenuItem_updatePlistFolder_click;

        m_toolStripMenuItem_deletePlistFolder = new ToolStripMenuItem();
        m_contextMenuStrip_plist.Items.Add(m_toolStripMenuItem_deletePlistFolder);
        m_toolStripMenuItem_deletePlistFolder.Text = UiLang.delete;
        m_toolStripMenuItem_deletePlistFolder.ForeColor = Color.White;
        m_toolStripMenuItem_deletePlistFolder.Click += toolStripMenuItem_deletePlistFolder_click;
      }
    }

    private void toolStripMenuItem_markPlistAsFinished_click(object sender, EventArgs e)
    {
      TreeNode node = treeView_playlist.SelectedNode;
      node.ForeColor = m_colorFinished;
      PlaylistFile file = node.Tag as PlaylistFile;
      file.timeWatched = 0;
      file.playState = PlaylistFile.enumPlayState.finished;
    }

    private void toolStripMenuItem_deletePlistFile_click(object sender, EventArgs e)
    {     
      if(!Archive.deleteFileDirectly)
      {
        FormPlistFileDeleteConfirm confirm = new FormPlistFileDeleteConfirm();
        if (confirm.ShowDialog(this) == DialogResult.No)
          return;
      }

      TreeNode node = treeView_playlist.SelectedNode;
      TreeNode folderNode = node.Parent;
      PlaylistFile file = node.Tag as PlaylistFile;
      string url = file.url;

      if(url == m_mainForm.m_strCurPlayingUrl && RpCore.IsPlaying())
      {
        m_mainForm.StopPlay();
      }

      try
      {
        File.Delete(url);
      }
      catch(System.IO.IOException)
      {
        MessageBox.Show(UiLang.msgAnotherProcessUsingTheFile);
        return;
      }

      if(!m_mainForm.deletePlayingPlistFile(file)) // not playing file
      {
        foreach (PlaylistFolder folder in Archive.playlist)
        {
          if(folder.playlistFiles.IndexOf(file) != -1)
          {
            folder.playlistFiles.Remove(file);
            break;
          }          
        }
      }

      foreach(TreeNode fileNode in folderNode.Nodes)
      {
        PlaylistFile plistFile = fileNode.Tag as PlaylistFile;
        TreeNode nextNode = fileNode.NextNode;
        if (plistFile.url == url)
        {
          folderNode.Nodes.Remove(fileNode);

          if (nextNode != null)
            treeView_playlist.SelectedNode = nextNode;
          break;
        }
      }
    }

    private void toolStripMenuItem_updatePlistFolder_click(object sender, EventArgs e)
    {
      TreeNode node = treeView_playlist.SelectedNode;
      PlaylistFolder folder = node.Tag as PlaylistFolder;
      AddOrUpdatePlaylist(folder.url, true);
    }


    private void toolStripMenuItem_deletePlistFolder_click(object sender, EventArgs e)
    {
      TreeNode node = treeView_playlist.SelectedNode;
      PlaylistFolder folder = node.Tag as PlaylistFolder;
      m_mainForm.deletePlayingPlistFolder(folder);
      Archive.playlist.Remove(folder);
      treeView_playlist.Nodes.Remove(node);
    }

    private void comboBox_repeat_SelectedIndexChanged(object sender, EventArgs e)
    {
      Archive.repeatPlayback = (Archive.enumRepeatPlayback)comboBox_repeat.SelectedIndex;
    }

    private void comboBox_sort_SelectedIndexChanged(object sender, EventArgs e)
    {
      Archive.sortBy = (Archive.enumSortBy)comboBox_sort.SelectedIndex;
      SortPlist();
    }
  }

  public class CustomToolStripProfessionalRendererPlist : ToolStripProfessionalRenderer
  {
    public CustomToolStripProfessionalRendererPlist() : base(new CustomProfessionalColorTablePlist()) { }
  }

  public class CustomProfessionalColorTablePlist : ProfessionalColorTable
  {
    private Color m_color = Color.LightSlateGray;
    private Color m_backColor = Color.SlateGray;
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
