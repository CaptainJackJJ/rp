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
  public partial class FormPlistFileDeleteConfirm : Form
  {
    public FormPlistFileDeleteConfirm()
    {
      InitializeComponent();
    }

    private void button_yse_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Yes;
      this.Close();
    }

    private void button_no_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.No;
      this.Close();
    }

    private void button_deleteNoAsk_Click(object sender, EventArgs e)
    {
      Archive.deleteFileDirectly = true;
      this.DialogResult = DialogResult.Yes;
      this.Close();
    }
  }
}
