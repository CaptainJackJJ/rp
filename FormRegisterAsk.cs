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
  public partial class FormRegisterAsk : Form
  {
    private MainForm m_mainForm;

    public string url;
    public FormRegisterAsk(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();
      if (Archive.lang == "中文")
      {
        button_allow.Text = "好的";
        button_notAllow.Text = "稍后";
        richTextBox_description.Text = @"亲，将海盗兔影音设为默认播放器吧！设置后双击视频文件即可自动播放。

或者您可稍后在本软件的“设置->一般”中选择“设置为系统默认播放器”。

某些安全软件可能会再次征求您的许可,请选择“更多->允许程序所有操作”";
      }
    }

    private void button_allow_Click(object sender, EventArgs e)
    {
      m_mainForm.AssociateExtension();

      this.Close();
    }

    private void button_notAllow_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
