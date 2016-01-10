using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using CoreWrapper;
using System.Xml;

namespace RPlayer
{
  class Updater
  {
    private MainForm m_mainForm;
    private Thread m_thread;
    private bool m_bStopThread;
    private WebClient m_SetupSelfInfoDownloader;
    private WebClient m_SetupSelfDownloader;
    static readonly private string m_strSetupSelfInfoXmlName = "setupSelfInfo.xml";
    static readonly private string m_strSetupSelfInfoRemoteUrl = "http://downloads.sourceforge.net/project/piraterabbitplayer/" + m_strSetupSelfInfoXmlName;
    private string m_strDownloadedSetupSelfInfoUrl;
    static readonly private string m_strSetupSelfName = "RPlayerSetupSelf.exe";
    private string m_strDownloadedSetupSelfUrl;
    private bool m_bDownloadCompleted;
    private string m_strRemoteSetupSelfVerison;
    private string m_strDownloadedVersion;

    public Updater(MainForm mainForm)
    {
      m_mainForm = mainForm;
      m_bStopThread = m_bDownloadCompleted = false;
      m_strRemoteSetupSelfVerison = m_strDownloadedVersion = "";

      m_SetupSelfInfoDownloader = new WebClient();
      m_SetupSelfInfoDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);
      m_SetupSelfInfoDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(SetupSelfInfoDownloadCompeleted);
      m_SetupSelfDownloader = new WebClient();
      m_SetupSelfDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);
      m_SetupSelfDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(SetupSelfDownloadCompeleted);

