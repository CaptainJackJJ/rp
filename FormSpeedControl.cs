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
  public partial class FormSpeedControl : Form
  {
    private FormBottomBar m_formBottomBar;
    private bool m_bShowing = false;

    public FormSpeedControl(FormBottomBar formBottomBar)
    {
      m_formBottomBar = formBottomBar;
      InitializeComponent();
    }

    private void FormSpeedControl_Shown(object sender, EventArgs e)
    {
      try
      {
        label_Close.Image = Image.FromFile(Application.StartupPath + @"\pic\close.png");
      }
      catch { }
    }

    public void ShowMe(bool bFF)
    {
      if (m_bShowing)
        return;

      if(m_formBottomBar.IsSameSpeed(m_formBottomBar.Speed,1.0f)
        || m_formBottomBar.IsSameSpeed(m_formBottomBar.Speed, 0.0f))
      {
        float fSpeed;
        if (bFF)
          fSpeed = Archive.speedFF;
        else
          fSpeed = Archive.speedRW;
        int nSpeed = (int)fSpeed;

        int nSliderValue = 0;
        if (nSpeed == -16)
          nSliderValue = 0;
        else if (nSpeed == -8)
          nSliderValue = 1;
        else if (nSpeed == -4)
          nSliderValue = 2;
        else if (nSpeed == -2)
          nSliderValue = 3;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 0.0f))
          nSliderValue = 4;
        else if (m_formBottomBar.IsSameSpeed(fSpeed,0.5f))
          nSliderValue = 5;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 0.6f))
          nSliderValue = 6;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 0.7f))
          nSliderValue = 7;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 0.8f))
          nSliderValue = 8;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 0.9f))
          nSliderValue = 9;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 1.0f))
          nSliderValue = 10;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 1.1f))
          nSliderValue = 11;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 1.2f))
          nSliderValue = 12;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 1.3f))
          nSliderValue = 13;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 1.4f))
          nSliderValue = 14;
        else if (m_formBottomBar.IsSameSpeed(fSpeed, 1.5f))
          nSliderValue = 15;
        else if (nSpeed == 2)
          nSliderValue = 16;
        else if (nSpeed == 4)
          nSliderValue = 17;
        else if (nSpeed == 8)
          nSliderValue = 18;
        else if (nSpeed == 16)
          nSliderValue = 19;
        else if (nSpeed == 32)
          nSliderValue = 20;

        colorSlider_speedProcess.Value = nSliderValue;   
      }

      Show();
      m_bShowing = true;
    }

    public void HideMe()
    {
      Hide();
      m_bShowing = false;
    }

    private void label_Close_Click(object sender, EventArgs e)
    {
      HideMe();
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

    private void colorSlider_speedProcess_ValueChanged(object sender, EventArgs e)
    {
      int nSliderValue = colorSlider_speedProcess.Value;
      float fSpeed = 1f;
      switch(nSliderValue)
      {
        case 0:
          fSpeed = -16.0f;
          break;
        case 1:
          fSpeed = -8.0f;
          break;
        case 2:
          fSpeed = -4.0f;
          break;
        case 3:
          fSpeed = -2.0f;
          break;
        case 4:
          fSpeed = 0.0f;
          break;
        case 5:
          fSpeed = 0.5f;
          break;
        case 6:
          fSpeed = 0.6f;
          break;
        case 7:
          fSpeed = 0.7f;
          break;
        case 8:
          fSpeed = 0.80f;
          break;
        case 9:
          fSpeed = 0.90f;
          break;
        case 10:
          fSpeed = 1.0f;
          break;
        case 11:
          fSpeed = 1.1f;
          break;
        case 12:
          fSpeed = 1.2f;
          break;
        case 13:
          fSpeed = 1.3f;
          break;
        case 14:
          fSpeed = 1.4f;
          break;
        case 15:
          fSpeed = 1.5f;
          break;
        case 16:
          fSpeed = 2.0f;
          break;
        case 17:
          fSpeed = 4.0f;
          break;
        case 18:
          fSpeed = 8.0f;
          break;
        case 19:
          fSpeed = 16.0f;
          break;
        case 20:
          fSpeed = 32.0f;
          break;
      }

      m_formBottomBar.SetSpeed(fSpeed);
    }
  }
}
