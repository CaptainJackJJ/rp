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
    
    public FormPlaylist(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();
      ConfigByArchive();
      SetUiLange();
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

    private void FormPlaylist_MouseUp(object sender, MouseEventArgs e)
    {
      m_bLeftEdgeMouseDown = false;
    }
  }
}
