using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.IO;

namespace RPlayer
{
  class InfoItemUI
  {
    private GroupBox m_groupBoxItem;
    private PictureBox m_PicBoxImage;
    private Label m_labelTitle;
    private Label m_labelDate;
    private Label m_labelCasts;
    private Label m_labelLang;
    private RichTextBox m_textBoxDesc;
    private Button[] m_btnFiles;

    public InfoItemUI(Panel panelSection, int x, int y)
    {
      m_groupBoxItem = new GroupBox();
      m_groupBoxItem.Location = new Point(x, y);
      m_groupBoxItem.Size = new Size(445, 420);
      m_groupBoxItem.Text = "";

      m_PicBoxImage = new PictureBox();
      m_PicBoxImage.Location = new Point(10, 16);
      m_PicBoxImage.Size = new Size(224, 315);
      m_PicBoxImage.BackgroundImageLayout = ImageLayout.Stretch;
      m_groupBoxItem.Controls.Add(m_PicBoxImage);

      Color colorLableFore = Color.Snow;

      m_labelTitle = new Label();
      m_labelTitle.Location = new Point(240, 18);
      m_labelTitle.Size = new Size(188, 23);
      m_labelTitle.BackColor = Color.Transparent;
      m_labelTitle.ForeColor = colorLableFore;
      m_labelTitle.Font = new Font("SimSun", 12.0f, FontStyle.Bold);
      m_labelTitle.TextAlign = ContentAlignment.MiddleLeft;
      m_groupBoxItem.Controls.Add(m_labelTitle);

      m_labelDate = new Label();
      m_labelDate.Location = new Point(240, 51);
      m_labelDate.Size = new Size(188, 15);
      m_labelDate.BackColor = Color.Transparent;
      m_labelDate.ForeColor = colorLableFore;
      m_labelDate.Font = new Font("SimSun", 9.0f);
      m_labelDate.TextAlign = ContentAlignment.MiddleLeft;
      m_groupBoxItem.Controls.Add(m_labelDate);

      m_labelCasts = new Label();
      m_labelCasts.Location = new Point(240, 83);
      m_labelCasts.Size = new Size(188, 15);
      m_labelCasts.BackColor = Color.Transparent;
      m_labelCasts.ForeColor = colorLableFore;
      m_labelCasts.Font = new Font("SimSun", 9.0f);
      m_labelCasts.TextAlign = ContentAlignment.MiddleLeft;
      m_groupBoxItem.Controls.Add(m_labelCasts);

      m_labelLang = new Label();
      m_labelLang.Location = new Point(240, 118);
      m_labelLang.Size = new Size(188, 15);
      m_labelLang.BackColor = Color.Transparent;
      m_labelLang.ForeColor = colorLableFore;
      m_labelLang.Font = new Font("SimSun", 9.0f);
      m_labelLang.TextAlign = ContentAlignment.MiddleLeft;
      m_groupBoxItem.Controls.Add(m_labelLang);

      m_textBoxDesc = new RichTextBox();
      m_textBoxDesc.BackColor = GlobalConstants.Common.colorMainBG;
      m_textBoxDesc.BorderStyle = BorderStyle.None;
      m_textBoxDesc.Font = new Font("SimSun", 9.0f);
      m_textBoxDesc.ForeColor = colorLableFore;
      m_textBoxDesc.Location = new Point(7, 337);
      m_textBoxDesc.Size = new Size(435, 78);
      m_textBoxDesc.ScrollBars = RichTextBoxScrollBars.None;
      m_groupBoxItem.Controls.Add(m_textBoxDesc);

      m_btnFiles = new Button[3];
      for (int i = 0; i < m_btnFiles.Length; ++i)
      {
        Button btn = new Button();
        m_btnFiles[i] = btn;
        btn.Visible = false;
        btn.BackColor = GlobalConstants.Common.colorMainBG;
        btn.FlatStyle = FlatStyle.Flat;
        btn.Font = new Font("SimSun", 9.0f, FontStyle.Bold);
        btn.ForeColor = Color.Orange;
        btn.TextAlign = ContentAlignment.MiddleCenter;
        btn.Location = new Point(240, 175 + i * 49);
        btn.Size = new Size(197, 34);
        btn.Click += new System.EventHandler(btn_file_Click);
        m_groupBoxItem.Controls.Add(btn);
      }

      panelSection.Controls.Add(m_groupBoxItem);
    }

    public void FreshItem(XmlElement itemElem)
    {
      string strImageName
        = itemElem.GetElementsByTagName(GlobalConstants.infoXml.strElemImage)[0].Attributes[GlobalConstants.infoXml.strAttrName].InnerText;
      m_PicBoxImage.BackgroundImage = Image.FromFile(MainForm.m_strDownloadedFolderUrl + "\\" + strImageName);
      m_labelTitle.Text = itemElem.Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText;
      m_labelDate.Text = itemElem.GetElementsByTagName(GlobalConstants.infoXml.strElemDate)[0].InnerText;
      m_labelCasts.Text = itemElem.GetElementsByTagName(GlobalConstants.infoXml.strElemCasts)[0].InnerText;
      m_labelLang.Text = itemElem.GetElementsByTagName(GlobalConstants.infoXml.strElemLang)[0].InnerText;
      m_textBoxDesc.Text = itemElem.GetElementsByTagName(GlobalConstants.infoXml.strElemDesc)[0].InnerText;

      XmlNodeList fileNodeList = itemElem.GetElementsByTagName(GlobalConstants.infoXml.strElemFile);

      for (int i = 0; i < m_btnFiles.Length; ++i)
      {
        Button btn = m_btnFiles[i];
        btn.Visible = false;
        if (i >= fileNodeList.Count)
          continue;
        btn.Visible = true;
        btn.Invalidate();
        btn.Text = fileNodeList[i].Attributes[GlobalConstants.infoXml.strAttrTitle].InnerText;
        btn.Tag = fileNodeList[i].Attributes[GlobalConstants.infoXml.strAttrName].InnerText;
      }
      m_groupBoxItem.Invalidate();
    }

    private void btn_file_Click(object sender, EventArgs e)
    {
      string strFileName = (sender as Button).Tag as string;
      if (strFileName.Contains(".torrent"))
      {
        System.Diagnostics.Process.Start(MainForm.m_strDownloadedFolderUrl + "\\" + strFileName);
      }
      else
      {
        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
        DialogResult result = folderDlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          try
          {
            File.Copy(MainForm.m_strDownloadedFolderUrl + "\\" + strFileName, folderDlg.SelectedPath + "\\" + strFileName); 
          }
          catch (IOException ex)
          {
            MessageBox.Show(ex.ToString());
          }
        }
      }
    }
  }
}
