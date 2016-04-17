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
  public partial class FormAskShare : Form
  {
    private MainForm m_formMain;
    static private bool m_bInstanced = false;
    public FormAskShare(MainForm formMain)
    {
      if (m_bInstanced)
        return;
      m_bInstanced = true;

      m_formMain = formMain;
      InitializeComponent();
    }

    private void button_share_Click(object sender, EventArgs e)
    {
      m_formMain.LaunchPRRes("share");
      this.Close();
    }

    private void FormAskShare_FormClosing(object sender, FormClosingEventArgs e)
    {
      m_bInstanced = false;
    }

    private void FormAskShare_Load(object sender, EventArgs e)
    {

    }
  }
}
