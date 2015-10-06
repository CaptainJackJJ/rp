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
        }


    }
}
