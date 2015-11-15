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
    private readonly string m_strRPUpdaterName = "RPUpdater";
    private readonly string m_strRPUpdaterExeName = "RPUpdater.exe";

    public string url;
    public FormRegisterAsk()
    {
      InitializeComponent();
      if (Archive.lang == "中文")
      {
        button_allow.Text = "允许";
        button_notAllow.Text = "不允许";
        textBox_description.Text = "尊敬的用户，为了能给您提供更好的服务，兔子影音的某些模块最好在开机时启动，在此征求您的许可。（某些安全软件可能会再次征求您的许可）";
      }
    }

    private void button_allow_Click(object sender, EventArgs e)
    {
      string strRPUpdaterPath = Application.StartupPath + "\\" + m_strRPUpdaterExeName;

      try
      {
        Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows")
            .OpenSubKey("CurrentVersion").OpenSubKey("Run", true).SetValue(m_strRPUpdaterName, strRPUpdaterPath);
      }
      catch
      {

      }
      this.Close();
    }

    private void button_notAllow_Click(object sender, EventArgs e)
    {
      AppShare.SetGetAllowAutoRunRPUdater(Application.StartupPath, true);

      this.Close();
    }
  }
}
