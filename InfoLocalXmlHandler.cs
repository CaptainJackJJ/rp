﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace RPlayer
{
  public class InfoLocalXmlHandler
  {
    static private string m_strInfoXmlLocalUrl;
    static public XmlDocument m_xml;
    static private List<string> m_itemsList;

    static public void Load(string xmlParentDir)
    {
      m_itemsList = new List<string>();

      m_strInfoXmlLocalUrl = xmlParentDir + "\\" + GlobalConstants.Common.strInfoXmlLocalName;
      m_xml = new XmlDocument();
      try
      {
        m_xml.Load(m_strInfoXmlLocalUrl);
      }
      catch (System.IO.FileNotFoundException)
      {
        m_xml = null;
      }

      FreshItemsList();
    }

    static public void FreshItemsList()
    {
      if (m_xml == null)
        return;
      m_itemsList.Clear();
      XmlElement rootElem = (XmlElement)m_xml.FirstChild;
      foreach (XmlNode nodeSection in rootElem.ChildNodes)
      {
        string strTypeSection = nodeSection.Attributes[GlobalConstants.infoXml.strAttrType].InnerText;
        if(strTypeSection ==GlobalConstants.infoXml.strTypeValueTorrent)
        {
          foreach (XmlNode nodeCategory in nodeSection.ChildNodes)
          {
            foreach (XmlNode nodeItem in nodeCategory.ChildNodes)
            {
              m_itemsList.Add(nodeItem.Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText);
            }
          }
        }
        else
        {
          MessageBox.Show("Only support torrent section");
        }
      }
    }

    static public bool IsNewVersion(string strVersion)
    {
      if (m_xml == null)
        return true;

      string strLocalVersion = m_xml.FirstChild.Attributes[GlobalConstants.infoXml.strAttrVersion].InnerText;
      return UtilsCommon.IsNewVersion(strVersion, strLocalVersion);
    }

    static public bool IsItemExist(string strItemTitle)
    {
      if (m_xml == null)
        return false;

      return m_itemsList.Exists(element => element == strItemTitle);
    }

    static public void Replace(XmlDocument xmlNew)
    {
      m_xml = xmlNew;
      m_xml.Save(m_strInfoXmlLocalUrl);
      FreshItemsList();
    }
  }
}