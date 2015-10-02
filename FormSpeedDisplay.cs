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
  public partial class FormSpeedDisplay : Form
  {
    public FormSpeedDisplay()
    {
      InitializeComponent();
    }

    public void SetString(string str)
    {
      label_speed.Text = str;
    }
  }
}
