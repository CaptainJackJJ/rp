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
    static private string xmlFileName = "appShare.xml";
    static private string appShareUrl = "/appShare/url";
    static private string appRunning = "/appShare/appRunning";

    static private void GetNode(XmlDocument xml,string xmlPath,string nodeUrl, out XmlNode node)
    {
      try
      {
        xml.Load(xmlPath + "\\" + xmlFileName);
      }
      catch (System.IO.FileNotFoundException)
      {
      }

      XmlNode nodeAppShare = xml.SelectSingleNode("/appShare");
      if (nodeAppShare == null)
      {
        nodeAppShare = xml.CreateElement("appShare");
        xml.AppendChild(nodeAppShare);
        node = xml.CreateElement("appRunning");
        nodeAppShare.AppendChild(node);
        node.InnerText = "False";
        node = xml.CreateElement("allowAutoRunRPUdater");
        nodeAppShare.AppendChild(node);
        node.InnerText = "True";
        node = xml.CreateElement("url");
        nodeAppShare.AppendChild(node);
        node.InnerText = "";
      }

      node = xml.SelectSingleNode(nodeUrl);
    }

    static public bool GetAllowAutoRunRPUdater(string xmlPath)
    {
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, xmlPath, "/appShare/allowAutoRunRPUdater", out node);
      xml.Save(xmlPath + "\\" + xmlFileName);
      return Convert.ToBoolean(node.InnerText);
    }

    static public bool SetGetAppIsRunning(string xmlPath, bool bSet, ref bool bRunning)
    {
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, xmlPath, "/appShare/appRunning", out node);
      if (bSet)
      {
        node.InnerText = bRunning.ToString();
        xml.Save(xmlPath + "\\" + xmlFileName);
      }
      else
        bRunning = Convert.ToBoolean(node.InnerText);
      return true;
    }

    static public bool SetGetNewUrl(string xmlPath,bool bSet,ref string url)
    {
      bool bNeedSave = true;

      if(!bSet)
        url = "";
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, xmlPath, "/appShare/url", out node);
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

      if(bNeedSave)
        xml.Save(xmlPath + "\\" + xmlFileName);

      return true;
    }


  }
}
