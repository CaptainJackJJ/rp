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
  public partial class FormBigThumb : Form
  {
    public FormBigThumb()
    {
      InitializeComponent();
    }

    public void ShowForm(string thumbUrl)
    {
      try
      {
        this.BackgroundImage = Image.FromFile(thumbUrl);
      }
      catch
      {
        this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\black.jpg");
      }
      this.Show();
    }
  }
}
