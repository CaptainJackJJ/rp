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
            InitComboBoxUiLang();
        }

        private void InitComboBoxUiLang()
        {
          int index = comboBox_uiLang.Items.Add(UiLang.comboBoxLangEnglish);
          if (UiLang.GetLang() == UiLang.enumUiLang.english)
            comboBox_uiLang.SelectedIndex = index;
          index = comboBox_uiLang.Items.Add(UiLang.comboBoxLangChinese);
          if (UiLang.GetLang() == UiLang.enumUiLang.chinese)
            comboBox_uiLang.SelectedIndex = index;
          comboBox_uiLang.SelectedIndexChanged += comboBox_uiLang_SelectedIndexChanged;
        }

        private void comboBox_uiLang_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (comboBox_uiLang.SelectedItem as string == UiLang.comboBoxLangEnglish)
          {
            UiLang.SetLang(UiLang.enumUiLang.english);
          }
          else if (comboBox_uiLang.SelectedItem as string == UiLang.comboBoxLangChinese)
          {
            UiLang.SetLang(UiLang.enumUiLang.chinese);
          }
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
