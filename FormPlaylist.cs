using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    private ListViewItem m_viewItemFocusingHistroy;
    private ContextMenuStrip m_contextMenuStrip_histroy;
    private ToolStripMenuItem m_toolStripMenuItem_histroyDelete;
    
    public FormPlaylist(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();
      ConfigByArchive();
      SetUiLange();
      m_formHistroyDetails = new FormHistroyDetails();
      this.AddOwnedForm(m_formHistroyDetails);
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
      listView_playlist.Size = listViewSize;
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

      UpdateListView();
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
        listView_histroy.Items.Add(listItem);
      }
    }

    public void UpdateListView()
    {
      UpdateListViewHistroy();
    }

    private void SwitchListView(Archive.enumSelectedPListBtn selectedBtn)
    {
      switch (selectedBtn)
      {
        case Archive.enumSelectedPListBtn.playlist:
          button_histroy.BackColor = Color.DimGray;
          button_playlist.BackColor = Color.DodgerBlue;
          listView_histroy.Hide();
          listView_playlist.Show();
          Archive.selectedPListBtn = Archive.enumSelectedPListBtn.playlist;
          break;
        case Archive.enumSelectedPListBtn.histroy:
          button_histroy.BackColor = Color.DodgerBlue;
          button_playlist.BackColor = Color.DimGray;
          listView_histroy.Show();
          listView_playlist.Hide();
          Archive.selectedPListBtn = Archive.enumSelectedPListBtn.histroy;
          break;
      }
    }

    public void SetAllUiLange()
    {
      SetUiLange();
      m_formHistroyDetails.SetAllUiLange();
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
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByAddedTime);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByCreatedTime);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByFileName);
      comboBox_sort.Items.Add(UiLang.ComboBoxSortByFileSize);
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
        string strTimeWatched = UiLang.labelHistroyDetailsFinished;
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
        m_mainForm.SwitchFormMode(true);
        m_mainForm.StartPlay(item.url);
      }

    }
  }
}
