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
  public partial class FormNoticeUseQuickLook : Form
  {
    public FormNoticeUseQuickLook()
    {
      InitializeComponent();
    }

    private void button_ok_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
