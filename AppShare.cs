using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;


namespace RPlayer
{
  class AppShare
  {
    #region fields
    static readonly private string m_strXmlFileName = "appShare.xml";
    static private string m_strXmlFileUrl;
    static readonly private string m_strNodeNameRoot = "/appShare";

    static readonly private string m_strNodeNameDownloadedSetupsSelfVersion = "downloadedSetupSelfVersion";
    static readonly private string m_strNodeUrlDownloadedSetupSelfVersion 
      = m_strNodeNameRoot + "/" + m_strNodeNameDownloadedSetupsSelfVersion;

    static readonly private string m_strNodeNameLaunchTimes = "LaunchTimes";
    static readonly private string m_strNodeUrlLaunchTimes
      = m_strNodeNameRoot + "/" + m_strNodeNameLaunchTimes;

    static readonly private string m_strNodeNameShared = "Shared";
    static readonly private string m_strNodeUrlShared
      = m_strNodeNameRoot + "/" + m_strNodeNameShared;

    static readonly public string m_strNodeNameIsFirstOpenFile = "IsFirstOpenFile";
    static readonly private string m_strNodeUrlIsFirstOpenFile
      = m_strNodeNameRoot + "/" + m_strNodeNameIsFirstOpenFile;

    static readonly public string m_strNodeNameIsFirstInPlistFile = "IsFirstInPlistFile";
    static readonly private string m_strNodeUrlIsFirstInPlistFile
      = m_strNodeNameRoot + "/" + m_strNodeNameIsFirstInPlistFile;

    static readonly public string m_strNodeNameIsFirstInQuickLook = "IsFirstInQuickLook";
    static readonly private string m_strNodeUrlIsFirstInQuickLook
      = m_strNodeNameRoot + "/" + m_strNodeNameIsFirstInQuickLook;

    static readonly public string m_strNodeNameIsFirstPlay = "IsFirstPlay";
    static readonly private string m_strNodeUrlIsFirstPlay
      = m_strNodeNameRoot + "/" + m_strNodeNameIsFirstPlay;

    #endregion

    static private void GetNode(XmlDocument xml,string nodeUrl, out XmlNode node)
    {
      try
      {
        xml.Load(m_strXmlFileUrl);
      }
      catch{}

      XmlNode nodeAppShare = xml.SelectSingleNode("/appShare");
      if (nodeAppShare == null)
      {
        nodeAppShare = xml.CreateElement("appShare");
        xml.AppendChild(nodeAppShare);
      }

      node = xml.SelectSingleNode(nodeUrl);
      if(node == null)
      {
        #region AddDefault
        //if (nodeUrl == "/appShare/allowAutoRunRPUdater")
        //{
          //node = xml.CreateElement("allowAutoRunRPUdater");
          //nodeAppShare.AppendChild(node);
          //node.InnerText = "True";
        //}
        if (nodeUrl == "/appShare/firstTimeRun")
        {
          node = xml.CreateElement("firstTimeRun");
          nodeAppShare.AppendChild(node);
          node.InnerText = "True";
        }
        else if (nodeUrl == "/appShare/url")
        {
          node = xml.CreateElement("url");
          nodeAppShare.AppendChild(node);
          node.InnerText = "";
        }
        else if (nodeUrl == m_strNodeUrlDownloadedSetupSelfVersion)
        {
          node = xml.CreateElement(m_strNodeNameDownloadedSetupsSelfVersion);
          nodeAppShare.AppendChild(node);
          node.InnerText = "";
        }
        else if (nodeUrl == m_strNodeUrlLaunchTimes)
        {
          node = xml.CreateElement(m_strNodeNameLaunchTimes);
          nodeAppShare.AppendChild(node);
          node.InnerText = "1";
        }
        else if (nodeUrl == m_strNodeUrlShared)
        {
          node = xml.CreateElement(m_strNodeNameShared);
          nodeAppShare.AppendChild(node);
          node.InnerText = "False";
        }
        else if (nodeUrl == m_strNodeUrlIsFirstOpenFile)
        {
          node = xml.CreateElement(m_strNodeNameIsFirstOpenFile);
          nodeAppShare.AppendChild(node);
          node.InnerText = "True";
        }
        else if (nodeUrl == m_strNodeUrlIsFirstInPlistFile)
        {
          node = xml.CreateElement(m_strNodeNameIsFirstInPlistFile);
          nodeAppShare.AppendChild(node);
          node.InnerText = "True";
        }
        else if (nodeUrl == m_strNodeUrlIsFirstInQuickLook)
        {
          node = xml.CreateElement(m_strNodeNameIsFirstInQuickLook);
          nodeAppShare.AppendChild(node);
          node.InnerText = "True";
        }
        else if (nodeUrl == m_strNodeUrlIsFirstPlay)
        {
          node = xml.CreateElement(m_strNodeNameIsFirstPlay);
          nodeAppShare.AppendChild(node);
          node.InnerText = "True";
        }
        #endregion
      }
    }

