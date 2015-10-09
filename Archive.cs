using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace RPlayer
{
  public class HistroyItem
  {
    public string url;
    public double timeWatched;
    public double duration;
  }

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
    static public int mainFormLocX, mainFormLocY, mainFormWidth, mainFormHeight;
    static public string lang;
    public enum enumRepeatPlayback { none,one,all}
    static public enumRepeatPlayback repeatPlayback;
    public enum enumSortBy { addedTime, createdTime, fileName, fileSize}
    static public enumSortBy sortBy;
    public enum enumSelectedPListBtn { playlist, histroy}
    static public enumSelectedPListBtn selectedPListBtn;
    static public int formPlistWidth;
    static public int formPlistHeight;

    static public List<HistroyItem> histroy;

    static public Color colorContextMenu = Color.FromArgb(255, 25, 25, 25);

    static public bool Load()
    {
      try
      {
        xml.Load(xmlFileName);
      }
      catch (System.IO.FileNotFoundException)
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
      node = xml.SelectSingleNode(sectionOthers + "mainFormLocX");
      mainFormLocX = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormLocY");
      mainFormLocY = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormWidth");
      mainFormWidth = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormHeight");
      mainFormHeight = Convert.ToInt32(node.InnerText);


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

      // histroy
      histroy = new List<HistroyItem>();
      node = xml.SelectSingleNode("/archive/histroy");
      if(node != null)
      {
        for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
        {
          XmlNode childNode = node.ChildNodes[i];
          HistroyItem item = new HistroyItem();
          item.url = childNode.InnerText;
          item.timeWatched = Convert.ToDouble(childNode.Attributes["timeWatched"].InnerText);
          item.duration = Convert.ToDouble(childNode.Attributes["duration"].InnerText);
          histroy.Add(item);
        }
      }
      

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
      node = xml.SelectSingleNode(sectionOthers + "mainFormLocX");
      node.InnerText = mainFormLocX.ToString();
      node = xml.SelectSingleNode(sectionOthers + "mainFormLocY");
      node.InnerText = mainFormLocY.ToString();
      node = xml.SelectSingleNode(sectionOthers + "mainFormWidth");
      node.InnerText = mainFormWidth.ToString();
      node = xml.SelectSingleNode(sectionOthers + "mainFormHeight");
      node.InnerText = mainFormHeight.ToString();

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

      // histroy
      node = xml.SelectSingleNode("/archive/histroy");
      if(node != null)
        xml.DocumentElement.RemoveChild(node);

      XmlElement histroyElement = xml.CreateElement("histroy");
      xml.DocumentElement.AppendChild(histroyElement);
      for (int i = Archive.histroy.Count - 1; i >= 0; i--)
      {
        HistroyItem item = Archive.histroy[i];

        XmlElement itemElement = xml.CreateElement("item");
        itemElement.InnerText = item.url;
        histroyElement.AppendChild(itemElement);

        XmlAttribute attribute = xml.CreateAttribute("timeWatched");
        attribute.Value = item.timeWatched.ToString();
        itemElement.Attributes.Append(attribute);
        attribute = xml.CreateAttribute("duration");
        attribute.Value = item.duration.ToString();
        itemElement.Attributes.Append(attribute);
      }

      xml.Save(xmlFileName);
    }
  }
}
