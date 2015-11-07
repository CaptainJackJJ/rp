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
    public int audioIndex;
    public int subtitleIndex;
    public bool subtitleVisible;
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
    static private string xmlFilePath;
    static private XmlDocument xml = new XmlDocument();
    static private string xmlFileName = "archive.xml";
    static private string sectionOthers = "/archive/others/";
    static private string sectionFormPList = "/archive/formPList/";
    static private string sectionGeneralSettings = "/archive/generalSettings/";
    static private string sectionSubtitleSettings = "/archive/subtitleSettings/";
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
    static public bool associateFiles;

    // subtitleSettings
    static public int fontSize;
    static public int fontPos;
    static public int fontColor;
    static public int fontBorderColor;
    static public bool bold;
    static public bool italic;
    static public bool overAssOrig;

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
      node = xml.SelectSingleNode(sectionGeneralSettings + "associateFiles");
      associateFiles = Convert.ToBoolean(node.InnerText);
    }

    static private void LoadSubtitleSettings()
    {
      // subtitleSettings
      XmlNode node = xml.SelectSingleNode(sectionSubtitleSettings + "fontSize");
      fontSize = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontPos");
      fontPos = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontColor");
      fontColor = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontBorderColor");
      fontBorderColor = Convert.ToInt32(node.InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "bold");
      bold = Convert.ToBoolean(node.InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "italic");
      italic = Convert.ToBoolean(node.InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "overAssOrig");
      overAssOrig = Convert.ToBoolean(node.InnerText);
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
          item.audioIndex = Convert.ToInt32(childNode.Attributes["audioIndex"].InnerText);
          item.subtitleIndex = Convert.ToInt32(childNode.Attributes["subtitleIndex"].InnerText);
          item.subtitleVisible = Convert.ToBoolean(childNode.Attributes["subtitleVisible"].InnerText);
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

    static public bool Load(string xmlPath)
    {
      try
      {
        xmlFilePath = xmlPath;
        xml.Load(xmlFilePath + "\\" + xmlFileName);
      }
      catch (System.IO.FileNotFoundException)
      {
        return false;
      }

      LoadOthers();
      LoadFormPlist();
      LoadGeneralSettings();
      LoadSubtitleSettings();
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
      node = xml.SelectSingleNode(sectionGeneralSettings + "associateFiles");
      node.InnerText = associateFiles.ToString(); 
    }

    static private void SaveSubtitleSettings()
    {
      // subtitleSettings
      XmlNode node = xml.SelectSingleNode(sectionSubtitleSettings + "fontSize");
      node.InnerText = fontSize.ToString();
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontPos");
      node.InnerText = fontPos.ToString();
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontColor");
      node.InnerText = fontColor.ToString();
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontBorderColor");
      node.InnerText = fontBorderColor.ToString();
      node = xml.SelectSingleNode(sectionSubtitleSettings + "bold");
      node.InnerText = bold.ToString();
      node = xml.SelectSingleNode(sectionSubtitleSettings + "italic");
      node.InnerText = italic.ToString();
      node = xml.SelectSingleNode(sectionSubtitleSettings + "overAssOrig");
      node.InnerText = overAssOrig.ToString();
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
        attribute = xml.CreateAttribute("audioIndex");
        attribute.Value = item.audioIndex.ToString();
        itemElement.Attributes.Append(attribute);
        attribute = xml.CreateAttribute("subtitleIndex");
        attribute.Value = item.subtitleIndex.ToString();
        itemElement.Attributes.Append(attribute);
        attribute = xml.CreateAttribute("subtitleVisible");
        attribute.Value = item.subtitleVisible.ToString();
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
      SaveSubtitleSettings();
      SavePlistSettings();
      SaveHistroy();
      SavePlaylist();

      xml.Save(xmlFilePath + "\\" + xmlFileName);
    }

    static public void Reset()
    {
      XmlNode node = xml.SelectSingleNode(sectionOthers + "volume");
      volume = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mute");
      mute = Convert.ToBoolean(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionOthers + "plistShowingInNoneDesktop");
      plistShowingInNoneDesktop = Convert.ToBoolean(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormLocX");
      mainFormLocX = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormLocY");
      mainFormLocY = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormWidth");
      mainFormWidth = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionOthers + "mainFormHeight");
      mainFormHeight = Convert.ToInt32(node.Attributes["default"].InnerText);

      // formPList
      node = xml.SelectSingleNode(sectionFormPList + "repeat");
      repeatPlayback = (enumRepeatPlayback)Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "sortBy");
      sortBy = (enumSortBy)Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "selectedPListBtn");
      selectedPListBtn = (enumSelectedPListBtn)Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "width");
      formPlistWidth = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionFormPList + "height");
      formPlistHeight = Convert.ToInt32(node.Attributes["default"].InnerText);

      // generalSettings
      node = xml.SelectSingleNode(sectionGeneralSettings + "lang");
      lang = node.Attributes["default"].InnerText;
      node = xml.SelectSingleNode(sectionGeneralSettings + "snapSavePath");
      snapSavePath = node.Attributes["default"].InnerText;
      node = xml.SelectSingleNode(sectionGeneralSettings + "associateFiles");
      associateFiles = Convert.ToBoolean(node.Attributes["default"].InnerText);

      // subtitleSettings
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontSize");
      fontSize = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontPos");
      fontPos = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontColor");
      fontColor = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "fontBorderColor");
      fontBorderColor = Convert.ToInt32(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "bold");
      bold = Convert.ToBoolean(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "italic");
      italic = Convert.ToBoolean(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionSubtitleSettings + "overAssOrig");
      overAssOrig = Convert.ToBoolean(node.Attributes["default"].InnerText);

      // plistSettings
      node = xml.SelectSingleNode(sectionPlistSettings + "updatePlistAfterLaunch");
      updatePlistAfterLaunch = Convert.ToBoolean(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionPlistSettings + "autoAddFolderToPlist");
      autoAddFolderToPlist = Convert.ToBoolean(node.Attributes["default"].InnerText);
      node = xml.SelectSingleNode(sectionPlistSettings + "deleteFileDirectly");
      deleteFileDirectly = Convert.ToBoolean(node.Attributes["default"].InnerText);

    }
  }
}
