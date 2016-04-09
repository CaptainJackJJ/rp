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
      static public string strChinaDl1 = "http://www.cangyunge.com/";
      static public string strChinaDl2 = "http://www.xiagaoqing.com/";
      static public readonly string strLocalPlay = "local";
      static public string strChinaOnline = "http://www.youku.com/";
      static public string strOverseaDl = "http://www.rarbg.to";
      static public string strSubtitle = "http://sub.makedie.me/";
      static public readonly string strOfficalWebsite = "http://prplayer.com/";
      static public readonly string strSetupSelfInfoXmlName = "setupSelfInfo.xml";
      static public readonly string strSetupSelfInfoRemoteUrl = "http://prplayer.com/" + strSetupSelfInfoXmlName;
      static public readonly string strLaunchTimesXmlName = "LaunchTimes.xml";
      static public readonly string strLaunchTimesRemoteUrl 
        = "http://downloads.sourceforge.net/project/piraterabbitplayer/" + strLaunchTimesXmlName;
      static public readonly string strAppUpdateTimesXmlName = "AppUpdateTimes.xml";
      static public readonly string strAppUpdateTimesRemoteUrl
        = "http://downloads.sourceforge.net/project/piraterabbitplayer/" + strAppUpdateTimesXmlName;
      static public readonly Color colorSelectedNavBtn = Color.DarkSalmon;

      static public readonly string strExtFilters = "*.mp4|*.mkv|*.avi|*.wmv|*.rm|*.rmvb|*.m4v|*.3g2|*.3gp|*.mov|*.asf|*.m2v|*.mpg|*.mpeg|*.avc|*.flv|*.m2ts|*.h264|*.td";
     
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