    static public bool SetGetIsFirst(string xmlPath, bool bSet,string nodeName)
    {
      m_strXmlFileUrl = xmlPath + "\\" + m_strXmlFileName;
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, m_strNodeNameRoot + "/" + nodeName, out node);
      if (bSet)
      {
        node.InnerText = "False";

        try
        {
          xml.Save(m_strXmlFileUrl);
        }
        catch { }
      }
      else
      {
        return Convert.ToBoolean(node.InnerText);
      }
      return true;
    }

    static public bool SetGetShared(string xmlPath, bool bSet)
    {
      m_strXmlFileUrl = xmlPath + "\\" + m_strXmlFileName;
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, m_strNodeUrlShared, out node);
      if (bSet)
      {
        node.InnerText = "True";

        try
        {
          xml.Save(m_strXmlFileUrl);
        }
        catch { }
      }
      else
      {
        return Convert.ToBoolean(node.InnerText);
      }
      return false;
    }

    static public void SetGetLaunchTimes(string xmlPath, bool bSet, ref UInt64 times)
    {
      m_strXmlFileUrl = xmlPath + "\\" + m_strXmlFileName;
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, m_strNodeUrlLaunchTimes, out node);
      if (bSet)
      {
        node.InnerText = times.ToString();

        try
        {
          xml.Save(m_strXmlFileUrl);
        }
        catch { }
      }
      else
      {
        times = Convert.ToUInt64(node.InnerText);
      }
    }

    static public void SetGetDownloadedSetupSelfVersion(string xmlPath, bool bSet,ref string strVersion)
    {
      m_strXmlFileUrl = xmlPath + "\\" + m_strXmlFileName;
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, m_strNodeUrlDownloadedSetupSelfVersion, out node);
      if (bSet)
      {
        node.InnerText = strVersion;

        try
        {
          xml.Save(m_strXmlFileUrl);
        }
        catch { }
      }
      else
      {
        strVersion = node.InnerText;
      }
    }

    static public bool SetGetFirstTimeRun(string xmlPath, bool bSet)
    {
      m_strXmlFileUrl = xmlPath + "\\" + m_strXmlFileName;
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, "/appShare/firstTimeRun", out node);
      bool first = true;
      if (bSet)
      {
        node.InnerText = "False";
      }
      else
        first = Convert.ToBoolean(node.InnerText);
      try
      {
        xml.Save(m_strXmlFileUrl);
      }
      catch{}
      return first;
    }

    //static public bool SetGetAllowAutoRunRPUdater(string xmlPath,bool bSet)
    //{
    //  XmlDocument xml = new XmlDocument();
    //  XmlNode node;
    //  GetNode(xml, xmlPath, "/appShare/allowAutoRunRPUdater", out node);
    //  bool allow = true;
    //  if (bSet)
    //  {
    //    node.InnerText = "False";
    //  }
    //  else
    //    allow = Convert.ToBoolean(node.InnerText);
    //  try
    //  {
    //    xml.Save(xmlPath + "\\" + m_strXmlFileName);
    //  }
    //  catch
    //  {
    //  }
    //  return allow;
    //}

    static public bool SetGetNewUrl(string xmlPath,bool bSet,ref string url)
    {
      m_strXmlFileUrl = xmlPath + "\\" + m_strXmlFileName;
      bool bNeedSave = true;

      if(!bSet)
        url = "";
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, "/appShare/url", out node);
      if (bSet)
      {
        node.InnerText = url;
      }
      else
      {
        url = node.InnerText;
        if (url == "") // If no url. then no need change and no need save
          bNeedSave = false;
        else
          node.InnerText = "";
      }

      if (bNeedSave)
      {
        try
        {
          xml.Save(m_strXmlFileUrl);
        }
        catch{}
      }

      return true;
    }


  }
}
