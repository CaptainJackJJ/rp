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

using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using OpenPop.Common.Logging;
using Message = OpenPop.Mime.Message;

namespace RPlayer
{
  class AppUpdater : ThreadEx
  {
    private MainForm m_mainForm;
    private WebClient m_SetupSelfInfoDownloader;
    private WebClient m_LanuchTimesDownloader;
    private WebClient m_AppUpdateTimesXmlDownloader;
    private string m_strDownloadedSetupSelfInfoUrl;
    static readonly private string m_strSetupSelfName = "RPlayerSetupSelf.exe";
    private string m_strDownloadedSetupSelfUrl;
    private string m_strRemoteSetupSelfVerison;
    private string m_strDownloadedVersion;
    private string m_strDlEmail,m_strDlCode;    
    private Thread m_DlSelfThread;
    private string m_strDlLaunchTimesXmlUrl;
    private string m_strDlAppUpdateTimesXmlUrl;
    
    public AppUpdater(MainForm mainForm)
    {
      m_mainForm = mainForm;
      m_bStopThread = false;
      m_strRemoteSetupSelfVerison = m_strDownloadedVersion = "";

      m_SetupSelfInfoDownloader = new WebClient();
      m_SetupSelfInfoDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);
      m_SetupSelfInfoDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(SetupSelfInfoDownloadCompeleted);
      m_LanuchTimesDownloader = new WebClient();
      m_LanuchTimesDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);
      m_AppUpdateTimesXmlDownloader = new WebClient();
      m_AppUpdateTimesXmlDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);   
  
      m_strDownloadedSetupSelfInfoUrl = MainForm.m_tempPath + "\\" + GlobalConstants.Common.strSetupSelfInfoXmlName;
      m_strDownloadedSetupSelfUrl = MainForm.m_tempPath + "\\" + m_strSetupSelfName;
      m_strDlLaunchTimesXmlUrl = MainForm.m_tempPath + "\\" + GlobalConstants.Common.strLaunchTimesXmlName;
      m_strDlAppUpdateTimesXmlUrl = MainForm.m_tempPath + "\\" + GlobalConstants.Common.strAppUpdateTimesXmlName;

      UpdateWebUrl();
    }

    public void UpdateWebUrl()
    {
      XmlDocument xml = new XmlDocument();
      try
      {
        xml.Load(m_strDownloadedSetupSelfInfoUrl);
      }
      catch (Exception e)
      {
        Core.WriteLog(Core.ELogType.error, "Load setupSelfInfo xml fail: " + e.ToString());
        return;
      }

      XmlNode node = xml.SelectSingleNode("/setupSelfInfo/dl1");
      if (node != null)
      {
        GlobalConstants.Common.strChinaDl1 = node.InnerText;
      }
      else
      {
        Core.WriteLog(Core.ELogType.error, "read SetupSelfInfo xml fail");
        return;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/dl2");
      if (node != null)
      {
        GlobalConstants.Common.strChinaDl2 = node.InnerText;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/dlOversea");
      if (node != null)
      {
        GlobalConstants.Common.strOverseaDl = node.InnerText;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/dlSub");
      if (node != null)
      {
        GlobalConstants.Common.strSubtitle = node.InnerText;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/onlineTv");
      if (node != null)
      {
        GlobalConstants.Common.strChinaOnline = node.InnerText;
      }
    }

    private void GetRemoteSetupSelfInfo(out string strRemoteSetupSelfVerison, out string strUrl, 
      out string strEmail, out string strCode)
    {
      strRemoteSetupSelfVerison = strUrl = strEmail = strCode = "";

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
      if (node != null)
      {
        strUrl = node.InnerText;
        strRemoteSetupSelfVerison = node.Attributes["verison"].Value;
      }
      else
      {
        Core.WriteLog(Core.ELogType.error, "read SetupSelfInfo xml fail");
        return;
      }

      node = xml.SelectSingleNode("/setupSelfInfo/ec");
      if (node != null)
      {
        strEmail = node.InnerText;
        strCode = node.Attributes["c"].Value;
      }
    }

    private void DlSetupSelfProcess()
    {      
      Pop3Client pop3Client = new Pop3Client();
      while (!m_bStopThread)
      {
        try
        {
          if (pop3Client.Connected)
            pop3Client.Disconnect();
          pop3Client.Connect("pop.qq.com", 995, true);
          pop3Client.Authenticate(m_strDlEmail + "@qq.com", m_strDlCode);
          int count = pop3Client.GetMessageCount();

          int success = 0;
          int fail = 0;
          for (int i = count; i >= 1; --i)
          {
            if (m_bStopThread)
              return;

            try
            {
              Message message = pop3Client.GetMessage(i);

              List<MessagePart> attachments = message.FindAllAttachments();
              foreach (MessagePart attachment in attachments)
              {
                if (attachment.FileName == "RPlayerSetupSelf.txt")
                {
                  // Now we want to save the attachment
                 FileInfo file = new FileInfo(m_strDownloadedSetupSelfUrl);

                  // Lets try to save to the file
                  try
                  {
                    attachment.Save(file);
                    AppShare.SetGetDownloadedSetupSelfVersion(MainForm.m_tempPath, true, ref m_strRemoteSetupSelfVerison);
                    DlAppUpdateTimesXml();
                    LauchSetupSelf();
                    return;
                  }
                  catch {}
                }
              }

              success++;
            }
            catch (Exception e)
            {
              fail++;
            }
          }
        }
        catch
        {
          continue;
        }
      }
    }

    private void DlSetupSelf()
    {
      m_DlSelfThread = new Thread(DlSetupSelfProcess);
      m_DlSelfThread.Start();
    }

    private void SetupSelfInfoDownloadCompeleted(object sender,AsyncCompletedEventArgs e)
    {
      if (e.Cancelled)
        return;
      
      string strRemoteSetupUrl = "";
      GetRemoteSetupSelfInfo(out m_strRemoteSetupSelfVerison, out strRemoteSetupUrl, out m_strDlEmail,out m_strDlCode);
      if(m_strRemoteSetupSelfVerison == "" || strRemoteSetupUrl == "")
      {
        Core.WriteLog(Core.ELogType.error, "SetupSelf verison or url is empty");
        return;
      }

      if (UtilsCommon.IsNewVersion(m_strRemoteSetupSelfVerison, m_mainForm.m_strAppVersion) &&
        (m_strDownloadedVersion == "" || UtilsCommon.IsNewVersion(m_strRemoteSetupSelfVerison, m_strDownloadedVersion)))
      {
        try
        {
          File.Delete(m_strDownloadedSetupSelfUrl);
        }
        catch (Exception ex)
        {
          Core.WriteLog(Core.ELogType.error, "Delete setupSelf fail: " + ex.ToString());
          return;
        }

        m_strDownloadedVersion = "";
        AppShare.SetGetDownloadedSetupSelfVersion(MainForm.m_tempPath, true, ref m_strDownloadedVersion);

        Core.WriteLog(Core.ELogType.notice, "Download setupSelf");
        try
        {
          DlSetupSelf();
        }
        catch (Exception exc)
        {
          Core.WriteLog(Core.ELogType.error, "Download setupSelf fail: " + exc.ToString());
          return;
        }
      }
    }

    private void DlLaunchTimesXml()
    {
      try
      {
        File.Delete(m_strDlLaunchTimesXmlUrl);
        Uri uri = new Uri(GlobalConstants.Common.strLaunchTimesRemoteUrl);
        m_LanuchTimesDownloader.DownloadFileAsync(uri, m_strDlLaunchTimesXmlUrl);
      }
      catch (Exception e)
      {
        Core.WriteLog(Core.ELogType.error, "DlLaunchTimesXml fail: " + e.ToString());
      }
    }

    private void DlAppUpdateTimesXml()
    {
      try
      {
        File.Delete(m_strDlAppUpdateTimesXmlUrl);
        Uri uri = new Uri(GlobalConstants.Common.strAppUpdateTimesRemoteUrl);
        m_AppUpdateTimesXmlDownloader.DownloadFileAsync(uri, m_strDlAppUpdateTimesXmlUrl);
      }
      catch (Exception e)
      {
        Core.WriteLog(Core.ELogType.error, "DlAppUpdateTimesXml fail: " + e.ToString());
      }
    }
    
    private bool LauchSetupSelf()
    {
      AppShare.SetGetDownloadedSetupSelfVersion(MainForm.m_tempPath, false, ref m_strDownloadedVersion);

      if (m_mainForm.m_strAppVersion == "")
        MessageBox.Show("AppVersion is empty");

      // Launch setupSelf.
      if (m_strDownloadedVersion != "" && UtilsCommon.IsNewVersion(m_strDownloadedVersion, m_mainForm.m_strAppVersion))
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
          AppShare.SetGetDownloadedSetupSelfVersion(MainForm.m_tempPath, true, ref m_strDownloadedVersion);
        }
        catch (Exception e)
        {
          Core.WriteLog(Core.ELogType.error, "lauch setupSelf fail: " + e.ToString());
          MessageBox.Show("自启动失败");
          return false;
        }
        return true;
      }
      return false;
    }

    protected override void ThreadProcess()
    {
      DlLaunchTimesXml();

      if (LauchSetupSelf())
        return;

      while(!m_bStopThread)
      {
        Core.WriteLog(Core.ELogType.notice, "Download setupSelfInfo xml");
        try
        {
          File.Delete(m_strDownloadedSetupSelfInfoUrl);

          Uri uri = new Uri(GlobalConstants.Common.strSetupSelfInfoRemoteUrl);
          m_SetupSelfInfoDownloader.DownloadFileAsync(uri, m_strDownloadedSetupSelfInfoUrl);
        }
        catch(Exception e)
        {
          Core.WriteLog(Core.ELogType.error, "Delete setupSelfInfo xml fail or Download setupSelfInfo xml fail: " + e.ToString());
          Thread.Sleep(1000 * 60);
          continue;
        }

        try
        {
          Thread.Sleep(1000 * 60 * 60);
        }catch (ThreadInterruptedException){}
      }
    }

    protected override void ThreadPrepStop()
    {
      //m_LanuchTimesDownloader.CancelAsync();
      if (m_DlSelfThread != null)
        m_DlSelfThread.Abort();
      m_SetupSelfInfoDownloader.CancelAsync();
    }
  }
}
