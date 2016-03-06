using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace RPlayer
{
  class GlobalConstants
  {
    public class Common
    {
      static public readonly string strInfoXmlRemoteName = "infoRemote.xml";
      static public readonly string strInfoMoreXmlRemoteName = "infoMoreRemote.xml";
      //static private readonly string strRemoteHost = "http://downloads.sourceforge.net/project/piraterabbitplayer/";
      static private readonly string strRemoteHost = "http://rabbitplayer.cn/";
      static public readonly string strInfoRemoteXmlUrl = strRemoteHost + strInfoXmlRemoteName;
      static public readonly string strInfoMoreRemoteXmlUrl = strRemoteHost + strInfoMoreXmlRemoteName;
      static public readonly string strInfoXmlLocalName = "infoLocal.xml";
      static public readonly string strInfoMoreXmlLocalName = "infoMoreLocal.xml";
      static public readonly string strDownloadedFolderName = "download";
      static public readonly string strInfoItemFolderRemoteUrl = strRemoteHost + "info";
      static public readonly Color colorMainBG = Color.FromArgb(255, 66, 75, 92);
      static public readonly Color colorNormalText = Color.Snow;
      static public readonly Color colorBtnSelected = Color.DodgerBlue;
      static public readonly string strMoreInfoText = "更多";
      static public readonly Color colorMainBtnBG = Color.MediumPurple;
    }

    public class infoXml
    {
      static public readonly string strAttrVersion = "version";
      static public readonly string strAttrType = "type";
      static public readonly string strTypeValueTorrent = "torrent";
      static public readonly string strAttrTitle = "title";
      static public readonly string strElemDate = "date";
      static public readonly string strElemCasts = "casts";
      static public readonly string strElemLang = "lang";
      static public readonly string strAttrNew = "new";
      static public readonly string strElemImage = "image";
      static public readonly string strElemFile = "file";
      static public readonly string strAttrName = "name";
      static public readonly string strElemCategory = "category";
      static public readonly string strElemDesc = "desc";
      static public readonly string strCateTypeValueMoive = "moive";
    }
  }
}
