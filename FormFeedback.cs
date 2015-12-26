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
  public partial class FormFeedback : Form
  {
    public FormFeedback()
    {
      InitializeComponent();
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      }
      catch { }
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      this.Close();
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

    private void FormFeedback_Shown(object sender, EventArgs e)
    {
      if (Archive.lang == "English")
      {
        label_guide.Text = "Scan WeChat to feedback please.";
      }
      else
      {
        label_guide.Text = "亲，扫我微信进行反馈！";
      }
    }
  }
}
