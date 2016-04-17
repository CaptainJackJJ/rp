using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace PRResource
{
  public partial class FormDownload : Form
  {
    Uri m_uri;
    WebClient m_Downloader;
    string m_strDLedUrl;

    public FormDownload(Uri Uri)
    {
      m_uri = Uri;

      InitializeComponent();
    }

    private void FormDownload_Load(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      textBoxFileName.Text = System.IO.Path.GetFileName(m_uri.LocalPath);
      m_strDLedUrl = FormMain.m_strDownloadedFolderUrl + "\\" + textBoxFileName.Text;

      m_Downloader = new WebClient();
      m_Downloader.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
      m_Downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompeleted);
      m_Downloader.DownloadProgressChanged += m_Downloader_DownloadProgressChanged;
      m_Downloader.DownloadFileAsync(m_uri, m_strDLedUrl);
    }

    void m_Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      if (label_progress.IsDisposed)
        return;
      label_progress.Text = "已下载： " + e.ProgressPercentage + "%";
    }

    private void DownloadCompeleted(object sender, AsyncCompletedEventArgs e)
    {
      if (e.Cancelled)
        return;

      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.FileName = m_strDLedUrl;
      try
      {
        Process.Start(startInfo);
      }
      catch (Exception ex)
      {
      }
      if (!this.IsDisposed)
        this.Close();
    }
    
    private void label_Close_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void label_Min_MouseEnter(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
    }

    private void label_Min_MouseLeave(object sender, EventArgs e)
    {
      label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
    }

    private void label_Min_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
    }

    private void FormDownload_FormClosing(object sender, FormClosingEventArgs e)
    {
      m_Downloader.CancelAsync();
    }
  }
}
