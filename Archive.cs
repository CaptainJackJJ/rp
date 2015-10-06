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
    static private string sectionFormPList = "/archive/formPList/";
    static private string sectionGeneral = "/archive/general/";

    static public int volume;
    static public bool mute;
    static public bool plistShowingInNoneDesktop;
    static public string lang;
    public enum enumRepeatPlayback { none,one,all}
    static public enumRepeatPlayback repeatPlayback;
    public enum enumSortBy { addedTime, createdTime, fileName, fileSize}
    static public enumSortBy sortBy;
    public enum enumSelectedPListBtn { playlist, histroy}
    static public enumSelectedPListBtn selectedPListBtn;
    static public int formPlistWidth;
    static public int formPlistHeight;

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
      node = xml.SelectSingleNode(sectionOthers + "plistShowingInNoneDesktop");
      plistShowingInNoneDesktop = Convert.ToBoolean(node.InnerText);

      // formPList
      node = xml.SelectSingleNode(sectionFormPList + "repeat");
      repeatPlayback = (enumRepeatPlayback)Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "sortBy");
      sortBy = (enumSortBy)Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "selectedPListBtn");
      selectedPListBtn = (enumSelectedPListBtn)Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "width");
      formPlistWidth = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "height");
      formPlistHeight = Convert.ToInt32(node.InnerText);

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
      node = xml.SelectSingleNode(sectionOthers + "plistShowingInNoneDesktop");
      node.InnerText = plistShowingInNoneDesktop.ToString();

      // formPList
      node = xml.SelectSingleNode(sectionFormPList + "repeat");
      node.InnerText = ((int)repeatPlayback).ToString();
      node = xml.SelectSingleNode(sectionFormPList + "sortBy");
      node.InnerText = ((int)sortBy).ToString();
      node = xml.SelectSingleNode(sectionFormPList + "selectedPListBtn");
      node.InnerText = ((int)selectedPListBtn).ToString();
      node = xml.SelectSingleNode(sectionFormPList + "width");
      node.InnerText = formPlistWidth.ToString();
      node = xml.SelectSingleNode(sectionFormPList + "height");
      node.InnerText = formPlistHeight.ToString();

      // general
      node = xml.SelectSingleNode(sectionGeneral + "lang");
      node.InnerText = lang;      

      xml.Save(xmlFileName);
    }
  }
}
