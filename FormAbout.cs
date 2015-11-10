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
  public partial class FormAbout : Form
  {
    public FormAbout()
    {
      InitializeComponent();
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      }
      catch { }
    }

    public void ShowForm(string version)
    {
      if (Archive.lang == "English")
      {
        label_logo.Text = "RabbitPlayer";
        label_version.Text = "Version:";
        label_webSite.Text = "WebSite:";
      }
      else
      {
        label_logo.Text = "兔子影音";
        label_version.Text = "版本号:";
        label_webSite.Text = "官方网站:";
      }
      label_versionShow.Text = version;
      this.Show();
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void label_webSiteShow_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("http://rabbitplayer.com/");
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
      }
      catch { }
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      }
      catch { }
    }
  }
}
