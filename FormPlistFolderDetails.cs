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
  public partial class FormPlistFolderDetails : Form
  {
    public FormPlistFolderDetails()
    {
      InitializeComponent();
      SetUiLange();
    }

    public void ShowForm(string creationTime, string url)
    {
      label_creationTimeShow.Text = creationTime;
      textBox_url.Text = url;
      this.Show();
    }

    public void SetAllUiLange()
    {
      SetUiLange();
    }

    private void SetUiLange()
    {
      label_creationTime.Text = UiLang.labelDetailsCreationTime;
      label_url.Text = UiLang.labelDetailsUrl;
    }

    private void FormPlistFileDetails_MouseLeave(object sender, EventArgs e)
    {
      //this.Hide();
    }
  }
}
