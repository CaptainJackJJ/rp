using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWrapper;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.Xml;
using System.Windows.Forms;

namespace RPlayer
{
  class InfoUpdater:ThreadEx
  {
    private MainForm m_mainForm;
    private WebClient m_InfoRemoteXmlDownloader;
    private WebClient m_ItemDownloader;
    string m_strDownloadedInfoRemoteXmlUrl;
    private bool m_bItemDownloadFinished;

    public InfoUpdater(MainForm mainForm)
    {
      m_mainForm = mainForm;
      m_strDownloadedInfoRemoteXmlUrl = MainForm.m_tempPath + "\\" + GlobalConstants.Common.strInfoXmlRemoteName;

      m_InfoRemoteXmlDownloader = new WebClient();
      m_InfoRemoteXmlDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);
      m_InfoRemoteXmlDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(InfoRemoteXmlDownloadCompeleted);

      m_ItemDownloader = new WebClient();
      m_ItemDownloader.Headers.Add("user-agent", m_mainForm.m_strAppVersion);
      m_ItemDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(ItemDownloadCompeleted);

      m_bItemDownloadFinished = false;
    }

    protected override void ThreadPrepStop() 
    {
      m_InfoRemoteXmlDownloader.CancelAsync();
      m_ItemDownloader.CancelAsync();
    }

    private void ItemDownloadCompeleted(object sender, AsyncCompletedEventArgs e)
    {
      m_bItemDownloadFinished = true;
    }

    private void InfoRemoteXmlDownloadCompeleted(object sender, AsyncCompletedEventArgs e)
    {
      if (e.Cancelled)
        return;

      XmlDocument xmlRemote = new XmlDocument();
      try
      {
        xmlRemote.Load(m_strDownloadedInfoRemoteXmlUrl);
      }
      catch(Exception ex)
      {
        Core.WriteLog(Core.ELogType.error, "InfoRemoteXmlDownloadCompeleted: " + ex.ToString());
        return;
      }
      XmlElement rootElem = null;
      string strVersionRemote = "";

      try 
      {
        rootElem = (XmlElement)xmlRemote.FirstChild;
        strVersionRemote = rootElem.Attributes[GlobalConstants.infoXml.strAttrVersion].InnerText;
      }
      catch (Exception ex)
      {
        Core.WriteLog(Core.ELogType.error, "remote info xml is wrong: " + ex.ToString());
        return;
      }
      

      if (m_mainForm.m_infoLocalXmlHandler.IsNewVersion(strVersionRemote))
      {
        try
        {
        m_mainForm.InfoUpdateNotice("电影资源更新中...");
        foreach (XmlNode nodeSection in rootElem.ChildNodes)
        {
          if (m_bStopThread) return;
          string strTypeSection = nodeSection.Attributes[GlobalConstants.infoXml.strAttrType].InnerText;
            if (strTypeSection == GlobalConstants.infoXml.strTypeValueTorrent)
          {
            foreach (XmlNode nodeCategory in nodeSection.ChildNodes)
            {
              if (m_bStopThread) return;
              foreach (XmlNode nodeItem in nodeCategory.ChildNodes)
              {
                if (m_bStopThread) return;
                XmlAttribute attrNew = xmlRemote.CreateAttribute(GlobalConstants.infoXml.strAttrNew);
                bool bNew = false;
                if (!m_mainForm.m_infoLocalXmlHandler.IsItemExist(nodeItem.Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText))
                {
                  bNew = true;
                  foreach (XmlNode node in nodeItem.ChildNodes)
                  {
                    if (m_bStopThread) return;
                      if (node.Name == GlobalConstants.infoXml.strElemImage || node.Name == GlobalConstants.infoXml.strElemFile)
                    {
                      string strItemName = node.Attributes[GlobalConstants.infoXml.strAttrName].InnerText;
                      string strDownloadedUrl = MainForm.m_strDownloadedFolderUrl + "\\" + strItemName;
                        if (!File.Exists(strDownloadedUrl)) // everythings is unique.(subtitle file append date)
                      {
                        string strRemoteUrl = GlobalConstants.Common.strInfoItemFolderRemoteUrl + "\\" + strItemName;
                        m_bItemDownloadFinished = false;
                        m_ItemDownloader.DownloadFileAsync(new Uri(strRemoteUrl), strDownloadedUrl);

                          while (!m_bItemDownloadFinished) { Thread.Sleep(100); }
                      }
                    }
                  }
                }
                attrNew.Value = bNew.ToString();
                nodeItem.Attributes.Append(attrNew);
              }
            }
          }
          else
          {
            MessageBox.Show("Only support torrent section");
          }
        }

        m_mainForm.m_infoLocalXmlHandler.Replace(xmlRemote);
        m_mainForm.InfoUpdateNotice("");
      }
        catch (Exception ex)
        {
          Core.WriteLog(Core.ELogType.error, "dl info crash: " + ex.ToString());
          return;
        }
      }
    }

    protected override void ThreadProcess()
    {
      while (!m_bStopThread)
      {
        Core.WriteLog(Core.ELogType.notice, "Download infoRemote.xml");
        try
        {
          File.Delete(m_strDownloadedInfoRemoteXmlUrl);

          m_InfoRemoteXmlDownloader.DownloadFileAsync(new Uri(GlobalConstants.Common.strInfoRemoteXmlUrl), m_strDownloadedInfoRemoteXmlUrl);
        }
        catch (Exception e)
        {
          Core.WriteLog(Core.ELogType.error, "Delete infoRemote xml fail or Download infoRemote xml fail: " + e.ToString());
          Thread.Sleep(1000 * 60);
          continue;
        }

        try
        {
          Thread.Sleep(1000 * 60 * 60);
        }
        catch (ThreadInterruptedException) { }
      }
    }
  }
}
