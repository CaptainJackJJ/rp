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
  public partial class FormTopBar : Form
  {
    private const int m_nTopBarButtonsMargin = 20;
    private const int m_nTopBarButtonsWidth = 13;
    private MainForm m_mainForm;
    private Point m_FormMouseDownPos;
    private bool m_bFormMouseDown = false;

    public FormTopBar(MainForm mainForm)
    {     
      InitializeComponent();
      SetUiLange();
      this.ShowInTaskbar = false;
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
        label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");
      }
      catch
      {
        this.BackColor = Color.Gainsboro;
        label_settings.Text = "settings";
        label_Close.Text = "close";
        label_Max.Text = "max";
        label_Min.Text = "min";
      }
      m_mainForm = mainForm;
    }

    public void SetAllUiLange()
    {
      SetUiLange();
    }

    private void SetUiLange()
    {
      label_logo.Text = UiLang.rabbitPlayer;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      m_mainForm.TriggerVolumeOnMouseWheel(e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (m_mainForm.HandleCmdKey(keyData))
        return true;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    public void setFileName(string str)
    {
      label_fileName.Text = str;
    }

    private void FormTopBar_Resize(object sender, EventArgs e)
    {
      label_Close.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin - m_nTopBarButtonsWidth + 10,
              label_Close.Location.Y);
      label_Max.Location =
          new Point(this.Size.Width - m_nTopBarButtonsMargin * 2 - m_nTopBarButtonsWidth * 2 + 10,
              label_Max.Location.Y);
      label_Min.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 3 - m_nTopBarButtonsWidth * 3 + 10,
              label_Min.Location.Y);
      label_settings.Location =
         new Point(this.Size.Width - m_nTopBarButtonsMargin * 4 - m_nTopBarButtonsWidth * 4 + 10,
              label_settings.Location.Y);
      label_curTime.Location =
         new Point(label_settings.Location.X - label_curTime.Width - 5,label_curTime.Location.Y);
      label_fileName.Size =
        new Size(this.Width - (this.Width - label_curTime.Location.X + 25) * 2, label_fileName.Height);
    }

    private void label_Min_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\minFocus.png");
      }
      catch { }
    }

    private void label_Min_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Min.Image = Image.FromFile(Application.StartupPath + @"\pic\min.png");
      }
      catch { }
    }

    private void label_Min_Click(object sender, EventArgs e)
    {
      m_mainForm.WindowState = FormWindowState.Minimized;
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      m_mainForm.ClickClose();
    }

    private void label_Close_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\closeFocus.png");
      }
      catch { }
    }

    private void label_Close_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      }
      catch { }
    }

    private void label_Max_Click(object sender, EventArgs e)
    {
      m_mainForm.ClickMax();
    }

    private void label_Max_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\maxFocus.png");
      }
      catch { }
    }

    private void label_Max_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_Max.Image = Image.FromFile(Application.StartupPath + @"\pic\max.png");
      }
      catch { }
    }

    private void label_settings_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settingsFocus.png");
      }
      catch { }
    }

    private void label_settings_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        label_settings.Image = Image.FromFile(Application.StartupPath + @"\pic\settings.png");
      }
      catch { }
    }

    private void label_settings_Click(object sender, EventArgs e)
    {
      m_mainForm.ShowFormSettings(FormSettings.enumSettingFormType.regular);
    }

    private void FormTopBar_MouseDown(object sender, MouseEventArgs e)
    {
      m_bFormMouseDown = true;
      m_FormMouseDownPos = e.Location;
    }

    private void FormTopBar_MouseMove(object sender, MouseEventArgs e)
    {
      if (m_bFormMouseDown)
      {
        int xDiff = e.X - m_FormMouseDownPos.X;
        int yDiff = e.Y - m_FormMouseDownPos.Y;
        m_mainForm.Location = new Point(this.Location.X + xDiff, this.Location.Y + yDiff);
      }
    }

    private void FormTopBar_MouseUp(object sender, MouseEventArgs e)
    {
      m_bFormMouseDown = false;
    }

    public void ShowCurrentTime(bool bShow)
    {
      label_curTime.Text = "";
      if (bShow)
        timer1.Start();
      else
        timer1.Stop();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      label_curTime.Text = DateTime.Now.ToString("HH : mm : ss");
    }

    private void label_logo_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start(m_mainForm.m_strRabbitSiteUrl);
    }

    private void label_logo_MouseEnter(object sender, EventArgs e)
    {
      label_logo.ForeColor = Color.DodgerBlue;
    }

    private void label_logo_MouseLeave(object sender, EventArgs e)
    {
      label_logo.ForeColor = Color.White;
    }
  }
}
