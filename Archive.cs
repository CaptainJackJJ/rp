using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RPlayer
{
  class Archive
  {
    static private XmlDocument xml = new XmlDocument();
    static private string xmlFileName = "archive.xml";
    static private string sectionOthers = "/archive/others/";
    static private string sectionGeneral = "/archive/general/";

    static public int volume;
    static public bool mute;
    static public string lang;

    static public bool Load()
    {
      try
      {
        xml.Load(xmlFileName);
      }
      catch(System.IO.FileNotFoundException)
      {
        return false;
      }

      // others
      XmlNode node = xml.SelectSingleNode(sectionOthers +"volume");
      volume = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mute");
      mute = Convert.ToBoolean(node.InnerText);

      // general
      node = xml.SelectSingleNode(sectionGeneral + "lang");
      lang = node.InnerText;

      return true;
    }

    static public void Save()
    {
      // others
      XmlNode node = xml.SelectSingleNode(sectionOthers + "volume");
      node.InnerText = volume.ToString();
      node = xml.SelectSingleNode(sectionOthers + "mute");
      node.InnerText = mute.ToString();

      // general
      node = xml.SelectSingleNode(sectionGeneral + "lang");
      node.InnerText = lang;

      xml.Save(xmlFileName);
    }
  }
}
