using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.Xml;

namespace RPlayer
{
  public partial class FormUpdateNoticy : Form
  {
    public string url;
    public FormUpdateNoticy(string verison)
    {
      InitializeComponent();
      if (Archive.lang == "中文")
      {
        button_ok.Text = "好的";
        richTextBox_notice.Text = "感谢您使用海盗兔影音。软件已升级至最新版V" + verison + "，几秒钟后将会自动重启。重启后点击左上角的软件名即可查看升级的详细内容";
      }
      else
      {
        button_ok.Text = "OK";
        richTextBox_notice.Text = "Player updated to V" + verison + ", and is gonna restart after a few seconds.";
      }
    }

    private void button_ok_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
