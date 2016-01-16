using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPlayer
{
  class UiLang
  {
    public static string langEnglish = "English";
    public static string langChinese = "中文";

    // Common
    public static string rabbitPlayer;
    public static string yes;
    public static string no;
    public static string pathNotFound;
    public static string noPreFileInPlist;
    public static string noNextFileInPlist;
    public static string btnBrowse;
    public static string msgAnotherProcessUsingTheFile;
    public static string msgCannotPlay;
    public static string msgWndClosedBySfApp;
    public static string msgSetAsDefaultFailed;
    public static string labelFeedback;

    // MainForm
    public static string contextMenuSubtitles;
    public static string contextMenuAudios;
    public static string contextMenuChapters;
    public static string contextMenuAddSubtitle;
    public static string contextMenuHideSubtitle;
    public static string contextMenuChapter;
    public static string contextMenuSnapshot;
    public static string contextMenuPlayerSettings;
    public static string buttonOpenFile;

    // FormSettings    
    public static string labelSettings;
    public static string labelGeneral;
    public static string labelSubtitle;
    public static string labelAV;
    public static string labelPlist;

    // PanelGeneral
    public static string uiLangLabel;
    public static string labelSnapSavePath;
    public static string buttonSetAsDefaultPlayer;
    public static string btnRestoreFactory;

    // PanelSubtitle
    public static string labelSubtitleSize;
    public static string labelSubtitlePos;
    public static string labelSubtitleColor;
    public static string labelSubtitleBorderColor;
    public static string labelSubtitleBold;
    public static string labelSubtitleItalic;
    public static string labelSubtitleOverAssOrig;
    public static string textBoxSubNotice;

    // PanelPlist
    public static string checkBoxUpdatePlistAfterLaunch;
    public static string checkBoxAutoAddFolderToPlist;
    public static string checkBoxDeleteFileDirectly;

    // FormBottomBar
    public static string speedDisplay;

    // FormPlaylist    
    public static string btnPlaylist;
    public static string btnHistory;
    public static string labelRepeatPlayback;
    public static string ComboBoxRepeatNone;
    public static string ComboBoxRepeatOne;
    public static string ComboBoxRepeatAll;
    public static string labelSortBy;
    public static string ComboBoxSortByCreatedTimeUp;
    public static string ComboBoxSortByCreatedTimeDown;
    public static string ComboBoxSortByFileNameUp;
    public static string ComboBoxSortByFileNameDown;
    public static string ComboBoxSortByDurationUp;
    public static string ComboBoxSortByDurationDown;
    public static string messageToSelectItem;
    public static string delete;
    public static string update;
    public static string markAsFinished;
    public static string PlistFileDeleteWarning; 

    // MediaInfo
    public static string labelDetailsTimeWatched;
    public static string labelDetailsDuration;
    public static string labelDetailsCreationTime;
    public static string labelDetailsUrl;
    public static string labelDetailsFinished;
    public static string labelMediainfo;
    public static string labelDetailsFileSize;
    public static string mediaInfoBitrate;
    public static string mediaInfoVideoAspectRatio;
    public static string mediaInfoVideoHeight;
    public static string mediaInfoVideoWidth;
    public static string mediaInfoCodecName;
    public static string mediaInfoAudioChannels;
    public static string mediaInfoAudioSamplerate;
    public static string mediaInfoAudioBitspersample;
    public static string mediaInfoAudioLanguage;
    public static string mediaInfoName;
    public static string mediaInfoVideo;
    public static string mediaInfoAudio;
    public static string mediaInfoSubtitle;

    public static void SetLang(string uiLang)
    {
      Archive.lang = uiLang;
      switch(uiLang)
      {
        case "English":
          SetEnglish();
          break;
        case "中文":
          SetChinese();
          break;
      }
    }

    private static void SetEnglish()
    {
      rabbitPlayer = "RabbitPlayer";
      yes = "Yes";
      no = "No";
      pathNotFound = "Can not find this source. It may be deleted or renamed or moved... Source path is:";
      noPreFileInPlist = "No previous file in playlist";
      noNextFileInPlist = "No next file in playlist";
      btnBrowse = "Browse";
      msgAnotherProcessUsingTheFile = "Another process using the file, so can not delete it";
      msgCannotPlay = "Can not playback this file";
      msgWndClosedBySfApp = "RPlayer's sub window is closed by some antivirus in misjudge way."
      + "Pelease set your antivirus to allow RPlayer's subwindow";
      msgSetAsDefaultFailed = "Associate media file failed. This is may caused by some antivirus."
      + "If you want RabbitPlayer to be the default MediaPlayer, please restart RabbitPlayer,"
      + "and allow it to modify all registry when your antivirus ask you."
      + "If you do not want RabbitPlayer as your default MediaPlayer,"
      + "you can go to settings->general to change setting.";
      labelFeedback = "Feedback";

      contextMenuSubtitles = "Subtitles";
      contextMenuAudios = "Audios";
      contextMenuChapters = "Chapters";
      contextMenuAddSubtitle = "Add Subtitle";
      contextMenuHideSubtitle = "Hide Subtitle";
      contextMenuChapter = "Chapter";
      contextMenuSnapshot = "Snapshot";
      contextMenuPlayerSettings = "Player Settings";
      buttonOpenFile = "Open File";

      labelSettings = "Settings";
      labelGeneral = "General";
      labelSubtitle = "Subtitle";
      labelAV = "AudioVideo";
      labelPlist = "Playlist";

      uiLangLabel = "UI Language";
      labelSnapSavePath = "Snapshot Save Path";
      buttonSetAsDefaultPlayer = "Set as default player";
      btnRestoreFactory = "Restore factory settings";

      labelSubtitleSize = "Size";
      labelSubtitlePos = "Position";
      labelSubtitleColor = "Subtitle Color";
      labelSubtitleBorderColor = "Border Color";
      labelSubtitleBold = "Bold";
      labelSubtitleItalic = "Italic";
      labelSubtitleOverAssOrig = "Over Ass Original Settings";
      textBoxSubNotice = "Notice: picture subtitle can not be adjusted";

      checkBoxUpdatePlistAfterLaunch = "Auto update playlist after player launch";
      checkBoxAutoAddFolderToPlist = "Auto add playing folder to playlist";
      checkBoxDeleteFileDirectly = "Delete plist file directly without asking";

      btnPlaylist = "Playlist";
      btnHistory = "Histroy";
      labelRepeatPlayback = "Repeat";
      ComboBoxRepeatNone = "No Repeat";
      ComboBoxRepeatOne = "Repeat One";
      ComboBoxRepeatAll = "Repeat All";
      labelSortBy = "Sort By";
      ComboBoxSortByCreatedTimeUp = "Created Time Up";
      ComboBoxSortByCreatedTimeDown = "Created Time Down";
      ComboBoxSortByFileNameUp = "File Name Up";
      ComboBoxSortByFileNameDown = "File Name Down";
      ComboBoxSortByDurationUp = "Duration Up";
      ComboBoxSortByDurationDown = "Duration Down";
      messageToSelectItem = "Please select the item that you want to delete first";
      delete = "Delete";
      update = "Update";
      markAsFinished = "Mark as finished";
      PlistFileDeleteWarning = @"
Warning: This will also delete the source file.
(delete playlist folder does not delete source folder)

Are you still want to delete it?";

      labelDetailsTimeWatched = "Time Watched:";
      labelDetailsDuration = "Duration:";
      labelDetailsCreationTime = "CreationTime:";
      labelDetailsUrl = "Url:";
      labelDetailsFinished = "Finished";
      labelMediainfo = "MediaInfo";
      labelDetailsFileSize = "File Size: ";
      mediaInfoBitrate = "Bitrate: ";
      mediaInfoVideoAspectRatio = "AspectRatio: ";
      mediaInfoVideoHeight = "Height: ";
      mediaInfoVideoWidth = "Width: ";
      mediaInfoCodecName = "CodecName: ";
      mediaInfoAudioChannels = "Channels: ";
      mediaInfoAudioSamplerate = "Samplerate: ";
      mediaInfoAudioBitspersample = "Bitspersample: ";
      mediaInfoAudioLanguage = "Language: ";
      mediaInfoName = "Name: ";
      mediaInfoVideo = "Video";
      mediaInfoAudio = "Audio";
      mediaInfoSubtitle = "Subtitle";

      speedDisplay = "Speed: X";
    }

    private static void SetChinese()
    {
      rabbitPlayer = "兔子影音";
      yes = "是的";
      no = "不了";
      pathNotFound = "无法找到该源。它可能已被删除或改名或移动... 源路径为：";
      noPreFileInPlist = "播放列表中没有上一个文件";
      noNextFileInPlist = "播放列表中没有下一个文件";
      btnBrowse = "浏览";
      msgAnotherProcessUsingTheFile = "另外一个软件正在使用该文件，所以无法删除它";
      msgCannotPlay = "无法播放该文件";
      msgWndClosedBySfApp = "您电脑上的安全软件错误的屏蔽了兔子影音的子窗体，例如360安全卫士。"
        + "您可以打开它的360弹窗拦截器，设置为不拦截兔子影音的窗体!";
      msgSetAsDefaultFailed = "无法注册为默认播放器。一般是由于一些安全软件导致的。"
        + "如果您想让兔子影音成为您的默认播放器，请重新打开本软件，并且当您的安全软件询问您是否允许兔子影音修改"
        + "注册表时，您选择允许所有操作。";
      labelFeedback = "反馈";

      contextMenuSubtitles = "字幕";
      contextMenuAudios = "音轨";
      contextMenuChapters = "章节";
      contextMenuAddSubtitle = "添加外挂字幕";
      contextMenuHideSubtitle = "隐藏字幕";
      contextMenuChapter = "章节";
      contextMenuSnapshot = "快照";
      contextMenuPlayerSettings = "播放器设置";
      buttonOpenFile = "打开文件";

      labelSettings = "设置";
      labelGeneral = "一般";
      labelSubtitle = "字幕";
      labelAV = "音视频";
      labelPlist = "播放列表";

      uiLangLabel = "界面语言";
      labelSnapSavePath = "快照保存路径";
      buttonSetAsDefaultPlayer = "设置为系统默认播放器";
      btnRestoreFactory = "恢复出厂设置";

      labelSubtitleSize = "大小";
      labelSubtitlePos = "位置";
      labelSubtitleColor = "字幕颜色";
      labelSubtitleBorderColor = "边框颜色";
      labelSubtitleBold = "粗体";
      labelSubtitleItalic = "斜体";
      labelSubtitleOverAssOrig = "替换掉Ass字幕的原始设置";
      textBoxSubNotice = "小提示：图形字幕无法被调整";

      checkBoxUpdatePlistAfterLaunch = "播放器启动后自动更新播放列表";
      checkBoxAutoAddFolderToPlist = "自动将新播放的文件夹加入到播放列表中";
      checkBoxDeleteFileDirectly = "直接删除播放列表中的文件，不用询问";

      btnPlaylist = "播放列表";
      btnHistory = "播放历史";
      labelRepeatPlayback = "循环播放";
      ComboBoxRepeatNone = "不循环";
      ComboBoxRepeatOne = "单个循环";
      ComboBoxRepeatAll = "列表循环";
      labelSortBy = "排序按";
      ComboBoxSortByCreatedTimeUp = "创建时间 升序";
      ComboBoxSortByCreatedTimeDown = "创建时间 降序";
      ComboBoxSortByFileNameUp = "文件名称 升序";
      ComboBoxSortByFileNameDown = "文件名称 降序";
      ComboBoxSortByDurationUp = "时长 升序";
      ComboBoxSortByDurationDown = "时长 降序";
      messageToSelectItem = "请先选择要删除的项";
      delete = "删除";
      update = "更新";
      markAsFinished = "标记为已看完";
      PlistFileDeleteWarning = @"
警告: 这将同时删除源文件。
(删除播放列表中的文件夹不会删除源文件夹)

你仍然要删除它吗？";

      labelDetailsTimeWatched = "上次看到:";
      labelDetailsDuration = "总时长:";
      labelDetailsCreationTime = "创建时间:";
      labelDetailsUrl = "全路径:";
      labelDetailsFinished = "已看完";
      labelMediainfo = "媒体信息";
      labelDetailsFileSize = "文件大小:";
      mediaInfoBitrate = "比特率: ";
      mediaInfoVideoAspectRatio = "纵横比: ";
      mediaInfoVideoHeight = "高: ";
      mediaInfoVideoWidth = "宽: ";
      mediaInfoCodecName = "编码格式: ";
      mediaInfoAudioChannels = "声道: ";
      mediaInfoAudioSamplerate = "采样率: ";
      mediaInfoAudioBitspersample = "音频位数: ";
      mediaInfoAudioLanguage = "语言: ";
      mediaInfoName = "名称: ";
      mediaInfoVideo = "视频";
      mediaInfoAudio = "音频";
      mediaInfoSubtitle = "字幕";

      speedDisplay = "速度: X";
    }
  }
}
