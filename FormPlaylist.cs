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
    private const int m_nMinWidth = 170;
    private FormHistroyDetails m_formHistroyDetails;
    private FormPlistFileDetails m_formPlistFileDetails;
    private ListViewItem m_viewItemFocusingHistroy;
    private ContextMenuStrip m_contextMenuStrip_histroy;
    private ToolStripMenuItem m_toolStripMenuItem_histroyDelete;
    private bool m_bFirstShowHistroy = true;
    private bool m_bFirstShowPlaylist = true;
    
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
      InitContextMenuStrip();
    }

    private void InitContextMenuStrip()
    {
      m_contextMenuStrip_histroy = new ContextMenuStrip();
      m_contextMenuStrip_histroy.BackColor = Archive.colorContextMenu;
      m_contextMenuStrip_histroy.ForeColor = Color.White;
      m_contextMenuStrip_histroy.Renderer = new CustomToolStripProfessionalRenderer();
      listView_histroy.ContextMenuStrip = m_contextMenuStrip_histroy;

      m_toolStripMenuItem_histroyDelete = new ToolStripMenuItem();
      m_contextMenuStrip_histroy.Items.Add(m_toolStripMenuItem_histroyDelete);
      m_toolStripMenuItem_histroyDelete.Text = UiLang.delete;
      m_toolStripMenuItem_histroyDelete.ForeColor = Color.White;
      m_toolStripMenuItem_histroyDelete.Click += toolStripMenuItem_histroyDelete_click;
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
        }
        UpdateListViewHistroy();
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

    private void ConfigByArchive()
    {
      this.Size = new Size(Archive.formPlistWidth, Archive.formPlistHeight);
      SwitchListView(Archive.selectedPListBtn);
    }

    private void UpdatePlayList(bool bAllFloder, string folderUrl)
    {
      List<PlaylistFolder> deleteFolders = new List<PlaylistFolder>();
      foreach(PlaylistFolder folder in Archive.playlist)
      {
        if(!bAllFloder)
        {
          if (folder.url != folderUrl)
            continue;
        }

        if (!Directory.Exists(folder.url))
        {
          if(bAllFloder)
          {
            deleteFolders.Add(folder);
            continue;
          }
          else
          {
            MessageBox.Show(UiLang.pathNotFound + folder.url);
            return;
          }
        }
         
        string strFilters = "*.m4v|*.3g2|*.3gp|*.nsv|*.tp|*.ts|*.ty|*.strm|*.pls|*.rm|*.rmvb|*.m3u|*.m3u8|*.ifo|*.mov|*.qt|*.divx|*.xvid|*.bivx|*.vob|*.nrg|*.img|*.iso|*.pva|*.wmv|*.asf|*.asx|*.ogm|*.m2v|*.avi|*.bin|*.dat|*.mpg|*.mpeg|*.mp4|*.mkv|*.mk3d|*.avc|*.vp3|*.svq3|*.nuv|*.viv|*.dv|*.fli|*.flv|*.rar|*.001|*.wpl|*.zip|*.vdr|*.dvr-ms|*.xsp|*.mts|*.m2t|*.m2ts|*.evo|*.ogv|*.sdp|*.avs|*.rec|*.url|*.pxml|*.vc1|*.h264|*.rcv|*.rss|*.mpls|*.webm|*.bdmv|*.wtv";
        string[] strFilesInCurrentDirectory
          = strFilters.Split('|').SelectMany(filter =>
            Directory.GetFiles(folder.url, filter, SearchOption.TopDirectoryOnly)
            ).ToArray();

        List<PlaylistFile> deleteFiles = new List<PlaylistFile>();
        List<string> addFiles = strFilesInCurrentDirectory.ToList();

        foreach (PlaylistFile file in folder.playlistFiles)
        {
          int index = addFiles.IndexOf(file.url);
          if(index != -1)
          {
            addFiles.RemoveAt(index);
          }
          else
          {
            deleteFiles.Add(file);
          }
        }

        foreach(PlaylistFile file in deleteFiles)
        {
          folder.playlistFiles.Remove(file);
        }

        if (addFiles.Count > 0)
          AddPlaylist(folder.url, addFiles);

        if (!bAllFloder)
        {
          UpdatePlayListView(false, folderUrl);
          break;
        }
      }
      if (bAllFloder)
      {
        foreach (PlaylistFolder folder in deleteFolders)
        {
          Archive.playlist.Remove(folder);
        }

        UpdatePlayListView(true, "");
      }
    }

    public PlaylistFolder AddPlaylist(string folderUrl,List<string> addFiles)
    {
      PlaylistFolder folder = null;
      foreach (PlaylistFolder folderItem in Archive.playlist)
      {
        if (folderItem.url == folderUrl) 
        {
          folder = folderItem;
          break;
        }
      }

      if (folder == null)
      {
        folder = new PlaylistFolder();
        folder.url = folderUrl;        
        DirectoryInfo dir = new DirectoryInfo(folderUrl);
        folder.folderName = dir.Name;
        folder.expand = true;
        folder.creationTime = dir.CreationTime.ToString();
        folder.playlistFiles = new List<PlaylistFile>();
        Archive.playlist.Add(folder);

        Archive.playlist.Sort(delegate(PlaylistFolder folder1, PlaylistFolder folder2)
        {
          switch (Archive.sortBy)
          {
            case Archive.enumSortBy.creationTime:
              return folder1.creationTime.CompareTo(folder2.creationTime);
            case Archive.enumSortBy.name:
              return folder1.folderName.CompareTo(folder2.folderName);
            default:
              return 0;
          }
        });
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
        folder.playlistFiles.Add(file);
      }
      folder.playlistFiles.Sort(delegate(PlaylistFile file1, PlaylistFile file2)
      {
        switch (Archive.sortBy)
        {
          case Archive.enumSortBy.creationTime:
            return file1.creationTime.CompareTo(file2.creationTime);
          case Archive.enumSortBy.name:
            return file1.fileName.CompareTo(file2.fileName);
          default:
            return 0;
        }
      });
      return folder;
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
              fileNode.ForeColor = Color.RosyBrown;
              break;
            case PlaylistFile.enumPlayState.played:
              fileNode.ForeColor = Color.DodgerBlue;
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
          listItem.ForeColor = Color.DodgerBlue;
        else
          listItem.ForeColor = Color.RosyBrown;
        listView_histroy.Items.Add(listItem);
      }
    }

    private void SwitchListView(Archive.enumSelectedPListBtn selectedBtn)
    {
      switch (selectedBtn)
      {
        case Archive.enumSelectedPListBtn.playlist:
          button_histroy.BackColor = Color.DimGray;
          button_playlist.BackColor = Color.DodgerBlue;
          listView_histroy.Hide();
          treeView_playlist.Show();
          Archive.selectedPListBtn = Archive.enumSelectedPListBtn.playlist;
          if (m_bFirstShowPlaylist)
          {
            if (Archive.updatePlistAfterLaunch)
              UpdatePlayList(true, "");
            else
              UpdatePlayListView(true, "");
            m_bFirstShowPlaylist = false;
          }
          break;
        case Archive.enumSelectedPListBtn.histroy:
          button_histroy.BackColor = Color.DodgerBlue;
          button_playlist.BackColor = Color.DimGray;
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
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByCreatedTime);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByFileName);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByDuration);
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
      if (viewItem != null)
      {
        if (m_viewItemFocusingHistroy == viewItem 
          || listView_histroy.SelectedItems.Count > 1)
          return;
        m_viewItemFocusingHistroy = viewItem;
        HistroyItem item = viewItem.Tag as HistroyItem;

        m_formHistroyDetails.Location = view.PointToScreen(new Point(e.X + 3, e.Y + 3));
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
      else
      {
        m_viewItemFocusingHistroy = null;
        m_formHistroyDetails.Hide();
      }
    }

    private void listView_histroy_MouseLeave(object sender, EventArgs e)
    {
      m_viewItemFocusingHistroy = null;
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
      }
    }

    private void treeView_playlist_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
    {
      TreeNode node = e.Node;
      if(node.Parent == null) // folder node
      {
        m_formPlistFileDetails.Hide();
      }
      else
      {
        PlaylistFile file = node.Tag as PlaylistFile;

        m_formPlistFileDetails.Location = new Point(Control.MousePosition.X + 3, Control.MousePosition.Y + 3);
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
    }
  }
}
