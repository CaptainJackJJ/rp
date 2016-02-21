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
  public partial class FormInfoMore : Form
  {
    private InfoSectionUI m_infoSectionTorrentUI;
    private InfoLocalXmlHandler m_infoLocalXmlHandler;
    private InfoUpdater m_updaterInfo;
    private MainForm m_mainForm;

    public FormInfoMore(MainForm mForm)
    {
      m_mainForm = mForm;

      InitializeComponent();

      m_infoLocalXmlHandler = new InfoLocalXmlHandler();
      m_infoLocalXmlHandler.Load(MainForm.m_tempPath + "\\" + GlobalConstants.Common.strInfoMoreXmlLocalName);
      m_infoSectionTorrentUI = new InfoSectionUI(this, m_infoLocalXmlHandler);
    }

    private void FormInfoMore_Shown(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");

      m_infoSectionTorrentUI.ShowSection(true);

      m_updaterInfo = new InfoUpdater(m_mainForm, true, m_infoLocalXmlHandler);
      m_updaterInfo.ThreadStart();
    }

    delegate void InfoUpdateNoticeDel(string strNotice);
    public void InfoUpdateNotice(string strNotice)
    {
      if (this.InvokeRequired)
      {
        InfoUpdateNoticeDel del = new InfoUpdateNoticeDel(InfoUpdateNotice);
        this.Invoke(del, strNotice);
      }
      else
      {
        label_InfoUpdateNotice.Text = strNotice;
        if (strNotice == "")
        {
          m_infoSectionTorrentUI.FreshItems();
          FormNotice f = new FormNotice("更多电影资源已更新完毕");
          f.ShowDialog();
        }
      }
    }

    private void label_Min_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void label_Min_MouseEnter(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
    }

    private void label_Min_MouseLeave(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
    }

    private void FormInfoMore_FormClosing(object sender, FormClosingEventArgs e)
    {
      m_updaterInfo.ThreadStop();
    }
  }
}
