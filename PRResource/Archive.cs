using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

namespace PRResource
{ 
  class Archive
  {
    #region fields
    static private bool bLoaded = false;
    static private string xmlFilePath;
    static private XmlDocument xml = new XmlDocument();
    static private XmlNode nodeArchive, nodeSectionOthers;
    static private string xmlFileName = "archiveRes.xml";
    static private string sectionOthers = "others";

    // others
    static public bool maxed;
    static public int mainFormLocX, mainFormLocY, mainFormWidth, mainFormHeight;

    static private readonly string SettingName_maxed = "maxed";
    static private readonly string SettingName_mainFormLocX = "mainFormLocX";
    static private readonly string SettingName_mainFormLocY = "mainFormLocY";
    static private readonly string SettingName_mainFormWidth = "mainFormWidth";
    static private readonly string SettingName_mainFormHeight = "mainFormHeight";

    static private readonly bool maxedDefault = false;
    static public readonly int mainFormLocXDefault = -1, mainFormLocYDefault = -1,
      mainFormWidthDefault = 1024, mainFormHeightDefault = 720;

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

    static private void LoadOthers()
    {
      // others
      LoadNode(nodeSectionOthers, SettingName_maxed, out maxed, maxedDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormLocX,out mainFormLocX,mainFormLocXDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormLocY,out mainFormLocY,mainFormLocYDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormWidth,out mainFormWidth,mainFormWidthDefault);
      LoadNode(nodeSectionOthers,SettingName_mainFormHeight,out mainFormHeight,mainFormHeightDefault);
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

      LoadOthers();

      bLoaded = true;

      return bLoaded;
    }

    static private void SaveOthers()
    {
      // others
      XmlNode node = nodeSectionOthers.SelectSingleNode(SettingName_maxed);
      node.InnerText = maxed.ToString();
      
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormLocX);
      node.InnerText = mainFormLocX.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormLocY);
      node.InnerText = mainFormLocY.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormWidth);
      node.InnerText = mainFormWidth.ToString();
      node = nodeSectionOthers.SelectSingleNode(SettingName_mainFormHeight);
      node.InnerText = mainFormHeight.ToString();
    }

    static public void Save()
    {
      if (!bLoaded)
        return;
      SaveOthers();

      xml.Save(xmlFilePath + "\\" + xmlFileName);
    }
  }
}
