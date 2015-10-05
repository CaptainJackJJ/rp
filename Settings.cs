using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RPlayer
{
  class Settings
  {
    static private XmlDocument xml = new XmlDocument();
    static private string xmlFileName = "settings.xml";
    static private string sectionOthers = "/others/";

    static public int volume;

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

      XmlNode node = xml.SelectSingleNode(sectionOthers +"volume");
      volume = Convert.ToInt32(node.InnerText);


      return true;
    }

    static public void Save()
    {
      XmlNode node = xml.SelectSingleNode(sectionOthers + "volume");
      node.InnerText = volume.ToString();

      xml.Save(xmlFileName);
    }
  }
}
