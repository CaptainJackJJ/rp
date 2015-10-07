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
  public partial class FormHistroyDetails : Form
  {
    public FormHistroyDetails()
    {
      InitializeComponent();
      SetUiLange();
    }

    public void ShowForm(string watchedTime,string duration, string url)
    {
      label_timeWatchedShow.Text = watchedTime;
      label_durationShow.Text = duration;
      textBox_url.Text = url;
      this.Show();
    }

    public void SetAllUiLange()
    {
      SetUiLange();
    }

    private void SetUiLange()
    {
      label_timeWatched.Text = UiLang.labelHistroyDetailsTimeWatched;
      label_duration.Text = UiLang.labelHistroyDetailsDuration;
      label_url.Text = UiLang.labelHistroyDetailsUrl;
    }
  }
}
