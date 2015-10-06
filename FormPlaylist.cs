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
    public FormPlaylist(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();
    }

    public void SetAllUiLange()
    {
      SetUiLange();
    }

    private void SetUiLange()
    {
    }
  }
}
