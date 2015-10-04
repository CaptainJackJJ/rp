using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPlayer
{
  class UiLang
  {
    public enum enumUiLang { none, english, chinese }

    public static string comboBoxLangEnglish = "English";
    public static string comboBoxLangChinese = "中文";

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

    private static enumUiLang m_uiLang = enumUiLang.none;
    public static enumUiLang GetLang()
    {
      return m_uiLang;
    }
    public static void SetLang(enumUiLang uiLang)
    {
      if(m_uiLang == uiLang)
        return;
      m_uiLang = uiLang;
      switch(uiLang)
      {
        case enumUiLang.english:
          SetEnglish();
          break;
        case enumUiLang.chinese:
          SetChinese();
          break;
      }
    }

    private static void SetEnglish()
    {      
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

      speedDisplay = "Speed: X";
    }

    private static void SetChinese()
    {      
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
      speedDisplay = "速度: X";
    }
  }
}