      m_strDownloadedSetupSelfInfoUrl = m_mainForm.m_tempPath + "\\" + m_strSetupSelfInfoXmlName;
      m_strDownloadedSetupSelfUrl = m_mainForm.m_tempPath + "\\" + m_strSetupSelfName;
    }

    private void GetRemoteSetupSelfInfo(out string strRemoteSetupSelfVerison, out string strUrl)
    {
      strRemoteSetupSelfVerison = strUrl = "";

      XmlDocument xml = new XmlDocument();
      try
      {
        xml.Load(m_strDownloadedSetupSelfInfoUrl);
      }
      catch(Exception e)
      {
        Core.WriteLog(Core.ELogType.error, "Load setupSelfInfo xml fail: " + e.ToString());
        return;
      }

      XmlNode node = xml.SelectSingleNode("/setupSelfInfo/setup");
      if(node != null)
      {
        strUrl = node.InnerText;
        strRemoteSetupSelfVerison = node.Attributes["verison"].Value;
        return;
      }

      Core.WriteLog(Core.ELogType.error, "read SetupSelfInfo xml fail");
    }

    private void SetupSelfInfoDownloadCompeleted(object sender,AsyncCompletedEventArgs e)
    {
      if (e.Cancelled)
      {
        m_bDownloadCompleted = true;
        return;
      }
      
      string strRemoteSetupUrl = "";
      GetRemoteSetupSelfInfo(out m_strRemoteSetupSelfVerison, out strRemoteSetupUrl);
      if(m_strRemoteSetupSelfVerison == "" || strRemoteSetupUrl == "")
      {
        Core.WriteLog(Core.ELogType.error, "SetupSelf verison or url is empty");
        return;
      }

      if (IsNewVersion(m_strRemoteSetupSelfVerison, m_mainForm.m_strAppVersion) &&
        (m_strDownloadedVersion == "" || IsNewVersion(m_strRemoteSetupSelfVerison, m_strDownloadedVersion)))
      {
        try
        {
          File.Delete(m_strDownloadedSetupSelfUrl);
        }
        catch (Exception ex)
        {
          Core.WriteLog(Core.ELogType.error, "Delete setupSelf fail: " + ex.ToString());
          m_bDownloadCompleted = true;
          return;
        }

        m_strDownloadedVersion = "";
        AppShare.SetGetDownloadedSetupSelfVersion(m_mainForm.m_tempPath, true, ref m_strDownloadedVersion);

        Core.WriteLog(Core.ELogType.notice, "Download setupSelf");
        try
        {
          m_SetupSelfDownloader.DownloadFileAsync(new Uri(strRemoteSetupUrl), m_strDownloadedSetupSelfUrl);
        }
        catch (Exception exc)
        {
          Core.WriteLog(Core.ELogType.error, "Download setupSelf fail: " + exc.ToString());
          m_bDownloadCompleted = true;
          return;
        }
      }
      else
        m_bDownloadCompleted = true;
    }

    private void SetupSelfDownloadCompeleted(object sender, AsyncCompletedEventArgs e)
    {
      if (e.Cancelled)
      {
        m_bDownloadCompleted = true;
        return;
      }

      AppShare.SetGetDownloadedSetupSelfVersion(m_mainForm.m_tempPath, true, ref m_strRemoteSetupSelfVerison);
      m_bDownloadCompleted = true;
    }

    public bool IsNewVersion(string strCompared,string strCompareWith)
    {
      if (strCompared == "" || strCompareWith == "")
        MessageBox.Show("IsNewVersion get wrong agru");

      string[] strAarryCompared = strCompared.Split('.');
      string[] strAarryCompareWith = strCompareWith.Split('.');
      uint nIndex = 0;
      foreach(string strComparedItem in strAarryCompared)
      {
        if(Convert.ToUInt32(strComparedItem) > Convert.ToUInt32(strAarryCompareWith[nIndex++]))
        {
          return true;
        }
      }
      return false;
    }

    private void ThreadProcess()
    {      
      AppShare.SetGetDownloadedSetupSelfVersion(m_mainForm.m_tempPath, false, ref m_strDownloadedVersion);

      if (m_mainForm.m_strAppVersion == "")
        MessageBox.Show("AppVersion is empty");

      // Launch setupSelf.
      if(m_strDownloadedVersion != "" && IsNewVersion(m_strDownloadedVersion,m_mainForm.m_strAppVersion))
      {
        Core.WriteLog(Core.ELogType.notice, "Launch setupSelf");

        FormUpdateNoticy f = new FormUpdateNoticy(m_strDownloadedVersion);
        f.ShowDialog();

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = m_strDownloadedSetupSelfUrl;
        startInfo.Arguments = "/VERYSILENT /SUPPRESSMSGBOXES /NORESTART";
        try
        {
          Process.Start(startInfo);

          // This will cause download again when run app next time if launch setup failed.
          m_strDownloadedVersion = "";
          AppShare.SetGetDownloadedSetupSelfVersion(m_mainForm.m_tempPath, true, ref m_strDownloadedVersion);
        }
        catch(Exception e)
        {
          Core.WriteLog(Core.ELogType.error, "lauch setupSelf fail: " + e.ToString());
        }
        return;
      }

      bool bDownloadRmoteSetupInfo = true;
      ulong nSleepTimes = 0;
      const ulong nSleepMaxTimes = 10 * 60 * 60; // one hour
      while(!m_bStopThread)
      {
        if(bDownloadRmoteSetupInfo)
        {
          Core.WriteLog(Core.ELogType.notice, "Download setupSelfInfo xml");

          try
          {
            File.Delete(m_strDownloadedSetupSelfInfoUrl);
          }
          catch (Exception e)
          {
            Core.WriteLog(Core.ELogType.error, "Delete setupSelfInfo xml fail: " + e.ToString());
            continue ;
          }
          
          m_bDownloadCompleted = false;

          try
          {
            m_SetupSelfInfoDownloader.DownloadFileAsync(new Uri(m_strSetupSelfInfoRemoteUrl), m_strDownloadedSetupSelfInfoUrl);
          }
          catch(Exception e)
          {
            Core.WriteLog(Core.ELogType.error, "Download setupSelfInfo xml fail: " + e.ToString());
            continue;
          }

          while (!m_bDownloadCompleted)
          {
            Thread.Sleep(100);
          }

          bDownloadRmoteSetupInfo = false;
          continue;
        }

        Thread.Sleep(100);
        if (++nSleepTimes > nSleepMaxTimes)
        {
          bDownloadRmoteSetupInfo = true;
          nSleepTimes = 0;
        }
      }
    }

    public void Start()
    {
      m_bStopThread = false;
      m_thread = new Thread(ThreadProcess);
      m_thread.Start();
    }

    public void Stop()
    {
      m_SetupSelfDownloader.CancelAsync();
      m_SetupSelfInfoDownloader.CancelAsync();
      m_bDownloadCompleted = true;
      m_bStopThread = true;
      if(m_thread.ThreadState != System.Threading.ThreadState.Unstarted)
        m_thread.Join();
    }
  }
}
