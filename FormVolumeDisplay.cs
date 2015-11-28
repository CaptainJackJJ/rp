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
  public partial class FormVolumeDisplay : Form
  {
    private int m_nLastVolume = -1;
    private bool m_bShowing = false;
    private MainForm m_mainForm;
    private int nSomeVolumeHit = 0;

    public FormVolumeDisplay(MainForm mainForm)
    {
      m_mainForm = mainForm;
      InitializeComponent();     
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (m_mainForm.HandleCmdKey(keyData))
        return true;
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if(m_nLastVolume == -1)
      {        
        m_nLastVolume = Archive.volume;
      }
      else
      {
        if(m_nLastVolume != Archive.volume)
        {
          label_volume.Text = Archive.volume.ToString() + "%";
          if (!m_bShowing)
          {
            this.Show();
            this.Size = new Size(60, 35);
            m_bShowing = true;
            m_mainForm.Activate();
          }
          m_nLastVolume = Archive.volume;
          nSomeVolumeHit--;
        }
        else
        {
          if (m_bShowing)
          {
            nSomeVolumeHit++;
            if (nSomeVolumeHit == 5) // 0.5 second
            {
              this.Hide();
              m_bShowing = false;
              nSomeVolumeHit = 0;
            }
          }
        }
      }
    }
  }
}
