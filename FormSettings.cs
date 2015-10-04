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

        private bool m_bTopBarMouseDown = false;
        private Point m_TopBarMouseDownPos;
        FormSettingRegular m_FormSettingRegular;
        FormSettingSubtitle m_FormSettingSubtitle;
        FormSettingAv m_FormSettingAv;
        private bool m_bShowing = false;
        public MainForm m_mainForm;

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

            m_FormSettingRegular = new FormSettingRegular(this);
            m_FormSettingSubtitle = new FormSettingSubtitle(this);
            m_FormSettingAv = new FormSettingAv(this);
            this.AddOwnedForm(m_FormSettingRegular);
            this.AddOwnedForm(m_FormSettingSubtitle);
            this.AddOwnedForm(m_FormSettingAv);
        }

        public void SetAllUiLange()
        {
          SetUiLange();
          m_FormSettingRegular.SetAllUiLange();
          m_FormSettingSubtitle.SetAllUiLange();
          m_FormSettingAv.SetAllUiLange();
        }

        private void SetUiLange()
        {
          label_settings.Text = UiLang.labelSettings;
          label_regular.Text = UiLang.labelGeneral;
          label_subtitle.Text = UiLang.labelSubtitle;
          label_AV.Text = UiLang.labelAV;
        }

        public void ShowForm(enumSettingFormType SettingType)
        {
          if (m_bShowing)
            return;
          m_bShowing = true;
          this.Show();
          switch (SettingType)
          {
            case enumSettingFormType.regular:
              showRegularForm();
              break;
            case enumSettingFormType.subtitle:
              showSubtitleForm();
              break;
            case enumSettingFormType.av:
              showAvForm();
              break;
          }
          this.TopMost = true;
        }

        private void HideForm()
        {
          label_regular.BackColor = Color.Transparent;
          label_subtitle.BackColor = Color.Transparent;
          label_AV.BackColor = Color.Transparent;
          m_FormSettingAv.Hide();
          m_FormSettingSubtitle.Hide();
          m_FormSettingRegular.Hide();
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

                if (label_regular.BackColor == Color.DodgerBlue)
                {
                    m_FormSettingRegular.Location = new Point(this.Location.X + 100, this.Location.Y + 43);
                }
                else if (label_subtitle.BackColor == Color.DodgerBlue)
                {
                    m_FormSettingSubtitle.Location = new Point(this.Location.X + 100, this.Location.Y + 43);
                }
                else if (label_AV.BackColor == Color.DodgerBlue)
                {
                    m_FormSettingAv.Location = new Point(this.Location.X + 100, this.Location.Y + 43);
                }
            }
        }

        private void panel_topBar_MouseUp(object sender, MouseEventArgs e)
        {
            m_bTopBarMouseDown = false;
        }

        private void showRegularForm()
        {
            if (label_regular.BackColor == Color.DodgerBlue)
                return;
            label_regular.BackColor = Color.DodgerBlue;
            label_subtitle.BackColor = Color.Transparent;
            label_AV.BackColor = Color.Transparent;

            m_FormSettingSubtitle.Hide();
            m_FormSettingAv.Hide();
            m_FormSettingRegular.Show();
            m_FormSettingRegular.Location = new Point(this.Location.X + 100, this.Location.Y + 43);
        }

        private void showSubtitleForm()
        {
            if (label_subtitle.BackColor == Color.DodgerBlue)
                return;
            label_regular.BackColor = Color.Transparent;
            label_subtitle.BackColor = Color.DodgerBlue;
            label_AV.BackColor = Color.Transparent;

            m_FormSettingAv.Hide();
            m_FormSettingSubtitle.Show();
            m_FormSettingRegular.Hide();
            m_FormSettingSubtitle.Location = new Point(this.Location.X + 100, this.Location.Y + 43);
        }

        private void showAvForm()
        {
            if (label_AV.BackColor == Color.DodgerBlue)
                return;
            label_regular.BackColor = Color.Transparent;
            label_subtitle.BackColor = Color.Transparent;
            label_AV.BackColor = Color.DodgerBlue;

            m_FormSettingAv.Show();
            m_FormSettingSubtitle.Hide();
            m_FormSettingRegular.Hide();
            m_FormSettingAv.Location = new Point(this.Location.X + 100, this.Location.Y + 43);
        }

        private void label_regular_Click(object sender, EventArgs e)
        {
            showRegularForm();            
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
            showSubtitleForm();
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
            showAvForm();
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

        private void button_ok_Click(object sender, EventArgs e)
        {
          HideForm();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
          HideForm();
        }
    }
}
