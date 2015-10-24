using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpCoreWrapper;
using System.IO;

namespace RPlayer
{
    public partial class FormMediaInfo : Form
    {
      private bool m_bTopBarMouseDown = false;
      private Point m_TopBarMouseDownPos;

      public FormMediaInfo(string url)
      {
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

        textBox_url.Text = url;

        TimeSpan t = TimeSpan.FromSeconds(RpCore.GetTotalTime());
        string strText = string.Format("{0:D2} : {1:D2} : {2:D2}",t.Hours,t.Minutes,t.Seconds);
        label_durationShow.Text = strText;

        FileInfo f = new FileInfo(url);
        long size = f.Length;
        if(size > 1024 * 1024 * 1024)
        {
          label_fileSizeShow.Text = Convert.ToString((float)size / (1024 * 1024 * 1024)) + " GB";
        }
        else
        {
          label_fileSizeShow.Text = Convert.ToString((float)size / (1024 * 1024)) + " MB";
        }

        DirectoryInfo dir = new DirectoryInfo(url);
        label_creationTimeShow.Text = dir.CreationTime.ToString();

        string strInfoDetail;
        VideoStreamInfo vInfo = RpCore.GetVideoStreamInfo();
        strInfoDetail =
UiLang.mediaInfoVideo +
Environment.NewLine +
UiLang.mediaInfoCodecName + vInfo.videoCodecName +
Environment.NewLine +
UiLang.mediaInfoVideoWidth + vInfo.width +
Environment.NewLine +
UiLang.mediaInfoVideoHeight + vInfo.height +
Environment.NewLine +
UiLang.mediaInfoVideoAspectRatio + vInfo.videoAspectRatio +
Environment.NewLine +
UiLang.mediaInfoBitrate + (vInfo.bitrate/ 1024) +" kbps" +
Environment.NewLine +
Environment.NewLine;

        for (int i = 0; i < RpCore.GetAudioCount(); i++)
        {
          AudioStreamInfo aInfo = RpCore.GetAudioStreamInfo(i);
          strInfoDetail += 
UiLang.mediaInfoAudio + (i + 1) +
Environment.NewLine +
UiLang.mediaInfoCodecName + aInfo.audioCodecName +
Environment.NewLine +
UiLang.mediaInfoAudioLanguage + aInfo.language +
Environment.NewLine +
UiLang.mediaInfoAudioChannels + aInfo.channels +
Environment.NewLine +
UiLang.mediaInfoBitrate + (aInfo.bitrate / 1024) + " kbps" +
Environment.NewLine +
UiLang.mediaInfoAudioSamplerate + aInfo.samplerate + " Hz" +
Environment.NewLine +
UiLang.mediaInfoAudioBitspersample + aInfo.bitspersample + " bits" +
Environment.NewLine +
Environment.NewLine;
        }

        textBox_infoDetail.Text = strInfoDetail;
      }

      private void SetUiLange()
      {
        label_mediaInfo.Text = UiLang.labelMediainfo;
        label_fileSize.Text = UiLang.labelDetailsFileSize;
        label_duration.Text = UiLang.labelDetailsDuration;
        label_creationTime.Text = UiLang.labelDetailsCreationTime;
        label_url.Text = UiLang.labelDetailsUrl;
      }


      private void label_settingsClose_Click(object sender, EventArgs e)
      {
        this.Close();
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
    }
}
