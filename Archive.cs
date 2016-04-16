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
    #region fields
    static private bool bLoaded = false;
    static private string xmlFilePath;
    static private XmlDocument xml = new XmlDocument();
    static private XmlNode nodeArchive,nodeSectionOthers,nodeSectionFormPList,
      nodeSectionGeneralSettings, nodeSectionSubtitleSettings, nodeSectionPlistSettings;
    static private string xmlFileName = "archive.xml";
    static private string sectionOthers = "others";
    static private string sectionFormPList = "formPList";
    static private string sectionGeneralSettings = "generalSettings";
    static private string sectionSubtitleSettings = "subtitleSettings";
    static private string sectionPlistSettings = "plistSettings";

    // others
    static public int volume;
    static public bool mute;
    static public bool plistShowingInNoneDesktop;
    static public bool maxed;
    static public int mainFormLocX, mainFormLocY, mainFormWidth, mainFormHeight;
    static public float speedFF,speedRW;

    static private readonly string SettingName_volume = "volume";
    static private readonly string SettingName_mute = "mute";
    static private readonly string SettingName_maxed = "maxed";
    static private readonly string SettingName_plistShowingInNoneDesktop = "plistShowingInNoneDesktop";
    static private readonly string SettingName_mainFormLocX = "mainFormLocX";
    static private readonly string SettingName_mainFormLocY = "mainFormLocY";
    static private readonly string SettingName_mainFormWidth = "mainFormWidth";
    static private readonly string SettingName_mainFormHeight = "mainFormHeight";
    static private readonly string SettingName_speedFF = "speedFF";
    static private readonly string SettingName_speedRW = "speedRW";

    static private readonly int volumeDefault = 100;
    static private readonly bool muteDefault = false;
    static private readonly bool maxedDefault = false;
    static private readonly bool plistShowingInNoneDesktopDefault = false;
    static public readonly int mainFormLocXDefault = -1, mainFormLocYDefault = -1,
      mainFormWidthDefault = 1024, mainFormHeightDefault = 720;
    static private readonly int speedFFDefault = 2;
    static private readonly int speedRWDefault = -2;

    // formPList
    public enum enumRepeatPlayback { none,one,all}
    static public enumRepeatPlayback repeatPlayback;
    public enum enumSortBy { creationTimeUp, creationTimeDown, nameUp, nameDown, durationUp, durationDown,pathLen }
    static public enumSortBy sortBy;
    public enum enumSelectedPListBtn { playlist, histroy}
    static public enumSelectedPListBtn selectedPListBtn;
    static public int formPlistWidth;
    static public int formPlistHeight;

    static private readonly string SettingName_repeatPlayback = "repeatPlayback";
    static private readonly string SettingName_sortBy = "sortBy";
    static private readonly string SettingName_selectedPListBtn = "selectedPListBtn";
    static private readonly string SettingName_formPlistWidth = "formPlistWidth";
    static private readonly string SettingName_formPlistHeight = "formPlistHeight";

    static private readonly enumRepeatPlayback repeatPlaybackDefault = enumRepeatPlayback.all;
    static private readonly enumSortBy sortByDefault = enumSortBy.nameUp;
    static private readonly enumSelectedPListBtn selectedPListBtnDefault = enumSelectedPListBtn.playlist;
    static private readonly int formPlistWidthDefault = 196;
    static private readonly int formPlistHeightDefault = 590;

    // generalSettings
    static public string lang;
    static public string snapSavePath;

    static private readonly string SettingName_lang = "lang";
    static private readonly string SettingName_snapSavePath = "snapSavePath";

    static private readonly string langDefault = "中文";
    static private readonly string snapSavePathDefault = "";

    // subtitleSettings
    static public int fontSize;
    static public int fontPos;
    static public int fontColor;
    static public int fontBorderColor;
    static public bool bold;
    static public bool italic;
    static public bool overAssOrig;

    static private readonly string SettingName_fontSize = "fontSize";
    static private readonly string SettingName_fontPos = "fontPos";
    static private readonly string SettingName_fontColor = "fontColor";
    static private readonly string SettingName_fontBorderColor = "fontBorderColor";
    static private readonly string SettingName_bold = "bold";
    static private readonly string SettingName_italic = "italic";
    static private readonly string SettingName_overAssOrig = "overAssOrig";

    static private readonly int fontSizeDefault = 17;
    static private readonly int fontPosDefault = 3;
    static private readonly int fontColorDefault = -1;
    static private readonly int fontBorderColorDefault = -16777216;
    static private readonly bool boldDefault = false;
    static private readonly bool italicDefault = false;
    static private readonly bool overAssOrigDefault = false;

    // plistSettings
    static public bool updatePlistAfterLaunch;
    static public bool autoAddFolderToPlist;
    static public bool deleteFileDirectly;

    static private readonly string SettingName_updatePlistAfterLaunch = "updatePlistAfterLaunch";
    static private readonly string SettingName_autoAddFolderToPlist = "autoAddFolderToPlist";
    static private readonly string SettingName_deleteFileDirectly = "deleteFileDirectly";

    static private readonly bool updatePlistAfterLaunchDefault = true;
    static private readonly bool autoAddFolderToPlistDefault = true;
    static private readonly bool deleteFileDirectlyDefault = false;

    // histroy
    static public List<HistroyItem> histroy;
    // playlist
    static public List<PlaylistFolder> playlist;


    static public Color colorContextMenu = Color.FromArgb(255, 25, 25, 25);
    #endregion

    static private string LoadNodeInner(XmlNode nodeSection, string nodeUrl)
    {
      XmlNode node = nodeSection.SelectSingleNode(nodeUrl);
      if (node == null)
      {
        node = xml.CreateElement(nodeUrl);
        nodeSection.AppendChild(node);
      }

      return node.InnerText;
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out int nodeValue, int nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = Convert.ToInt32(vaule);
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out float nodeValue, float nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = Convert.ToSingle(vaule);
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out bool nodeValue, bool nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = Convert.ToBoolean(vaule);
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out string nodeValue, string nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = vaule;
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out enumRepeatPlayback nodeValue, 
      enumRepeatPlayback nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = (enumRepeatPlayback)Convert.ToInt32(vaule);
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out enumSortBy nodeValue, 
      enumSortBy nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = (enumSortBy)Convert.ToInt32(vaule);
    }

    static private void LoadNode(XmlNode nodeSection, string nodeUrl, out enumSelectedPListBtn nodeValue, 
      enumSelectedPListBtn nodeValueDefault)
    {
      string vaule = LoadNodeInner(nodeSection, nodeUrl);
      if (vaule == "")
        nodeValue = nodeValueDefault;
      else
        nodeValue = (enumSelectedPListBtn)Convert.ToInt32(vaule);
    }

    static private void LoadOthers()
    {
      // others
      LoadNode(nodeSectionOthers,SettingName_volume,out volume,volumeDefault);
      LoadNode(nodeSectionOthers,SettingName_mute,out mute,muteDefault);
      LoadNode(nodeSectionOthers, SettingName_maxed, out maxed, maxedDefault);
      LoadNode(nodeSectionOthers,SettingName_plistShowingInNoneDesktop,out plistShowingInNoneDesktop,plistShowingInNoneDesktopDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormLocX,out mainFormLocX,mainFormLocXDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormLocY,out mainFormLocY,mainFormLocYDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormWidth,out mainFormWidth,mainFormWidthDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormHeight,out mainFormHeight,mainFormHeightDefault);
      LoadNode(nodeSectionOthers, SettingName_speedFF, out speedFF, speedFFDefault);
      LoadNode(nodeSectionOthers, SettingName_speedRW, out speedRW, speedRWDefault);
    }

    static private void LoadFormPlist()
    {
      LoadNode(nodeSectionFormPList, SettingName_repeatPlayback, out repeatPlayback, repeatPlaybackDefault);
      LoadNode(nodeSectionFormPList, SettingName_sortBy, out sortBy, sortByDefault);
      LoadNode(nodeSectionFormPList, SettingName_selectedPListBtn, out selectedPListBtn, selectedPListBtnDefault);
      LoadNode(nodeSectionFormPList, SettingName_formPlistWidth, out formPlistWidth, formPlistWidthDefault);
      LoadNode(nodeSectionFormPList, SettingName_formPlistHeight, out formPlistHeight, formPlistHeightDefault);
    }

    static private void LoadGeneralSettings()
    {
      LoadNode(nodeSectionGeneralSettings, SettingName_lang, out lang, langDefault);
      LoadNode(nodeSectionGeneralSettings, SettingName_snapSavePath, out snapSavePath, snapSavePathDefault);
    }

    static private void LoadSubtitleSettings()
    {
      LoadNode(nodeSectionSubtitleSettings, SettingName_fontSize, out fontSize, fontSizeDefault);
      LoadNode(nodeSectionSubtitleSettings, SettingName_fontPos, out fontPos, fontPosDefault);
      LoadNode(nodeSectionSubtitleSettings, SettingName_fontColor, out fontColor, fontColorDefault);
      LoadNode(nodeSectionSubtitleSettings, SettingName_fontBorderColor, out fontBorderColor, fontBorderColorDefault);
      LoadNode(nodeSectionSubtitleSettings, SettingName_bold, out bold, boldDefault);
      LoadNode(nodeSectionSubtitleSettings, SettingName_italic, out italic, italicDefault);
      LoadNode(nodeSectionSubtitleSettings, SettingName_overAssOrig, out overAssOrig, overAssOrigDefault);
    }

    static private void LoadPlistSettings()
    {
      LoadNode(nodeSectionPlistSettings, SettingName_updatePlistAfterLaunch, out updatePlistAfterLaunch,
        updatePlistAfterLaunchDefault);
      LoadNode(nodeSectionPlistSettings, SettingName_autoAddFolderToPlist, out autoAddFolderToPlist,
        autoAddFolderToPlistDefault);
      LoadNode(nodeSectionPlistSettings, SettingName_deleteFileDirectly, out deleteFileDirectly,
        deleteFileDirectlyDefault);
    }

    static private void LoadHistroy()
    {
      // histroy
      histroy = new List<HistroyItem>();
      XmlNode node = xml.SelectSingleNode("/archive/histroy");
      if (node != null)
      {
        int count = node.ChildNodes.Count;
        for (int i = count - 1; i >= 0; --i)
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

    static private void LoadSection(out XmlNode nodeSection, string section)
    {
      nodeSection = nodeArchive.SelectSingleNode(section);
      if(nodeSection == null)
      {
        nodeSection = xml.CreateElement(section);
        nodeArchive.AppendChild(nodeSection);
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
      }

      nodeArchive = xml.SelectSingleNode("/archive");
      if(nodeArchive == null)
      {
        nodeArchive = xml.CreateElement("archive");
        xml.AppendChild(nodeArchive);
      }

      LoadSection(out nodeSectionOthers, sectionOthers);
      LoadSection(out nodeSectionFormPList, sectionFormPList);
      LoadSection(out nodeSectionGeneralSettings, sectionGeneralSettings);
      LoadSection(out nodeSectionSubtitleSettings, sectionSubtitleSettings);
      LoadSection(out nodeSectionPlistSettings, sectionPlistSettings);

      LoadOthers();
      LoadFormPlist();
      LoadGeneralSettings();
      LoadSubtitleSettings();
      LoadPlistSettings();
      LoadHistroy();
      LoadPlist();

      bLoaded = true;

      return bLoaded;
    }

    static private void SaveOthers()
    {
      // others
      XmlNode node = nodeSectionOthers.SelectSingleNode(SettingName_volume);      
      node.InnerText = volume.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mute);
      node.InnerText = mute.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_maxed);
      node.InnerText = maxed.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_plistShowingInNoneDesktop);
      node.InnerText = plistShowingInNoneDesktop.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormLocX);
      node.InnerText = mainFormLocX.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormLocY);
      node.InnerText = mainFormLocY.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormWidth);
      node.InnerText = mainFormWidth.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormHeight);
      node.InnerText = mainFormHeight.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_speedFF);
      node.InnerText = speedFF.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_speedRW);
      node.InnerText = speedRW.ToString();
    }

    static private void SaveFormPlist()
    {
      // formPList
      XmlNode node = nodeSectionFormPList.SelectSingleNode(SettingName_repeatPlayback);
      node.InnerText = ((int)repeatPlayback).ToString();
      node = nodeSectionFormPList.SelectSingleNode(SettingName_sortBy);
      node.InnerText = ((int)sortBy).ToString();
      node = nodeSectionFormPList.SelectSingleNode(SettingName_selectedPListBtn);
      node.InnerText = ((int)selectedPListBtn).ToString();
      node = nodeSectionFormPList.SelectSingleNode(SettingName_formPlistWidth);
      node.InnerText = formPlistWidth.ToString();
      node = nodeSectionFormPList.SelectSingleNode(SettingName_formPlistHeight);
      node.InnerText = formPlistHeight.ToString(); 
    }

    static private void SaveGeneralSettings()
    {
      // generalSettings
      XmlNode node = nodeSectionGeneralSettings.SelectSingleNode(SettingName_lang);
      node.InnerText = lang;
      node = nodeSectionGeneralSettings.SelectSingleNode(SettingName_snapSavePath);
      node.InnerText = snapSavePath;
    }

    static private void SaveSubtitleSettings()
    {
      // subtitleSettings
      XmlNode node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_fontSize);
      node.InnerText = fontSize.ToString();
      node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_fontPos);
      node.InnerText = fontPos.ToString();
      node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_fontColor);
      node.InnerText = fontColor.ToString();
      node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_fontBorderColor);
      node.InnerText = fontBorderColor.ToString();
      node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_bold);
      node.InnerText = bold.ToString();
      node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_italic);
      node.InnerText = italic.ToString();
      node = nodeSectionSubtitleSettings.SelectSingleNode(SettingName_overAssOrig);
      node.InnerText = overAssOrig.ToString();
    }

    static private void SavePlistSettings()
    {
      // PlistSettings
      XmlNode node = nodeSectionPlistSettings.SelectSingleNode(SettingName_updatePlistAfterLaunch);
      node.InnerText = updatePlistAfterLaunch.ToString();
      node = nodeSectionPlistSettings.SelectSingleNode(SettingName_autoAddFolderToPlist);
      node.InnerText = autoAddFolderToPlist.ToString();
      node = nodeSectionPlistSettings.SelectSingleNode(SettingName_deleteFileDirectly);
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
      if (!bLoaded)
        return;
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
      // other
      volume = volumeDefault;
      mute = muteDefault;
      maxed = maxedDefault;
      plistShowingInNoneDesktop = plistShowingInNoneDesktopDefault;
      mainFormLocX = mainFormLocXDefault;
      mainFormLocY = mainFormLocYDefault;
      mainFormWidth = mainFormWidthDefault;
      mainFormHeight = mainFormHeightDefault;

      // plistfrom
      repeatPlayback = repeatPlaybackDefault;
      sortBy = sortByDefault;
      selectedPListBtn = selectedPListBtnDefault;
      formPlistWidth = formPlistWidthDefault;
      formPlistHeight = formPlistHeightDefault;

      // generalSettings
      lang = langDefault;
      snapSavePath = snapSavePathDefault;

      // subtitleSettings
      fontSize = fontSizeDefault;
      fontPos = fontPosDefault;
      fontColor = fontColorDefault;
      fontBorderColor = fontBorderColorDefault;
      bold = boldDefault;
      italic = italicDefault;
      overAssOrig = overAssOrigDefault;

      // plistSettings
      updatePlistAfterLaunch = updatePlistAfterLaunchDefault;
      autoAddFolderToPlist = autoAddFolderToPlistDefault;
      deleteFileDirectly = deleteFileDirectlyDefault;
    }
  }
}
