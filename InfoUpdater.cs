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
    bool m_bInfoMore;
    InfoLocalXmlHandler m_infoLocalXmlHandler;

    public InfoUpdater(MainForm mainForm,bool bInfoMore,InfoLocalXmlHandler infoLocalXmlHandler)
    {
      m_bInfoMore = bInfoMore;
      m_infoLocalXmlHandler = infoLocalXmlHandler;
      m_mainForm = mainForm;
      string strXmlRemoteName;
      if (m_bInfoMore)
        strXmlRemoteName = GlobalConstants.Common.strInfoMoreXmlRemoteName;
      else
        strXmlRemoteName = GlobalConstants.Common.strInfoXmlRemoteName;
      m_strDownloadedInfoRemoteXmlUrl = MainForm.m_tempPath + "\\" + strXmlRemoteName;

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
        Core.WriteLog(Core.ELogType.error, "InfoRemoteXmlDownloadCompeleted: load xml exc. xml is " + m_strDownloadedInfoRemoteXmlUrl.ToString()
          + "exc is : " + ex.ToString());
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
        Core.WriteLog(Core.ELogType.error, "remote info xml is exc: " + ex.ToString());
        return;
      }
      

      if (m_infoLocalXmlHandler.IsNewVersion(strVersionRemote))
      {
        try
        {
          if(m_bInfoMore)
            m_mainForm.m_infoSectionTorrentUI.m_formInfoMore.InfoUpdateNotice("电影资源更新中...");
          else
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
                  if (!m_infoLocalXmlHandler.IsItemExist(nodeItem.Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText))
                  {
                    bNew = true;
                    foreach (XmlNode node in nodeItem.ChildNodes)
                    {
                      if (m_bStopThread) return;
                      if (node.Name == GlobalConstants.infoXml.strElemImage || node.Name == GlobalConstants.infoXml.strElemFile)
                      {
                        string strItemName = node.Attributes[GlobalConstants.infoXml.strAttrName].InnerText;
                        string strDownloadedUrl = MainForm.m_strDownloadedFolderUrl + "\\" + strItemName;
                        if (!File.Exists(strDownloadedUrl)) // everythings is unique.
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

          m_infoLocalXmlHandler.Replace(xmlRemote);
          if (m_bInfoMore)
            m_mainForm.m_infoSectionTorrentUI.m_formInfoMore.InfoUpdateNotice("");
          else
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
        Core.WriteLog(Core.ELogType.notice, "Download infoRemote xml. more ? " + m_bInfoMore.ToString());
        try
        {
          File.Delete(m_strDownloadedInfoRemoteXmlUrl);

          string strXmlRemoteUrl;
          if (m_bInfoMore)
            strXmlRemoteUrl = GlobalConstants.Common.strInfoMoreRemoteXmlUrl;
          else
            strXmlRemoteUrl = GlobalConstants.Common.strInfoRemoteXmlUrl;

          m_InfoRemoteXmlDownloader.DownloadFileAsync(new Uri(strXmlRemoteUrl), m_strDownloadedInfoRemoteXmlUrl);
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
