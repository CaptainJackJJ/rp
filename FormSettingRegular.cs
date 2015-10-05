using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPlayer
{
    public partial class FormSettingRegular : Form
    {
      private FormSettings m_formSettings;
        public FormSettingRegular(FormSettings formSettings)
        {
          m_formSettings = formSettings;
            InitializeComponent();
            SetUiLange();
            this.ShowInTaskbar = false;
            ConfigByArchive();
        }

        private void ConfigByArchive()
        {
          ConfigComboBoxUiLang();
        }

        private void ConfigComboBoxRepeatPlayback()
        {
          comboBox_repeatPlayback.Items.Clear();
          comboBox_repeatPlayback.Items.Add(UiLang.ComboBoxRepeatNone);
          comboBox_repeatPlayback.Items.Add(UiLang.ComboBoxRepeatOne);
          comboBox_repeatPlayback.Items.Add(UiLang.ComboBoxRepeatAll);
          comboBox_repeatPlayback.SelectedIndex = (int)Archive.repeatPlayback;
          comboBox_repeatPlayback.SelectedIndexChanged += comboBox_repeatPlayback_SelectedIndexChanged;
        }

        private void comboBox_repeatPlayback_SelectedIndexChanged(object sender, EventArgs e)
        {
          Archive.repeatPlayback = (Archive.enumRepeatPlayback)comboBox_repeatPlayback.SelectedIndex;
        }

        private void ConfigComboBoxUiLang()
        {
          comboBox_uiLang.Items.Add(UiLang.langEnglish);
          comboBox_uiLang.Items.Add(UiLang.langChinese);
          comboBox_uiLang.SelectedItem = Archive.lang;
          comboBox_uiLang.SelectedIndexChanged += comboBox_uiLang_SelectedIndexChanged;
        }

        private void comboBox_uiLang_SelectedIndexChanged(object sender, EventArgs e)
        {
          UiLang.SetLang(comboBox_uiLang.SelectedItem as string);

          m_formSettings.m_mainForm.SetAllUiLange();
        }

        public void SetAllUiLange()
        {
          SetUiLange();
        }

        private void SetUiLange()
        {
          label_uiLang.Text = UiLang.uiLangLabel;
          label_repeatPlayback.Text = UiLang.labelRepeatPlayback;
          ConfigComboBoxRepeatPlayback();
        }


    }
}
