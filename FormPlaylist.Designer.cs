namespace RPlayer
{
  partial class FormPlaylist
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "av2.mkv                                                                          " +
                "                "}, -1, System.Drawing.Color.DodgerBlue, System.Drawing.Color.DimGray, null);
      System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "av3.iso"}, -1, System.Drawing.Color.YellowGreen, System.Drawing.Color.DimGray, null);
      this.label_TopEdge = new System.Windows.Forms.Label();
      this.label_LeftEdge = new System.Windows.Forms.Label();
      this.label_BottomEdge = new System.Windows.Forms.Label();
      this.button_playlist = new System.Windows.Forms.Button();
      this.button_histroy = new System.Windows.Forms.Button();
      this.comboBox_repeat = new System.Windows.Forms.ComboBox();
      this.label_repeat = new System.Windows.Forms.Label();
      this.label_sortBy = new System.Windows.Forms.Label();
      this.comboBox_sort = new System.Windows.Forms.ComboBox();
      this.listView_histroy = new System.Windows.Forms.ListView();
      this.treeView_playlist = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // label_TopEdge
      // 
      this.label_TopEdge.BackColor = System.Drawing.Color.Gray;
      this.label_TopEdge.Cursor = System.Windows.Forms.Cursors.Default;
      this.label_TopEdge.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_TopEdge.Location = new System.Drawing.Point(0, 0);
      this.label_TopEdge.Name = "label_TopEdge";
      this.label_TopEdge.Size = new System.Drawing.Size(173, 1);
      this.label_TopEdge.TabIndex = 30;
      // 
      // label_LeftEdge
      // 
      this.label_LeftEdge.BackColor = System.Drawing.Color.Gray;
      this.label_LeftEdge.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.label_LeftEdge.Dock = System.Windows.Forms.DockStyle.Left;
      this.label_LeftEdge.Location = new System.Drawing.Point(0, 1);
      this.label_LeftEdge.Name = "label_LeftEdge";
      this.label_LeftEdge.Size = new System.Drawing.Size(1, 453);
      this.label_LeftEdge.TabIndex = 31;
      // 
      // label_BottomEdge
      // 
      this.label_BottomEdge.BackColor = System.Drawing.Color.Gray;
      this.label_BottomEdge.Cursor = System.Windows.Forms.Cursors.Default;
      this.label_BottomEdge.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.label_BottomEdge.Location = new System.Drawing.Point(1, 453);
      this.label_BottomEdge.Name = "label_BottomEdge";
      this.label_BottomEdge.Size = new System.Drawing.Size(172, 1);
      this.label_BottomEdge.TabIndex = 32;
      // 
      // button_playlist
      // 
      this.button_playlist.BackColor = System.Drawing.Color.DodgerBlue;
      this.button_playlist.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_playlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_playlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_playlist.ForeColor = System.Drawing.Color.White;
      this.button_playlist.Location = new System.Drawing.Point(10, 10);
      this.button_playlist.Name = "button_playlist";
      this.button_playlist.Size = new System.Drawing.Size(75, 23);
      this.button_playlist.TabIndex = 33;
      this.button_playlist.Text = "Playlist";
      this.button_playlist.UseVisualStyleBackColor = false;
      this.button_playlist.Click += new System.EventHandler(this.button_playlist_Click);
      // 
      // button_histroy
      // 
      this.button_histroy.BackColor = System.Drawing.Color.DimGray;
      this.button_histroy.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
      this.button_histroy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.button_histroy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_histroy.ForeColor = System.Drawing.Color.White;
      this.button_histroy.Location = new System.Drawing.Point(84, 10);
      this.button_histroy.Name = "button_histroy";
      this.button_histroy.Size = new System.Drawing.Size(75, 23);
      this.button_histroy.TabIndex = 33;
      this.button_histroy.Text = "histroy";
      this.button_histroy.UseVisualStyleBackColor = false;
      this.button_histroy.Click += new System.EventHandler(this.button_histroy_Click);
      // 
      // comboBox_repeat
      // 
      this.comboBox_repeat.BackColor = System.Drawing.Color.DimGray;
      this.comboBox_repeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox_repeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox_repeat.ForeColor = System.Drawing.Color.White;
      this.comboBox_repeat.FormattingEnabled = true;
      this.comboBox_repeat.Location = new System.Drawing.Point(63, 403);
      this.comboBox_repeat.Name = "comboBox_repeat";
      this.comboBox_repeat.Size = new System.Drawing.Size(96, 20);
      this.comboBox_repeat.TabIndex = 35;
      // 
      // label_repeat
      // 
      this.label_repeat.AutoSize = true;
      this.label_repeat.BackColor = System.Drawing.Color.Transparent;
      this.label_repeat.ForeColor = System.Drawing.Color.White;
      this.label_repeat.Location = new System.Drawing.Point(10, 406);
      this.label_repeat.Name = "label_repeat";
      this.label_repeat.Size = new System.Drawing.Size(41, 12);
      this.label_repeat.TabIndex = 34;
      this.label_repeat.Text = "Repeat";
      // 
      // label_sortBy
      // 
      this.label_sortBy.AutoSize = true;
      this.label_sortBy.BackColor = System.Drawing.Color.Transparent;
      this.label_sortBy.ForeColor = System.Drawing.Color.White;
      this.label_sortBy.Location = new System.Drawing.Point(10, 432);
      this.label_sortBy.Name = "label_sortBy";
      this.label_sortBy.Size = new System.Drawing.Size(47, 12);
      this.label_sortBy.TabIndex = 34;
      this.label_sortBy.Text = "Sort By";
      // 
      // comboBox_sort
      // 
      this.comboBox_sort.BackColor = System.Drawing.Color.DimGray;
      this.comboBox_sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox_sort.ForeColor = System.Drawing.Color.White;
      this.comboBox_sort.FormattingEnabled = true;
      this.comboBox_sort.Location = new System.Drawing.Point(63, 429);
      this.comboBox_sort.Name = "comboBox_sort";
      this.comboBox_sort.Size = new System.Drawing.Size(96, 20);
      this.comboBox_sort.TabIndex = 35;
      // 
      // listView_histroy
      // 
      this.listView_histroy.BackColor = System.Drawing.Color.DimGray;
      this.listView_histroy.ForeColor = System.Drawing.Color.White;
      this.listView_histroy.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8});
      this.listView_histroy.Location = new System.Drawing.Point(10, 33);
      this.listView_histroy.Name = "listView_histroy";
      this.listView_histroy.Size = new System.Drawing.Size(149, 362);
      this.listView_histroy.TabIndex = 37;
      this.listView_histroy.UseCompatibleStateImageBehavior = false;
      this.listView_histroy.View = System.Windows.Forms.View.List;
      this.listView_histroy.DoubleClick += new System.EventHandler(this.listView_histroy_DoubleClick);
      this.listView_histroy.MouseLeave += new System.EventHandler(this.listView_histroy_MouseLeave);
      this.listView_histroy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_histroy_MouseMove);
      // 
      // treeView_playlist
      // 
      this.treeView_playlist.AllowDrop = true;
      this.treeView_playlist.BackColor = System.Drawing.Color.DimGray;
      this.treeView_playlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.treeView_playlist.ForeColor = System.Drawing.Color.White;
      this.treeView_playlist.LineColor = System.Drawing.Color.White;
      this.treeView_playlist.Location = new System.Drawing.Point(10, 33);
      this.treeView_playlist.Name = "treeView_playlist";
      this.treeView_playlist.ShowLines = false;
      this.treeView_playlist.ShowPlusMinus = false;
      this.treeView_playlist.Size = new System.Drawing.Size(149, 362);
      this.treeView_playlist.TabIndex = 0;
      this.treeView_playlist.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_playlist_AfterCollapse);
      this.treeView_playlist.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_playlist_AfterExpand);
      this.treeView_playlist.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeView_playlist_NodeMouseHover);
      this.treeView_playlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_playlist_DragDrop);
      this.treeView_playlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_playlist_DragEnter);
      this.treeView_playlist.DoubleClick += new System.EventHandler(this.treeView_playlist_DoubleClick);
      this.treeView_playlist.MouseLeave += new System.EventHandler(this.treeView_playlist_MouseLeave);
      this.treeView_playlist.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView_playlist_MouseMove);
      // 
      // FormPlaylist
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DimGray;
      this.ClientSize = new System.Drawing.Size(173, 454);
      this.Controls.Add(this.treeView_playlist);
      this.Controls.Add(this.listView_histroy);
      this.Controls.Add(this.comboBox_sort);
      this.Controls.Add(this.label_sortBy);
      this.Controls.Add(this.comboBox_repeat);
      this.Controls.Add(this.label_repeat);
      this.Controls.Add(this.button_histroy);
      this.Controls.Add(this.button_playlist);
      this.Controls.Add(this.label_BottomEdge);
      this.Controls.Add(this.label_LeftEdge);
      this.Controls.Add(this.label_TopEdge);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FormPlaylist";
      this.Opacity = 0.8D;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FormPlaylist";
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormPlaylist_MouseDown);
      this.MouseLeave += new System.EventHandler(this.FormPlaylist_MouseLeave);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPlaylist_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormPlaylist_MouseUp);
      this.Resize += new System.EventHandler(this.FormPlaylist_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label_TopEdge;
    private System.Windows.Forms.Label label_LeftEdge;
    private System.Windows.Forms.Label label_BottomEdge;
    private System.Windows.Forms.Button button_playlist;
    private System.Windows.Forms.Button button_histroy;
    private System.Windows.Forms.ComboBox comboBox_repeat;
    private System.Windows.Forms.Label label_repeat;
    private System.Windows.Forms.Label label_sortBy;
    private System.Windows.Forms.ComboBox comboBox_sort;
    private System.Windows.Forms.ListView listView_histroy;
    private System.Windows.Forms.TreeView treeView_playlist;
  }
}