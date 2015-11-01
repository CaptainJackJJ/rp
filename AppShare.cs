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

    static public bool SetGetAppIsRunning(string xmlPath, bool bSet, ref bool bRunning)
    {
      XmlDocument xml = new XmlDocument();
      try
      {
        xml.Load(xmlPath + "\\" + xmlFileName);
      }
      catch (System.IO.FileNotFoundException)
      {
        return false;
      }

      XmlNode node = xml.SelectSingleNode(appRunning);
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
      try
      {
        xml.Load(xmlPath + "\\" + xmlFileName);
      }
      catch (System.IO.FileNotFoundException)
      {
        return false;
      }

      XmlNode node = xml.SelectSingleNode(appShareUrl);
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

    //static public bool GetUrl(string xmlPath, out string url)
    //{
    //  url = "";
    //  XmlDocument xml = new XmlDocument();
    //  try
    //  {
    //    xml.Load(xmlPath + "\\" + xmlFileName);
    //  }
    //  catch (System.IO.FileNotFoundException)
    //  {
    //    return false;
    //  }

    //  XmlNode node = xml.SelectSingleNode(appShareUrl);
    //  url = node.InnerText;
    //  node.InnerText = "";

    //  xml.Save(xmlPath + "\\" + xmlFileName);

    //  return true;
    //}
  }
}
