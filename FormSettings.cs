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
    public partial class FormSettings : Form
    {
        public enum enumSettingFormType { regular,subtitle,av}

        private bool m_bShowing = false;
        public MainForm m_mainForm;
        private bool m_bTopBarMouseDown = false;
        private Point m_TopBarMouseDownPos;

        public FormSettings(MainForm mainForm)
        {
          m_mainForm = mainForm;
            InitializeComponent();
            SetUiLange();
            try
            {
                label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
            }
            catch
            {
                label_settingsClose.Text = "close";
            }
        }

        private void ConfigByArchive()
        {
          comboBox_uiLang.Items.Clear();
          comboBox_uiLang.Items.Add(UiLang.langEnglish);
          comboBox_uiLang.Items.Add(UiLang.langChinese);
          comboBox_uiLang.SelectedItem = Archive.lang;
          comboBox_uiLang.SelectedIndexChanged += comboBox_uiLang_SelectedIndexChanged;
          checkBox_updatePlistAfterLaunch.Checked = Archive.updatePlistAfterLaunch;
          checkBox_addPlayingFolderToPlist.Checked = Archive.autoAddFolderToPlist;
          checkBox_deleteFileDirectly.Checked = Archive.deleteFileDirectly;

          if (Archive.snapSavePath == "")
            Archive.snapSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          textBox_snapSavePath.Text = Archive.snapSavePath;
        }

        private void comboBox_uiLang_SelectedIndexChanged(object sender, EventArgs e)
        {
          UiLang.SetLang(comboBox_uiLang.SelectedItem as string);

          m_mainForm.SetAllUiLange();
        }

        public void SetAllUiLange()
        {
          SetUiLange();
        }

        private void SetUiLange()
        {
          label_settings.Text = UiLang.labelSettings;
          label_regular.Text = UiLang.labelGeneral;
          label_subtitle.Text = UiLang.labelSubtitle;
          label_AV.Text = UiLang.labelAV;
          label_plist.Text = UiLang.labelPlist;

          label_uiLang.Text = UiLang.uiLangLabel;
          checkBox_updatePlistAfterLaunch.Text = UiLang.checkBoxUpdatePlistAfterLaunch;
          checkBox_addPlayingFolderToPlist.Text = UiLang.checkBoxAutoAddFolderToPlist;
          checkBox_deleteFileDirectly.Text = UiLang.checkBoxDeleteFileDirectly;

          label_snapSavePath.Text = UiLang.labelSnapSavePath;
          button_snapSavePath.Text = UiLang.btnBrowse;
        }

        public void ShowForm(enumSettingFormType SettingType)
        {
          if (m_bShowing)
            return;

          ConfigByArchive();

          m_bShowing = true;
          this.Show();
          switch (SettingType)
          {
            case enumSettingFormType.regular:
              showRegularPanel();
              break;
            case enumSettingFormType.subtitle:
              showSubtitlePanel();
              break;
            case enumSettingFormType.av:
              showAvPanel();
              break;
          }
          this.TopMost = true;
        }

        private void HideForm()
        {
          label_regular.BackColor = Color.Transparent;
          label_subtitle.BackColor = Color.Transparent;
          label_AV.BackColor = Color.Transparent;
          label_plist.BackColor = Color.Transparent;
          this.Hide();
          m_bShowing = false;
          this.TopMost = false;
          m_mainForm.BringToFront();
        }

        private void label_settingsClose_Click(object sender, EventArgs e)
        {
          HideForm();
        }

        private void FormSettings_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void FormSettings_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void FormSettings_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void label_settingsClose_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
            }
            catch { }
        }

        private void label_settingsClose_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_settingsClose.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
            }
            catch { }
        }

        private void panel_topBar_MouseDown(object sender, MouseEventArgs e)
        {
          m_bTopBarMouseDown = true;
          m_TopBarMouseDownPos = e.Location;
        }

        private void panel_topBar_MouseMove(object sender, MouseEventArgs e)
        {
          if (m_bTopBarMouseDown)
          {
            int xDiff = e.X - m_TopBarMouseDownPos.X;
            int yDiff = e.Y - m_TopBarMouseDownPos.Y;
            this.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
          }
        }

        private void panel_topBar_MouseUp(object sender, MouseEventArgs e)
        {
          m_bTopBarMouseDown = false;
        }

        private void showRegularPanel()
        {
            if (label_regular.BackColor == Color.DodgerBlue)
                return;
            label_regular.BackColor = Color.DodgerBlue;
            label_subtitle.BackColor = Color.Transparent;
            label_AV.BackColor = Color.Transparent;
            label_plist.BackColor = Color.Transparent;

            panel_general.BringToFront();
        }

        private void showSubtitlePanel()
        {
            if (label_subtitle.BackColor == Color.DodgerBlue)
                return;
            label_regular.BackColor = Color.Transparent;
            label_subtitle.BackColor = Color.DodgerBlue;
            label_AV.BackColor = Color.Transparent;
            label_plist.BackColor = Color.Transparent;

            panel_subtitle.BringToFront();
        }

        private void showAvPanel()
        {
            if (label_AV.BackColor == Color.DodgerBlue)
                return;
            label_regular.BackColor = Color.Transparent;
            label_subtitle.BackColor = Color.Transparent;
            label_AV.BackColor = Color.DodgerBlue;
            label_plist.BackColor = Color.Transparent;

            panel_av.BringToFront();
        }

        private void showPlistPanel()
        {
          if (label_plist.BackColor == Color.DodgerBlue)
            return;
          label_regular.BackColor = Color.Transparent;
          label_subtitle.BackColor = Color.Transparent;
          label_AV.BackColor = Color.Transparent;
          label_plist.BackColor = Color.DodgerBlue;

          panel_plist.BringToFront();
        }

        private void label_regular_Click(object sender, EventArgs e)
        {
            showRegularPanel();            
        }

        private void label_regular_MouseEnter(object sender, EventArgs e)
        {
            if (label_regular.BackColor != Color.DodgerBlue)
                label_regular.BackColor = Color.Silver;
        }

        private void label_regular_MouseLeave(object sender, EventArgs e)
        {
            if (label_regular.BackColor != Color.DodgerBlue)
                label_regular.BackColor = Color.Transparent;
        }

        private void label_subtitle_Click(object sender, EventArgs e)
        {
            showSubtitlePanel();
        }

        private void label_subtitle_MouseEnter(object sender, EventArgs e)
        {
            if (label_subtitle.BackColor != Color.DodgerBlue)
                label_subtitle.BackColor = Color.Silver;
        }

        private void label_subtitle_MouseLeave(object sender, EventArgs e)
        {
            if (label_subtitle.BackColor != Color.DodgerBlue)
                label_subtitle.BackColor = Color.Transparent;
        }

        private void label_AV_Click(object sender, EventArgs e)
        {
            showAvPanel();
        }

        private void label_AV_MouseEnter(object sender, EventArgs e)
        {
            if (label_AV.BackColor != Color.DodgerBlue)
                label_AV.BackColor = Color.Silver;
        }

        private void label_AV_MouseLeave(object sender, EventArgs e)
        {
            if (label_AV.BackColor != Color.DodgerBlue)
                label_AV.BackColor = Color.Transparent;
        }

        private void label_plist_Click(object sender, EventArgs e)
        {
          showPlistPanel();
        }

        private void label_plist_MouseEnter(object sender, EventArgs e)
        {
          if (label_plist.BackColor != Color.DodgerBlue)
            label_plist.BackColor = Color.Silver;
        }

        private void label_plist_MouseLeave(object sender, EventArgs e)
        {
          if (label_plist.BackColor != Color.DodgerBlue)
            label_plist.BackColor = Color.Transparent;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
          HideForm();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
          HideForm();
        }

        private void checkBox_updatePlistAfterLaunch_CheckedChanged(object sender, EventArgs e)
        {
          Archive.updatePlistAfterLaunch = checkBox_updatePlistAfterLaunch.Checked;
        }

        private void checkBox_addPlayingFolderToPlist_CheckedChanged(object sender, EventArgs e)
        {
          Archive.autoAddFolderToPlist = checkBox_addPlayingFolderToPlist.Checked;
        }

        private void checkBox_deleteFileDirectly_CheckedChanged(object sender, EventArgs e)
        {
          Archive.deleteFileDirectly = checkBox_deleteFileDirectly.Checked;
        }

        private void button_snapSavePath_Click(object sender, EventArgs e)
        {
          FolderBrowserDialog fbd = new FolderBrowserDialog();
          DialogResult result = fbd.ShowDialog();

          Archive.snapSavePath = fbd.SelectedPath;
          textBox_snapSavePath.Text = Archive.snapSavePath; 
        }
    }
}
