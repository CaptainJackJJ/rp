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

    static private void GetNode(XmlDocument xml,string xmlPath,string nodeUrl, out XmlNode node)
    {
      try
      {
        xml.Load(xmlPath + "\\" + xmlFileName);
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
        if(nodeUrl == "/appShare/appRunning")
        {
          node = xml.CreateElement("appRunning");
          nodeAppShare.AppendChild(node);
          node.InnerText = "False";
        }
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
        if (nodeUrl == "/appShare/url")
        {
          node = xml.CreateElement("url");
          nodeAppShare.AppendChild(node);
          node.InnerText = "";
        }
      }
    }

    static public bool SetGetFirstTimeRun(string xmlPath, bool bSet)
    {
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, xmlPath, "/appShare/firstTimeRun", out node);
      bool first = true;
      if (bSet)
      {
        node.InnerText = "False";
      }
      else
        first = Convert.ToBoolean(node.InnerText);
      try
      {
        xml.Save(xmlPath + "\\" + xmlFileName);
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
    //    xml.Save(xmlPath + "\\" + xmlFileName);
    //  }
    //  catch
    //  {
    //  }
    //  return allow;
    //}

    static public bool SetGetAppIsRunning(string xmlPath, bool bSet, ref bool bRunning)
    {
      XmlDocument xml = new XmlDocument();
      XmlNode node;
      GetNode(xml, xmlPath, "/appShare/appRunning", out node);
      if (bSet)
      {
        node.InnerText = bRunning.ToString();
        try
        {
          xml.Save(xmlPath + "\\" + xmlFileName);
        }
        catch{}
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

      if (bNeedSave)
      {
        try
        {
          xml.Save(xmlPath + "\\" + xmlFileName);
        }
        catch{}
      }

      return true;
    }


  }
}
