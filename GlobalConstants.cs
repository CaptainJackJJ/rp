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
      //static private readonly string strInfoRemoteHost = "http://downloads.sourceforge.net/project/piraterabbitplayer/";
      static private readonly string strInfoRemoteHost = "http://rabbitplayer.cn/";
      static public readonly string strInfoRemoteXmlUrl = strInfoRemoteHost + strInfoXmlRemoteName;
      static public readonly string strInfoMoreRemoteXmlUrl = strInfoRemoteHost + strInfoMoreXmlRemoteName;
      static public readonly string strInfoXmlLocalName = "infoLocal.xml";
      static public readonly string strInfoMoreXmlLocalName = "infoMoreLocal.xml";
      static public readonly string strDownloadedFolderName = "download";
      static public readonly string strInfoItemFolderRemoteUrl = strInfoRemoteHost + "info";
      static public readonly Color colorMainBG = Color.FromArgb(255, 66, 75, 92);
      static public readonly Color colorNormalText = Color.Snow;
      static public readonly Color colorBtnSelected = Color.DodgerBlue;
      static public readonly string strMoreInfoText = "更多";
      static public readonly Color colorMainBtnBG = Color.MediumPurple;
      static public readonly Color colorMainFormBG = Color.FromArgb(255,84, 175, 254);
      static public readonly string strChinaDl1 = "http://gaoqing.la/";
      static public readonly string strChinaDl2 = "http://www.chdw.org/";
      static public readonly string strChinaDl3 = "http://www.xiagaoqing.com/";
      static public readonly string strChinaOnline = "http://www.youku.com/";
      static public readonly string strOverseaDl = "http://www.rarbg.to";
      static public readonly string strSubtitle = "http://sub.makedie.me/";
      static public readonly string strOfficalWebsite = "http://rabbitplayer.cn/";
      static public readonly string strSetupSelfInfoXmlName = "setupSelfInfo.xml";
      static public readonly string strSetupSelfInfoRemoteUrl = "http://rabbitplayer.cn/" + strSetupSelfInfoXmlName;
      static public readonly string strLaunchTimesXmlName = "LaunchTimes.xml";
      static public readonly string strLaunchTimesRemoteUrl 
        = "http://downloads.sourceforge.net/project/piraterabbitplayer/" + strLaunchTimesXmlName;
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
