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
  public partial class FormPlistFileDetails : Form
  {
    public FormPlistFileDetails()
    {
      InitializeComponent();
      SetUiLange();
    }

    public void ShowForm(string watchedTime,string duration,string creationTime, string url)
    {
      label_timeWatchedShow.Text = watchedTime;
      label_durationShow.Text = duration;
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
      label_timeWatched.Text = UiLang.labelDetailsTimeWatched;
      label_duration.Text = UiLang.labelDetailsDuration;
      label_creationTime.Text = UiLang.labelDetailsCreationTime;
      label_url.Text = UiLang.labelDetailsUrl;
    }

    private void FormPlistFileDetails_MouseLeave(object sender, EventArgs e)
    {
      //this.Hide();
    }
  }
}
