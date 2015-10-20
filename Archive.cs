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

  public class PlaylistFile
  {
    public enum enumPlayState { notPlayed, played,finished}
    public string url;
    public string fileName;
    public double timeWatched;
    public enumPlayState playState;
    public double duration;
    public string creationTime;
  }

  public class PlaylistFolder
  {    
    public string url;
    public string folderName;
    public bool expand;
    public string creationTime;
    public List<PlaylistFile> playlistFiles;
  }

  class Archive
  {
    static private XmlDocument xml = new XmlDocument();
    static private string xmlFileName = "archive.xml";
    static private string sectionOthers = "/archive/others/";
    static private string sectionFormPList = "/archive/formPList/";
    static private string sectionGeneralSettings = "/archive/generalSettings/";
    static private string sectionPlistSettings = "/archive/plistSettings/";

    // others
    static public int volume;
    static public bool mute;
    static public bool plistShowingInNoneDesktop;
    static public int mainFormLocX, mainFormLocY, mainFormWidth, mainFormHeight;

    // formPList
    public enum enumRepeatPlayback { none,one,all}
    static public enumRepeatPlayback repeatPlayback;
    public enum enumSortBy { creationTimeUp, creationTimeDown, nameUp, nameDown, durationUp, durationDown }
    static public enumSortBy sortBy;
    public enum enumSelectedPListBtn { playlist, histroy}
    static public enumSelectedPListBtn selectedPListBtn;
    static public int formPlistWidth;
    static public int formPlistHeight;

    // generalSettings
    static public string lang;
    static public string snapSavePath;

    // plistSettings
    static public bool updatePlistAfterLaunch;
    static public bool autoAddFolderToPlist;
    static public bool deleteFileDirectly;

    // histroy
    static public List<HistroyItem> histroy;
    // playlist
    static public List<PlaylistFolder> playlist;


    static public Color colorContextMenu = Color.FromArgb(255, 25, 25, 25);

    static private void LoadOthers()
    {
      // others
      XmlNode node = xml.SelectSingleNode(sectionOthers + "volume");
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
    }

    static private void LoadFormPlist()
    {
      // formPList
      XmlNode node = xml.SelectSingleNode(sectionFormPList + "repeat");
      repeatPlayback = (enumRepeatPlayback)Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "sortBy");
      sortBy = (enumSortBy)Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "selectedPListBtn");
      selectedPListBtn = (enumSelectedPListBtn)Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "width");
      formPlistWidth = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "height");
      formPlistHeight = Convert.ToInt32(node.InnerText);
    }

    static private void LoadGeneralSettings()
    {
      // generalSettings
      XmlNode node = xml.SelectSingleNode(sectionGeneralSettings + "lang");
      lang = node.InnerText;
      node = xml.SelectSingleNode(sectionGeneralSettings + "snapSavePath");
      snapSavePath = node.InnerText;
    }

    static private void LoadPlistSettings()
    {
      // plistSettings
      XmlNode node = xml.SelectSingleNode(sectionPlistSettings + "updatePlistAfterLaunch");
      updatePlistAfterLaunch = Convert.ToBoolean(node.InnerText);
      node = xml.SelectSingleNode(sectionPlistSettings + "autoAddFolderToPlist");
      autoAddFolderToPlist = Convert.ToBoolean(node.InnerText);
      node = xml.SelectSingleNode(sectionPlistSettings + "deleteFileDirectly");
      deleteFileDirectly = Convert.ToBoolean(node.InnerText);
    }

    static private void LoadHistroy()
    {
      // histroy
      histroy = new List<HistroyItem>();
      XmlNode node = xml.SelectSingleNode("/archive/histroy");
      if (node != null)
      {
        int count = node.ChildNodes.Count;
        for (int i = count - 1; i >= 0; i--)
        {
          XmlNode childNode = node.ChildNodes[i];
          HistroyItem item = new HistroyItem();
          item.url = childNode.InnerText;
          item.timeWatched = Convert.ToDouble(childNode.Attributes["timeWatched"].InnerText);
          item.duration = Convert.ToDouble(childNode.Attributes["duration"].InnerText);
          histroy.Add(item);
        }
      }
    }

    static private void LoadPlist()
    {
      // playlist
      playlist = new List<PlaylistFolder>();
      XmlNode node = xml.SelectSingleNode("/archive/playlist");
      if (node != null)
      {
        int countFolders = node.ChildNodes.Count;
        for (int i = 0; i < countFolders; i++)
        {
          XmlNode childFolderNode = node.ChildNodes[i];
          PlaylistFolder folder = new PlaylistFolder();
          folder.url = childFolderNode.Attributes["url"].InnerText;
          folder.folderName = childFolderNode.Attributes["folderName"].InnerText;
          folder.expand = Convert.ToBoolean(childFolderNode.Attributes["expand"].InnerText);
          folder.creationTime = childFolderNode.Attributes["creationTime"].InnerText;

          folder.playlistFiles = new List<PlaylistFile>();
          int countFiles = childFolderNode.ChildNodes.Count;

          for (int j = 0; j < countFiles; j++)
          {
            XmlNode childFileNode = childFolderNode.ChildNodes[j];
            PlaylistFile file = new PlaylistFile();
            file.url = childFileNode.InnerText;
            file.fileName = childFileNode.Attributes["fileName"].InnerText;
            file.timeWatched = Convert.ToDouble(childFileNode.Attributes["timeWatched"].InnerText);
            file.playState
              = (PlaylistFile.enumPlayState)(Convert.ToInt32(childFileNode.Attributes["playState"].InnerText));
            file.duration = Convert.ToDouble(childFileNode.Attributes["duration"].InnerText);
            file.creationTime = childFileNode.Attributes["creationTime"].InnerText;

            folder.playlistFiles.Add(file);
          }

          playlist.Add(folder);
        }
      }
    }

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

      LoadOthers();
      LoadFormPlist();
      LoadGeneralSettings();
      LoadPlistSettings();
      LoadHistroy();
      LoadPlist();

      return true;
    }

    static private void SaveOthers()
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
    }

    static private void SaveFormPlist()
    {
      // formPList
      XmlNode node = xml.SelectSingleNode(sectionFormPList + "repeat");
      node.InnerText = ((int)repeatPlayback).ToString();
      node = xml.SelectSingleNode(sectionFormPList + "sortBy");
      node.InnerText = ((int)sortBy).ToString();
      node = xml.SelectSingleNode(sectionFormPList + "selectedPListBtn");
      node.InnerText = ((int)selectedPListBtn).ToString();
      node = xml.SelectSingleNode(sectionFormPList + "width");
      node.InnerText = formPlistWidth.ToString();
      node = xml.SelectSingleNode(sectionFormPList + "height");
      node.InnerText = formPlistHeight.ToString();
    }

    static private void SaveGeneralSettings()
    {
      // generalSettings
      XmlNode node = xml.SelectSingleNode(sectionGeneralSettings + "lang");
      node.InnerText = lang;
      node = xml.SelectSingleNode(sectionGeneralSettings + "snapSavePath");
      node.InnerText = snapSavePath; 
    }

    static private void SavePlistSettings()
    {
      // PlistSettings
      XmlNode node = xml.SelectSingleNode(sectionPlistSettings + "updatePlistAfterLaunch");
      node.InnerText = updatePlistAfterLaunch.ToString();
      node = xml.SelectSingleNode(sectionPlistSettings + "autoAddFolderToPlist");
      node.InnerText = autoAddFolderToPlist.ToString();
      node = xml.SelectSingleNode(sectionPlistSettings + "deleteFileDirectly");
      node.InnerText = deleteFileDirectly.ToString();
    }

    static private void SaveHistroy()
    {
      // histroy
      XmlNode node = xml.SelectSingleNode("/archive/histroy");
      if (node != null)
        xml.DocumentElement.RemoveChild(node);

      XmlElement histroyElement = xml.CreateElement("histroy");
      xml.DocumentElement.AppendChild(histroyElement);
      for (int i = Archive.histroy.Count - 1; i >= 0; i--)
      {
        HistroyItem item = Archive.histroy[i];

        XmlElement itemElement = xml.CreateElement("file");
        itemElement.InnerText = item.url;
        histroyElement.AppendChild(itemElement);

        XmlAttribute attribute = xml.CreateAttribute("timeWatched");
        attribute.Value = item.timeWatched.ToString();
        itemElement.Attributes.Append(attribute);
        attribute = xml.CreateAttribute("duration");
        attribute.Value = item.duration.ToString();
        itemElement.Attributes.Append(attribute);
      }
    }

    static private void SavePlaylist()
    {
      // playlist
      XmlNode node = xml.SelectSingleNode("/archive/playlist");
      if (node != null)
        xml.DocumentElement.RemoveChild(node);

      XmlElement playlistElement = xml.CreateElement("playlist");
      xml.DocumentElement.AppendChild(playlistElement);
      int countFolder = playlist.Count;
      for (int i = 0; i < countFolder; i++)
      {
        PlaylistFolder folder = playlist[i];

        XmlElement folderElement = xml.CreateElement("folder");

        XmlAttribute attributeFolder = xml.CreateAttribute("url");
        attributeFolder.Value = folder.url;
        folderElement.Attributes.Append(attributeFolder);

        attributeFolder = xml.CreateAttribute("expand");
        attributeFolder.Value = folder.expand.ToString();
        folderElement.Attributes.Append(attributeFolder);

        attributeFolder = xml.CreateAttribute("folderName");
        attributeFolder.Value = folder.folderName;
        folderElement.Attributes.Append(attributeFolder);

        attributeFolder = xml.CreateAttribute("creationTime");
        attributeFolder.Value = folder.creationTime;
        folderElement.Attributes.Append(attributeFolder);

        playlistElement.AppendChild(folderElement);

        int countFile = folder.playlistFiles.Count;
        for (int j = 0; j < countFile; j++)
        {
          PlaylistFile file = folder.playlistFiles[j];

          XmlElement fileElement = xml.CreateElement("file");
          fileElement.InnerText = file.url;

          XmlAttribute attributeFile = xml.CreateAttribute("fileName");
          attributeFile.Value = file.fileName;
          fileElement.Attributes.Append(attributeFile);

          attributeFile = xml.CreateAttribute("timeWatched");
          attributeFile.Value = file.timeWatched.ToString();
          fileElement.Attributes.Append(attributeFile);

          attributeFile = xml.CreateAttribute("playState");
          attributeFile.Value = ((int)(file.playState)).ToString();
          fileElement.Attributes.Append(attributeFile);

          attributeFile = xml.CreateAttribute("duration");
          attributeFile.Value = file.duration.ToString();
          fileElement.Attributes.Append(attributeFile);

          attributeFile = xml.CreateAttribute("creationTime");
          attributeFile.Value = file.creationTime;
          fileElement.Attributes.Append(attributeFile);

          folderElement.AppendChild(fileElement);
        }
      }
    }

    static public void Save()
    {
      SaveOthers();
      SaveFormPlist();
      SaveGeneralSettings();
      SavePlistSettings();
      SaveHistroy();
      SavePlaylist();

      xml.Save(xmlFileName);
    }
  }
}
