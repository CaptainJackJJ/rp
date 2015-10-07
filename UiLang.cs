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
    public static string delete;

    // MainForm
    public static string contextMenuSubtitles;
    public static string contextMenuAudios;
    public static string contextMenuChapters;
    public static string contextMenuAddSubtitle;
    public static string contextMenuHideSubtitle;
    public static string contextMenuChapter;

    // FormSettings    
    public static string labelSettings;
    public static string labelGeneral;
    public static string labelSubtitle;
    public static string labelAV;

    // FormRegular
    public static string uiLangLabel;


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
    public static string ComboBoxSortByAddedTime;
    public static string ComboBoxSortByCreatedTime;
    public static string ComboBoxSortByFileName;
    public static string ComboBoxSortByFileSize;
    public static string messageToSelectItem;

    // FormPlaylistDetails
    public static string labelHistroyDetailsTimeWatched;
    public static string labelHistroyDetailsDuration;
    public static string labelHistroyDetailsUrl;
    public static string labelHistroyDetailsFinished;

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
      delete = "delete";

      contextMenuSubtitles = "Subtitles";
      contextMenuAudios = "Audios";
      contextMenuChapters = "Chapters";
      contextMenuAddSubtitle = "Add Subtitle";
      contextMenuHideSubtitle = "Hide Subtitle";
      contextMenuChapter = "Chapter";

      labelSettings = "Settings";
      labelGeneral = "General";
      labelSubtitle = "Subtitle";
      labelAV = "AudioVideo";

      uiLangLabel = "UI Language";

      btnPlaylist = "Playlist";
      btnHistory = "Histroy";
      labelRepeatPlayback = "Repeat";
      ComboBoxRepeatNone = "No Repeat";
      ComboBoxRepeatOne = "Repeat One";
      ComboBoxRepeatAll = "Repeat All";
      labelSortBy = "Sort By";
      ComboBoxSortByAddedTime = "Added Time";
      ComboBoxSortByCreatedTime = "Created Time";
      ComboBoxSortByFileName = "File Name";
      ComboBoxSortByFileSize = "File Size";
      messageToSelectItem = "Please select the item that you want to delete first";

      labelHistroyDetailsTimeWatched = "Time Watched:";
      labelHistroyDetailsDuration = "Duration:";
      labelHistroyDetailsUrl = "Url:";
      labelHistroyDetailsFinished = "Finished";

      speedDisplay = "Speed: X";
    }

    private static void SetChinese()
    {
      delete = "删除";

      contextMenuSubtitles = "字幕";
      contextMenuAudios = "音轨";
      contextMenuChapters = "章节";
      contextMenuAddSubtitle = "添加字幕";
      contextMenuHideSubtitle = "隐藏字幕";
      contextMenuChapter = "章节";

      labelSettings = "设置";
      labelGeneral = "一般";
      labelSubtitle = "字幕";
      labelAV = "音视频";

      uiLangLabel = "界面语言";

      btnPlaylist = "播放列表";
      btnHistory = "播放历史";
      labelRepeatPlayback = "循环播放";
      ComboBoxRepeatNone = "不循环";
      ComboBoxRepeatOne = "单个循环";
      ComboBoxRepeatAll = "列表循环";
      labelSortBy = "排序按";
      ComboBoxSortByAddedTime = "添加时间";
      ComboBoxSortByCreatedTime = "创建时间";
      ComboBoxSortByFileName = "文件名称";
      ComboBoxSortByFileSize = "文件大小";
      messageToSelectItem = "请先选择要删除的项";

      labelHistroyDetailsTimeWatched = "上次看到:";
      labelHistroyDetailsDuration = "总时长:";
      labelHistroyDetailsUrl = "全路径:";
      labelHistroyDetailsFinished = "已看完";

      speedDisplay = "速度: X";
    }
  }
}
