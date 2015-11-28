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
    private MainForm m_mainForm;

    public FormSpeedDisplay(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (m_mainForm.HandleCmdKey(keyData))
        return true;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public void SetString(string str)
    {
      label_speed.Text = str;
    }
  }
}
